using System.IO;

namespace CensusAnalyzerProblem
{
    public class CensusAnalyzer
    {
        public int getCount(string path)
        {
            int count = 0;
            if (!path.Contains("IndiaStateCensusData"))
                throw new CensusAnalyzerException("Invalid file ",CensusAnalyzerException.ExceptionType.NOT_FOUND);
            if(!path.Contains("csv"))
                throw new CensusAnalyzerException("Invalid file type ",CensusAnalyzerException.ExceptionType.INVALID_TYPE);
            
            string[] data = File.ReadAllLines(path);
            
            if(data[0]!= "State,Population,AreaInSqKm,DensityPerSqKm")
                throw new CensusAnalyzerException("Invalid file header ", CensusAnalyzerException.ExceptionType.INVALID_HEADER);
            foreach (string d in data)
            {
                if (!d.Contains(','))
                    throw new CensusAnalyzerException("Invalid file delimiter ", CensusAnalyzerException.ExceptionType.INVALID_DELIMITER);
            }
            
            for (int i = 0; i < data.Length; i++)
                {
                    count++;
                }
                return count - 1;
            }
        public int getStateCount(string path)
        {
            int count = 0;
            if (!path.Contains("IndiaStateCode"))
                throw new CensusAnalyzerException("Invalid file ", CensusAnalyzerException.ExceptionType.NOT_FOUND);
            if (!path.Contains("csv"))
                throw new CensusAnalyzerException("Invalid file type ", CensusAnalyzerException.ExceptionType.INVALID_TYPE);

            string[] data = File.ReadAllLines(path);

            if (data[0] != "SrNo,State Name,TIN,StateCode")
                throw new CensusAnalyzerException("Invalid file header ", CensusAnalyzerException.ExceptionType.INVALID_HEADER);
            foreach (string d in data)
            {
                if (!d.Contains(','))
                    throw new CensusAnalyzerException("Invalid file delimiter ",CensusAnalyzerException.ExceptionType.INVALID_DELIMITER);
            }

            for (int i = 0; i < data.Length; i++)
            {
                count++;
            }
            return count - 1;
        }
    }
}