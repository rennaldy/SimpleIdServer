﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using SimpleIdServer.IdServer.Stores;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleIdServer.Configuration
{
    public interface IKeyValueConnector
    {
        Task<Dictionary<string, string>> GetAll(CancellationToken cancellationToken);
        Task Set(string key, string value, CancellationToken cancellationToken);
    }

    public class EFKeyValueConnector : IKeyValueConnector
    {
        private readonly IKeyValueRepository _repository;

        public EFKeyValueConnector(IKeyValueRepository repository)
        {
            _repository = repository;
        }

        public async Task<Dictionary<string, string>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _repository.GetAll(cancellationToken);
            return result.ToDictionary(r => r.Name, r => r.Value);
        }

        public async Task Set(string key, string value, CancellationToken cancellationToken)
        {
            var record = await _repository.Get(key, cancellationToken);
            if (record == null)
                _repository.Add(new IdServer.Domains.ConfigurationKeyPairValueRecord { Name = key, Value = value });
            else
                record.Value = value;
            await _repository.SaveChanges(cancellationToken);
        }
    }
}
