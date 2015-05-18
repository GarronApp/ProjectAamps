using Aamps.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            AampService.AampServiceClient context = new AampService.AampServiceClient();

            var result = context.GetDevelopmentById(1);

            if (result != null)
            {
                Console.WriteLine("");
            }

       
        }
    }
}
