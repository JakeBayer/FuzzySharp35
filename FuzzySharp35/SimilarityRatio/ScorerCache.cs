using System;
using System.Collections.Generic;
using FuzzySharp.SimilarityRatio.Scorer;

namespace FuzzySharp.SimilarityRatio
{
    public static class ScorerCache
    {
        private static readonly Dictionary<Type, IRatioScorer> s_scorerCache = new Dictionary<Type, IRatioScorer>();
        private static readonly object _mutex = new object();
        public static IRatioScorer Get<T>() where T : IRatioScorer, new()
        {
            lock (_mutex)
            {
                var typeOfT = typeof(T);
                if (!s_scorerCache.ContainsKey(typeOfT))
                {
                    s_scorerCache.Add(typeOfT, new T());
                }
                return s_scorerCache[typeOfT];
            }
            
        }
    }
}
