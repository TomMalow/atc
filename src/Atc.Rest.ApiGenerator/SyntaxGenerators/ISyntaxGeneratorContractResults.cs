﻿using System.Collections.Generic;

namespace Atc.Rest.ApiGenerator.SyntaxGenerators
{
    public interface ISyntaxGeneratorContractResults : ISyntaxGeneratorContract
    {
        List<SyntaxGeneratorContractResult> GenerateSyntaxTrees();
    }
}