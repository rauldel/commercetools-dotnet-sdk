﻿using commercetools.Sdk.Client;
using System.Net.Http;

namespace commercetools.Sdk.HttpApi
{
    public class GetHttpApiCommand<T> : IHttpApiCommand<GetCommand<T>, T>
    {
        private GetCommand<T> command;
        private readonly GetRequestMessageBuilder requestBuilder;

        public HttpRequestMessage HttpRequestMessage
        {
            get
            {
                return this.requestBuilder.GetRequestMessage(command);
            }
        }

        public GetHttpApiCommand(GetCommand<T> command, IRequestMessageBuilderFactory requestMessageBuilderFactory)
        {
            this.command = command;
            this.requestBuilder = requestMessageBuilderFactory.GetRequestMessageBuilder<GetRequestMessageBuilder>();
        }
    }
}