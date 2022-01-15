using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


namespace LINQExample
{
    class Program
    {
        public static void Main(string[] args)
        {
            string[] names = {"Anil", "Sharma", "Srihari", "Banoth",
               "Shiva", "Shankar", "Naresh", "Suresh", "Suman"};

            //Using LINQ Queries 
            //UsingLinq(names);

            //using extension methods
            // UsingLinqExtensions(names); 

            //using functions 
            // UsingLINQFunctons(names);

            //using anonymous methods
            //UsingAnonymousMethods(names);

            //using LINQ read XML
            LINQReadXML(names);
        }
          // using normal linq queries syntax  in sql based in line num:17
        private static void UsingLinq(string[] names)
        {

            IEnumerable<string> query = from s in names
                                        where s.Length == 6
                                        orderby s
                                        select s.ToUpper();

            //select * from 
             foreach(string item in query)
                Console.WriteLine(item);

            Console.Read();
        }
          // by using LINQ Extensions Method in c# based in line num:20
        private static void UsingLinqExtensions(string[] names)
        {
            IEnumerable<string> query = names
                                        .Where(s => s.Length == 6) //here s is not mandotary we can put any character
                                        .OrderBy(s => s)
                                        .Select(s => s.ToUpper());

            foreach (string item in query)
                Console.WriteLine(item);

            Console.Read();
                
                    
        }
         // by using LINQ functions method in line num:23

        private static void UsingLINQFunctons(string[] names)
        {
            Func<string, bool> filters = s=> s.Length == 5; //here func keyword used for first string is for input and second bool is for output
            Func<string, string> extract = s => s;
            Func<string, string> project = s => s.ToUpper();

            IEnumerable<string> query = names.Where(filters)
                                           .OrderBy(extract)
                                           .Select(project);

            foreach (string item in query)
                Console.WriteLine(item);

            Console.Read();
        }
        //by using anonymous method see line 26

        private static void UsingAnonymousMethods(string[] names)
        {
            Func<string, bool> filter = delegate (string s)
             {
                 return s.Length == 5;
             };
            Func<string, string> extract = delegate (string s)
            {
                return s;
            };
            Func<string, string> project = delegate (string s)
            {
                return s.ToUpper();
            };

            IEnumerable<string> query = names.Where(filter)
                                           .OrderBy(extract)
                                           .Select(project);

            foreach (string item in query)
                Console.WriteLine(item);

            Console.Read();
        }
        private static void LINQReadXML(string[] names)
        {
            string myXML = @"<Departments>
                        <Department>Account</Department>
                        <Department>Sales</Department>
                        <Department>Pre-Sales</Department>
                        <Department>Marketing</Department>
                        </Departments>";

            XDocument xdoc = new XDocument();
            xdoc = XDocument.Parse(myXML);

            //add new element
            xdoc.Element("Departments").Add(new XElement("Department", "Finance"));

            //Add new element at first
            xdoc.Element("Departments").AddFirst(new XElement("Department", "Support"));

            var result = xdoc.Element("Departments").Descendants();

            foreach(XElement item in result)
            {
                Console.WriteLine("Department Name --" + item.Value);
            }
            Console.WriteLine("\n Press any key to continue.");
            Console.ReadKey();

        }

    }
}
