using System;
using System.Net;

namespace SampleLinQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var URL = new UriBuilder("https://www2.icfesinteractivo.gov.co/interoperabilidad-web/rest/dominios/TIPO_DOCUMENTO");
            var client = new WebClient();
            Console.WriteLine(client.DownloadString(URL.ToString()));
        }
    }
    class TipoDoc
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
    }
}