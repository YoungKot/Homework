using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    public class Validator
    {
        CSVWriter Writer;
        CSVReader Reader;
        PathConstructor Path;
        Result Result;
        
        public Validator(CSVWriter writer, CSVReader reader, PathConstructor path, Result result)
        {
            this.Writer = writer;
            this.Reader = reader;
            this.Path = path;
            this.Result = result;
        }

        /// <summary>
        /// Checks if the file with user count exists, if not creates it, else retrieves the data from the existing file
        /// </summary>
        /// <param name="directory">directory name</param>
        /// <param name="fileName">file name</param>
        /// <param name="total">total amount of users</param>
        /// <param name="lvs">total amount of users in LV</param>
        /// <param name="lts">total amount of users in LT</param>
        /// <param name="ests">total amount of users in EE</param>
        public void ValidateFile(string directory, string fileName, int total, int lvs, int lts, int ests)
        {
            List<Result> records = new List<Result>();
            string[] files = Directory.GetFiles(directory, "UserC*");
            if (files.Length == 1)
            {
                records = Reader.GetTotal(Path.pathConstructor(directory + "//" + fileName)).Item2;
                VerifyData(total, lvs, lts, ests, records);
            }
            else
            {
                records = Result.CreateResults(total, lvs, lts, ests);
                Writer.WriteToCSVFile(directory + "//" + fileName, records);
                VerifyData(total, lvs, lts, ests, records);
            }
        }

        /// <summary>
        /// Compares the data from a given file with the previous import data
        /// </summary>
        /// <param name="total">total amount of users</param>
        /// <param name="lvs">total amount of users in LV</param>
        /// <param name="lts">total amount of users in LT</param>
        /// <param name="ests">total amount of users in EE</param>
        /// <param name="records">The data from the previous import</param>
        public void VerifyData(int total, int lvs, int lts, int ests, List<Result> records)
        {
            foreach(var record in records)
            {
                if(total == record.Total && lvs == record.LV && lts == record.LT && ests == record.EE)
                {
                    Console.WriteLine("Records are being imported...");
                }
                else
                { 
                    throw new InvalidOperationException("User amounts do not match.");
                }
            }
        }
    }
}
