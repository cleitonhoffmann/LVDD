using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace LVDD.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/users
        public IEnumerable<Models.UserItem> Get()
        {
            var path = HttpContext.Current.Server.MapPath("~/App_Data/users.json");
            var json = System.IO.File.ReadAllText(path);
            var deserialized = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Models.UserItem>>(json);

            return deserialized;
        }
    }
}
