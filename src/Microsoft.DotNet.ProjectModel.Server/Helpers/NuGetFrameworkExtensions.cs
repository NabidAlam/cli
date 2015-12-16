﻿// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.DotNet.ProjectModel.Resolution;
using Microsoft.DotNet.ProjectModel.Server.Models;
using NuGet.Frameworks;

namespace Microsoft.DotNet.ProjectModel.Server.Helpers
{
    public static class NuGetFrameworkExtensions
    {
        public static FrameworkData ToPayload(this NuGetFramework framework,
                                              FrameworkReferenceResolver resolver)
        {
            return new FrameworkData
            {
                ShortName = framework.GetShortFolderName(),
                FrameworkName = framework.DotNetFrameworkName,
                FriendlyName = framework.Framework,
                RedistListPath = resolver.GetFrameworkRedistListPath(framework)
            };
        }

        public static IEnumerable<FrameworkData> ToPayloads(this IEnumerable<NuGetFramework> frameworks,
                                                            FrameworkReferenceResolver resolver)
        {
            return frameworks.Select(f => f.ToPayload(resolver));
        }
    }
}