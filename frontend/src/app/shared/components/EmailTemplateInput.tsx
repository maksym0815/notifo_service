/*
 * Notifo.io
 *
 * @license
 * Copyright (c) Sebastian Stehle. All rights reserved.
 */

import * as React from 'react';
import { useDispatch } from 'react-redux';
import { FormEditorOption, FormEditorProps, Forms } from '@app/framework';
import { loadEmailTemplates, useApp, useEmailTemplates } from '@app/state';

export const EmailTemplateInput = (props: FormEditorProps) => {
    const dispatch = useDispatch();
    const app = useApp()!;
    const appId = app.id;
    const templates = useEmailTemplates(x => x.templates);

    React.useEffect(() => {
        if (!templates.isLoaded) {
            dispatch(loadEmailTemplates(appId));
        }
    }, [dispatch, appId, templates.isLoaded]);

    const options = React.useMemo(() => {
        const result: FormEditorOption<string | undefined>[] = [{
            label: '',
        }];

        if (templates.items) {
            for (const { name: label } of templates.items) {
                if (label) {
                    result.push({ label, value: label });
                }
            }
        }

        return result;
    }, [templates.items]);

    if (options.length <= 1) {
        return null;
    }

    return (
        <Forms.Select {...props} options={options} />
    );
};
