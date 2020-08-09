using System;

namespace CensusAnalyzerProblem
{
    public class CensusAnalyzerException:Exception
    {
         public string exceptionMessage;
        public enum ExceptionType
        {
            NOT_FOUND,INVALID_HEADER,INVALID_DELIMITER,INVALID_TYPE
        }
        public ExceptionType type;
        public CensusAnalyzerException(string exceptionMessage,ExceptionType type) : base(String.Format(exceptionMessage))
        {
            this.exceptionMessage = exceptionMessage;
            this.type = type;
        }
    }
}
