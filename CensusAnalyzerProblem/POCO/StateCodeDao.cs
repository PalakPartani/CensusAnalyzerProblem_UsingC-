using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProblem
{
   public class StateCodeDao
    {
        public string stateCode;
        public int srNo;
        public string stateName;
        public int tin;
        

        public StateCodeDao(string v1, string v2, string v3, string v4)
        {
            this.srNo = Convert.ToInt32(v1);
            this.stateName = v2;
            this.tin = Convert.ToInt32(v3);
            this.stateCode = v4;
        }
    }
}

