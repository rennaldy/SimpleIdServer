﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Microsoft.IdentityModel.JsonWebTokens;
using SimpleIdServer.IdServer.Domains;
using SimpleIdServer.IdServer.Domains.DTOs;
using SimpleIdServer.IdServer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleIdServer.IdServer.Builders
{
    public class UserBuilder
    {
        private readonly User _user;

        private UserBuilder() 
        { 
            _user = new User();
        }

        /// <summary>
        /// Allows to create an instace for building an user.
        /// </summary>
        /// <param name="login">The user's name for login.</param>
        /// <param name="password">The user's password.</param>
        /// <param name="name">(Optional) The user's first name.</param>
        /// <param name="realm">(Optional) The realm to asign.</param>
        /// <param name="hashAlg">(Optional) Algorithm used to hash the password.</param>
        /// <returns>An instace for building an user.</returns>
        public static UserBuilder Create(string login, string password, string name = null, Domains.Realm realm = null, PasswordHashAlgs hashAlg = PasswordHashAlgs.Default)
        {
            var result = new UserBuilder();
            result._user.Id = Guid.NewGuid().ToString();
            result._user.Name = login;
            var userCredential = new UserCredential
            {
                Id = Guid.NewGuid().ToString(),
                CredentialType = "pwd",
                IsActive = true,
                HashAlg = hashAlg
            };
            userCredential.Value = PasswordHelper.ComputerHash(userCredential, password);
            result._user.Credentials.Add(userCredential);
            if (realm == null) result._user.Realms.Add(new RealmUser { RealmsName = Config.DefaultRealms.Master.Name });
            else result._user.Realms.Add(new RealmUser { RealmsName = realm.Name });

            if (!string.IsNullOrEmpty(name)) result.SetFirstname(name);

            result._user.CreateDateTime = DateTime.UtcNow;
            result._user.UpdateDateTime = DateTime.UtcNow;
            return result;
        }

        #region User claims

        public UserBuilder SetFirstname(string firstName)
        {
            _user.Firstname = firstName;
            return this;
        }

        public UserBuilder SetLastname(string lastName)
        {
            _user.Lastname = lastName;
            return this;
        }

        public UserBuilder SetEmail(string email)
        {
            _user.Email = email;
            return this;
        }

        public UserBuilder SetPhoneNumber(string phoneNumber)
        {
            _user.AddClaim(JwtRegisteredClaimNames.PhoneNumber, phoneNumber);
            return this;
        }

        public UserBuilder SetEmailVerified(bool emailVerified)
        {
            _user.EmailVerified = emailVerified;
            return this;
        }

        #endregion

        #region Claims

        public UserBuilder SetPicture(string picture)
        {
            _user.UpdateClaim(Config.DefaultUserClaims.Picture, picture);
            return this;
        }

        public UserBuilder AddRole(string role)
        {
            _user.AddClaim(Config.DefaultUserClaims.Role, role);
            return this;
        }

        public UserBuilder AddGroup(Group group)
        {
            _user.Groups.Add(new GroupUser
            {
                GroupsId = group.Id
            });
            return this; 
        }

        public UserBuilder SetAddress(string street, string locality, string region, string postalCode, string country, string formatted)
        {
            _user.UpdateClaim(AddressClaimNames.Street, street);
            _user.UpdateClaim(AddressClaimNames.Locality, locality);
            _user.UpdateClaim(AddressClaimNames.Region, region);
            _user.UpdateClaim(AddressClaimNames.PostalCode, postalCode);
            _user.UpdateClaim(AddressClaimNames.Country, country);
            _user.UpdateClaim(AddressClaimNames.Formatted, formatted);
            return this;
        }

        public UserBuilder AddClaim(string name, string value)
        {
            _user.AddClaim(name, value);
            return this;
        }

        #endregion

        #region Consents

        public UserBuilder AddConsent(string realm, string clientId, params string[] scopes)
        {
            _user.Consents.Add(new Consent { Id = Guid.NewGuid().ToString(), ClientId = clientId, Scopes = scopes.Select(s => new AuthorizedScope { Scope = s }).ToList(), UpdateDateTime = DateTime.UtcNow, CreateDateTime = DateTime.UtcNow, Realm = realm, Status = ConsentStatus.ACCEPTED });
            return this;
        }

        public UserBuilder AddConsent(string realm, string clientId, ICollection<string> scopes, ICollection<AuthorizationData> authorizationDetails, string consentId = null)
        {
            _user.Consents.Add(new Consent { Id = consentId ?? Guid.NewGuid().ToString(), ClientId = clientId, Scopes = scopes.Select(s => new AuthorizedScope { Scope = s }).ToList(), UpdateDateTime = DateTime.UtcNow, CreateDateTime = DateTime.UtcNow, Realm = realm, AuthorizationDetails = authorizationDetails.ToList(), Status = ConsentStatus.ACCEPTED });
            return this;
        }


        public UserBuilder AddConsent(string realm, string clientId, ICollection<string> scopes, ICollection<string> claims)
        {
            _user.Consents.Add(new Consent { Id = Guid.NewGuid().ToString(), Scopes = scopes.Select(s => new AuthorizedScope { Scope = s }).ToList(), ClientId = clientId, UpdateDateTime = DateTime.UtcNow, Claims = claims, CreateDateTime = DateTime.UtcNow, Realm = realm, Status = ConsentStatus.ACCEPTED });
            return this;
        }

        public UserBuilder AddConsent(string realm, string clientId, params AuthorizationData[] authData)
        {
            _user.Consents.Add(new Consent { Id = Guid.NewGuid().ToString(), ClientId = clientId, AuthorizationDetails = authData, UpdateDateTime = DateTime.UtcNow, CreateDateTime = DateTime.UtcNow, Realm = realm, Status = ConsentStatus.ACCEPTED });
            return this;
        }

        #endregion

        public UserBuilder EnableTemporaryPassword()
        {
            foreach(var credential in _user.Credentials.Where(c => c.CredentialType == "pwd"))
            {
                credential.IsTemporary = true;
            }

            return this;
        }

        public UserBuilder GenerateRandomHOTPKey()
        {
            _user.GenerateHOTP();
            return this;
        }

        public UserBuilder GenerateRandomTOTPKey()
        {
            _user.GenerateTOTP();
            return this;
        }

        public User Build() => _user;
    }
}
