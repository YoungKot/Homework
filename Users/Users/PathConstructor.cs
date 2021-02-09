using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    public class PathConstructor
    {   
        /// <summary>
        /// Creates a path to the files
        /// </summary>
        /// <param name="filename">file name to be given to a file</param>
        /// <returns>returns created path</returns>
        public string pathConstructor(string filename)
        {
            string path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
            string fullPath = Path.Combine(path, filename);
            return fullPath;
        }

    }
}
