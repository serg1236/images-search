using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchSimilarImages
{
    public class ResultsComparator
    {
        public List<String> SampleResults {set; get;}

        public int CompareWithSample(List<String> results)
        {
            int distance = 0;
            if (SampleResults != null)
            {
                foreach(String sample in SampleResults) {
                    if (results.Contains(sample))
                    {
                        distance += Math.Abs(results.IndexOf(sample) - SampleResults.IndexOf(sample));
                    }
                }
            }
            return distance;
        }
    }
}
