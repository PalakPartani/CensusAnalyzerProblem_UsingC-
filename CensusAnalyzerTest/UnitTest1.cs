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
        static string wrongStateCodeHeader = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\WrongDelimiter.csv";
        static string wrongStateCodeDelimiter = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\WrongStateCodeHeader.csv";
        static string wrongCensusHeader = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\WrongCensusHeader.csv";
        static string wrongCensusDelimiter = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\WrongCensusDelimiter.csv";

        CensusAnalyzer censusAnalyzer;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void givenCensusFile_shouldReturnCorrectNumberOfRecords()
        {
            censusAnalyzer = new CensusAnalyzer(censusFilePath, indianStateCensusHeaders);
            int count = censusAnalyzer.loadData();
            Assert.AreEqual(count, 29);
        }

        [Test]
        public void givenWrongFilePath_ShouldThrowCustomException()
        {
            censusAnalyzer = new CensusAnalyzer(censusWrongPath, indianStateCensusHeaders);

            var count = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.loadData());

            Assert.AreEqual(CensusAnalyzerException.ExceptionType.NOT_FOUND, count.type);
        }

        [Test]
        public void givenWrongFileType_ShouldThrowCustomException()
        {
            censusAnalyzer = new CensusAnalyzer(censusWrongType, indianStateCensusHeaders);

            var count = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.loadData());

            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_TYPE, count.type);

        }
        [Test]
        public void givenWrongFileDelimiter_ShouldThrowCustomException()
        {
            censusAnalyzer = new CensusAnalyzer(wrongCensusDelimiter, indianStateCensusHeaders);

            var count = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.loadData());

            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, count.type);
        }

        [Test]
        public void givenWrongFileHeader_ShouldThrowCustomException()
        {
            censusAnalyzer = new CensusAnalyzer(wrongCensusHeader, indianStateCensusHeaders);

            var count = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.loadData());

            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, count.type);
        }

        [Test]
        public void givenIndiaStateCode_ShouldReturnNumberOfResult()
        {
            censusAnalyzer = new CensusAnalyzer(stateCodeFilePath, indianStateCodeHeaders);
            int count = censusAnalyzer.loadData();
            Assert.AreEqual(37, count);
        }
        [Test]
        public void givenWrongStatecodeFilePath_ShouldThrowCustomException()
        {
            censusAnalyzer = new CensusAnalyzer(censusWrongPath, indianStateCodeHeaders);

            var count = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.loadData());


            Assert.AreEqual(CensusAnalyzerException.ExceptionType.NOT_FOUND, count.type);
        }

        [Test]
        public void givenWrongStatecodeFileType_ShouldThrowCustomException()
        {
            censusAnalyzer = new CensusAnalyzer(wrongstateCodeFilePath, indianStateCodeHeaders);

            var count = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.loadData());

            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_TYPE, count.type);
        }

        [Test]
        public void givenWrongStateCodeFileDelimiter_ShouldThrowCustomException()
        {
            censusAnalyzer = new CensusAnalyzer(wrongStateCodeDelimiter, indianStateCodeHeaders);

            var count = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.loadData());

            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, count.type);
        }

        [Test]
        public void givenWrongStatecodeFileHeader_ShouldThrowCustomException()
        {
            censusAnalyzer = new CensusAnalyzer(wrongStateCodeHeader, indianStateCodeHeaders);
            var count = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.loadData());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, count.type);
        }
    }
}


