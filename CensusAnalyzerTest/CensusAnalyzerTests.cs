using NUnit.Framework;
using CensusAnalyzerProblem;
using static CensusAnalyzerProblem.CensusAnalyzer;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace CensusAnalyzerTest
{
    public class Tests
    {
        string censusFilePath = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CensusAnalyzerTest\CSVFiles\IndiaStateCensusData.csv";
        string censusWrongPath = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CensusAnalyzerTest\CSVFiles\IndiaCensusDataa.csv";
        string censusWrongType = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CensusAnalyzerTest\CSVFiles\IndiaStateCensusData.txt";
        string stateCodeFilePath = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CensusAnalyzerTest\CSVFiles\IndiaStateCode.csv";
        string wrongstateCodeFilePath = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CensusAnalyzerTest\CSVFiles\IndiaStateCode.txt";
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string wrongStateCodeHeader = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CensusAnalyzerTest\CSVFiles\WrongDelimiter.csv";
        static string wrongStateCodeDelimiter = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CensusAnalyzerTest\CSVFiles\WrongStateCodeHeader.csv";
        static string wrongCensusHeader = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CensusAnalyzerTest\CSVFiles\WrongCensusHeader.csv";
        static string wrongCensusDelimiter = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CensusAnalyzerTest\CSVFiles\WrongCensusDelimiter.csv";
        static string newFile = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CensusAnalyzerTest\CSVFiles\newFile.csv";
      
        Dictionary<int, string> data = new Dictionary<int, string>();
        Dictionary<int, string> stateData = new Dictionary<int, string>();
        CSVBuilderFactory cSVBuilderFactory;

        [SetUp]
        public void Setup()
        {
            cSVBuilderFactory = new CSVBuilderFactory();
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusFilePath, indianStateCensusHeaders);
            CSVData count = new CSVData(census.loadData);
            data = (Dictionary<int, string>)count();
            Assert.AreEqual(29, data.Count);
            CensusAnalyzer census1 = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", stateCodeFilePath, indianStateCodeHeaders);
            CSVData count1 = new CSVData(census1.loadData);
            stateData = (Dictionary<int, string>)count1();
            Assert.AreEqual(37, stateData.Count);
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileNotExist_ShouldThrowException()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusWrongPath, indianStateCensusHeaders);
            CSVData count = new CSVData(census.loadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            System.Console.WriteLine(error.type);
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.NOT_FOUND, error.type);
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileTypeIsIncorrect_ShouldThrowException()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusWrongType, indianStateCensusHeaders);
            CSVData count = new CSVData(census.loadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_TYPE, error.type);

        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowException()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", wrongCensusDelimiter, indianStateCensusHeaders);
            CSVData count = new CSVData(census.loadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, error.type);
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowException()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", wrongCensusHeader, indianStateCensusHeaders);
            CSVData count = new CSVData(census.loadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, error.type);
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", stateCodeFilePath, indianStateCodeHeaders);
            CSVData count = new CSVData(census.loadData);
            data = (Dictionary<int, string>)count();
            Assert.AreEqual(37, data.Count);
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusWrongPath, indianStateCodeHeaders);
            CSVData count = new CSVData(census.loadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.NOT_FOUND, error.type);
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileTypeIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", wrongstateCodeFilePath, indianStateCodeHeaders);
            CSVData count = new CSVData(census.loadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_TYPE, error.type);
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", wrongStateCodeDelimiter, indianStateCodeHeaders);
            CSVData count = new CSVData(census.loadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, error.type);
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", wrongStateCodeHeader, indianStateCodeHeaders);
            CSVData count = new CSVData(census.loadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, error.type);
        }

        [Test]
        public void givenCSVDatatoSort_ShouldReturnSortedDataInJsonFormat()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusFilePath, indianStateCensusHeaders);
            // CSVData count = new CSVData(counte.sortingCSVData);
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer(censusFilePath, indianStateCensusHeaders);
            string sorted = censusAnalyzer.sortingCSVData(censusFilePath, newFile,0).ToString();
            string[] d = JsonConvert.DeserializeObject<string[]>(sorted);
            Assert.AreEqual("Andhra Pradesh,49386799,162968,303", d[0]);
        }
        [Test]
        public void givenCSVDatatoSort_ShouldReturnLastSortedDataInJsonFormat()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusFilePath, indianStateCensusHeaders);
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer(censusFilePath, indianStateCensusHeaders);
            string sorted = censusAnalyzer.sortingCSVData(censusFilePath, newFile, 0).ToString();
            string[] d = JsonConvert.DeserializeObject<string[]>(sorted);
            Assert.AreEqual("Uttarakhand,10116752,53483,189", d[27]);
        }

        [Test]
        public void givenCSVDatatoSortByStateCode_ShouldReturnSortedDataInJsonFormat()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusFilePath, indianStateCensusHeaders);
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer(censusFilePath, indianStateCensusHeaders);
            string sorted = censusAnalyzer.sortingCSVData(stateCodeFilePath, newFile,3).ToString();
            string[] d = JsonConvert.DeserializeObject<string[]>(sorted);
            Assert.AreEqual("3,Andhra Pradesh New,37,AD", d[0]);
        }
        [Test]
        public void givenCSVDatatoSortByStateCode_ShouldReturnLastSortedDataInJsonFormat()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusFilePath, indianStateCensusHeaders);
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer(censusFilePath, indianStateCensusHeaders);
            string sorted = censusAnalyzer.sortingCSVData(stateCodeFilePath, newFile, 3).ToString();
            string[] d = JsonConvert.DeserializeObject<string[]>(sorted);
            Assert.AreEqual("37,West Bengal,19,WB", d[36]);
        }
    }
}