using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.IO;

namespace CLIENTHTTP2
{
    
    class Program
    {
        StringContent content;
        string port;
        public Program(StringContent content, string port)
        {
            this.content = content;
            this.port = port;
            this.Wyslij();
        }
       
       
        private async void Wyslij()

        {
            try
            {
                string uri = "http://localhost:" + port +  "/" ;
                var myHttpClient = new HttpClient();
                var response = await myHttpClient.PostAsync(uri, content);
                var stringContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(" \n Informacje dodatkowe");
                //Console.WriteLine(content);
                Console.WriteLine(response);
                //Console.WriteLine(stringContent);
            }
            catch(Exception error)
            {
                Console.WriteLine("Nie udało sie przesłać wiadomości + {0}",error);
            }

        }
        /*źródłem strona: https://msdn.microsoft.com/pl-pl/library/system.net.http.httpclient(v=vs.110).aspx */
      



    }
}
