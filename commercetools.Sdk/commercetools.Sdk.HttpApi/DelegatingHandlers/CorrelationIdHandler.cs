﻿namespace commercetools.Sdk.HttpApi
{
    using Microsoft.Extensions.Logging;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class CorrelationIdHandler : DelegatingHandler
    {
        private readonly ICorrelationIdProvider correlationIdProvider;

        public CorrelationIdHandler(ICorrelationIdProvider correlationIdProvider)
        {
            this.correlationIdProvider = correlationIdProvider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var correlationId = this.correlationIdProvider.CorrelationId;
            request.Headers.Add("X-Correlation-ID", correlationId);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}