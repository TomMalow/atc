﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;

// ReSharper disable InvertIf
namespace Atc.Rest.ApiGenerator.Factories
{
    internal static class ProjectContractPropertyFactory
    {
        public static string[] CreateUsingList(
            IList<OpenApiParameter>? globalParameters,
            IList<OpenApiParameter>? parameters,
            OpenApiRequestBody? requestBody)
        {
            var list = new List<string>();

            if (globalParameters != null)
            {
                if (globalParameters.HasFormatTypeFromSystemNamespace())
                {
                    list.Add("System");
                }

                if (ShouldUseDataAnnotationsNamespace(globalParameters))
                {
                    list.Add("System.ComponentModel.DataAnnotations");
                }
            }

            if (parameters != null)
            {
                if (list.All(x => x != "System") &&
                    parameters.HasFormatTypeFromSystemNamespace())
                {
                    list.Add("System");
                }

                list.Add("System.CodeDom.Compiler");

                if (list.All(x => x != "System.ComponentModel.DataAnnotations") &&
                    ShouldUseDataAnnotationsNamespace(parameters))
                {
                    list.Add("System.ComponentModel.DataAnnotations");
                }

                list.Add("Microsoft.AspNetCore.Mvc");
            }

            var contentSchema = requestBody?.Content?.GetSchema();
            if (contentSchema != null && contentSchema.HasAnyProperties())
            {
                if (list.All(x => x != "System") &&
                    contentSchema.HasFormatTypeFromSystemNamespace())
                {
                    list.Add("System");
                }

                if (list.All(x => x != "System.Collections.Generic") &&
                    (contentSchema.Type == OpenApiDataTypeConstants.Array || contentSchema.HasDataTypeFromSystemCollectionGenericNamespace()))
                {
                    list.Add("System");
                }

                if (list.All(x => x != "System.ComponentModel.DataAnnotations") &&
                    ShouldUseDataAnnotationsNamespace(contentSchema))
                {
                    list.Add("System.ComponentModel.DataAnnotations");
                }
            }

            return list.ToArray();
        }

        private static bool ShouldUseDataAnnotationsNamespace(OpenApiSchema schema)
            => schema.Required.Any() || schema.HasFormatTypeFromDataAnnotationsNamespace();

        private static bool ShouldUseDataAnnotationsNamespace(IList<OpenApiParameter> parameters)
            => parameters.Any(x => x.Required) || parameters.HasFormatTypeFromDataAnnotationsNamespace();
    }
}