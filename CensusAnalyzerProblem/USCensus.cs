using System.Collections.Generic;
using System.Linq;
namespace CensusAnalyzerProblem
{
    public class USCensus : Adapter
    {
        string[] censusData;
        Dictionary<string, CensusDTO> censusDictionary;

        public Dictionary<string, CensusDTO> getUSCensus(string path,string headers)
        {
            censusDictionary = new Dictionary<string, CensusDTO>();
            censusData = LoadData(path, headers);

            foreach (string data in censusData.Skip(1))
            {
                if (!data.Contains(","))
                    throw new CensusAnalyzerException("Invalid file delimiter ", CensusAnalyzerException.ExceptionType.INVALID_DELIMITER);
                string[] column = data.Split(",");
                if (path.Contains("USCensusData.csv"))
                    censusDictionary.Add(column[0], new CensusDTO(new USCensusDao(column[0], column[1], column[2], column[3], column[4], column[5], column[6], column[7], column[8])));
            }

            return censusDictionary.ToDictionary(k => k.Key, k => k.Value);
        }
    }
}