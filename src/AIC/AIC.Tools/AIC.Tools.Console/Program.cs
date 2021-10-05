using AIC.Tools.Infraestructure.Query;
using System;
using System.Threading.Tasks;

namespace AIC.Tools.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var axieDetail = await GetDetailAxieId.DoIt(4111479);
            
        }
    }
}