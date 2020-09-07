﻿using System;
using System.Collections.Generic;
using Atc.Rest.ApiGenerator.Models;
using Microsoft.OpenApi.Models;

// ReSharper disable ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable UseDeconstruction
namespace Atc.Rest.ApiGenerator.SyntaxGenerators
{
    public class SyntaxGeneratorContractParameters : ISyntaxGeneratorContractParameters
    {
        public SyntaxGeneratorContractParameters(
            ApiProjectOptions apiProjectOptions,
            string focusOnSegmentName)
        {
            this.ApiProjectOptions = apiProjectOptions ?? throw new ArgumentNullException(nameof(apiProjectOptions));
            this.FocusOnSegmentName = focusOnSegmentName ?? throw new ArgumentNullException(nameof(focusOnSegmentName));
        }

        public ApiProjectOptions ApiProjectOptions { get; }

        public string FocusOnSegmentName { get; }

        public List<SyntaxGeneratorContractParameter> GenerateSyntaxTrees()
        {
            var list = new List<SyntaxGeneratorContractParameter>();
            foreach (var urlPath in ApiProjectOptions.Document.Paths)
            {
                if (!urlPath.IsPathStartingSegmentName(FocusOnSegmentName))
                {
                    continue;
                }

                foreach (var apiOperation in urlPath.Value.Operations)
                {
                    if (!apiOperation.Value.HasParametersOrRequestBody())
                    {
                        continue;
                    }

                    var generator = new SyntaxGeneratorContractParameter(ApiProjectOptions, apiOperation.Key, apiOperation.Value, FocusOnSegmentName);
                    generator.GenerateCode();
                    list.Add(generator);
                }
            }

            return list;
        }
    }
}