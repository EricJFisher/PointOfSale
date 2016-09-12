using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Attempt to save transaction to service");
            CreateNewTransaction();
            Console.WriteLine("Attempt to retrieve transaction from service");
            GetTransaction();
            Console.ReadLine();
        }

        private static Uri baseAddress = new Uri("http://localhost:5001/");
        private static Transaction transaction = new Transaction() { Id = 1, CustomerName = "Test", Total = 1000, CompletedOn = new DateTime(2016, 01, 01) };

        public static void CreateNewTransaction()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsJsonAsync("api/transactions/Create", transaction).Result;
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Transaction saved successfully");
            }
        }

        public static void GetTransaction()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("api/transactions/GetTransaction/1").Result;

                response.EnsureSuccessStatusCode();

                Transaction results = response.Content.ReadAsAsync<Transaction>().Result;
                Console.WriteLine("transaction successfully retrieved results ");
            }
        }
    }
}
