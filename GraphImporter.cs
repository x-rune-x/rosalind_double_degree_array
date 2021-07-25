using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DegreeArray
{
    class GraphImporter
    {              
        public List<string[]> ImportGraph(string filePath)
        {
            List<string[]> edgeList = new();

            using StreamReader sr = new(filePath);
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] edgeComponents = line.Split(" ");
                    edgeList.Add(edgeComponents);
                }
            }

            return edgeList;
        }
    }
}
