﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.7.0.0
//      SpecFlow Generator Version:3.7.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SimpleIdServer.OpenBankingApi.Host.Acceptance.Tests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.7.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class AuthorizationErrorsFeature : object, Xunit.IClassFixture<AuthorizationErrorsFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "AuthorizationErrors.feature"
#line hidden
        
        public AuthorizationErrorsFeature(AuthorizationErrorsFeature.FixtureData fixtureData, SimpleIdServer_OpenBankingApi_Host_Acceptance_Tests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "AuthorizationErrors", "\tCheck errors returned by authorization", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Error is returned when Account Access Consent doesn\'t exist")]
        [Xunit.TraitAttribute("FeatureTitle", "AuthorizationErrors")]
        [Xunit.TraitAttribute("Description", "Error is returned when Account Access Consent doesn\'t exist")]
        public virtual void ErrorIsReturnedWhenAccountAccessConsentDoesntExist()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Error is returned when Account Access Consent doesn\'t exist", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 4
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table24 = new TechTalk.SpecFlow.Table(new string[] {
                            "Type",
                            "Kid",
                            "AlgName"});
                table24.AddRow(new string[] {
                            "SIG",
                            "1",
                            "RS256"});
#line 5
 testRunner.When("build JSON Web Keys, store JWKS into \'jwks\' and store the public keys into \'jwks_" +
                        "json\'", ((string)(null)), table24, "When ");
#line hidden
                TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table25.AddRow(new string[] {
                            "token_endpoint_auth_method",
                            "tls_client_auth"});
                table25.AddRow(new string[] {
                            "response_types",
                            "[token,code,id_token]"});
                table25.AddRow(new string[] {
                            "grant_types",
                            "[client_credentials]"});
                table25.AddRow(new string[] {
                            "scope",
                            "accounts"});
                table25.AddRow(new string[] {
                            "redirect_uris",
                            "[https://localhost:8080/callback]"});
                table25.AddRow(new string[] {
                            "tls_client_auth_san_dns",
                            "firstMtlsClient"});
                table25.AddRow(new string[] {
                            "request_object_signing_alg",
                            "RS256"});
                table25.AddRow(new string[] {
                            "jwks",
                            "$jwks_json$"});
#line 9
 testRunner.When("execute HTTP POST JSON request \'https://localhost:8080/register\'", ((string)(null)), table25, "When ");
#line hidden
#line 20
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 21
 testRunner.And("extract parameter \'client_id\' from JSON body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table26 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table26.AddRow(new string[] {
                            "response_type",
                            "code id_token"});
                table26.AddRow(new string[] {
                            "client_id",
                            "$client_id$"});
                table26.AddRow(new string[] {
                            "state",
                            "state"});
                table26.AddRow(new string[] {
                            "response_mode",
                            "fragment"});
                table26.AddRow(new string[] {
                            "scope",
                            "accounts"});
                table26.AddRow(new string[] {
                            "redirect_uri",
                            "https://localhost:8080/callback"});
                table26.AddRow(new string[] {
                            "nonce",
                            "nonce"});
                table26.AddRow(new string[] {
                            "exp",
                            "$tomorrow$"});
                table26.AddRow(new string[] {
                            "aud",
                            "https://localhost:8080"});
                table26.AddRow(new string[] {
                            "claims",
                            "{ id_token: { openbanking_intent_id: { value: \"value\", essential : true } } }"});
#line 23
 testRunner.And("use \'1\' JWK from \'jwks\' to build JWS and store into \'request\'", ((string)(null)), table26, "And ");
#line hidden
                TechTalk.SpecFlow.Table table27 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table27.AddRow(new string[] {
                            "response_type",
                            "code id_token"});
                table27.AddRow(new string[] {
                            "client_id",
                            "$client_id$"});
                table27.AddRow(new string[] {
                            "request",
                            "$request$"});
                table27.AddRow(new string[] {
                            "scope",
                            "accounts"});
#line 36
 testRunner.And("execute HTTP GET request \'https://localhost:8080/authorization\'", ((string)(null)), table27, "And ");
