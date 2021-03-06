﻿// <copyright file="TracerProviderSdk.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using OpenTelemetry.Resources;

namespace OpenTelemetry.Trace
{
    internal class TracerProviderSdk : TracerProvider
    {
        public readonly List<object> Instrumentations = new List<object>();
        public Resource Resource;
        public ActivityProcessor ActivityProcessor;
        public ActivityListener ActivityListener;
        public Sampler Sampler;

        static TracerProviderSdk()
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            Activity.ForceDefaultIdFormat = true;
        }

        internal TracerProviderSdk()
        {
        }

        protected override void Dispose(bool disposing)
        {
            foreach (var item in this.Instrumentations)
            {
                (item as IDisposable)?.Dispose();
            }

            this.Instrumentations.Clear();

            this.ActivityProcessor?.Dispose();

            // Shutdown the listener last so that anything created while instrumentation cleans up will still be processed.
            // Redis instrumentation, for example, flushes during dispose which creates Activity objects for any profiling
            // sessions that were open.
            this.ActivityListener?.Dispose();

            base.Dispose(disposing);
        }
    }
}
