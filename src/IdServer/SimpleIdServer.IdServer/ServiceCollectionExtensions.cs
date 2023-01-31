﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using SimpleIdServer.IdServer;
using SimpleIdServer.IdServer.Api.Authorization;
using SimpleIdServer.IdServer.Api.Authorization.ResponseModes;
using SimpleIdServer.IdServer.Api.Authorization.ResponseTypes;
using SimpleIdServer.IdServer.Api.Authorization.Validators;
using SimpleIdServer.IdServer.Api.BCAuthorize;
using SimpleIdServer.IdServer.Api.Configuration;
using SimpleIdServer.IdServer.Api.Jwks;
using SimpleIdServer.IdServer.Api.Register;
using SimpleIdServer.IdServer.Api.Token;
using SimpleIdServer.IdServer.Api.Token.Handlers;
using SimpleIdServer.IdServer.Api.Token.Helpers;
using SimpleIdServer.IdServer.Api.Token.PKCECodeChallengeMethods;
using SimpleIdServer.IdServer.Api.Token.TokenBuilders;
using SimpleIdServer.IdServer.Api.Token.TokenProfiles;
using SimpleIdServer.IdServer.Api.Token.Validators;
using SimpleIdServer.IdServer.Api.TokenIntrospection;
using SimpleIdServer.IdServer.Authenticate;
using SimpleIdServer.IdServer.Authenticate.AssertionParsers;
using SimpleIdServer.IdServer.Authenticate.Handlers;
using SimpleIdServer.IdServer.ClaimsEnricher;
using SimpleIdServer.IdServer.ClaimTokenFormats;
using SimpleIdServer.IdServer.Helpers;
using SimpleIdServer.IdServer.Infrastructures;
using SimpleIdServer.IdServer.Jwt;
using SimpleIdServer.IdServer.Options;
using SimpleIdServer.IdServer.Store;
using SimpleIdServer.IdServer.Stores;
using SimpleIdServer.IdServer.SubjectTypeBuilders;
using SimpleIdServer.IdServer.UI;
using SimpleIdServer.IdServer.UI.AuthProviders;
using SimpleIdServer.IdServer.UI.Infrastructures;
using SimpleIdServer.IdServer.UI.Services;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {

        /// <summary>
        /// Configure OPENID & OAUTH2.0 server.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IdServerStoreChooser AddSIDIdentityServer(this IServiceCollection services, Action<IdServerHostOptions>? callback = null)
        {
            if (callback != null) services.Configure(callback);
            else services.Configure<IdServerHostOptions>(o => { });
            services.Configure<RouteOptions>(opt =>
            {
                opt.ConstraintMap.Add("realmPrefix", typeof(RealmRoutePrefixConstraint));
            });
            services.AddControllersWithViews();
            services.AddDataProtection();
            services.AddDistributedMemoryCache();
            services.AddResponseModeHandlers()
                .AddOAuthClientAuthentication()
                .AddClientAssertionParsers()
                .AddOAuthJwksApi()
                .AddOAuthTokenApi()
                .AddOAuthAuthorizationApi()
                .AddOAuthJwt()
                .AddLib()
                .AddConfigurationApi()
                .AddUI()
                .AddSubjectTypeBuilder()
                .AddClaimsEnricher()
                .AddOAuthIntrospectionTokenApi()
                .AddRegisterApi()
                .AddBCAuthorizeApi();
            services.AddAuthorization();
            services.Configure<AuthorizationOptions>(o =>
            {
                o.AddPolicy(Constants.Policies.Register, p => p.RequireAssertion(a => true));
                o.AddPolicy(Constants.Policies.AuthSchemeProvider, p => p.RequireAssertion(a => true));
                o.AddPolicy(Constants.Policies.Authenticated, p => p.RequireAuthenticatedUser());
            });
            return new IdServerStoreChooser(services);
        }

        #region Private methods

        private static IServiceCollection AddResponseModeHandlers(this IServiceCollection services)
        {
            services.AddTransient<IOAuthResponseMode, QueryResponseModeHandler>();
            services.AddTransient<IOAuthResponseMode, FragmentResponseModeHandler>();
            services.AddTransient<IOAuthResponseMode, FormPostResponseModeHandler>();
            services.AddTransient<IOAuthResponseModeHandler, QueryResponseModeHandler>();
            services.AddTransient<IOAuthResponseModeHandler, FragmentResponseModeHandler>();
            services.AddTransient<IOAuthResponseModeHandler, FormPostResponseModeHandler>();
            services.AddTransient<IResponseModeHandler, ResponseModeHandler>();
            return services;
        }

        private static IServiceCollection AddOAuthClientAuthentication(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticateClient>(s => new AuthenticateClient(s.GetService<IClientRepository>(), s.GetServices<IOAuthClientAuthenticationHandler>(), s.GetServices<IClientAssertionParser>(), s.GetService<IOptions<IdServerHostOptions>>() ));
            services.AddTransient<IOAuthClientAuthenticationHandler, OAuthClientPrivateKeyJwtAuthenticationHandler>();
            services.AddTransient<IOAuthClientAuthenticationHandler, OAuthClientSecretBasicAuthenticationHandler>();
            services.AddTransient<IOAuthClientAuthenticationHandler, OAuthClientSecretJwtAuthenticationHandler>();
            services.AddTransient<IOAuthClientAuthenticationHandler, OAuthClientSecretPostAuthenticationHandler>();
            services.AddTransient<IOAuthClientAuthenticationHandler, OAuthPKCEAuthenticationHandler>();
            services.AddTransient<IOAuthClientAuthenticationHandler, OAuthClientTlsClientAuthenticationHandler>();
            services.AddTransient<IOAuthClientAuthenticationHandler, OAuthClientSelfSignedTlsClientAuthenticationHandler>();
            return services;
        }

        private static IServiceCollection AddClientAssertionParsers(this IServiceCollection services)
        {
            services.AddTransient<IClientAssertionParser, ClientJwtAssertionParser>();
            return services;
        }

        private static IServiceCollection AddOAuthJwksApi(this IServiceCollection services)
        {
            services.AddTransient<IJwksRequestHandler, JwksRequestHandler>();
            services.AddSingleton<IKeyStore, InMemoryKeyStore>();
            return services;
        }

        private static IServiceCollection AddSubjectTypeBuilder(this IServiceCollection services)
        {
            services.AddTransient<ISubjectTypeBuilder, PairWiseSubjectTypeBuidler>();
            services.AddTransient<ISubjectTypeBuilder, PublicSubjectTypeBuilder>();
            return services;
        }

        private static IServiceCollection AddClaimsEnricher(this IServiceCollection services)
        {
            services.AddTransient<IClaimsExtractor, HttpClaimsExtractor>();
            services.AddTransient<IClaimsEnricher, ClaimsEnricher>();
            return services;
        }

        private static IServiceCollection AddOAuthTokenApi(this IServiceCollection services)
        {
            services.AddTransient<ITokenRequestHandler>(s => new TokenRequestHandler(s.GetServices<IGrantTypeHandler>()));
            services.AddTransient<IClientCredentialsGrantTypeValidator, ClientCredentialsGrantTypeValidator>();
            services.AddTransient<IRefreshTokenGrantTypeValidator, RefreshTokenGrantTypeValidator>();
            services.AddTransient<IAuthorizationCodeGrantTypeValidator, AuthorizationCodeGrantTypeValidator>();
            services.AddTransient<IRevokeTokenValidator, RevokeTokenValidator>();
            services.AddTransient<IPasswordGrantTypeValidator, PasswordGrantTypeValidator>();
            services.AddTransient<IGrantedTokenHelper, GrantedTokenHelper>();
            services.AddTransient<IGrantTypeHandler, ClientCredentialsHandler>();
            services.AddTransient<IGrantTypeHandler, RefreshTokenHandler>();
            services.AddTransient<IGrantTypeHandler, PasswordHandler>();
            services.AddTransient<IGrantTypeHandler, AuthorizationCodeHandler>();
            services.AddTransient<IGrantTypeHandler, CIBAHandler>();
            services.AddTransient<IGrantTypeHandler, UmaTicketHandler>();
            services.AddTransient<ICIBAGrantTypeValidator, CIBAGrantTypeValidator>();
            services.AddTransient<IClientAuthenticationHelper, ClientAuthenticationHelper>();
            services.AddTransient<IRevokeTokenRequestHandler, RevokeTokenRequestHandler>();
            services.AddTransient<ITokenProfile, BearerTokenProfile>();
            services.AddTransient<ITokenProfile, MacTokenProfile>();
            services.AddTransient<ITokenBuilder, AccessTokenBuilder>();
            services.AddTransient<ITokenBuilder, IdTokenBuilder>();
            services.AddTransient<ITokenBuilder, RefreshTokenBuilder>();
            services.AddTransient<IClaimsJwsPayloadEnricher, ClaimsJwsPayloadEnricher>();
            services.AddTransient<ICodeChallengeMethodHandler, PlainCodeChallengeMethodHandler>();
            services.AddTransient<ICodeChallengeMethodHandler, S256CodeChallengeMethodHandler>();
            services.AddTransient<IClientHelper, OAuthClientHelper>();
            services.AddTransient<IAmrHelper, AmrHelper>();
            services.AddTransient<IUmaPermissionTicketHelper, UMAPermissionTicketHelper>();
            services.AddTransient<IExtractRequestHelper, ExtractRequestHelper>();
            services.AddTransient<IGrantHelper, GrantHelper>();
            services.AddTransient<IClaimTokenFormat, OpenIDClaimTokenFormat>();
            services.AddTransient<IUmaTicketGrantTypeValidator, UmaTicketGrantTypeValidator>();
            return services;
        }

        private static IServiceCollection AddOAuthIntrospectionTokenApi(this IServiceCollection services)
        {
            services.AddTransient<ITokenIntrospectionRequestHandler, TokenIntrospectionRequestHandler>();
            return services;
        }

        private static IServiceCollection AddOAuthAuthorizationApi(this IServiceCollection services)
        {
            services.AddTransient<IAuthorizationRequestHandler, AuthorizationRequestHandler>();
            services.AddTransient<IResponseTypeHandler, AuthorizationCodeResponseTypeHandler>();
            services.AddTransient<IResponseTypeHandler, IdTokenResponseTypeHandler>();
            services.AddTransient<IResponseTypeHandler, TokenResponseTypeHandler>();
            services.AddTransient<IAuthorizationRequestValidator, OAuthAuthorizationRequestValidator>();
            services.AddTransient<IAuthorizationRequestEnricher, AuthorizationRequestEnricher>();
            services.AddTransient<IUserConsentFetcher, OAuthUserConsentFetcher>();
            return services;
        }

        private static IServiceCollection AddBCAuthorizeApi(this IServiceCollection services)
        {
            services.AddTransient<IBCAuthorizeHandler, BCAuthorizeHandler>();
            services.AddTransient<IBCAuthorizeRequestValidator, BCAuthorizeRequestValidator>();
            services.AddTransient<IBCNotificationService, BCConsoleNotificationService>();
            return services;
        }

        private static IServiceCollection AddOAuthJwt(this IServiceCollection services)
        {
            services.AddTransient<IJwtBuilder, JwtBuilder>();
            return services;
        }

        private static IServiceCollection AddLib(this IServiceCollection services)
        {
            services.AddTransient<IHttpClientFactory, HttpClientFactory>();
            return services;
        }
        
        private static IServiceCollection AddConfigurationApi(this IServiceCollection services)
        {
            services.AddTransient<IOAuthConfigurationRequestHandler, OAuthConfigurationRequestHandler>();
            services.AddTransient<IOAuthWorkflowConverter, OAuthWorkflowConverter>();
            return services;
        }

        private static IServiceCollection AddUI(this IServiceCollection services)
        {
            services.AddTransient<IOTPAuthenticator, HOTPAuthenticator>();
            services.AddTransient<IOTPAuthenticator, TOTPAuthenticator>();
            services.AddTransient<ISessionManager, SessionManager>();
            // services.AddTransient<IAuthenticationSchemeProvider, DynamicAuthenticationSchemeProvider>();
            services.AddTransient<IPasswordAuthService, PasswordAuthService>();
            services.AddTransient<IUserTransformer, UserTransformer>();
            return services;
        }

        private static IServiceCollection AddRegisterApi(this IServiceCollection services)
        {
            services.AddTransient<IRegisterClientRequestValidator, RegisterClientRequestValidator>();
            return services;
        }

        #endregion
    }

    public class RealmRoutePrefixConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection) => true;
    }
}