using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using TokenAuthentication.Filter;
using TokenAuthentication.Helper;
using TokenAuthentication.Models;

namespace TokenAuthentication.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class UserController : ApiController
    {

        [HttpPost]
        [AllowAnonymous]
        [Route("api/user/login/")]
        public HttpResponseMessage Login([FromBody]UserRequestEntity userData)
        {
            if (!string.IsNullOrEmpty(userData.UserName) && !string.IsNullOrEmpty(userData.Password))
            {
                // TODO :: Verify credntial then set the required role 
                var token = TokenHelper.GenerateToken(userData.UserName, "Role of user");
                return Request.CreateResponse(HttpStatusCode.OK, token);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Client data invalid, request un-authrorized.");
            }
        }

        [HttpPost]
        [TokenAuthenticate]
        [Route("api/user/getdashboard/")]
        public HttpResponseMessage GetDashBoard([FromBody]JObject formData)
        {
            string something = formData["testid"].ToString();
            var text = "Dashboard view for role : " + HttpContext.Current.Items["Role"] + " For " + HttpContext.Current.Items["UserName"];
            return Request.CreateResponse(HttpStatusCode.OK,text);
        }
    }
}