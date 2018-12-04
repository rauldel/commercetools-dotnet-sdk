﻿using commercetools.Sdk.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using Type = System.Type;

namespace commercetools.Sdk.Serialization
{
    public class ProductDiscountValueConverter : JsonConverterDecoratorTypeRetrieverBase<ProductDiscountValue>
    {
        public override string PropertyName => "type";

        public ProductDiscountValueConverter(IDecoratorTypeRetriever<ProductDiscountValue> decoratorTypeRetriever) : base(decoratorTypeRetriever)
        {
        }
    }
}