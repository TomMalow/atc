﻿using Microsoft.OpenApi.Models;

namespace Atc.OpenApi.Tests.XUnitTestData
{
    public static class TestDataOpenApiSchemaOfTypeFactory
    {
        public static OpenApiSchema CreateString()
        {
            return new OpenApiSchema
            {
                Type = "string",
            };
        }

        public static OpenApiSchema CreateInt32()
        {
            return new OpenApiSchema
            {
                Type = "integer",
                Format = "int32",
            };
        }

        public static OpenApiSchema CreateInt64()
        {
            return new OpenApiSchema
            {
                Type = "integer",
                Format = "int64",
            };
        }

        public static OpenApiSchema CreateNumberFloat()
        {
            return new OpenApiSchema
            {
                Type = "number",
                Format = "float",
            };
        }

        public static OpenApiSchema CreateStringByte()
        {
            return new OpenApiSchema
            {
                Type = "string",
                Format = "byte",
            };
        }

        public static OpenApiSchema CreateStringDate()
        {
            return new OpenApiSchema
            {
                Type = "string",
                Format = "date",
            };
        }

        public static OpenApiSchema CreateStringDateTime()
        {
            return new OpenApiSchema
            {
                Type = "string",
                Format = "date-time",
            };
        }

        public static OpenApiSchema CreateStringEmail()
        {
            return new OpenApiSchema
            {
                Type = "string",
                Format = "email",
            };
        }

        public static OpenApiSchema CreateStringTime()
        {
            return new OpenApiSchema
            {
                Type = "string",
                Format = "time",
            };
        }

        public static OpenApiSchema CreateStringTimestamp()
        {
            return new OpenApiSchema
            {
                Type = "string",
                Format = "timestamp",
            };
        }

        public static OpenApiSchema CreateStringUri()
        {
            return new OpenApiSchema
            {
                Type = "string",
                Format = "uri",
            };
        }

        public static OpenApiSchema CreateStringUuid()
        {
            return new OpenApiSchema
            {
                Type = "string",
                Format = "uuid",
            };
        }

        public static OpenApiSchema CreateListString()
        {
            return new OpenApiSchema
            {
                Type = "array",
                Items = CreateString(),
            };
        }

        public static OpenApiSchema CreateListInt32()
        {
            return new OpenApiSchema
            {
                Type = "array",
                Items = CreateInt32(),
            };
        }

        public static OpenApiSchema CreateListInt64()
        {
            return new OpenApiSchema
            {
                Type = "array",
                Items = CreateInt64(),
            };
        }

        public static OpenApiSchema CreateListNumberFloat()
        {
            return new OpenApiSchema
            {
                Type = "array",
                Items = CreateNumberFloat(),
            };
        }

        public static OpenApiSchema CreateListStringByte()
        {
            return new OpenApiSchema
            {
                Type = "array",
                Items = CreateStringByte(),
            };
        }

        public static OpenApiSchema CreateListStringDate()
        {
            return new OpenApiSchema
            {
                Type = "array",
                Items = CreateStringDate(),
            };
        }

        public static OpenApiSchema CreateListStringDateTime()
        {
            return new OpenApiSchema
            {
                Type = "array",
                Items = CreateStringDateTime(),
            };
        }

        public static OpenApiSchema CreateListStringEmail()
        {
            return new OpenApiSchema
            {
                Type = "array",
                Items = CreateStringEmail(),
            };
        }

        public static OpenApiSchema CreateListStringTime()
        {
            return new OpenApiSchema
            {
                Type = "array",
                Items = CreateStringTime(),
            };
        }

        public static OpenApiSchema CreateListStringTimestamp()
        {
            return new OpenApiSchema
            {
                Type = "array",
                Items = CreateStringTimestamp(),
            };
        }

        public static OpenApiSchema CreateListStringUri()
        {
            return new OpenApiSchema
            {
                Type = "array",
                Items = CreateStringUri(),
            };
        }

        public static OpenApiSchema CreateListStringUuid()
        {
            return new OpenApiSchema
            {
                Type = "array",
                Items = CreateStringUuid(),
            };
        }
    }
}