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
        static string usCensusData = @"C:\Users\Palak Rubi\source\repos\CensusAnalyzerProblem\CensusAnalyzerTest\CSVFiles\USCensusData.csv";

        Dictionary<string, CensusDTO> censusData;
        Dictionary<string, CensusDTO> stateData;

        [SetUp]
        public void Setup()
        {
            censusData = new Dictionary<string, CensusDTO>();
            stateData = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            CensusAnalyzer census = new CensusAnalyzer(censusFilePath, indianStateCensusHeaders);
            censusData = census.LoadCensusData(Country.CountryName.INDIA);
            Assert.AreEqual(29, censusData.Count);
            CensusAnalyzer census1 = new CensusAnalyzer(stateCodeFilePath, indianStateCodeHeaders);
            stateData = census1.LoadCensusData(Country.CountryName.INDIA);
            Assert.AreEqual(37, stateData.Count);
        }
  
        [Test]
        public void GivenIndianCensusCSVFile_WhenFileNotExist_ShouldThrowException()
        {
            CensusAnalyzer census = new CensusAnalyzer(censusWrongPath, indianStateCensusHeaders);
            var error = Assert.Throws<CensusAnalyzerException>(() => census.LoadCensusData(Country.CountryName.INDIA));
            System.Console.WriteLine(error.type);
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.NOT_FOUND, error.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenFileTypeIsIncorrect_ShouldThrowException()
        {
            CensusAnalyzer census = new CensusAnalyzer(censusWrongType, indianStateCensusHeaders);
            var error = Assert.Throws<CensusAnalyzerException>(() => census.LoadCensusData(Country.CountryName.INDIA));
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_TYPE, error.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowException()
        {
            CensusAnalyzer census = new CensusAnalyzer(wrongCensusDelimiter, indianStateCensusHeaders);
            var error = Assert.Throws<CensusAnalyzerException>(() => census.LoadCensusData(Country.CountryName.INDIA));
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, error.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowException()
        {
            CensusAnalyzer census = new CensusAnalyzer(wrongCensusHeader, indianStateCensusHeaders);
            var error = Assert.Throws<CensusAnalyzerException>(() => census.LoadCensusData(Country.CountryName.INDIA));
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, error.type);
        }

        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            CensusAnalyzer census = new CensusAnalyzer(censusWrongPath, indianStateCodeHeaders);
            var error = Assert.Throws<CensusAnalyzerException>(() => census.LoadCensusData(Country.CountryName.INDIA));
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.NOT_FOUND, error.type);
        }

        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileTypeIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            CensusAnalyzer census = new CensusAnalyzer(wrongstateCodeFilePath, indianStateCodeHeaders);
            var error = Assert.Throws<CensusAnalyzerException>(() => census.LoadCensusData(Country.CountryName.INDIA));
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_TYPE, error.type);
        }
        //.....
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            CensusAnalyzer census = new CensusAnalyzer(wrongStateCodeDelimiter, indianStateCodeHeaders);
            var error = Assert.Throws<CensusAnalyzerException>(() => census.LoadCensusData(Country.CountryName.INDIA));
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, error.type);
        }

        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            CensusAnalyzer census = new CensusAnalyzer(wrongStateCodeHeader, indianStateCodeHeaders);
            var error = Assert.Throws<CensusAnalyzerException>(() => census.LoadCensusData(Country.CountryName.INDIA));
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, error.type);
        }

        [Test]
        public void GivenCSVDatatoSortByStateCode_ShouldReturnSortedDataInJsonFormat()
        {
            CensusAnalyzer census = new CensusAnalyzer(censusFilePath, indianStateCodeHeaders);
            censusData = (Dictionary<string, CensusDTO>)census.LoadCensusData(Country.CountryName.INDIA);
            string sorted = census.SortingCSVData(censusData, "state").ToString();
            IndiaCensusDAO[] d = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(sorted);
            Assert.AreEqual("Andhra Pradesh", d[0].state);
        }

        [Test]
        public void GivenCSVDatatoSortByCensus_ShouldReturnLastSortedDataInJsonFormat()
        {
            CensusAnalyzer census = new CensusAnalyzer(censusFilePath, indianStateCensusHeaders);
            censusData = (Dictionary<string, CensusDTO>)census.LoadCensusData(Country.CountryName.INDIA);
            string sorted = census.SortingCSVData(censusData, "state").ToString();
            IndiaCensusDAO[] d = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(sorted);
            Assert.AreEqual("West Bengal", d[28].state);
        }

        [Test]
        public void GivenCSVDatatoSortByStateCode_ShouldReturnFirstSorteNameInJsonFormat()
        {
            CensusAnalyzer census = new CensusAnalyzer(stateCodeFilePath, indianStateCodeHeaders);
            censusData = (Dictionary<string, CensusDTO>)census.LoadCensusData(Country.CountryName.INDIA);
            string sorted = census.SortingCSVData(censusData, "stateCode").ToString();
            StateCodeDao[] indiaStateCodes = JsonConvert.DeserializeObject<StateCodeDao[]>(sorted);
            Assert.AreEqual("AD", indiaStateCodes[0].stateCode);
        }

        [Test]
        public void GivenCSVDatatoSortByStateCode_ShouldReturnLastSorteNameInJsonFormat()
        {
            CensusAnalyzer census = new CensusAnalyzer(stateCodeFilePath, indianStateCodeHeaders);
            censusData = (Dictionary<string, CensusDTO>)census.LoadCensusData(Country.CountryName.INDIA);
            string sorted = census.SortingCSVData(censusData, "stateCode").ToString();
            StateCodeDao[] indiaStateCodes = JsonConvert.DeserializeObject<StateCodeDao[]>(sorted);
            Assert.AreEqual("WB", indiaStateCodes[36].stateCode);
        }

        [Test]
        public void GivenCSVDatatoSortByPopulation_ShouldReturnMostPopulousState()
        {
            CensusAnalyzer census = new CensusAnalyzer(censusFilePath, indianStateCensusHeaders);
            censusData = (Dictionary<string, CensusDTO>)census.LoadCensusData(Country.CountryName.INDIA);
            string sorted = census.SortingCSVData(censusData, "population").ToString();
            IndiaCensusDAO[] sortedResult = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(sorted);
            Assert.AreEqual("Uttar Pradesh", sortedResult[0].state);
        }

        [Test]
        public void GivenCSVDatatoSortByPopulation_ShouldReturnleastPopulousState()
        {
            CensusAnalyzer census = new CensusAnalyzer(censusFilePath, indianStateCensusHeaders);
            censusData = (Dictionary<string, CensusDTO>)census.LoadCensusData(Country.CountryName.INDIA);
            string sorted = census.SortingCSVData(censusData, "population").ToString();
            IndiaCensusDAO[] sortedResult = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(sorted);
            Assert.AreEqual("Sikkim", sortedResult[28].state);
        }

        [Test]
        public void GivenCSVDatatoSortByPopulationDensity_ShouldReturnMostPopulationDensityState()
        {
            CensusAnalyzer census = new CensusAnalyzer(censusFilePath, indianStateCensusHeaders);
            censusData = (Dictionary<string, CensusDTO>)census.LoadCensusData(Country.CountryName.INDIA);
            string sorted = census.SortingCSVData(censusData, "populationDensity").ToString();
            IndiaCensusDAO[] sortedResult = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(sorted);
            Assert.AreEqual("Bihar", sortedResult[0].state);
        }

        [Test]
        public void GivenCSVDatatoSortByPopulationDensity_ShouldReturnLeastPopulationDensityState()
        {

            CensusAnalyzer census = new CensusAnalyzer(censusFilePath, indianStateCensusHeaders);
            censusData = (Dictionary<string, CensusDTO>)census.LoadCensusData(Country.CountryName.INDIA);
            string sorted = census.SortingCSVData(censusData, "populationDensity").ToString();
            IndiaCensusDAO[] sortedResult = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(sorted);
            Assert.AreEqual("Arunachal Pradesh", sortedResult[28].state);
        }

        [Test]
        public void GivenCSVDatatoSortByLargestArea_ShouldReturnMostPopulationDensityState()
        {
            CensusAnalyzer census = new CensusAnalyzer(censusFilePath, indianStateCensusHeaders);
            censusData = (Dictionary<string, CensusDTO>)census.LoadCensusData(Country.CountryName.INDIA);
            string sorted = census.SortingCSVData(censusData, "area").ToString();
            IndiaCensusDAO[] sortedResult = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(sorted);
            Assert.AreEqual("Rajasthan", sortedResult[0].state);
        }

        [Test]
        public void GivenCSVDatatoSortByLargestArea_ShouldReturnLeastPopulationDensityState()
        {
            CensusAnalyzer census = new CensusAnalyzer(censusFilePath, indianStateCensusHeaders);
            censusData = (Dictionary<string, CensusDTO>)census.LoadCensusData(Country.CountryName.INDIA);
            string sorted = census.SortingCSVData(censusData, "area").ToString();
            IndiaCensusDAO[] sortedResult = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(sorted);
            Assert.AreEqual("Goa", sortedResult[28].state);
        }

        [Test]
        public void GivenUSCensusCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            CensusAnalyzer census = new CensusAnalyzer(usCensusData, usCodeHeaders);
            censusData = census.LoadCensusData(Country.CountryName.US);
            Assert.AreEqual(51, censusData.Count);
        }

        [Test]
        public void GivenUSCensusCSVFile_WhenFileNotExist_ShouldThrowException()
        {
            CensusAnalyzer census = new CensusAnalyzer(censusWrongPath, usCodeHeaders);
            var error = Assert.Throws<CensusAnalyzerException>(() => census.LoadCensusData(Country.CountryName.US));
            System.Console.WriteLine(error.type);
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.NOT_FOUND, error.type);
        }

        [Test]
        public void GivenUSCensusCSVFile_WhenFileTypeIsIncorrect_ShouldThrowException()
        {
            CensusAnalyzer census = new CensusAnalyzer(censusWrongType, usCodeHeaders);
            var error = Assert.Throws<CensusAnalyzerException>(() => census.LoadCensusData(Country.CountryName.US));
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_TYPE, error.type);
        }

        [Test]
        public void GivenUSCensusCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowException()
        {
            CensusAnalyzer census = new CensusAnalyzer(wrongStateCodeDelimiter,usCodeHeaders);
            var error = Assert.Throws<CensusAnalyzerException>(() => census.LoadCensusData(Country.CountryName.US));
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, error.type);
        }

        [Test]
        public void GivenUSCensusCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowException()
        {
            CensusAnalyzer census = new CensusAnalyzer(usCensusData, indianStateCensusHeaders);
            var error = Assert.Throws<CensusAnalyzerException>(() => census.LoadCensusData(Country.CountryName.US));
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, error.type);
        }
    }
}