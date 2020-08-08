using NUnit.Framework;
using CensusAnalyzerProblem;
namespace CensusAnalyzerTest
{
    public class Tests
    {
        string censusFilePath = @"C:\Users\Palak Rubi\Desktop\IndiaStateCensusData.csv";
        string censusWrongPath = @"C:\Users\Palak Rubi\Desktop\IndiaCensusDataa.csv";
        string censusWrongType = @"C:\Users\Palak Rubi\Desktop\IndiaStateCensusData.java";
        string stateCodeFilePath = @"C:\Users\Palak Rubi\Desktop\IndiaStateCode.csv";
        [SetUp]
        public void Setup()
        {

        }


        [Test]
        public void Test1()
        {
          
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
            int count = censusAnalyzer.getCount(censusFilePath);
            Assert.AreEqual(count, 29);
        }

        [Test]
        public void givenWrongFilePath_ShouldThrowCustomException()
        {
           
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
            try
            {
                int count = censusAnalyzer.getCount(censusWrongPath);
            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual("Invalid file ", e.exceptionMessage);
            }
        }
        [Test]
        public void givenWrongFileType_ShouldThrowCustomException()
        {
          
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
            try
            {
                int count = censusAnalyzer.getCount(censusWrongType);
            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual("Invalid file type ", e.exceptionMessage);
            }
        }
        [Test]
        public void givenWrongFileDelimiter_ShouldThrowCustomException()
        {
           
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
            try
            {
                int count = censusAnalyzer.getCount(censusFilePath);
            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual("Invalid file delimiter ", e.exceptionMessage);
            }
        }
        [Test]
        public void givenWrongFileHeader_ShouldThrowCustomException()
        {
         
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
            try
            {
                int count = censusAnalyzer.getCount(censusFilePath);
            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual("Invalid file Header ", e.exceptionMessage);
            }
        }
        [Test]
        public void givenIndiaStateCode_ShouldReturnNumberOfResult()
        {

            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
           
                int count = censusAnalyzer.getStateCount(stateCodeFilePath);
                Assert.AreEqual(37, count);
          
        }

    }
}
