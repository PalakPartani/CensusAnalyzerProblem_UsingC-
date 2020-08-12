
using System.IO;

namespace CensusAnalyzerProblem
{
    public abstract class Adapter
    {
        public string[] LoadData(string path,string headers)
        {
            string[] censusData;
            if (!File.Exists(path))
            {
                throw new CensusAnalyzerException("File Not Found", CensusAnalyzerException.ExceptionType.NOT_FOUND);
            }
            if (Path.GetExtension(path) != ".csv")
            {
                throw new CensusAnalyzerException("Invalid File Type", CensusAnalyzerException.ExceptionType.INVALID_TYPE);
            }
            censusData = File.ReadAllLines(path);
            if (censusData[0] != headers)
            {
                throw new CensusAnalyzerException("Incorrect header", CensusAnalyzerException.ExceptionType.INVALID_HEADER);
            }
            return censusData;
        }
    }
}

