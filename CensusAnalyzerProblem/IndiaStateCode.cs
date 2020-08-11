using CsvHelper.Configuration.Attributes;
namespace CensusAnalyzerProblem
{
   public class IndiaStateCode
    {
        [Name("SrNo")]
        public int srNo { get; set; }

        [Name("State Name")]
        public string state { get; set; }

        [Name("TIN")]
        public int TIN { get; set; }

        [Name("StateCode")]
        public string stateCode { get; set; }
    }
}