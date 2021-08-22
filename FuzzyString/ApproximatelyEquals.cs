using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyString
{
    public static partial class ComparisonMetrics
    { 
        public static bool ApproximatelyEquals(this string source, string target,  FuzzyStringComparisonTolerance tolerance, params FuzzyStringComparisonOptions[] options)
        {
            double score = source.MatchingScore(target, options);

            if (score == 0)
            {
                return false;
            }

            switch (tolerance)
            {
                case FuzzyStringComparisonTolerance.Strong:
                    return score < 0.25;
                case FuzzyStringComparisonTolerance.Normal:
                    return score < 0.5;
                case FuzzyStringComparisonTolerance.Weak:
                    return score < 0.75;
                case FuzzyStringComparisonTolerance.Manual:
                    return score > 0.6;
                default:
                    return false;
            }
        }
    }
}