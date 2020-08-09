using System.IO;

namespace CensusAnalyzerProblem
{
    public class CensusAnalyzer
    {
        public delegate int CSVData();
        string path;
        string headers;
        
        public CensusAnalyzer(string path, string headers)
        {
            this.path = path;
            this.headers =headers;
        }
       /* public int loadData()
        {
            int count = 0;
            string[] data = File.ReadAllLines(this.path);
            for (int i = 0; i < data.Length; i++)
            {
                count++;
            }
            return count - 1;
        }*/

    
            public int loadData()
        {
            int count = 0;
           if(!File.Exists(path))
                throw new CensusAnalyzerException("Invalid file ",CensusAnalyzerException.ExceptionType.NOT_FOUND);
            if(Path.GetExtension(path)!=".csv")
                throw new CensusAnalyzerException("Invalid file type ",CensusAnalyzerException.ExceptionType.INVALID_TYPE);
            
            string[] data = File.ReadAllLines(path);
            
            if(data[0]!= headers)
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
       /* public int getStateCount(string path)
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
        }*/
    }
}