using System;
using System.Text.RegularExpressions;

namespace FuzzySharp.PreProcess
{
    public class StringPreprocessorFactory
    {
        private static string pattern = "[^ a-zA-Z0-9]";

        public static string Default(string input)
        {
            input = Regex.Replace(input, pattern, " ");
            input = input.ToLower();

            return input.Trim();
        }

        public static Func<string, string> GetPreprocessor(PreprocessMode mode)
        {
            switch (mode)
            {
                case PreprocessMode.Full:
                    return Default;
                case PreprocessMode.None:
                    return s => s;
                default:
                    throw new InvalidOperationException(string.Format("Invalid string preprocessor mode: {0}", mode));
            }
        }
    }
}
