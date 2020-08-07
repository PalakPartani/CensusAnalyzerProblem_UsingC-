using System.IO;

using System.Collections.Generic;
using System;
using System.Reflection.Metadata.Ecma335;

namespace CensusAnalyzerProblem
{
    public class CensusAnalyzer
    {
        public int getCount(string path)
        {
            int count = 0;

            if (!path.Contains("IndiaStateCensusData"))
                throw new CensusAnalyzerException("Invalid file ");
                string[] n = File.ReadAllLines(path);
     
                // IEnumerable<string> e = n;
                for (int i = 0; i < n.Length; i++)
                {
                    count++;
                }
                return count - 1;
            }
           /* catch(CensusAnalyzerException e)
            {
                 Console.WriteLine(e.Message);
                *//*throw new CensusAnalyzerException("Invalid file");*//*
            }
            return 0;*/
        }
    }
