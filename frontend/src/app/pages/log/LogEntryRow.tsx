/*
 * Notifo.io
 *
 * @license
 * Copyright (c) Sebastian Stehle. All rights reserved.
 */

import { FromNow } from '@app/framework';
import { LogEntryDto } from '@app/service';
import * as React from 'react';

export interface LogEntryRowProps {
    // The log entry.
    entry: LogEntryDto;
}

export const LogEntryRow = (props: LogEntryRowProps) => {
    const { entry } = props;

    return (
        <tr>
            <td>
                <span className='truncate'>{entry.message}</span>
            </td>
            <td>
                <span className='truncate'>{entry.count}</span>
            </td>
            <td>
                <span className='truncate'>
                    <FromNow date={entry.lastSeen} />
                </span>
            </td>
            <td>
                <span className='truncate'>
                    <FromNow date={entry.firstSeen} />
                </span>
            </td>
        </tr>
    );
};
