/*
 * Notifo.io
 *
 * @license
 * Copyright (c) Sebastian Stehle. All rights reserved.
 */

// tslint:disable: quotemark

import { IFrame } from '@app/framework';
import * as React from 'react';
import Split from 'react-split';
import { Alert } from 'reactstrap';
import { EmailHtmlTextEditor } from './EmailHtmlTextEditor';
import { usePreview } from './helpers';

export interface EmailHtmlEditorProps {
    // The value.
    initialValue: string;

    // The app name.
    appId: string;

    // When the html has changed.
    onChange?: (value: string) => void;

    // Called when the focus has been lost.
    onBlur?: () => void;
}

export const EmailHtmlEditor = (props: EmailHtmlEditorProps) => {
    const { appId, onChange, initialValue } = props;

    const [emailPreview, markup, setMarkup] = usePreview(appId, 'Html');

    React.useEffect(() => {
        onChange && emailPreview.emailMarkup && onChange(emailPreview.emailMarkup);
    }, [emailPreview, onChange]);

    React.useEffect(() => {
        setMarkup(initialValue);
    }, [setMarkup, initialValue]);

    return (
        <div className='email-editor'>
            <Split direction='horizontal'>
                <div className='left'>
                    <EmailHtmlTextEditor value={markup} errors={emailPreview.rendering?.errors} onChange={setMarkup} />
                </div>

                <div className='right'>
                    <IFrame html={emailPreview?.rendering?.result} />

                    {emailPreview.error &&
                        <Alert color='danger'>{emailPreview.error}</Alert>
                    }
                </div>
            </Split>
        </div>
    );
};
