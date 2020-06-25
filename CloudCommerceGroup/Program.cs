using CloudCommerceGroup.Context;
using CloudCommerceGroup.Converters.Database;
using CloudCommerceGroup.Converters.Files;
using System;

namespace CloudCommerceGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use this to set a reference to the required converter strategy 
            // IE convert csv -> json, csv -> xml etc
            ConverterContext conversionContext = new ConverterContext();

            Console.WriteLine("What conversion strategy would you like to use (1-7)?");
            Console.WriteLine("1: csv file to json");
            Console.WriteLine("2: csv file to xml");
            Console.WriteLine("3: json file to csv");
            Console.WriteLine("4: xml file to csv");
            Console.WriteLine("5: database to csv");
            Console.WriteLine("6: database to xml");
            Console.WriteLine("7: database to json");

            int conversionStrategy = int.Parse(Console.ReadKey().KeyChar.ToString());

            switch (conversionStrategy)
            {
                // Conversion Strategy -> csv file to json
                case 1:
                    conversionContext.SetConversionStrategy(new CsvToJsonConverter());
                    Console.WriteLine(conversionContext.Convert(@"CCGSample.csv"));
                    break;

                // Conversion Strategy -> csv file to xml
                case 2:
                    conversionContext.SetConversionStrategy(new CsvToXmlConverter());
                    Console.WriteLine(conversionContext.Convert(@"CCGSample.csv"));
                    break;

                // Conversion Strategy -> json file to csv - Convert method not implemented
                case 3:
                    conversionContext.SetConversionStrategy(new JsonToCsvConverter());
                    Console.WriteLine(conversionContext.Convert(@"CCGSample.json"));
                    break;

                // Conversion Strategy ->  xml file to csv - Convert method not implemented
                case 4:
                    conversionContext.SetConversionStrategy(new XmlToCsvConverter());
                    Console.WriteLine(conversionContext.Convert(@"CCGSample.xml"));
                    break;

                // Conversion Strategy -> database to csv - Convert method not implemented
                case 5:
                    conversionContext.SetConversionStrategy(new DatabaseToCsvConverter());
                    Console.WriteLine(conversionContext.Convert(@"dbConnectionString"));
                    break;

                // Conversion Strategy -> database to xml - Convert method not implemented
                case 6:
                    conversionContext.SetConversionStrategy(new DatabaseToXmlConverter());
                    Console.WriteLine(conversionContext.Convert(@"dbConnectionString"));
                    break;

                // Conversion Strategy -> Database to json - Convert method not implemented
                case 7:
                    conversionContext.SetConversionStrategy(new DatabaseToJsonConverter());
                    Console.WriteLine(conversionContext.Convert(@"dbConnectionString"));
                    break;

                default:
                    Console.WriteLine("Invalid Selection!");
                    break;
            }
            Console.ReadKey();
        }
    }
}