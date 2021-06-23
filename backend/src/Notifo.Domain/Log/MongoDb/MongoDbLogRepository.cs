﻿// ==========================================================================
//  Notifo.io
// ==========================================================================
//  Copyright (c) Sebastian Stehle
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using NodaTime;
using Notifo.Infrastructure;
using Notifo.Infrastructure.MongoDb;

namespace Notifo.Domain.Log.MongoDb
{
    public sealed class MongoDbLogRepository : MongoDbStore<MongoDbLogEntry>, ILogRepository
    {
        public MongoDbLogRepository(IMongoDatabase database)
            : base(database)
        {
        }

        protected override string CollectionName()
        {
            return "Log";
        }

        protected override async Task SetupCollectionAsync(IMongoCollection<MongoDbLogEntry> collection, CancellationToken ct)
        {
            await collection.Indexes.CreateOneAsync(
                new CreateIndexModel<MongoDbLogEntry>(
                    IndexKeys
                        .Ascending(x => x.Entry.AppId)
                        .Ascending(x => x.Entry.Message)
                        .Descending(x => x.Entry.LastSeen)),
                null, ct);
        }

        public async Task<IResultList<LogEntry>> QueryAsync(string appId, LogQuery query, CancellationToken ct)
        {
            var filters = new List<FilterDefinition<MongoDbLogEntry>>
            {
                Filter.Eq(x => x.Entry.AppId, appId)
            };

            if (!string.IsNullOrWhiteSpace(query.Query))
            {
                var regex = new BsonRegularExpression(Regex.Escape(query.Query), "i");

                filters.Add(Filter.Regex(x => x.Entry.Message, regex));
            }

            var filter = Filter.And(filters);

            var resultItems = await Collection.Find(filter).SortByDescending(x => x.Entry.LastSeen).ToListAsync(query, ct);
            var resultTotal = (long)resultItems.Count;

            if (query.ShouldQueryTotal(resultItems))
            {
                resultTotal = await Collection.Find(filter).CountDocumentsAsync(ct);
            }

            return ResultList.Create(resultTotal, resultItems.Select(x => x.ToEntry()));
        }

        public Task MatchWriteAsync(IEnumerable<(string AppId, string Message, int Count)> updates, Instant now, CancellationToken ct)
        {
            var writes = new List<WriteModel<MongoDbLogEntry>>();

            foreach (var (appId, message, count) in updates)
            {
                var docId = MongoDbLogEntry.CreateId(appId, message);

                var update =
                    Update
                        .SetOnInsert(x => x.DocId, docId)
                        .SetOnInsert(x => x.Entry.FirstSeen, now)
                        .SetOnInsert(x => x.Entry.AppId, appId)
                        .SetOnInsert(x => x.Entry.Message, message)
                        .Set(x => x.Entry.LastSeen, now)
                        .Inc(x => x.Entry.Count, count);

                var model = new UpdateOneModel<MongoDbLogEntry>(Filter.Eq(x => x.DocId, docId), update)
                {
                    IsUpsert = true
                };

                writes.Add(model);
            }

            return Collection.BulkWriteAsync(writes, cancellationToken: ct);
        }
    }
}
