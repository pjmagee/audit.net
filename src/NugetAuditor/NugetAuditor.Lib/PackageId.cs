﻿// Copyright (c) 2015-2016, Vör Security Ltd.
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
//     * Redistributions of source code must retain the above copyright
//       notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright
//       notice, this list of conditions and the following disclaimer in the
//       documentation and/or other materials provided with the distribution.
//     * Neither the name of Vör Security, OSS Index, nor the
//       names of its contributors may be used to endorse or promote products
//       derived from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL VÖR SECURITY BE LIABLE FOR ANY
// DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
// (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

using NuGet.Versioning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NugetAuditor.Lib
{
    public class PackageId 
    {
        private string _originalVersion;

        public string Id
        {
            get;
            private set;
        }

        public NuGetVersion Version
        {
            get;
            private set;
        }

        public string VersionString
        {
            get
            {
                return this.Version.ToNormalizedString();
            }
        }

        public PackageId(string id, string version)
            :this(id, NuGetVersion.Parse(version))
        {
            this._originalVersion = version;
        }

        private PackageId(string id, NuGetVersion version)
        {
            this.Id = id;
            this.Version = version;
        }

        public override bool Equals(object obj)
        {
            PackageId other = obj as PackageId;

            if (other == null)
            {
                return false;
            }

            return (this.Id.Equals(other.Id, StringComparison.OrdinalIgnoreCase) && this.VersionString.Equals(other.VersionString, StringComparison.OrdinalIgnoreCase));
        }

        public override int GetHashCode()
        {
            int h1 = this.Id.GetHashCode();
            int h2 = this.Version.GetHashCode();

            return (((h1 << 5) + h1) ^ h2);
        }

        public override string ToString()
        {
            return (this.Id + " " + this.Version);
        }
    }
}
