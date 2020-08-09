using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProblem
{
   public class CSVBuilderFactory
    {
        public ICSVBuilder CreateObject(string ClassName,string path,string headers)
        {
            if (ClassName== "CensusAnalyzer")
            {
                return new CensusAnalyzer(path,headers);
            }
            return null;
        }

    }
 
}