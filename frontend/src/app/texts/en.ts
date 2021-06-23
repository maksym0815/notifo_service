/*
 * Notifo.io
 *
 * @license
 * Copyright (c) Sebastian Stehle. All rights reserved.
 */

export const EN = {
    code: 'en',
    common: {
        actions: 'Actions',
        add: 'Add',
        appId: 'Application ID',
        apps: 'Apps',
        attempt: 'Attempts',
        back: 'Back',
        channels: 'Channels',
        cancel: 'Cancel',
        code: 'Code',
        confirm: 'Confirm',
        confirmMode: 'Confirm Mode',
        confirmModes: {
            explicit: 'Explicit',
            none: 'None',
            seen: 'Seen',
        },
        confirmText: 'Confirm Text',
        contributors: 'Contributors',
        create: 'Create',
        created: 'Created',
        count: 'Count',
        dangerZone: 'Danger Zone',
        dashboard: 'Home',
        data: 'Data',
        delete: 'Delete',
        demo: 'Demo',
        design: 'Design',
        disabled: 'Disabled',
        edit: 'Edit',
        enabled: 'Enabled',
        email: 'Email',
        emails: 'Emails',
        emailAddress: 'Email Address',
        emailName: 'Email Name',
        emailPlaceholder: 'name@my-site.com',
        emailVerificationStatus: 'Email verification',
        error: 'Error has occurred',
        failed: 'Failed',
        firstSeen: 'First seen',
        formatting: 'Formatting',
        html: 'HTML',
        id: 'Id',
        invite: 'Invite',
        inviteByEmail: 'Enter email-address to add contributor.',
        imageLarge: 'Large Image',
        imageSmall: 'Small Image',
        language: 'Language',
        languages: 'Languages',
        lastSeen: 'Last seen',
        loading: 'Loading',
        logout: 'Logout',
        linkText: 'Link Text',
        linkUrl: 'Link URL',
        message: 'Message',
        messageBody: 'Body',
        messageSubject: 'Subject',
        mobilePush: 'Mobile',
        mode: 'Mode',
        more: 'More',
        name: 'Name',
        no: 'No',
        notifications: 'Notifications',
        notificationSettings: 'Notification Settings',
        notStarted: 'Not started',
        pagination: (start: number, end: number, total: number) => `${start} to ${end} of ${total}`,
        pending: 'Pending',
        phoneNumber: 'Phone Number',
        prio: 'Prio',
        profile: 'Profile',
        publish: 'Publish',
        refresh: 'Refresh',
        sampleSubject: '-- No Subject yet --',
        save: 'Save',
        select: 'Select',
        send: 'Send',
        sendModes: {
            inherit: 'Inherit',
            send: 'Send',
            doNotSend: 'Do not send',
            doNotAllow: 'Do not allow',
        },
        sent: 'Sent',
        settings: 'Settings',
        silent: 'Silent',
        showDetails: 'Show details',
        sms: 'SMS',
        statisticsInfo: 'Updated every 5 seconds (needs refresh)',
        statisticsLabelFn: (name: string) => `${name} (Handled / Attempts / Failed)`,
        status: 'Status',
        subject: 'Subject',
        templateCode: 'Template Code',
        templateMode: 'Use template?',
        text: 'Text',
        timestamp: 'Timestamp',
        timeToLive: 'Time to live in seconds',
        timezone: 'Timezone',
        threemaId: 'Threema ID',
        topic: 'Topic',
        unnamed: 'Unnamed',
        uploadButton: 'Select file(s)',
        uploadText: 'Drop file on existing item to replace the asset with a newer version.',
        urlPlaceholder: 'https://my-site.com/path',
        users: 'Users',
        verified: 'Verified',
        welcome: 'Welcome',
        webPlugin: 'Web Plugin',
        webPluginHint: 'Integrate Notifo into your Web application using our Plugin',
        webPush: 'Web Push',
        yes: 'Yes',
    },
    app: {
        allowEmail: 'Allow Emails',
        allowSms: 'Allow SMS',
        apiDetails: 'Your API Credentials',
        apiKey: 'API Key',
        confirmUrl: 'Confirm URL',
        emailSettings: 'Email Settings',
        emailVerificationHint: 'You will receive an email from Amazon shortly to verify your email address. Please click the link in the email',
        firebaseCredential: 'Credential',
        firebaseProject: 'Project',
        firebaseSettings: 'Firebase Settings',
        smsSettings: 'SMS Settings',
        urls: 'URL Settings',
        webhookUrl: 'Webhook URL',
        welcome: (app: string) => `Welcome to the ${app} App`,
    },
    apps: {
        createHeader: 'Create new App',
        createButton: 'New App',
        header: 'Apps',
        notFound: 'App not found',
    },
    emails: {
        bodyHtml: 'HTML Body',
        bodyHtmlValid: 'HTML Body is required and must be a valid template',
        bodyText: 'Text Body',
        bodyTextValid: 'Text Body is required and must be a valid template',
        header: 'Emails',
        notFound: 'No email template found.',
        notFoundButton: 'Create template',
        subjectValid: 'Subject is required and must be a valid template',
    },
    events: {
        header: 'Events',
        eventsNotFound: 'No matching event found',
        searchPlaceholder: 'Search',
    },
    integrations: {
        configured: 'Configured',
        confirmDelete: 'Do you really want to delete the Integration?',
        enabledHints: 'Disable the ingration without deleting it.',
        header: 'Integrations',
        modeTest: 'TEST',
        modeProduction: 'PROD',
        priority: 'Priority',
        priorityHints: 'Define a priority when you have configured multiple integrations for the same channel such as MobilePush.',
        supported: 'Supported',
        test: 'Test Mode',
        testHints: 'Use this integration only for production or development mode.',
    },
    log: {
        header: 'Log',
        logEntriesNotFound: 'No matching log entry found',
        searchPlaceholder: 'Search',
    },
    media: {
        confirmDelete: 'Do you really want to delete the Media?',
        header: 'Media',
        mediaNotFound: 'No matching media found',
        searchPlaceholder: 'Search',
    },
    notifications: {
        header: 'Notifications',
        notificationsNotFound: 'No matching notifications found',
    },
    notificationSettings: {
        email: {
            name: 'Email',
            send: 'Send as Email',
            title: 'Email Settings',
        },
        messaging: {
            name: 'Messaging',
            send: 'Send using Messaging (Threema, ...)',
            title: 'Messaging Settings',
        },
        mobilepush: {
            name: 'Mobile Push',
            send: 'Send as Mobile Push',
            title: 'Mobile Push Settings',
        },
        sms: {
            name: 'SMS',
            send: 'Send as SMS',
            title: 'SMS Settings',
        },
        webpush: {
            name: 'Web Push',
            send: 'Send as Web Push',
            title: 'Web Push Settings',
        },
        delayInSeconds: 'Delay in seconds',
    },
    publish: {
        header: 'Publish',
    },
    subscriptions: {
        confirmDelete: 'Do you really want to delete the Subscription?',
        createButton: 'Subscribe',
        createHeader: 'Create new Subscription',
        editHeader: 'Edit Subscription',
        header: 'Subscriptions',
        searchPlaceholder: 'Search',
        subscriptionsNotFound: 'No matching subscriptions found',
    },
    templates: {
        confirmDelete: 'Do you really want to delete the Template?',
        createButton: 'New',
        header: 'Templates',
        templateEdit: 'Edit',
        templateNew: 'New Template',
        templatesNotFound: 'No matching template found',
    },
    users: {
        confirmDelete: 'Do you really want to delete the User?',
        createButton: 'New User',
        createHeader: 'Create new User',
        editHeader: 'Edit User',
        header: 'Users',
        searchPlaceholder: 'Search',
        userDetails: 'User Details',
        userNotFound: 'User not found',
        usersNotFound: 'No matching user found',
    },
    validation: {
        atLeastOnString: (p: { label?: string }) => `${p.label} needs at least one value.`,
        emailFn: (p: { label?: string }) => `${p.label} must be a valid email address.`,
        lessFn: (p: { label?: string; max: number }) => `${p.label} must be less than ${p.max}.`,
        lessThanFn: (p: { label?: string; less: number }) => `${p.label} must be less than ${p.less || 0}.`,
        minFn: (p: { label?: string; min: number }) => `${p.label} must have more than ${p.min || 0} items.`,
        moreFn: (p: { label?: string; min: number }) => `${p.label} must be greater than ${p.min}.`,
        moreThanFn: (p: { label?: string; more: number }) => `${p.label} must be greater than ${p.more || 0}.`,
        requiredFn: (p: { label?: string }) => `${p.label} is required.`,
        topicFn: (p: { label?: string }) => `${p.label} must be a valid topic.`,
        urlFn: (p: { label?: string }) => `${p.label} must be a valid URL.`,
    },
};
