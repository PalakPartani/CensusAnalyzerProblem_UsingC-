using NUnit.Framework;
using CensusAnalyzerProblem;
namespace CensusAnalyzerTest
{
    public class Tests
    {
        string censusFilePath = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\IndiaStateCensusData.csv";
        string censusWrongPath = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\IndiaCensusDataa.csv";
        string censusWrongType = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\IndiaStateCensusData.txt";
        string stateCodeFilePath = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\IndiaStateCode.csv";
        string wrongstateCodeFilePath = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\IndiaStateCode.txt";
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void givenCensusFile_shouldReturnCorrectNumberOfRecords()
        {
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
            int count = censusAnalyzer.loadData(censusFilePath,indianStateCensusHeaders);
            Assert.AreEqual(count, 29);
        }

        [Test]
        public void givenWrongFilePath_ShouldThrowCustomException()
        {
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
            try
            {
                int count = censusAnalyzer.loadData(censusWrongPath, indianStateCensusHeaders);
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
                int count = censusAnalyzer.loadData(censusWrongType, indianStateCensusHeaders);
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
                int count = censusAnalyzer.loadData(censusFilePath, indianStateCensusHeaders);
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
                int count = censusAnalyzer.loadData(censusFilePath, indianStateCensusHeaders);
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
            int count = censusAnalyzer.loadData(stateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, count);
        }
        [Test]
        public void givenWrongStatecodeFilePath_ShouldThrowCustomException()
        {
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
            try
            {
                int count = censusAnalyzer.loadData(censusWrongPath, indianStateCodeHeaders);
            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual("Invalid file ", e.exceptionMessage);
            }
        }
        [Test]
        public void givenWrongStatecodeFileType_ShouldThrowCustomException()
        {
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
            try
            {
                int count = censusAnalyzer.loadData(wrongstateCodeFilePath, indianStateCodeHeaders);
            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual("Invalid file type ", e.exceptionMessage);
            }
        }
        [Test]
        public void givenWrongStateCodeFileDelimiter_ShouldThrowCustomException()
        {
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
            try
            {
                int count = censusAnalyzer.loadData(stateCodeFilePath, indianStateCodeHeaders);
            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual("Invalid file delimiter ", e.exceptionMessage);
            }
        }
        [Test]
        public void givenWrongStatecodeFileHeader_ShouldThrowCustomException()
        {
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
            try
            {
                int count = censusAnalyzer.loadData(stateCodeFilePath, indianStateCodeHeaders);
            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual("Invalid file Header ", e.exceptionMessage);
            }
        }
    }
}