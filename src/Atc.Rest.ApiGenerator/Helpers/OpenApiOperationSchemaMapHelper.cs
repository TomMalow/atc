﻿using System;
using System.Collections.Generic;
using System.Linq;
using Atc.Rest.ApiGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

// ReSharper disable UseDeconstruction
// ReSharper disable InvertIf
// ReSharper disable ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
namespace Atc.Rest.ApiGenerator.Helpers
{
    public static class OpenApiOperationSchemaMapHelper
    {
        public static string GetSegmentName(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            return path
                .Split('/', StringSplitOptions.RemoveEmptyEntries)
                .First()
                .EnsureFirstLetterToUpperAndPlural();
        }

        public static List<ApiOperationSchemaMap> CollectMappings(OpenApiDocument apiDocument)
        {
            if (apiDocument == null)
            {
                throw new ArgumentNullException(nameof(apiDocument));
            }

            var list = new List<ApiOperationSchemaMap>();
            foreach (var apiPath in apiDocument.Paths)
            {
                foreach (var apiOperation in apiPath.Value.Operations)
                {
                    // Parameters
                    foreach (var apiParameter in apiOperation.Value.Parameters)
                    {
                        if (apiParameter.Content == null)
                        {
                            continue;
                        }

                        foreach (var apiMediaType in apiParameter.Content)
                        {
                            CollectSchema(
                                apiMediaType.Value.Schema,
                                SchemaMapLocatedAreaType.Parameter,
                                apiPath.Key,
                                apiOperation.Key,
                                null,
                                list);
                        }
                    }

                    // RequestBody
                    if (apiOperation.Value.RequestBody?.Content != null)
                    {
                        foreach (var apiMediaType in apiOperation.Value.RequestBody.Content)
                        {
                            CollectSchema(
                                apiMediaType.Value.Schema,
                                SchemaMapLocatedAreaType.RequestBody,
                                apiPath.Key,
                                apiOperation.Key,
                                null,
                                list);
                        }
                    }

                    // Responses
                    foreach (var apiResponse in apiOperation.Value.Responses)
                    {
                        if (apiResponse.Value?.Content == null)
                        {
                            continue;
                        }

                        foreach (var apiMediaType in apiResponse.Value.Content)
                        {
                            CollectSchema(
                                apiMediaType.Value.Schema,
                                SchemaMapLocatedAreaType.Response,
                                apiPath.Key,
                                apiOperation.Key,
                                null,
                                list);
                        }
                    }
                }
            }

            return list;
        }

        private static void CollectSchema(
            OpenApiSchema apiSchema,
            SchemaMapLocatedAreaType locatedArea,
            string apiPath,
            OperationType apiOperationType,
            string? parentApiSchema,
            List<ApiOperationSchemaMap> list)
        {
            var schemaKey = string.Empty;
            if (apiSchema.Reference?.Id != null)
            {
                schemaKey = apiSchema.Reference.Id;
            }
            else if (apiSchema.Items?.Reference?.Id != null)
            {
                schemaKey = apiSchema.Items.Reference.Id;
            }
            else if (apiSchema.AllOf.Count == 2)
            {
                if (apiSchema.AllOf[0].Reference?.Id == Microsoft.OpenApi.Models.NameConstants.Pagination ||
                    apiSchema.AllOf[1].Reference?.Id == Microsoft.OpenApi.Models.NameConstants.Pagination)
                {
                    if (apiSchema.AllOf[0].Reference?.Id != Microsoft.OpenApi.Models.NameConstants.Pagination)
                    {
                        schemaKey = apiSchema.AllOf[0].GetModelName();
                    }

                    if (apiSchema.AllOf[1].Reference?.Id != Microsoft.OpenApi.Models.NameConstants.Pagination)
                    {
                        schemaKey = apiSchema.AllOf[1].GetModelName();
                    }
                }
            }

            if (schemaKey.Length == 0 ||
                schemaKey == nameof(ProblemDetails) ||
                schemaKey == "Pagination")
            {
                return;
            }

            list.Add(new ApiOperationSchemaMap(schemaKey, locatedArea, apiPath, apiOperationType, parentApiSchema));
            Collect(
                apiSchema.Properties.ToList(),
                locatedArea,
                apiPath,
                apiOperationType,
                schemaKey,
                list);

            if (apiSchema.Items != null &&
                apiSchema.Type == OpenApiDataTypeConstants.Array &&
                apiSchema.Items.Reference?.Id != null &&
                schemaKey != apiSchema.Items.Reference.Id)
            {
                list.Add(new ApiOperationSchemaMap(apiSchema.Items.Reference.Id, locatedArea, apiPath, apiOperationType, schemaKey));
                Collect(
                    apiSchema.Items.Properties.ToList(),
                    locatedArea,
                    apiPath,
                    apiOperationType,
                    apiSchema.Items.Reference.Id,
                    list);
            }
        }

        private static void Collect(
            IEnumerable<KeyValuePair<string, OpenApiSchema>> apiSchemas,
            SchemaMapLocatedAreaType areaType,
            string apiPath,
            OperationType apiOperationType,
            string parentApiSchema,
            List<ApiOperationSchemaMap> list)
        {
            foreach (var apiSchema in apiSchemas)
            {
                CollectSchema(
                    apiSchema.Value,
                    areaType,
                    apiPath,
                    apiOperationType,
                    parentApiSchema,
                    list);
            }
        }
    }
}