using System;
using System.Collections.Generic;

namespace FuzzySharp.Extractor
{
    public class ExtractedResult<T> : IComparable<ExtractedResult<T>> 
    {

        public readonly T Value;
        public readonly int Score;
        public readonly int Index;

        public ExtractedResult(T value, int score)
        {
            Value = value;
            Score = score;
        }

        public ExtractedResult(T value, int score, int index)
        {
            Value = value;
            Score = score;
            Index = index;
        }

        public int CompareTo(ExtractedResult<T> other)
        {
            return Comparer<int>.Default.Compare(this.Score, other.Score);
        }

        public override string ToString()
        {
            if (typeof(T) == typeof(string))
            {
                return string.Format("(string: {0}, score: {1}, index: {2})", Value, Score, Index);
            }
            return string.Format("(value: {0}, score: {1}, index: {2})", Value.ToString(), Score, Index);
        }
    }
}
