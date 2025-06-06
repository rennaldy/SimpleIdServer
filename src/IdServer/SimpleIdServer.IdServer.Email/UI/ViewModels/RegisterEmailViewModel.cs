﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using SimpleIdServer.IdServer.Email.Resources;
using SimpleIdServer.IdServer.UI.ViewModels;

namespace SimpleIdServer.IdServer.Email.UI.ViewModels;

public class RegisterEmailViewModel : OTPRegisterViewModel
{
    public override List<string> SpecificValidate()
    {
        var result = new List<string>();
        if (!string.IsNullOrWhiteSpace(Value) && !EmailValidator.IsValidEmail(Value)) result.Add(Global.InvalidEmail);
        return result;
    }
}
