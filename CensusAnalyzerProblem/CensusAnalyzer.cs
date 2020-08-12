using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace CensusAnalyzerProblem
{
    public class CensusAnalyzer 
    {
        public delegate object CSVData();
        public string path;
        public string headers;
        Dictionary<string, CensusDTO> censusDictionary;

        public CensusAnalyzer(string path, string headers)
        {
            this.path = path;
            this.headers = headers;
        }

        public Dictionary<string, CensusDTO> LoadCensusData(Country.CountryName country)
        {
            censusDictionary = new AdapterFactory().getCountryCensusData(country, path, headers);
            return censusDictionary;
        }

        public string SortingCSVData(Dictionary<string,CensusDTO> data, string type)
        {
            var censusData = data;
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
                case "population": return lines.OrderByDescending(x => x.population).ToList();
                case "populationDensity": return lines.OrderByDescending(x => x.density).ToList();
                case "uspopulationDensity": return lines.OrderByDescending(x => x.populationDensity).ToList();
                case "area": return lines.OrderByDescending(x => x.area).ToList();
                case "USarea":return lines.OrderByDescending(x => x.totalArea).ToList();

                default: return lines;
            }
        }
    }
}
       