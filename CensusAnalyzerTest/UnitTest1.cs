using NUnit.Framework;
using CensusAnalyzerProblem;
using static CensusAnalyzerProblem.CensusAnalyzer;
using System.Collections.Generic;
using System.Linq;
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
        List<string> list = new List<string>();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void givenCensusFile_shouldReturnCorrectNumberOfRecords()
        {

            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer counte =(CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusFilePath, indianStateCensusHeaders);
            CSVData count = new CSVData(counte.loadData);
            //  int c = (int)count();

          //  string[] c = (string[])count();
            list = (List<string>)count();
            Assert.AreEqual(29, list.Count);
        }

        [Test]
        public void givenWrongFilePath_ShouldThrowCustomException()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusWrongPath, indianStateCensusHeaders);
            CSVData count = new CSVData(counte.loadData);
            var countt = Assert.Throws<CensusAnalyzerException>(() => count());
            System.Console.WriteLine(countt.type);
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.NOT_FOUND, countt.type);
        }

        [Test]
        public void givenWrongFileType_ShouldThrowCustomException()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusWrongType, indianStateCensusHeaders);
            CSVData count = new CSVData(counte.loadData);
            var countt = Assert.Throws<CensusAnalyzerException>(() =>count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_TYPE, countt.type);

        }
        [Test]
        public void givenWrongFileDelimiter_ShouldThrowCustomException()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", wrongCensusDelimiter, indianStateCensusHeaders);
            CSVData count = new CSVData(counte.loadData);
            var countt = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, countt.type);
        }

        [Test]
        public void givenWrongFileHeader_ShouldThrowCustomException()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", wrongCensusHeader, indianStateCensusHeaders);
            CSVData count = new CSVData(counte.loadData);
            var countt = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, countt.type);
        }

        [Test]
        public void givenIndiaStateCode_ShouldReturnNumberOfResult()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", stateCodeFilePath, indianStateCodeHeaders);
            CSVData count = new CSVData(counte.loadData);
           // int c = (int)count();
            list = (List<string>)count();
            Assert.AreEqual(37, list.Count);
        }
        [Test]
        public void givenWrongStatecodeFilePath_ShouldThrowCustomException()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusWrongPath, indianStateCodeHeaders);
            CSVData count = new CSVData(counte.loadData);
            var countt = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.NOT_FOUND, countt.type);
        }

        [Test]
        public void givenWrongStatecodeFileType_ShouldThrowCustomException()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", wrongstateCodeFilePath, indianStateCodeHeaders);
            CSVData count = new CSVData(counte.loadData);
            var countt = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_TYPE, countt.type);
        }

        [Test]
        public void givenWrongStateCodeFileDelimiter_ShouldThrowCustomException()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", wrongStateCodeDelimiter, indianStateCodeHeaders);
            CSVData count = new CSVData(counte.loadData);
            var countt = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, countt.type);
        }

        [Test]
        public void givenWrongStatecodeFileHeader_ShouldThrowCustomException()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", wrongStateCodeHeader, indianStateCodeHeaders);
            CSVData count = new CSVData(counte.loadData);
            var countt = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, countt.type);
        }
    }
}