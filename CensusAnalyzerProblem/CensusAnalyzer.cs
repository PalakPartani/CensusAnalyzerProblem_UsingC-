using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;


namespace CensusAnalyzerProblem
{
    public class CensusAnalyzer : ICSVBuilder
    {
        public delegate object CSVData();
        public string path;
        public string headers;

        public CensusAnalyzer(string path, string headers)
        {
            this.path = path;
            this.headers = headers;
        }
        public object loadData()
        {

            if (!File.Exists(path))
                throw new CensusAnalyzerException("Invalid file ", CensusAnalyzerException.ExceptionType.NOT_FOUND);
            if (Path.GetExtension(path) != ".csv")
                throw new CensusAnalyzerException("Invalid file type ", CensusAnalyzerException.ExceptionType.INVALID_TYPE);

            string[] data = File.ReadAllLines(path);
            List<string> list = data.ToList();
            if (data[0] != headers)
                throw new CensusAnalyzerException("Invalid file header ", CensusAnalyzerException.ExceptionType.INVALID_HEADER);
            foreach (string d in list)
            {
                if (!d.Contains(','))
                    throw new CensusAnalyzerException("Invalid file delimiter ", CensusAnalyzerException.ExceptionType.INVALID_DELIMITER);
            }

            return data.Skip(1).ToList();
        }

        public string sortingCSVData(string path, string newPath, int type)
        {
            string[] data = File.ReadAllLines(path);
            var details = data.Skip(1);
            IEnumerable<string> query =
            from line in details
            let x = line.Split(',')
            orderby x[type]
            select line;
            File.WriteAllLines(newPath, data.Take(1).Concat(query.ToArray()));
            List<string> sorted = query.ToList<string>();
            return JsonConvert.SerializeObject(sorted);
         
        }
    }
}