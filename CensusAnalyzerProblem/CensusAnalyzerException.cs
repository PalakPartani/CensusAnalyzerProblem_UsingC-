using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProblem
{
    public class CensusAnalyzerException:Exception
    {
        string exceptionMessage;
        public CensusAnalyzerException(string exceptionMessage)
        {
            this.exceptionMessage = exceptionMessage;
        }

        public override string Message
        {
            get
            {
                return this.exceptionMessage;
            }
        }
    }
}
