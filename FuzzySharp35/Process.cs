using System;
using System.Collections.Generic;
using FuzzySharp.Extractor;
using FuzzySharp.PreProcess;
using FuzzySharp.SimilarityRatio;
using FuzzySharp.SimilarityRatio.Scorer;
using FuzzySharp.SimilarityRatio.Scorer.Composite;

namespace FuzzySharp
{
    public static class Process
    {
        private static readonly IRatioScorer s_defaultScorer = ScorerCache.Get<WeightedRatioScorer>();
        private static readonly Func<string, string> s_defaultStringProcessor = StringPreprocessorFactory.GetPreprocessor(PreprocessMode.Full);

        #region ExtractAll
        /// <summary>
        /// Creates a list of ExtractedResult which contain all the choices with
        /// their corresponding score where higher is more similar
        /// </summary>
        /// <param name="query"></param>
        /// <param name="choices"></param>
        /// <param name="processor"></param>
        /// <param name="scorer"></param>
        /// <param name="cutoff"></param>
        /// <returns></returns>
        public static IEnumerable<ExtractedResult<string>> ExtractAll(
            string query, 
            IEnumerable<string> choices, 
            Func<string, string> processor, 
            IRatioScorer scorer,
            int cutoff)
        {
            if (processor == default(Func<string, string>)) processor = s_defaultStringProcessor;
            if (scorer == default(IRatioScorer)) scorer = s_defaultScorer;
            if (cutoff == default(int)) cutoff = 0;
            return ResultExtractor.ExtractWithoutOrder(query, choices, processor, scorer, cutoff);
        }

        /// <summary>
        /// Creates a list of ExtractedResult which contain all the choices with
        /// their corresponding score where higher is more similar
        /// </summary>
        /// <param name="query"></param>
        /// <param name="choices"></param>
        /// <param name="processor"></param>
        /// <param name="scorer"></param>
        /// <param name="cutoff"></param>
        /// <returns></returns>
        public static IEnumerable<ExtractedResult<string>> ExtractAll(
            string              query,
            IEnumerable<string> choices)
        {
            var processor = s_defaultStringProcessor;
            var scorer    = s_defaultScorer;
            var cutoff    = 0;
            return ResultExtractor.ExtractWithoutOrder(query, choices, processor, scorer, cutoff);
        }


        /// <summary>
        /// Creates a list of ExtractedResult which contain all the choices with
        /// their corresponding score where higher is more similar
        /// </summary>
        /// <param name="query"></param>
        /// <param name="choices"></param>
        /// <param name="processor"></param>
        /// <param name="scorer"></param>
        /// <param name="cutoff"></param>
        /// <returns></returns>
        public static IEnumerable<ExtractedResult<T>> ExtractAll<T>(
            T query, 
            IEnumerable<T> choices,
            Func<T, string> processor,
            IRatioScorer scorer,
            int cutoff)
        {
            if (scorer == default(IRatioScorer)) scorer = s_defaultScorer;
            if (cutoff == default(int)) cutoff = 0;
            return ResultExtractor.ExtractWithoutOrder(query, choices, processor, scorer, cutoff);
        }
        #endregion

        #region ExtractTop
        /// <summary>
        /// Creates a sorted list of ExtractedResult  which contain the
        /// top limit most similar choices
        /// </summary>
        /// <param name="query"></param>
        /// <param name="choices"></param>
        /// <param name="processor"></param>
        /// <param name="scorer"></param>
        /// <param name="limit"></param>
        /// <param name="cutoff"></param>
        /// <returns></returns>
        public static IEnumerable<ExtractedResult<string>> ExtractTop(
            string query,
            IEnumerable<string> choices,
            int limit)
        {
            var processor = s_defaultStringProcessor;
            var scorer = s_defaultScorer;
            return ResultExtractor.ExtractTop(query, choices, processor, scorer, limit, 0);
        }

        /// <summary>
        /// Creates a sorted list of ExtractedResult  which contain the
        /// top limit most similar choices
        /// </summary>
        /// <param name="query"></param>
        /// <param name="choices"></param>
        /// <param name="processor"></param>
        /// <param name="scorer"></param>
        /// <param name="limit"></param>
        /// <param name="cutoff"></param>
        /// <returns></returns>
        public static IEnumerable<ExtractedResult<string>> ExtractTop(
            string               query,
            IEnumerable<string>  choices,
            Func<string, string> processor,
            IRatioScorer         scorer,
            int                  limit,
            int                  cutoff)
        {
            if (processor == null) processor = s_defaultStringProcessor;
            if (scorer    == null) scorer    = s_defaultScorer;
            return ResultExtractor.ExtractTop(query, choices, processor, scorer, limit, cutoff);
        }


