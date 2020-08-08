using NUnit.Framework;
using CensusAnalyzerProblem;
namespace CensusAnalyzerTest
{
    public class Tests
    {
        string censusFilePath = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\IndiaStateCensusData.csv";
        string censusWrongPath = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\IndiaCensusDataa.csv";
        string censusWrongType = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\IndiaStateCensusData.java";
        string stateCodeFilePath = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\IndiaStateCode.csv";
        string wrongstateCodeFilePath = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\IndiaStateCode.jpg";
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void givenCensusFile_shouldReturnCorrectNumberOfRecords()
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
        [Test]
        public void givenWrongStatecodeFilePath_ShouldThrowCustomException()
        {
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
            try
            {
                int count = censusAnalyzer.getStateCount(censusWrongPath);
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
                int count = censusAnalyzer.getStateCount(wrongstateCodeFilePath);
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
                int count = censusAnalyzer.getStateCount(stateCodeFilePath);
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
                int count = censusAnalyzer.getStateCount(stateCodeFilePath);
            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual("Invalid file Header ", e.exceptionMessage);
            }
        }
    }
}