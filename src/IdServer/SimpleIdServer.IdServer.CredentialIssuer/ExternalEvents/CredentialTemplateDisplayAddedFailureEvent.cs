﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using SimpleIdServer.IdServer.ExternalEvents;

namespace SimpleIdServer.IdServer.CredentialIssuer.ExternalEvents;

public class CredentialTemplateDisplayAddedFailureEvent : IExternalEvent
{
    public string EventName => nameof(CredentialTemplateDisplayAddedFailureEvent);
    public string Realm { get; set; }
    public string Id { get; set; }
}
