using NUnit.Framework;
using CensusAnalyzerProblem;
using static CensusAnalyzerProblem.CensusAnalyzer;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using System.Linq;
namespace CensusAnalyzerTest
{
    public class Tests
    {
        string censusFilePath = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CSVFiles\IndiaStateCensusData.csv";
        string censusWrongPath = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CSVFiles\IndiaCensusDataa.csv";
        string censusWrongType = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CSVFiles\IndiaStateCensusData.txt";
        string stateCodeFilePath = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CSVFiles\IndiaStateCode.csv";
        string wrongstateCodeFilePath = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CSVFiles\IndiaStateCode.txt";
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string wrongStateCodeHeader = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CSVFiles\WrongDelimiter.csv";
        static string wrongStateCodeDelimiter = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CSVFiles\WrongStateCodeHeader.csv";
        static string wrongCensusHeader = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CSVFiles\WrongCensusHeader.csv";
        static string wrongCensusDelimiter = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CSVFiles\WrongCensusDelimiter.csv";
        static string newFile = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CSVFiles\newFile.csv";

        List<string> list = new List<string>();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {

            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusFilePath, indianStateCensusHeaders);
            CSVData count = new CSVData(census.loadData);
            list = (List<string>)count();
            Assert.AreEqual(29, list.Count);
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
            // int c = (int)count();
            list = (List<string>)count();
            Assert.AreEqual(37, list.Count);
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
            string sorted = censusAnalyzer.sortingCSVData(censusFilePath, newFile).ToString();
            string[] d = JsonConvert.DeserializeObject<string[]>(sorted);
            Assert.AreEqual("Andhra Pradesh,49386799,162968,303", d[0]);
        }
    }
}
