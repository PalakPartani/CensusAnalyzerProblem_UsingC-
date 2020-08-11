using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace CensusAnalyzerProblem
{
    public class CensusAnalyzer : ICSVBuilder
    {
        public delegate object CSVData();
        public string path;
        public string headers;
        int counter = 0;
        Dictionary<string, CensusDTO> censusDictionary;

        public CensusAnalyzer(string path, string headers)
        {
            this.path = path;
            this.headers = headers;

        }

        public object LoadData()
        {
            censusDictionary = new Dictionary<string, CensusDTO>();

            if (!File.Exists(path))
                throw new CensusAnalyzerException("Invalid file ", CensusAnalyzerException.ExceptionType.NOT_FOUND);
            if (Path.GetExtension(path) != ".csv")
                throw new CensusAnalyzerException("Invalid file type ", CensusAnalyzerException.ExceptionType.INVALID_TYPE);
            string[] data = File.ReadAllLines(path);
            List<string> list = data.ToList();
            if (data[0] != headers)
                throw new CensusAnalyzerException("Invalid file header ", CensusAnalyzerException.ExceptionType.INVALID_HEADER);

            foreach (string d in list.Skip(1))
            {
                if (!d.Contains(','))
                    throw new CensusAnalyzerException("Invalid file delimiter ", CensusAnalyzerException.ExceptionType.INVALID_DELIMITER);
                
                string[] column = d.Split(",");

                if (path.Contains("IndiaStateCode.csv"))
                    censusDictionary.Add(column[1], new CensusDTO(new StateCodeDao(column[0], column[1], column[2], column[3])));
                if (path.Contains("IndiaStateCensusData.csv"))
                    censusDictionary.Add(column[0], new CensusDTO(new IndiaCensusDAO(column[0], column[1], column[2], column[3])));
            }
            return censusDictionary.ToDictionary(k => k.Key, k => k.Value);
        }

        public string SortingCSVData(Dictionary<string,CensusDTO> path, string type)
        {
          
            var censusData = path;
            List<CensusDTO> lines = censusData.Values.ToList();
            List<CensusDTO> lists = getField(type, lines);
            return JsonConvert.SerializeObject(lists);
        }

        public List<CensusDTO> getField(string sortfield, List<CensusDTO> lines)
        {
            switch (sortfield)
            {
                case "stateName": return lines.OrderBy(x => x.stateName).ToList();
                case "stateCode": return lines.OrderBy(x => x.stateCode).ToList();
                case "state": return lines.OrderBy(x => x.state).ToList();
                default: return lines;
            }
        }
    }
}
       