using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace AdminstratorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();

            var user = new User();
            Console.WriteLine("please enter firstname");
            user.firstname = Console.ReadLine();
            Console.WriteLine("please enter lastname");
            user.lastname = Console.ReadLine();
            Console.WriteLine("please enter username");
            user.username = Console.ReadLine();
            Console.WriteLine("please enter password");
            user.password = Console.ReadLine();


            HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"),
                RequestUri = new Uri(@"http://localhost:51346/users/register")//192.168.1.128:4444
            };


            httpClient.SendAsync(httpRequestMessage).GetAwaiter().GetResult();

            Console.WriteLine("Registered user");
        }

        public class User
        {
            public string firstname;
            public string lastname;
            public string username;
            public string password;
        }
    }
}
