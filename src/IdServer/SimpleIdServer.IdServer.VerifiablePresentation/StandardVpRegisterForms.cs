﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using FormBuilder.Components.FormElements.Input;
using FormBuilder.Components.FormElements.ListData;
using FormBuilder.Components.FormElements.StackLayout;
using FormBuilder.Models;
using FormBuilder.Models.Rules;
using FormBuilder.Rules;
using SimpleIdServer.IdServer.Layout;
using SimpleIdServer.IdServer.Layout.RegisterFormLayout;
using SimpleIdServer.IdServer.Resources;
using SimpleIdServer.IdServer.VerifiablePresentation.UI.ViewModels;
using System.Collections.ObjectModel;

namespace SimpleIdServer.IdServer.VerifiablePresentation;

public static class StandardVpRegisterForms
{
    public static string vpRegistrationFormId = "c08b62d4-15db-4dc1-a552-1fd3d6a26578";
    public static string backBtnId = "a9de2d4b-eb3c-4e2c-87a5-6b38077e473a";

    public static FormRecord VpForm = RegisterLayoutBuilder.New("6b2f5313-6c4e-4080-b18c-0d2b29c443ef", "vpRegister", Constants.AMR)
        .AddElement(new FormStackLayoutRecord
        {
            Id = Guid.NewGuid().ToString(),
            HtmlAttributes = new Dictionary<string, object>
            {
                { "id", "generateQrCodeForm" }
            },
            Elements = new ObservableCollection<IFormElementRecord>
            {
                new ListDataRecord
                {
                    Id = vpRegistrationFormId,
                    CorrelationId = vpRegistrationFormId,
                    FieldType = FormStackLayoutDefinition.TYPE,
                    Transformations = new List<ITransformationRule>
                    {
                        new PropertyTransformationRule
                        {
                            PropertyName = nameof(FormStackLayoutRecord.IsFormEnabled),
                            PropertyValue = "true"
                        },
                        new PropertyTransformationRule
                        {
                            PropertyName = nameof(FormStackLayoutRecord.FormType),
                            PropertyValue = "HTML"
                        }
                    },
                    HtmlAttributes = new Dictionary<string, object>
                    {
                        { "class", "vpRegister" }
                    },
                    Children = new List<IFormElementRecord>
                    {
                        new FormInputFieldRecord
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = "id",
                            FormType = FormInputTypes.HIDDEN,
                            Transformations = new List<ITransformationRule>
                            {
                                new IncomingTokensTransformationRule
                                {
                                    Source = "$.Id"
                                }
                            }
                        },
                        StandardRegisterFormComponents.NewRegister()
                    },
                    RepetitionRule = new IncomingTokensRepetitionRule
                    {
                        Path = $"$.{nameof(VerifiablePresentationRegisterViewModel.VerifiablePresentations)}[*]"
                    }
                }
            }
        })
        .AddElement(StandardFormComponents.NewScanQrCode())
        .AddErrorMessage(RegisterFormErrorMessages.InvalidIncomingRequest, Global.InvalidIncomingRequest)
        .AddErrorMessage(RegisterFormErrorMessages.MissingVpTokenParameter, string.Format(Global.MissingParameter, "vp_token"))
        .AddErrorMessage(RegisterFormErrorMessages.MissingPresentationSubmissionParameter, string.Format(Global.MissingParameter, "presentation_submission"))
        .AddErrorMessage(RegisterFormErrorMessages.MissingStateParameter, string.Format(Global.MissingParameter, "state"))
        .AddErrorMessage(RegisterFormErrorMessages.InvalidVerifiablePresentation, Resources.Global.InvalidVerifiablePresentation)
        .AddErrorMessage(RegisterFormErrorMessages.InvalidPresentationSubmission, Resources.Global.InvalidPresentationSubmission)
        .AddErrorMessage(RegisterFormErrorMessages.StateIsNotValid, Resources.Global.StateIsNotValid)
        .AddErrorMessage(RegisterFormErrorMessages.PresentationSubmissionMissingVerifiableCredential, Resources.Global.PresentationSubmissionMissingVerifiableCredential)
        .AddErrorMessage(RegisterFormErrorMessages.PresentationSubmissinMissingPathNested, Resources.Global.PresentationSubmissinMissingPathNested)
        .AddErrorMessage(RegisterFormErrorMessages.PresentationSubmissionBadFormat, Resources.Global.PresentationSubmissionBadFormat)
        .AddErrorMessage(RegisterFormErrorMessages.CannotExtractVcFromPath, Resources.Global.CannotExtractVcFromPath)
        .AddErrorMessage(RegisterFormErrorMessages.InvalidVerifiableCredential, Resources.Global.InvalidVerifiableCredential)
        .AddErrorMessage(RegisterFormErrorMessages.VcIssuerNotDid, Resources.Global.VcIssuerNotDid)
        .AddErrorMessage(RegisterFormErrorMessages.VerifiableCredentialProofInvalid, Resources.Global.VerifiableCredentialProofInvalid)
        .AddErrorMessage(RegisterFormErrorMessages.UnknownPresentationDefinition, Resources.Global.UnknownPresentationDefinition)
        .AddErrorMessage(RegisterFormErrorMessages.VerifiablePresentationProofInvalid, Resources.Global.VerifiablePresentationProofInvalid)
        .ConfigureBackButton(backBtnId)
        .Build(DateTime.UtcNow);
}
