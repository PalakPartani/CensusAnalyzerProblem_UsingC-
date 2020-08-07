using System;

namespace CensusAnalyzerProblem
{
    public class CensusAnalyzerException:Exception
    {
         public string exceptionMessage;
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
