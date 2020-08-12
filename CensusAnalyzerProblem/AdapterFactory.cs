using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProblem
{
    class AdapterFactory
    {
        public Dictionary<string, CensusDTO> getCountryCensusData(Country.CountryName name,string path,string headers)
        {
            if (name.Equals(Country.CountryName.INDIA))
            {
                return new IndiaCensus().getIndiaCensus(path,headers);
            }
            else if (name.Equals(Country.CountryName.US))
            {
                return new USCensus().getUSCensus(path,headers);
            }
            throw new CensusAnalyzerException("Country not found!", CensusAnalyzerException.ExceptionType.NOT_FOUND);

        }
    }
}
