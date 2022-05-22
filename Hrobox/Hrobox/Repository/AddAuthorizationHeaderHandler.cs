﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Xamarin.Essentials;

namespace Hrobox.Repository
{
    public class AddAuthorizationHeaderHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor accessor;
        public AddAuthorizationHeaderHandler(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
            
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var accessToken = await GetAccessTokenAsync();

            request.Headers.Authorization = new AuthenticationHeaderValue("bearer", accessToken);
            return await base.SendAsync(request, cancellationToken);
        }

        protected Task<string?> GetAccessTokenAsync()
        {

            return SecureStorage.GetAsync("bearer");
        }
    }
}
