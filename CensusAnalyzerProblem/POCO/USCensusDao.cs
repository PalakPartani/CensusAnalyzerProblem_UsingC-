using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProblem
{
    public class USCensusDao
    {
        public string stateId;
        public string stateName;
        public long population;
        public long housingUnit;
        public double totalArea;
        public double waterArea;
        public double landArea;
        public double populationDensity;
        public double housingDensity;

        public USCensusDao(string stateId, string stateName, string population, string housingUnits, string totalArea, string waterArea, string landArea, string populationDensity, string housingDensity)
        {
            this.stateId = stateId;
            this.stateName = stateName;
            this.totalArea = Convert.ToDouble(totalArea);
            this.waterArea = Convert.ToDouble(waterArea);
            this.population = Convert.ToUInt32(population);
            this.housingUnit = Convert.ToUInt32(housingUnits);
            this.landArea = Convert.ToDouble(landArea);
            this.populationDensity = Convert.ToDouble(populationDensity);
            this.housingDensity = Convert.ToDouble(housingDensity);
        }
    }
}
