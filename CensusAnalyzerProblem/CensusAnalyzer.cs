using System.IO;

using System.Collections.Generic;

namespace CensusAnalyzerProblem
{
    public class CensusAnalyzer
    {
        public int getCount(string path)
        {
            int count = 0;
            try
            {
                string[] n = File.ReadAllLines(path);
                // IEnumerable<string> e = n;
                for (int i = 0; i < n.Length; i++)
                {
                    count++;
                }
                return count - 1;
            }
            catch(CensusAnalyzerException e)
            {
                throw new CensusAnalyzerException("Invalid file");
            }
        }
    }
}
