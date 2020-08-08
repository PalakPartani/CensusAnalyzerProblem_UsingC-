using NUnit.Framework;
using CensusAnalyzerProblem;
namespace CensusAnalyzerTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }


        [Test]
        public void Test1()
        {
            string path = @"C:\Users\Palak Rubi\Desktop\IndiaStateCensusData.csv";
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
            int count = censusAnalyzer.getCount(path);
            Assert.AreEqual(count, 29);
        }

        [Test]
        public void givenWrongFilePath_ShouldThrowCustomException()
        {
            string path = @"C:\Users\Palak Rubi\Desktop\IndiaCensusDataa.csv";
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
            try
            {
                int count = censusAnalyzer.getCount(path);
            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual("Invalid file ", e.exceptionMessage);
            }
        }
        [Test]
        public void givenWrongFileType_ShouldThrowCustomException()
        {
            string path = @"C:\Users\Palak Rubi\Desktop\IndiaStateCensusData.java";
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
            try
            {
                int count = censusAnalyzer.getCount(path);
            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual("Invalid file type ", e.exceptionMessage);
            }
        }
        [Test]
        public void givenWrongFileDelimiter_ShouldThrowCustomException()
        {
            string path = @"C:\Users\Palak Rubi\Desktop\IndiaStateCensusData.csv";
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
            try
            {
                int count = censusAnalyzer.getCount(path);
            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual("Invalid file delimiter ", e.exceptionMessage);
            }
        }
        [Test]
        public void givenWrongFileHeader_ShouldThrowCustomException()
        {
            string path = @"C:\Users\Palak Rubi\Desktop\IndiaStateCensusData.csv";
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();
            try
            {
                int count = censusAnalyzer.getCount(path);
            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual("Invalid file Header ", e.exceptionMessage);
            }
        }
    }
}
