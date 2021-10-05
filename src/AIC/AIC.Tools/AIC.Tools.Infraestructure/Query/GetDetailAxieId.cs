using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using AIC.Tools.Domain.Entities;

namespace AIC.Tools.Infraestructure.Query
{
    public class GetDetailAxieId
    {
        public static async Task<AxieDetail> DoIt(int axieId) 
        {
            await Task.Delay(1);
            var client = new RestClient("https://axieinfinity.com/graphql-server-v2/graphql");
            var body = new {
                operationName = "GetAxieDetail",
                variables = new { 
                                    axieId = axieId 
                                },
                query = "query GetAxieDetail($axieId: ID!) {\n axie(axieId:$axieId) {\n ...AxieDetail\n \n}\n}\n\nfragment AxieDetail on Axie {\n id\n image\n class\n stats {\n ...AxieStats\n}\n parts {\n ...AxiePart\n \n}\n stats {\n ...AxieStats\n\n}\n\n}\n\nfragment AxiePart on AxiePart {\n id\n name\n class\n type\n specialGenes\n stage\n abilities {\n ...AxieCardAbility\n\n}\n\n}\n\nfragment AxieCardAbility on AxieCardAbility {\n id\n name\n attack\n defense\n energy\n description\n backgroundUrl\n effectIconUrl\n\n}\n\nfragment AxieStats on AxieStats {\n hp\n speed\n skill\n morale\n}\n\n"
            };
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(body);
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<AxieDetail>(response.Content);
        }
    }
}