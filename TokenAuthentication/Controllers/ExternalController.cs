using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TokenAuthentication.Filter;
using TokenAuthentication.Helper;
using TokenAuthentication.Models;

namespace TokenAuthentication.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class ExternalController : ApiController
    {

        [HttpPost]
        [AllowAnonymous]
        [Route("api/externaluser/gettoken/")]
        public HttpResponseMessage GetToken([FromBody]ExternalRequestEntity userData)
        {
            if (!string.IsNullOrEmpty(userData.ClientID) && !string.IsNullOrEmpty(userData.ClientKey))
            {
                var token = TokenHelper.GenerateToken(userData.ClientID, "ExternalClient");
                return Request.CreateResponse(HttpStatusCode.OK, token);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Client data invalid, request un-authrorized. Key and Id mandatory");
            }
        }


        [HttpPost]
        [TokenAuthenticate]
        [Route("api/externaluser/config/")]
        public HttpResponseMessage TestExternalClient()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Config data + random GUID " + Guid.NewGuid().ToString());
        }
        
    }
}