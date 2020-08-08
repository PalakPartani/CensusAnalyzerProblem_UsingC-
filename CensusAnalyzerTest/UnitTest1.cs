using NUnit.Framework;
using CensusAnalyzerProblem;
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
           
                var count = Assert.Throws<CensusAnalyzerException>(()=>censusAnalyzer.loadData(censusWrongPath, indianStateCensusHeaders));
         
                Assert.AreEqual(CensusAnalyzerException.ExceptionType.NOT_FOUND, count.type);
            }
    
        [Test]
        public void givenWrongFileType_ShouldThrowCustomException()
        {
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
           
                var count = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.loadData(censusWrongType, indianStateCensusHeaders));
            
                Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_TYPE,count.type);
          
        }
        [Test]
        public void givenWrongFileDelimiter_ShouldThrowCustomException()
        {
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();

            var count = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.loadData(wrongCensusDelimiter, indianStateCensusHeaders));
            
                Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER,count.type);
            }
        
        [Test]
        public void givenWrongFileHeader_ShouldThrowCustomException()
        {
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();

            var count = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.loadData(wrongCensusHeader, indianStateCensusHeaders));
           
                Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER,count.type);
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

            var count = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.loadData(censusWrongPath, indianStateCodeHeaders));
            
            
                Assert.AreEqual(CensusAnalyzerException.ExceptionType.NOT_FOUND, count.type);
            }
        
        [Test]
        public void givenWrongStatecodeFileType_ShouldThrowCustomException()
        {
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();

            var count = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.loadData(wrongstateCodeFilePath, indianStateCodeHeaders));
            
                Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_TYPE, count.type);
            }
        
        [Test]
        public void givenWrongStateCodeFileDelimiter_ShouldThrowCustomException()
        {
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();

        var count = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.loadData(wrongStateCodeDelimiter, indianStateCodeHeaders));
            
                Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, count.type);
            }
        
        [Test]
        public void givenWrongStatecodeFileHeader_ShouldThrowCustomException()
        {
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();

            var count = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.loadData(wrongStateCodeHeader, indianStateCodeHeaders));
            
                Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADER, count.type);
            }
        }
    }
