//-----------------------------------------------------------------------------
// <auto-generated>
//     This file was generated by the C# SDK Code Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using Unity.Services.Core.Environments.Client.Http;

namespace Unity.Services.Core.Environments.Client
{
    /// <summary>
    /// Class to represent a base response.
    /// </summary>
    internal class Response {
        /// <summary>The response headers.</summary>
        public Dictionary<string, string> Headers { get; }
        /// <summary>The response status code.</summary>
        public long Status { get; set; }

        /// <summary>Constructor</summary>
        /// <param name="httpResponse">The HTTP response.</param>
        public Response(HttpClientResponse httpResponse)
        {
            this.Headers = httpResponse.Headers;
            this.Status = httpResponse.StatusCode;
        }
    }

    /// <summary>
    /// Response class with configurable result type.
    /// </summary>
    /// <typeparam name="T">The response type.</typeparam>
    internal class Response<T> : Response
    {
        /// <summary>The result object.</summary>
        public T Result { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="httpResponse">The HTTP response.</param>
        /// <param name="result">The result to store.</param>
        public Response(HttpClientResponse httpResponse, T result): base(httpResponse)
        {
            this.Result = result;
        }
    }
}
