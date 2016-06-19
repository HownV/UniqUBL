using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ServiceTesting.DataAccessService;

namespace ServiceTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            //Guid id = Guid.NewGuid();

            var client = new DataAccessServiceClient("BasicHttpBinding_IDataAccessService");
            User[] users = client.GetUser("qwe@qwe.qwe");
            string hash1 = users[0].PasswordHash;

            //HashAlgorithm hash = SHA512.Create();
            //byte[] b = hash.ComputeHash(Encoding.UTF8.GetBytes("qwe"));
            //string res = Convert.ToBase64String(b);

            Console.WriteLine("");
        }
    }
}
