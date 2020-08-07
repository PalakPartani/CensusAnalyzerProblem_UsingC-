using System.IO;

namespace CensusAnalyzerProblem
{
    public class CensusAnalyzer
    {
        public int getCount(string path)
        {
            int count = 0;

            if (!path.Contains("IndiaStateCensusData"))
                throw new CensusAnalyzerException("Invalid file ");
            if(!path.Equals("IndiaStateCensusData.csv"))
                throw new CensusAnalyzerException("Invalid file type ");
            string[] n = File.ReadAllLines(path);
                for (int i = 0; i < n.Length; i++)
                {
                    count++;
                }
                return count - 1;
            }
        }
    }
