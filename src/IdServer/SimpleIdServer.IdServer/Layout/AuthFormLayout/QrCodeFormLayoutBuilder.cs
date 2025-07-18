﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using FormBuilder.Components.FormElements.StackLayout;
using FormBuilder.Models;
using SimpleIdServer.IdServer.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SimpleIdServer.IdServer.Layout.AuthFormLayout;

public class QrCodeFormLayoutBuilder
{
    private FormRecord _record;
    private List<LabelTranslation> _loginTranslations;

    private QrCodeFormLayoutBuilder(FormRecord record, List<LabelTranslation> loginTranslations)
    {
        _record = record;
        _loginTranslations = loginTranslations;
    }

    public static QrCodeFormLayoutBuilder New(string id, string correlationId, string name, List<LabelTranslation> loginTranslations, string realm = null)
    {
        var record = new FormRecord
        {
            Id = id,
            CorrelationId = correlationId,
            Status = RecordVersionStatus.Published,
            Name = name,
            UpdateDateTime = DateTime.UtcNow,
            ActAsStep = true,
            Realm = realm ?? Constants.DefaultRealm,
            Category = FormCategories.Authentication,
            Elements = new ObservableCollection<IFormElementRecord>()
        };
        return new QrCodeFormLayoutBuilder(record, loginTranslations);
    }

    public QrCodeFormLayoutBuilder ConfigureQrCodeGenerationForm(string id)
    {
        var authForm = new FormStackLayoutRecord
        {
            Id = id,
            CorrelationId = id,
            IsFormEnabled = true,
            FormType = FormTypes.HTML,
            HtmlAttributes = new Dictionary<string, object>
            {
                { "id", "generateQrCodeForm" }
            },
            Elements = new ObservableCollection<IFormElementRecord>
            {
                // ReturnUrl.
                StandardFormComponents.NewReturnUrl(),
                // Realm.
                StandardFormComponents.NewRealm(),
                // SessionId
                StandardFormComponents.NewHidden(nameof(IQRCodeAuthViewModel.SessionId)),
                // Login.
                StandardFormComponents.NewLogin(_loginTranslations),
                // Generate the qr code.
                StandardFormComponents.NewGenerateQrCode()
            }
        };
        _record.Elements.Add(authForm);
        return this;
    }

    public QrCodeFormLayoutBuilder AddSuccessMessage(string code, string value)
    {
        _record.ErrorMessageTranslations.Add(new FormMessageTranslation
        {
            Language = Constants.DefaultLanguage,
            Value = value,
            Code = code
        });
        return this;
    }

    public QrCodeFormLayoutBuilder AddErrorMessage(string code, string value)
    {
        _record.ErrorMessageTranslations.Add(new FormMessageTranslation
        {
            Language = Constants.DefaultLanguage,
            Value = value,
            Code = code
        });
        return this;
    }

    public QrCodeFormLayoutBuilder ConfigureDisplayQrCode()
    {
        var record = StandardFormComponents.NewScanQrCode();
        _record.Elements.Add(record);
        return this;
    }

    public FormRecord Build() => _record;
}
