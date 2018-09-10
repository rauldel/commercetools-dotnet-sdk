﻿namespace commercetools.Sdk.HttpApi
{
    using System;
    using System.Net.Http;

    public class AnonymousSessionTokenProvider : TokenProvider, ITokenProvider
    {
        private IAnonymousCredentialsStoreManager anonymousCredentialsStoreManager;
        public TokenFlow TokenFlow => TokenFlow.AnonymousSession;        

        public AnonymousSessionTokenProvider(IHttpClientFactory httpClientFactory, IClientConfiguration clientConfiguration, IAnonymousCredentialsStoreManager anonymousCredentialsStoreManager) : base(httpClientFactory, clientConfiguration, anonymousCredentialsStoreManager)
        {
            this.anonymousCredentialsStoreManager = anonymousCredentialsStoreManager;
        }

        public override HttpRequestMessage GetRequestMessage()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            string requestUri = this.ClientConfiguration.AuthorizationBaseAddress + $"oauth/{this.ClientConfiguration.ProjectKey}/anonymous/token?grant_type=client_credentials";
            requestUri += $"&scope={this.ClientConfiguration.Scope}";
            if (!string.IsNullOrEmpty(this.anonymousCredentialsStoreManager.AnonymousId))
            { 
                requestUri += $"&anonymous_id={this.anonymousCredentialsStoreManager.AnonymousId}";
            }
            request.RequestUri = new Uri(requestUri);
            string credentials = $"{this.ClientConfiguration.ClientId}:{this.ClientConfiguration.ClientSecret}";
            request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(credentials)));
            request.Method = HttpMethod.Post;
            return request;
        }
    }
}