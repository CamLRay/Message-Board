using Microsoft.AspNetCore.Identity;
using MessageBoard.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;
using System.Web;

namespace MessageBoard.Models
{
    public class ApplicationUser : IdentityUser
    {
        private static string _userId { get; set; }

        public static void Register(RegisterViewModel model)
        {
            var apiCallTask = ApiHelper.ApiPostRegister(model);
            var result = apiCallTask.Result;

            JValue jsonResponse = JsonConvert.DeserializeObject<JValue>(result);
            
            _userId = jsonResponse.ToString();

        }

        public static string Login(LoginViewModel model)
        {
            var apiCallTask = ApiHelper.ApiPostLogin(model);
            var result = apiCallTask.Result;

            JValue jsonResponse = JsonConvert.DeserializeObject<JValue>(result);
            
            
            return jsonResponse.ToString();
        }


    }
}