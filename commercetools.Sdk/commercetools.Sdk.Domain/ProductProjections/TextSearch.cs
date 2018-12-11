﻿namespace commercetools.Sdk.Domain.ProductProjections
{
    using Domain.Validation.Attributes;

    public class TextSearch
    {
        [Language]
        public string Language { get; set; }

        public string Term { get; set; }
    }
}