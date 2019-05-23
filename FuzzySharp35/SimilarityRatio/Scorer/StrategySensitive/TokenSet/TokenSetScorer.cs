﻿using System;
using FuzzySharp.SimilarityRatio.Strategy;

namespace FuzzySharp.SimilarityRatio.Scorer.StrategySensitive
{
    public class TokenSetScorer : TokenSetScorerBase
    {
        protected override Func<string, string, int> Scorer
        {
            get { return DefaultRatioStrategy.Calculate; }
        }
    }
}
