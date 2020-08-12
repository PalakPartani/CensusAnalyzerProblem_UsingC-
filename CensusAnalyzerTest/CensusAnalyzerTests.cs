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
        static string usCodeHeaders = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";

        static string wrongStateCodeHeader = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CensusAnalyzerTest\CSVFiles\WrongDelimiter.csv";
        static string wrongStateCodeDelimiter = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CensusAnalyzerTest\CSVFiles\WrongStateCodeHeader.csv";
        static string wrongCensusHeader = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CensusAnalyzerTest\CSVFiles\WrongCensusHeader.csv";
        static string wrongCensusDelimiter = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CensusAnalyzerTest\CSVFiles\WrongCensusDelimiter.csv";
        //  static string newFile = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CensusAnalyzerTest\CSVFiles\newFile.csv";
        static string usCensusData = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CensusAnalyzerTest\CSVFiles\USCensusData.csv";
        
        Dictionary<string, CensusDTO> censusData = new Dictionary<string, CensusDTO>();
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
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusWrongPath, indianStateCensusHeaders);
            CSVData count = new CSVData(census.LoadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            System.Console.WriteLine(error.type);
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.NOT_FOUND, error.type);
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileTypeIsIncorrect_ShouldThrowException()
        {
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusWrongType, indianStateCensusHeaders);
            CSVData count = new CSVData(census.LoadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_TYPE, error.type);
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowException()
        {
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", wrongCensusDelimiter, indianStateCensusHeaders);
            CSVData count = new CSVData(census.LoadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, error.type);
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowException()
        {
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", wrongCensusHeader, indianStateCensusHeaders);
            CSVData count = new CSVData(census.LoadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, error.type);
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusWrongPath, indianStateCodeHeaders);
            CSVData count = new CSVData(census.LoadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.NOT_FOUND, error.type);
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileTypeIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", wrongstateCodeFilePath, indianStateCodeHeaders);
            CSVData count = new CSVData(census.LoadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_TYPE, error.type);
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", wrongStateCodeDelimiter, indianStateCodeHeaders);
            CSVData count = new CSVData(census.LoadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, error.type);
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", wrongStateCodeHeader, indianStateCodeHeaders);
            CSVData count = new CSVData(census.LoadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, error.type);
        }
        [Test]
        public void givenCSVDatatoSortByStateCode_ShouldReturnSortedDataInJsonFormat()
        {
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusFilePath, indianStateCensusHeaders);
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer(censusFilePath, indianStateCensusHeaders);
            CSVData count = new CSVData(censusAnalyzer.LoadData);
            censusData = (Dictionary<string, CensusDTO>)count();
            string sorted = censusAnalyzer.SortingCSVData(censusData, "state").ToString();
            IndiaCensusDAO[] d = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(sorted);
            Assert.AreEqual("Andhra Pradesh", d[0].state);
        }

        [Test]
        public void givenCSVDatatoSortByCensus_ShouldReturnLastSortedDataInJsonFormat()
        {
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusFilePath, indianStateCensusHeaders);
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer(censusFilePath, indianStateCensusHeaders);
            CSVData count = new CSVData(censusAnalyzer.LoadData);
            censusData = (Dictionary<string, CensusDTO>)count();
            string sorted = censusAnalyzer.SortingCSVData(censusData, "state").ToString();
            IndiaCensusDAO[] d = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(sorted);
            Assert.AreEqual("West Bengal", d[28].state);
        }
        [Test]
        public void givenCSVDatatoSortByStateCode_ShouldReturnFirstSorteNameInJsonFormat()
        {
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", stateCodeFilePath, indianStateCodeHeaders);
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer(stateCodeFilePath, indianStateCodeHeaders);
            CSVData count = new CSVData(censusAnalyzer.LoadData);
            censusData = (Dictionary<string, CensusDTO>)count();
            string sorted = censusAnalyzer.SortingCSVData(censusData, "stateCode").ToString();
            StateCodeDao[] indiaStateCodes = JsonConvert.DeserializeObject<StateCodeDao[]>(sorted);
            Assert.AreEqual("AD", indiaStateCodes[0].stateCode);
        }
        [Test]
        public void givenCSVDatatoSortByStateCode_ShouldReturnLastSorteNameInJsonFormat()
        {
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", stateCodeFilePath, indianStateCensusHeaders);
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer(stateCodeFilePath, indianStateCodeHeaders);
            CSVData count = new CSVData(censusAnalyzer.LoadData);
            censusData = (Dictionary<string, CensusDTO>)count();
            string sorted = censusAnalyzer.SortingCSVData(censusData, "stateCode").ToString();
            StateCodeDao[] indiaStateCodes = JsonConvert.DeserializeObject<StateCodeDao[]>(sorted);
            Assert.AreEqual("WB", indiaStateCodes[36].stateCode);
        }

        [Test]
        public void givenCSVDatatoSortByState_ShouldReturnMostPopulousState()
        {
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusFilePath, indianStateCensusHeaders);
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer(censusFilePath, indianStateCensusHeaders);
            CSVData count = new CSVData(censusAnalyzer.LoadData);
            censusData = (Dictionary<string, CensusDTO>)count();
            string sorted = censusAnalyzer.SortingCSVData(censusData, "population").ToString();
            IndiaCensusDAO[] sortedResult = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(sorted);
            Assert.AreEqual("Uttar Pradesh", sortedResult[0].state);
        }
        [Test]
        public void givenCSVDatatoSortByState_ShouldReturnleastPopulousState()
        {
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusFilePath, indianStateCensusHeaders);
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer(censusFilePath, indianStateCensusHeaders);
            CSVData count = new CSVData(censusAnalyzer.LoadData);
            censusData = (Dictionary<string, CensusDTO>)count();
            string sorted = censusAnalyzer.SortingCSVData(censusData, "population").ToString();
            IndiaCensusDAO[] sortedResult = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(sorted);
            Assert.AreEqual("Sikkim", sortedResult[28].state);
        }

        [Test]
        public void givenCSVDatatoSortByPopulationDensity_ShouldReturnMostPopulationDensityState()
        {
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusFilePath, indianStateCensusHeaders);
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer(censusFilePath, indianStateCensusHeaders);
            CSVData count = new CSVData(censusAnalyzer.LoadData);
            censusData = (Dictionary<string, CensusDTO>)count();
            string sorted = censusAnalyzer.SortingCSVData(censusData, "populationDensity").ToString();
            IndiaCensusDAO[] sortedResult = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(sorted);
            Assert.AreEqual("Bihar", sortedResult[0].state);
        }
        [Test]
        public void givenCSVDatatoSortByPopulationDensity_ShouldReturnLeastPopulationDensityState()
        {
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusFilePath, indianStateCensusHeaders);
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer(censusFilePath, indianStateCensusHeaders);
            CSVData count = new CSVData(censusAnalyzer.LoadData);
            censusData = (Dictionary<string, CensusDTO>)count();
            string sorted = censusAnalyzer.SortingCSVData(censusData, "populationDensity").ToString();
            IndiaCensusDAO[] sortedResult = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(sorted);
            Assert.AreEqual("Arunachal Pradesh", sortedResult[28].state);
        }
        [Test]
        public void givenCSVDatatoSortByLargestArea_ShouldReturnMostPopulationDensityState()
        {
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusFilePath, indianStateCensusHeaders);
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer(censusFilePath, indianStateCensusHeaders);
            CSVData count = new CSVData(censusAnalyzer.LoadData);
            censusData = (Dictionary<string, CensusDTO>)count();
            string sorted = censusAnalyzer.SortingCSVData(censusData, "area").ToString();
            IndiaCensusDAO[] sortedResult = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(sorted);
            Assert.AreEqual("Rajasthan", sortedResult[0].state);
        }

        [Test]
        public void givenCSVDatatoSortByLargestArea_ShouldReturnLeastPopulationDensityState()
        {
            CensusAnalyzer counte = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusFilePath, indianStateCensusHeaders);
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer(censusFilePath, indianStateCensusHeaders);
            CSVData count = new CSVData(censusAnalyzer.LoadData);
            censusData = (Dictionary<string, CensusDTO>)count();
            string sorted = censusAnalyzer.SortingCSVData(censusData, "area").ToString();
            IndiaCensusDAO[] sortedResult = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(sorted);
            Assert.AreEqual("Goa", sortedResult[28].state);
        }

        [Test]
        public void givenUSCensusCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", usCensusData, usCodeHeaders);
            CSVData count = new CSVData(census.LoadData);
            censusData = (Dictionary<string, CensusDTO>)count();
            Assert.AreEqual(51, censusData.Count);
        }
        [Test]
        public void givenUSCensusCSVFile_WhenFileNotExist_ShouldThrowException()
        {
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusWrongPath, usCodeHeaders);
            CSVData count = new CSVData(census.LoadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            System.Console.WriteLine(error.type);
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.NOT_FOUND, error.type);
        }

        [Test]
        public void givenUSCensusCSVFile_WhenFileTypeIsIncorrect_ShouldThrowException()
        {
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", censusWrongType, usCodeHeaders);
            CSVData count = new CSVData(census.LoadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_TYPE, error.type);
        }

        [Test]
        public void givenUSCensusCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowException()
        {
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", usCensusData, indianStateCensusHeaders);
            CSVData count = new CSVData(census.LoadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, error.type);
        }

        [Test]
        public void givenUSCensusCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowException()
        {
            CensusAnalyzer census = (CensusAnalyzer)cSVBuilderFactory.CreateObject("CensusAnalyzer", usCensusData, indianStateCensusHeaders);
            CSVData count = new CSVData(census.LoadData);
            var error = Assert.Throws<CensusAnalyzerException>(() => count());
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, error.type);
        }
    }
}