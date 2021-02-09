using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Users
{
    class Program
    {
        public static PathConstructor path = new PathConstructor();
        public static CSVReader reader = new CSVReader();
        public static UserAmounts amount = new UserAmounts();
        public static CSVWriter writer = new CSVWriter();
        public static Result result = new Result();
        public static Validator validator = new Validator(writer, reader, path, result);
        static void Main(string[] args)
        {
            //string pathRead = "CSV//UserData.csv";
            //string directory = "CSV";
            //string fileName = "UserCount.csv";
            //var list = reader.GetTotal(path.pathConstructor(pathRead)).Item1;
            //int total = amount.GetTotalUsersCount(list);
            //int lvs = amount.GetUsersByCountryCount("LV", list);
            //int lts = amount.GetUsersByCountryCount("LT", list);
            //int ests = amount.GetUsersByCountryCount("EE", list);
            //validator.ValidateFile(directory,fileName,total,lvs,lts,ests);
            //Console.ReadKey();
        }
    }
}
