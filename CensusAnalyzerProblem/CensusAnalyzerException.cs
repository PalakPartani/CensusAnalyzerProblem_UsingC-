using System;

namespace CensusAnalyzerProblem
{
    public class CensusAnalyzerException:Exception
    {
         public string exceptionMessage;
        public CensusAnalyzerException(string exceptionMessage) : base(String.Format(exceptionMessage))
        {
            this.exceptionMessage = exceptionMessage;
        }


        /*public override string Message
        {
            get
            {
                return this.exceptionMessage;
            }
        }*/
    }
}
