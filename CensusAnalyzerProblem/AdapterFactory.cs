namespace CensusAnalyzerProblem
{
    using System.Collections.Generic;

    class AdapterFactory
    {
        public Dictionary<string, CensusDTO> GetCountryCensusData(Country.CountryName name, string path, string headers)
        {
            if (name.Equals(Country.CountryName.INDIA))
            {
                return new IndiaCensus().getIndiaCensus(path, headers);
            }
            else if (name.Equals(Country.CountryName.US))
            {
                return new USCensus().getUSCensus(path, headers);
            }

            throw new CensusAnalyzerException("Country not found!", CensusAnalyzerException.ExceptionType.NOT_FOUND);
        }
    }
}
