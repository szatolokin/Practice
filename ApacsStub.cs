using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Text;

namespace Apacs.SDK.Web
{
    class ApacsStub
    {
        string userLogin;
        string userPassword;
        string apacsApiUrl;

        HttpClient httpClient;

        public ApacsStub(string userLogin, string userPassword, string apacsApiUrl) {
            this.userLogin = userLogin;
            this.userPassword = userPassword;
            this.apacsApiUrl = apacsApiUrl;
            httpClient = new HttpClient();
        }

        public async void GetRoot() {
            var auth = userLogin + ":" + userPassword;
            var authBytes = Encoding.UTF8.GetBytes(auth);
            var authHeader = Convert.ToBase64String(authBytes);

            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("Authorization", authHeader);
            httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var fullUrl = apacsApiUrl + "object/root";

            var response = await httpClient.GetStringAsync(fullUrl);
            Console.WriteLine(response);
        }
    }
}
