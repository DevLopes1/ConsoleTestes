using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ConsoleTestes.Programas
{
    public class ConsultaCep
    {
        public static void menuPrograma()
        {
            Console.WriteLine("===#Consulta Cep#===");
            Console.Write("Digite o cep que será consultado: \n=>");
            string cep = Console.ReadLine();

            consultarCep(cep).Wait();

            // getTokenOAuth2("", "").Wait(); //metodo simples de esperar um funcao asnyc em um func sync/ poderiamos ate usar uma thread
        }

        public static async Task consultarCep(string cep)
        {
            //cep
            string url = $"https://viacep.com.br/ws/{cep}/json/";

            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage httpResponse = await client.GetAsync(url);
                    string conteudo = await httpResponse.Content.ReadAsStringAsync();

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Deu certo!, Status: " + httpResponse.StatusCode + "\nCONTEUDO: \n" + conteudo);

                        var objCep = JsonConvert.DeserializeObject<Cep>(conteudo);
                        int a = 2;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("#Erro na requisição!!! \n" + e.ToString());
            }

        }

    }

    public class Cep
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }
        public string ddd { get; set; }
        public string siafi { get; set; }
    }

}
