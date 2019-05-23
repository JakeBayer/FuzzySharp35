using System;

namespace FuzzySharp.SimilarityRatio.Scorer.Generic
{
    public interface IRatioScorer<T> where T : IEquatable<T>
    {
        int Score(T[] input1, T[] input2);
    }
}
