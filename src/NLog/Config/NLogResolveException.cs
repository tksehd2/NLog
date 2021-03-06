﻿// 
// Copyright (c) 2004-2020 Jaroslaw Kowalski <jaak@jkowalski.net>, Kim Christensen, Julian Verdurmen
// 
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// * Redistributions of source code must retain the above copyright notice, 
//   this list of conditions and the following disclaimer. 
// 
// * Redistributions in binary form must reproduce the above copyright notice,
//   this list of conditions and the following disclaimer in the documentation
//   and/or other materials provided with the distribution. 
// 
// * Neither the name of Jaroslaw Kowalski nor the names of its 
//   contributors may be used to endorse or promote products derived from this
//   software without specific prior written permission. 
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
// ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE 
// LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
// CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF 
// THE POSSIBILITY OF SUCH DAMAGE.
// 

using System;
using System.Linq;
using JetBrains.Annotations;

namespace NLog.Config
{
    /// <summary>
    /// Failed to resolve a Type
    /// </summary>
    public sealed class NLogResolveException : Exception
    {
        /// <summary>
        /// Typed we tried to resolve
        /// </summary>
        [NotNull] public Type TypeToResolve { get; }
        
        /// <inheritdoc />
        public NLogResolveException(string message, [NotNull] Type typeToResolve) : base(CreateFullMessage(typeToResolve, message))
        {
            TypeToResolve = typeToResolve ?? throw new ArgumentNullException(nameof(typeToResolve));
        }

        /// <inheritdoc />
        public NLogResolveException(string message, Exception innerException, [NotNull] Type typeToResolve) : base(CreateFullMessage(typeToResolve, message), innerException)
        {
            TypeToResolve = typeToResolve ?? throw new ArgumentNullException(nameof(typeToResolve));
        }

        private static string CreateFullMessage(Type typeToResolve, string message) => $"Cannot resolve the type: '{typeToResolve.Name}'. {message}".Trim();
    }
}
