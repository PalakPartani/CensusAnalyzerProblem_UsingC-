using NUnit.Framework;
using CensusAnalyzerProblem;
using static CensusAnalyzerProblem.CensusAnalyzer;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace CensusAnalyzerTest
{
    public class CensusAnalyzerTests
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

        Dictionary<string, CensusDTO> censusData = new Dictionary<string , CensusDTO>();
        Dictionary<string, CensusDTO> stateData = new Dictionary<string, CensusDTO>();
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
            CSVData count = new CSVData(census.LoadData);
            censusData = (Dictionary<string, CensusDTO>)count();
            Assert.AreEqual(29, censusData.Count);
            CensusAnalyzer census1 = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", stateCodeFilePath, indianStateCodeHeaders);
            CSVData count1 = new CSVData(census1.LoadData);
            stateData = (Dictionary<string, CensusDTO>)count1();
            Assert.AreEqual(37, stateData.Count);
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileNotExist_ShouldThrowException()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusWrongPath, indianStateCensusHeaders);
            CSVData count = new CSVData(census.LoadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            System.Console.WriteLine(error.type);
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.NOT_FOUND, error.type);
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileTypeIsIncorrect_ShouldThrowException()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusWrongType, indianStateCensusHeaders);
            CSVData count = new CSVData(census.LoadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_TYPE, error.type);

        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowException()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", wrongCensusDelimiter, indianStateCensusHeaders);
            CSVData count = new CSVData(census.LoadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, error.type);
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowException()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", wrongCensusHeader, indianStateCensusHeaders);
            CSVData count = new CSVData(census.LoadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, error.type);
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusWrongPath, indianStateCodeHeaders);
            CSVData count = new CSVData(census.LoadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.NOT_FOUND, error.type);
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileTypeIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", wrongstateCodeFilePath, indianStateCodeHeaders);
            CSVData count = new CSVData(census.LoadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_TYPE, error.type);
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", wrongStateCodeDelimiter, indianStateCodeHeaders);
            CSVData count = new CSVData(census.LoadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, error.type);
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", wrongStateCodeHeader, indianStateCodeHeaders);
            CSVData count = new CSVData(census.LoadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, error.type);
        }
        [Test]
        public void givenCSVDatatoSortByStateCode_ShouldReturnSortedDataInJsonFormat()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusFilePath, indianStateCensusHeaders);
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer(censusFilePath, indianStateCensusHeaders);
            CSVData count = new CSVData(censusAnalyzer.LoadData);
            censusData = (Dictionary<string, CensusDTO>)count();
            string sorted = censusAnalyzer.SortingCSVData(censusData, "state", SortFieldEnum.SortType.ASCENDING).ToString();
            IndiaCensusDAO[] d = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(sorted);
            Assert.AreEqual("Andhra Pradesh", d[0].state);
        }

        [Test]
        public void givenCSVDatatoSortByCensus_ShouldReturnLastSortedDataInJsonFormat()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusFilePath, indianStateCensusHeaders);
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer(censusFilePath, indianStateCensusHeaders);
            CSVData count = new CSVData(censusAnalyzer.LoadData);
            censusData = (Dictionary<string, CensusDTO>)count();
            string sorted = censusAnalyzer.SortingCSVData(censusData, "state", SortFieldEnum.SortType.ASCENDING).ToString();
            IndiaCensusDAO[] d = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(sorted);
            Assert.AreEqual("West Bengal", d[28].state);
        }
        [Test]
        public void givenCSVDatatoSortByStateCode_ShouldReturnFirstSorteNameInJsonFormat()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", stateCodeFilePath, indianStateCodeHeaders);
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer(stateCodeFilePath, indianStateCodeHeaders);
            CSVData count = new CSVData(censusAnalyzer.LoadData);
            censusData = (Dictionary<string, CensusDTO>)count();
            string sorted = censusAnalyzer.SortingCSVData(censusData, "stateCode", SortFieldEnum.SortType.ASCENDING).ToString();
            StateCodeDao[] indiaStateCodes = JsonConvert.DeserializeObject<StateCodeDao[]>(sorted);
            Assert.AreEqual("AD", indiaStateCodes[0].stateCode);
        }
        [Test]
        public void givenCSVDatatoSortByStateCode_ShouldReturnLastSorteNameInJsonFormat()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", stateCodeFilePath, indianStateCensusHeaders);
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer(stateCodeFilePath, indianStateCodeHeaders);
            CSVData count = new CSVData(censusAnalyzer.LoadData);
            censusData = (Dictionary<string, CensusDTO>)count();
            string sorted = censusAnalyzer.SortingCSVData(censusData, "stateCode",SortFieldEnum.SortType.ASCENDING).ToString();
            StateCodeDao[] indiaStateCodes = JsonConvert.DeserializeObject<StateCodeDao[]>(sorted);
            Assert.AreEqual("WB", indiaStateCodes[36].stateCode);
        }

        [Test]
        public void givenCSVDatatoSortByState_ShouldReturnMostPopulousState()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusFilePath, indianStateCensusHeaders);
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer(censusFilePath, indianStateCensusHeaders);
            CSVData count = new CSVData(censusAnalyzer.LoadData);
            censusData = (Dictionary<string, CensusDTO>)count();
            string sorted = censusAnalyzer.SortingCSVData(censusData, "population", SortFieldEnum.SortType.DESCENDING).ToString();
            IndiaCensusDAO[] d = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(sorted);
            Assert.AreEqual("Uttar Pradesh", d[0].state);
        }
        [Test]
        public void givenCSVDatatoSortByState_ShouldReturnleastPopulousState()
        {
            CSVBuilderFactory cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusFilePath, indianStateCensusHeaders);
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer(censusFilePath, indianStateCensusHeaders);
            CSVData count = new CSVData(censusAnalyzer.LoadData);
            censusData = (Dictionary<string, CensusDTO>)count();
            string sorted = censusAnalyzer.SortingCSVData(censusData, "population", SortFieldEnum.SortType.DESCENDING).ToString();
            IndiaCensusDAO[] d = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(sorted);
            Assert.AreEqual("Sikkim", d[28].state);
        }
    }
}