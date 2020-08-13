// <copyright file="CensusAnalyzer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CensusAnalyzerProblem
{
   using System.Collections.Generic;
   using System.Linq; 
   using Newtonsoft.Json;

public class CensusAnalyzer
    {
        /// <summary>
        /// Census Analyzer Problem
        /// </summary>
       
        private delegate object CSVData();
        private string path;
        private string headers;
        Dictionary<string, CensusDTO> censusDictionary;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="headers"></param>
        public CensusAnalyzer(string path, string headers)
        {
            this.path = path;
            this.headers = headers;
        }

        public Dictionary<string, CensusDTO> LoadCensusData(Country.CountryName country)
        {
            censusDictionary = new AdapterFactory().GetCountryCensusData(country, path, headers);
            return censusDictionary;
        }

        public string SortingCSVData(Dictionary<string, CensusDTO> data, string type)
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
                case "USPopulationDensity": return lines.OrderByDescending(x => x.populationDensity).ToList();
                case "area": return lines.OrderByDescending(x => x.area).ToList();
                case "USArea": return lines.OrderByDescending(x => x.totalArea).ToList();

                default: return lines;
            }
        }
        public string getBothSorted(USCensusDao uSCensus, IndiaCensusDAO indiaCensus)
        {
            string sortedState = (uSCensus.populationDensity > indiaCensus.density) ? uSCensus.stateName : indiaCensus.state;
            return sortedState;
        }
    }
}