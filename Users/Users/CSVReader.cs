using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    public class CSVReader
    {
        List<User> users = new List<User>();
        List<Result> results = new List<Result>();
        /// <summary>
        /// Reads the data from csv file
        /// </summary>
        /// <param name="path">path to a file</param>
        /// <returns>Returns the data as list of users or results</returns>
        public Tuple<List<User>, List<Result>> GetTotal(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    using (var reader = new StreamReader(path))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Context.RegisterClassMap<UserMap>();
                        csv.Context.RegisterClassMap<ResultMap>();
                        var isHeader = true;
                        while (csv.Read())
                        {
                            if (isHeader)
                            {
                                csv.ReadHeader();
                                isHeader = false;
                                continue;
                            }

                            if (string.IsNullOrEmpty(csv.GetField(0)))
                            {
                                isHeader = true;
                                continue;
                            }

                            switch (csv.HeaderRecord[0])
                            {
                                case "UserId":
                                    users.Add(csv.GetRecord<User>());
                                    break;
                                case "Id":
                                    results.Add(csv.GetRecord<Result>());
                                    break;
                                default:
                                    throw new InvalidOperationException("Unknown record type.");
                            }
                        }
                    }
                    return Tuple.Create(users, results);
                }
                else
                {
                    throw new FileNotFoundException($"Could not find the file: {path}");
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.ToString());
            }
            
        }
    }
}
