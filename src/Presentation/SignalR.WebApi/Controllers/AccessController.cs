namespace SignalR.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using IdentityModel.Client;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]    
    public class AccessController : ControllerBase
    {
        // GET: api/GetAccessToken
        //[HttpGet("GetAccessToken")]
        //public async Task<TokenResponse> GetAccessToken(string client, string key, string resource)
        //{
        //    // return new JsonResult(from u in User.Claims select new { u.Type, u.Value });
        //    var disco = await DiscoveryClient.GetAsync("http://localhost:48404");
        //    var TokenClient = new TokenClient(disco.TokenEndpoint, client, key);
        //    var TokenResponse = await TokenClient.RequestClientCredentialsAsync(resource);
        //    var TokenJson = TokenResponse.Json;
        //    return TokenResponse;
        //}
    }
}
