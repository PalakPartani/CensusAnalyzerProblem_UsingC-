using System;
using System.Collections.Generic;
using System.Linq;

namespace CensusAnalyzerProblem
{
    public class IndiaCensus : Adapter
    {
        string[] censusData;
        Dictionary<string, CensusDTO> censusDictionary;
        public Dictionary<string, CensusDTO> getIndiaCensus(string path,string headers)
        {
            censusDictionary = new Dictionary<string, CensusDTO>();
            censusData = LoadData(path,headers);
            foreach (string data in censusData.Skip(1))
            {
                if (!data.Contains(","))
                {
                    throw new CensusAnalyzerException("Invalid delimiter", CensusAnalyzerException.ExceptionType.INVALID_DELIMITER);
                }
                string[] column = data.Split(",");
                if (path.Contains("IndiaStateCode.csv"))
                    censusDictionary.Add(column[1], new CensusDTO(new StateCodeDao(column[0], column[1], column[2], column[3])));
                if (path.Contains("IndiaStateCensusData.csv"))
                    censusDictionary.Add(column[0], new CensusDTO(new IndiaCensusDAO(column[0], column[1], column[2], column[3])));
            }
            return censusDictionary.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}

