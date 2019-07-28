using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TilleComm.BusinessServvice.Interfaces;
using TilleComm.Helpers;
using TilleComm.Models;
using TilleCommCommon;
using TilleCommModels;

namespace TilleComm.BusinessServvice.Concrete
{
    public class LoginBusinessService:ILoginBusinessService
    {
        public async Task<UserLogin> Login(UserLogin user)
        {
            UserLogin result = new UserLogin();
            try
            {
                var httpClient = TilleCommHttpClient.GetClient();
                HttpResponseMessage response;
                string jsonResult = JsonConvert.SerializeObject(user);
                response = await httpClient.PostAsync(TilleCommURL.LoginUrl, new StringContent(jsonResult, System.Text.Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    var userAsstring = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = JsonConvert.DeserializeObject<UserLogin>(userAsstring);
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
    }
}