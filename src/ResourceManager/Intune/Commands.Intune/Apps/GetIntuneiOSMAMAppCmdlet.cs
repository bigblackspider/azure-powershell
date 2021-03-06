﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Intune
{
    using Management.Intune;
    using Management.Intune.Models;
    using Microsoft.Azure.Commands.Intune.Properties;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Management.Automation;

    /// <summary>
    /// Cmdlet to get apps for iOS platform.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmIntuneiOSMAMApp"), OutputType(typeof(List<Application>))]
    public sealed class GetIntuneiOSMAMAppCmdlet : IntuneBaseCmdlet
    {
        /// <summary>
        /// Contains the cmdlet's execution logic.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            string filter = string.Format(CultureInfo.InvariantCulture, IntuneConstants.PlatformFilterQueryParam, PlatformType.iOS.ToString().ToLower());
            MultiPageGetter<Application> mpg = new MultiPageGetter<Application>();

            List<Application> items = mpg.GetAllResources(
               this.IntuneClient.GetApps,
               this.IntuneClient.GetAppsNext,
               this.AsuHostName,
               filter,
               top: null,
               select: null);

            this.WriteObject(items, enumerateCollection: true);
        }
    }
}
