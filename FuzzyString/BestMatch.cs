using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyString
{
    public static partial class ComparisonMetrics
    { 
        public static string GetBestMatch(this string source, List<string> targets, params FuzzyStringComparisonOptions[] options)
        {
            if (targets == null || targets.Count == 0 ) {
                return string.Empty;
            }
            
            string bestMatch = string.Empty;
            double highestScore = 0.0;

            foreach (string target in targets) {
                double score = source.MatchingScore(target, options);
                if (score > highestScore) {
                    bestMatch = target;
                    highestScore = score;
                }
            }

            return bestMatch;       
        }
    }
}
