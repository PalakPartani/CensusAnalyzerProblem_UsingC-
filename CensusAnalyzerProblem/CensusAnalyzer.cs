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
            if(!path.Contains("csv"))
                throw new CensusAnalyzerException("Invalid file type ");
            
            string[] n = File.ReadAllLines(path);
            if(n[0]!= "State,Population,AreaInSqKm,DensityPerSqKm")
                throw new CensusAnalyzerException("Invalid file header ");
            foreach (string d in n)
            {
                if (!d.Contains(','))
                    throw new CensusAnalyzerException("Invalid file delimiter ");
            }
            
            for (int i = 0; i < n.Length; i++)
                {
                    count++;
                }
                return count - 1;
            }
        public int getStateCount(string path)
        {
            int count = 0;
            string[] n = File.ReadAllLines(path);
            for (int i = 0; i < n.Length; i++)
            {
                count++;
            }
            return count - 1;
        }

    }
    }
 
