using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
namespace payday
{
    class Program
    {
        public static void Serialize(Pay p)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize<Pay>(p, options);
            File.WriteAllText("Payment.json", jsonString);
            XmlSerializer xml = new XmlSerializer(typeof(Pay));
            using (FileStream fs = new FileStream("Pay.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, p);
            }

        }
        public static Pay JsonDeSerialize()
        {
            Pay tmp = new Pay();
            var jsonString = File.ReadAllText("Payment.json");


            tmp = JsonSerializer.Deserialize<Pay>(jsonString);


            return tmp;
        }
        public static Pay XMLDeSerialize()
        {
            Pay tmp = new Pay();
            XmlSerializer xml = new XmlSerializer(typeof(Pay));
            using (FileStream fs = new FileStream("Pay.xml", FileMode.OpenOrCreate))
            {

                tmp = xml.Deserialize(fs) as Pay;
            }

            return tmp;
        }
        static void Main(string[] args)
        {
            Pay p = new Pay(50, 10, 15, 3);

            Serialize(p);
            Pay p1 = JsonDeSerialize();
            Pay p2 = XMLDeSerialize();
            Console.WriteLine(p1);
            Console.WriteLine("\n---------------------\n");
            Console.WriteLine(p2);
        }
    }
}