#line hidden
#line 43
 testRunner.And("extract query parameters into JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 45
 testRunner.Then("JSON \'error\'=\'invalid_request\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 46
 testRunner.Then("JSON \'error_description\'=\'account access consent \'value\' doesn\'t exist\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Error is returned when Account Access Consent has been rejected")]
        [Xunit.TraitAttribute("FeatureTitle", "AuthorizationErrors")]
        [Xunit.TraitAttribute("Description", "Error is returned when Account Access Consent has been rejected")]
        public virtual void ErrorIsReturnedWhenAccountAccessConsentHasBeenRejected()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Error is returned when Account Access Consent has been rejected", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 48
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table28 = new TechTalk.SpecFlow.Table(new string[] {
                            "Type",
                            "Kid",
                            "AlgName"});
                table28.AddRow(new string[] {
                            "SIG",
                            "1",
                            "RS256"});
#line 49
 testRunner.When("build JSON Web Keys, store JWKS into \'jwks\' and store the public keys into \'jwks_" +
                        "json\'", ((string)(null)), table28, "When ");
#line hidden
                TechTalk.SpecFlow.Table table29 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table29.AddRow(new string[] {
                            "token_endpoint_auth_method",
                            "tls_client_auth"});
                table29.AddRow(new string[] {
                            "response_types",
                            "[token,code,id_token]"});
                table29.AddRow(new string[] {
                            "grant_types",
                            "[client_credentials]"});
                table29.AddRow(new string[] {
                            "scope",
                            "accounts"});
                table29.AddRow(new string[] {
                            "redirect_uris",
                            "[https://localhost:8080/callback]"});
                table29.AddRow(new string[] {
                            "tls_client_auth_san_dns",
                            "firstMtlsClient"});
                table29.AddRow(new string[] {
                            "request_object_signing_alg",
                            "RS256"});
                table29.AddRow(new string[] {
                            "jwks",
                            "$jwks_json$"});
#line 53
 testRunner.When("execute HTTP POST JSON request \'https://localhost:8080/register\'", ((string)(null)), table29, "When ");
#line hidden
#line 64
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 65
 testRunner.And("extract parameter \'client_id\' from JSON body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 67
 testRunner.And("add rejected Account Access Consent \'$client_id$\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table30 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table30.AddRow(new string[] {
                            "response_type",
                            "code id_token"});
                table30.AddRow(new string[] {
                            "client_id",
                            "$client_id$"});
                table30.AddRow(new string[] {
                            "state",
                            "state"});
                table30.AddRow(new string[] {
                            "response_mode",
                            "fragment"});
                table30.AddRow(new string[] {
                            "scope",
                            "accounts"});
                table30.AddRow(new string[] {
                            "redirect_uri",
                            "https://localhost:8080/callback"});
                table30.AddRow(new string[] {
                            "nonce",
                            "nonce"});
                table30.AddRow(new string[] {
                            "exp",
                            "$tomorrow$"});
                table30.AddRow(new string[] {
                            "aud",
                            "https://localhost:8080"});
                table30.AddRow(new string[] {
                            "claims",
                            "{ id_token: { openbanking_intent_id: { value: \"$consentId$\", essential : true } }" +
                                " }"});
#line 69
 testRunner.And("use \'1\' JWK from \'jwks\' to build JWS and store into \'request\'", ((string)(null)), table30, "And ");
#line hidden
                TechTalk.SpecFlow.Table table31 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table31.AddRow(new string[] {
                            "response_type",
                            "code id_token"});
                table31.AddRow(new string[] {
                            "client_id",
                            "$client_id$"});
                table31.AddRow(new string[] {
                            "request",
                            "$request$"});
                table31.AddRow(new string[] {
                            "scope",
                            "accounts"});
#line 82
 testRunner.And("execute HTTP GET request \'https://localhost:8080/authorization\'", ((string)(null)), table31, "And ");
#line hidden
#line 89
 testRunner.And("extract query parameters into JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 91
 testRunner.Then("JSON \'error\'=\'invalid_request\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 92
 testRunner.Then("JSON \'error_description\'=\'Account Access Consent has been rejected\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Error is returned when \'exp\' claim is missing from the request object")]
        [Xunit.TraitAttribute("FeatureTitle", "AuthorizationErrors")]
        [Xunit.TraitAttribute("Description", "Error is returned when \'exp\' claim is missing from the request object")]
        public virtual void ErrorIsReturnedWhenExpClaimIsMissingFromTheRequestObject()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Error is returned when \'exp\' claim is missing from the request object", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 94
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table32 = new TechTalk.SpecFlow.Table(new string[] {
                            "Type",
                            "Kid",
                            "AlgName"});
                table32.AddRow(new string[] {
                            "SIG",
                            "1",
                            "RS256"});
#line 95
 testRunner.When("build JSON Web Keys, store JWKS into \'jwks\' and store the public keys into \'jwks_" +
                        "json\'", ((string)(null)), table32, "When ");
#line hidden
                TechTalk.SpecFlow.Table table33 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table33.AddRow(new string[] {
                            "token_endpoint_auth_method",
                            "tls_client_auth"});
                table33.AddRow(new string[] {
                            "response_types",
                            "[token,code,id_token]"});
                table33.AddRow(new string[] {
                            "grant_types",
                            "[client_credentials]"});
                table33.AddRow(new string[] {
                            "scope",
                            "accounts"});
                table33.AddRow(new string[] {
                            "request_object_signing_alg",
                            "RS256"});
                table33.AddRow(new string[] {
                            "jwks",
                            "$jwks_json$"});
                table33.AddRow(new string[] {
                            "client_id",
                            "invalid"});
                table33.AddRow(new string[] {
                            "redirect_uris",
                            "[https://localhost:8080/callback]"});
                table33.AddRow(new string[] {
                            "tls_client_auth_san_dns",
                            "firstMtlsClient"});
#line 99
 testRunner.And("execute HTTP POST JSON request \'https://localhost:8080/register\'", ((string)(null)), table33, "And ");
#line hidden
#line 111
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 112
 testRunner.And("extract parameter \'client_id\' from JSON body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table34 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table34.AddRow(new string[] {
                            "response_type",
                            "id_token"});
                table34.AddRow(new string[] {
                            "client_id",
                            "$client_id$"});
                table34.AddRow(new string[] {
                            "state",
                            "state"});
                table34.AddRow(new string[] {
                            "response_mode",
                            "fragment"});
                table34.AddRow(new string[] {
                            "scope",
                            "accounts"});
                table34.AddRow(new string[] {
                            "redirect_uri",
                            "https://localhost:8080/callback"});
                table34.AddRow(new string[] {
                            "nonce",
                            "nonce"});
#line 114
 testRunner.And("use \'1\' JWK from \'jwks\' to build JWS and store into \'request\'", ((string)(null)), table34, "And ");
#line hidden
                TechTalk.SpecFlow.Table table35 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table35.AddRow(new string[] {
                            "response_type",
                            "id_token"});
                table35.AddRow(new string[] {
                            "client_id",
                            "$client_id$"});
                table35.AddRow(new string[] {
                            "request",
                            "$request$"});
                table35.AddRow(new string[] {
                            "scope",
                            "accounts"});
#line 124
 testRunner.And("execute HTTP GET request \'https://localhost:8080/authorization\'", ((string)(null)), table35, "And ");
#line hidden
#line 131
 testRunner.And("extract query parameters into JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 133
 testRunner.Then("JSON \'error\'=\'invalid_request\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 134
 testRunner.Then("JSON \'error_description\'=\'missing parameter exp\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Error is returned when request object is expired")]
        [Xunit.TraitAttribute("FeatureTitle", "AuthorizationErrors")]
        [Xunit.TraitAttribute("Description", "Error is returned when request object is expired")]
        public virtual void ErrorIsReturnedWhenRequestObjectIsExpired()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Error is returned when request object is expired", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 136
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table36 = new TechTalk.SpecFlow.Table(new string[] {
                            "Type",
                            "Kid",
                            "AlgName"});
                table36.AddRow(new string[] {
                            "SIG",
                            "1",
                            "RS256"});
#line 137
 testRunner.When("build JSON Web Keys, store JWKS into \'jwks\' and store the public keys into \'jwks_" +
                        "json\'", ((string)(null)), table36, "When ");
#line hidden
                TechTalk.SpecFlow.Table table37 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table37.AddRow(new string[] {
                            "token_endpoint_auth_method",
                            "tls_client_auth"});
                table37.AddRow(new string[] {
                            "response_types",
                            "[token,code,id_token]"});
                table37.AddRow(new string[] {
                            "grant_types",
                            "[client_credentials]"});
                table37.AddRow(new string[] {
                            "scope",
                            "accounts"});
                table37.AddRow(new string[] {
                            "request_object_signing_alg",
                            "RS256"});
                table37.AddRow(new string[] {
                            "jwks",
                            "$jwks_json$"});
                table37.AddRow(new string[] {
                            "client_id",
                            "invalid"});
                table37.AddRow(new string[] {
                            "redirect_uris",
                            "[https://localhost:8080/callback]"});
                table37.AddRow(new string[] {
                            "tls_client_auth_san_dns",
                            "firstMtlsClient"});
#line 141
 testRunner.And("execute HTTP POST JSON request \'https://localhost:8080/register\'", ((string)(null)), table37, "And ");
#line hidden
#line 153
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 154
 testRunner.And("extract parameter \'client_id\' from JSON body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table38 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table38.AddRow(new string[] {
                            "response_type",
                            "id_token"});
                table38.AddRow(new string[] {
                            "client_id",
                            "$client_id$"});
                table38.AddRow(new string[] {
                            "state",
                            "state"});
                table38.AddRow(new string[] {
                            "response_mode",
                            "fragment"});
                table38.AddRow(new string[] {
                            "scope",
                            "accounts"});
                table38.AddRow(new string[] {
                            "redirect_uri",
                            "https://localhost:8080/callback"});
                table38.AddRow(new string[] {
                            "nonce",
                            "nonce"});
                table38.AddRow(new string[] {
                            "exp",
                            "1613046297"});
#line 156
 testRunner.And("use \'1\' JWK from \'jwks\' to build JWS and store into \'request\'", ((string)(null)), table38, "And ");
#line hidden
                TechTalk.SpecFlow.Table table39 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table39.AddRow(new string[] {
                            "response_type",
                            "id_token"});
                table39.AddRow(new string[] {
                            "client_id",
                            "$client_id$"});
                table39.AddRow(new string[] {
                            "request",
                            "$request$"});
                table39.AddRow(new string[] {
                            "scope",
                            "accounts"});
#line 167
 testRunner.And("execute HTTP GET request \'https://localhost:8080/authorization\'", ((string)(null)), table39, "And ");
#line hidden
#line 174
 testRunner.And("extract query parameters into JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 176
 testRunner.Then("JSON \'error\'=\'invalid_request_object\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 177
 testRunner.Then("JSON \'error_description\'=\'request object is expired\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Error is returned when request object contains invalid audience")]
        [Xunit.TraitAttribute("FeatureTitle", "AuthorizationErrors")]
        [Xunit.TraitAttribute("Description", "Error is returned when request object contains invalid audience")]
        public virtual void ErrorIsReturnedWhenRequestObjectContainsInvalidAudience()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Error is returned when request object contains invalid audience", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 179
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table40 = new TechTalk.SpecFlow.Table(new string[] {
                            "Type",
                            "Kid",
                            "AlgName"});
                table40.AddRow(new string[] {
                            "SIG",
                            "1",
                            "RS256"});
#line 180
 testRunner.When("build JSON Web Keys, store JWKS into \'jwks\' and store the public keys into \'jwks_" +
                        "json\'", ((string)(null)), table40, "When ");
#line hidden
                TechTalk.SpecFlow.Table table41 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table41.AddRow(new string[] {
                            "token_endpoint_auth_method",
                            "tls_client_auth"});
                table41.AddRow(new string[] {
                            "response_types",
                            "[token,code,id_token]"});
                table41.AddRow(new string[] {
                            "grant_types",
                            "[client_credentials]"});
                table41.AddRow(new string[] {
                            "scope",
                            "accounts"});
                table41.AddRow(new string[] {
                            "request_object_signing_alg",
                            "RS256"});
                table41.AddRow(new string[] {
                            "jwks",
                            "$jwks_json$"});
                table41.AddRow(new string[] {
                            "client_id",
                            "invalid"});
                table41.AddRow(new string[] {
                            "redirect_uris",
                            "[https://localhost:8080/callback]"});
                table41.AddRow(new string[] {
                            "tls_client_auth_san_dns",
                            "firstMtlsClient"});
#line 184
 testRunner.And("execute HTTP POST JSON request \'https://localhost:8080/register\'", ((string)(null)), table41, "And ");
#line hidden
#line 196
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 197
 testRunner.And("extract parameter \'client_id\' from JSON body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table42 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table42.AddRow(new string[] {
                            "response_type",
                            "id_token"});
                table42.AddRow(new string[] {
                            "client_id",
                            "$client_id$"});
                table42.AddRow(new string[] {
                            "state",
                            "state"});
                table42.AddRow(new string[] {
                            "response_mode",
                            "fragment"});
                table42.AddRow(new string[] {
                            "scope",
                            "accounts"});
                table42.AddRow(new string[] {
                            "redirect_uri",
                            "https://localhost:8080/callback"});
                table42.AddRow(new string[] {
                            "nonce",
                            "nonce"});
                table42.AddRow(new string[] {
                            "exp",
                            "$tomorrow$"});
                table42.AddRow(new string[] {
                            "aud",
                            "http://web.com"});
#line 199
 testRunner.And("use \'1\' JWK from \'jwks\' to build JWS and store into \'request\'", ((string)(null)), table42, "And ");
#line hidden
                TechTalk.SpecFlow.Table table43 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table43.AddRow(new string[] {
                            "response_type",
                            "id_token"});
                table43.AddRow(new string[] {
                            "client_id",
                            "$client_id$"});
                table43.AddRow(new string[] {
                            "request",
                            "$request$"});
                table43.AddRow(new string[] {
                            "scope",
                            "accounts"});
#line 211
 testRunner.And("execute HTTP GET request \'https://localhost:8080/authorization\'", ((string)(null)), table43, "And ");
#line hidden
#line 218
 testRunner.And("extract query parameters into JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 220
 testRunner.Then("JSON \'error\'=\'invalid_request_object\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 221
 testRunner.Then("JSON \'error_description\'=\'request object has bad audience\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.7.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                AuthorizationErrorsFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                AuthorizationErrorsFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion