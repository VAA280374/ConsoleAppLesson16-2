using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ConsoleAppLesson16_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "Products.txt";
            string jsonProductsString;
            using (StreamReader sr = new StreamReader(path))
            { 
                jsonProductsString = sr.ReadToEnd();
                sr.Close();
            }
            // Console.WriteLine(jsonProductsString);

            int count = 5;
            int result = 0;
            decimal _price = 0;
            Product[] products = new Product[count];
            products = JsonSerializer.Deserialize<Product[]>(jsonProductsString);
            for (int i = 0; i < count; i++) 
            {
                if (products[i].Price > _price) 
                { 
                    result = i;
                    _price = products[i].Price;
                }
                
            }
            Console.WriteLine("Самый дорогой товар : {0} ", products[result].Name);

            Console.ReadKey();
        }
    }
    class Product
    {
        [JsonPropertyName("art")]
        public int Art { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
}