        /// <summary>
        /// Creates a sorted list of ExtractedResult  which contain the
        /// top limit most similar choices
        /// </summary>
        /// <param name="query"></param>
        /// <param name="choices"></param>
        /// <param name="processor"></param>
        /// <param name="scorer"></param>
        /// <param name="limit"></param>
        /// <param name="cutoff"></param>
        /// <returns></returns>
        public static IEnumerable<ExtractedResult<T>> ExtractTop<T>(
            T query, 
            IEnumerable<T> choices,
            Func<T, string> processor,
            IRatioScorer scorer,
            int limit, 
            int cutoff)
        {
            if (scorer == null) scorer = s_defaultScorer;
            return ResultExtractor.ExtractTop(query, choices, processor, scorer, limit, cutoff);
        }
        #endregion

        #region ExtractSorted
        /// <summary>
        /// Creates a sorted list of ExtractedResult with the closest matches first
        /// </summary>
        /// <param name="query"></param>
        /// <param name="choices"></param>
        /// <param name="processor"></param>
        /// <param name="scorer"></param>
        /// <param name="cutoff"></param>
        /// <returns></returns>
        public static IEnumerable<ExtractedResult<string>> ExtractSorted(
            string query,
            IEnumerable<string> choices,
            Func<string, string> processor,
            IRatioScorer scorer,
            int cutoff)
        {
            if (processor == null) processor = s_defaultStringProcessor;
            if (scorer == null) scorer       = s_defaultScorer;
            return ResultExtractor.ExtractSorted(query, choices, processor, scorer, cutoff);
        }

        /// <summary>
        /// Creates a sorted list of ExtractedResult with the closest matches first
        /// </summary>
        /// <param name="query"></param>
        /// <param name="choices"></param>
        /// <param name="processor"></param>
        /// <param name="scorer"></param>
        /// <param name="cutoff"></param>
        /// <returns></returns>
        public static IEnumerable<ExtractedResult<string>> ExtractSorted(
            string               query,
            IEnumerable<string>  choices)
        {
            var processor = s_defaultStringProcessor;
            var scorer    = s_defaultScorer;
            return ResultExtractor.ExtractSorted(query, choices, processor, scorer, 0);
        }

        /// <summary>
        /// Creates a sorted list of ExtractedResult with the closest matches first
        /// </summary>
        /// <param name="query"></param>
        /// <param name="choices"></param>
        /// <param name="processor"></param>
        /// <param name="scorer"></param>
        /// <param name="cutoff"></param>
        /// <returns></returns>
        public static IEnumerable<ExtractedResult<T>> ExtractSorted<T>(
            T query,
            IEnumerable<T> choices,
            Func<T, string> processor,
            IRatioScorer scorer,
            int cutoff)
        {
            if (scorer == null) scorer = s_defaultScorer;
            return ResultExtractor.ExtractSorted(query, choices, processor, scorer, cutoff);
        }
        #endregion

        #region ExtractOne
        /// <summary>
        /// Find the single best match above a score in a list of choices.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="choices"></param>
        /// <param name="processor"></param>
        /// <param name="scorer"></param>
        /// <param name="cutoff"></param>
        /// <returns></returns>
        public static ExtractedResult<string> ExtractOne(
            string              query,
            IEnumerable<string> choices)
        {
            var processor = s_defaultStringProcessor;
            var scorer    = s_defaultScorer;
            return ResultExtractor.ExtractOne(query, choices, processor, scorer, 0);
        }

        /// <summary>
        /// Find the single best match above a score in a list of choices.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="choices"></param>
        /// <param name="processor"></param>
        /// <param name="scorer"></param>
        /// <param name="cutoff"></param>
        /// <returns></returns>
        public static ExtractedResult<string> ExtractOne(
            string               query,
            IEnumerable<string>  choices,
            int                  cutoff)
        {
            var processor = s_defaultStringProcessor;
            var scorer    = s_defaultScorer;
            return ResultExtractor.ExtractOne(query, choices, processor, scorer, cutoff);
        }

        /// <summary>
        /// Find the single best match above a score in a list of choices.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="choices"></param>
        /// <param name="processor"></param>
        /// <param name="scorer"></param>
        /// <param name="cutoff"></param>
        /// <returns></returns>
        public static ExtractedResult<T> ExtractOne<T>(
            T query,
            IEnumerable<T> choices,
            Func<T, string> processor,
            IRatioScorer scorer,
            int cutoff)
        {
            if (scorer == null) scorer       = s_defaultScorer;
            return ResultExtractor.ExtractOne(query, choices, processor, scorer, cutoff);
        }

        /// <summary>
        /// Find the single best match above a score in a list of choices.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="choices"></param>
        /// <returns></returns>
        public static ExtractedResult<string> ExtractOne(string query, params string[] choices)
        {
            return ResultExtractor.ExtractOne(query, choices, s_defaultStringProcessor, s_defaultScorer, 0);
        }
        #endregion
    }
}
