using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProblem
{
   public class CensusDTO
    {

        public int srNo;
        public string stateName;
        public string state;
        public int tin;
        public string stateCode;
        public long population;
        public long area;
        public long density;
        public string stateId;
        public long housingUnits;
        public double totalArea;
        public double waterArea;
        public double landArea;
        public double populationDensity;
        public double housingDensity;
        public CensusDTO(IndiaCensusDAO censusDataDao)
        {
            this.state = censusDataDao.state;
            this.population = censusDataDao.population;
            this.area = censusDataDao.area;
            this.density = censusDataDao.density;
        }
        public CensusDTO(StateCodeDao stateCodeDao)
        {
            this.srNo = stateCodeDao.srNo;
            this.stateName = stateCodeDao.stateName;
            this.tin = stateCodeDao.tin;
            this.stateCode = stateCodeDao.stateCode;
        }
        public CensusDTO(USCensusDao uSCensusDao)
        {
            this.stateCode = uSCensusDao.stateId;
            this.stateName = uSCensusDao.stateName;
            this.population = uSCensusDao.population;
            this.housingUnits = uSCensusDao.housingUnit;
            this.totalArea = uSCensusDao.totalArea;
            this.waterArea = uSCensusDao.waterArea;
            this.landArea = uSCensusDao.landArea;
            this.populationDensity = uSCensusDao.populationDensity;
            this.housingDensity = uSCensusDao.housingDensity;
        }
    }
}
