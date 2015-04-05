using System;
using System.Collections.Generic;
using System.Linq;
using Herolab.Umbraco;
using Herolab.WebAPI.Config;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Security.Infrastructure;

namespace Herolab.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ISystemStatus _systemStatus;
        private readonly IContentServer _contentServer;

        public ValuesController(ISystemStatus systemStatus, IContentServer contentServer)
        {
            _systemStatus = systemStatus;
            _contentServer = contentServer;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", _systemStatus.Magic, _contentServer.GetObject() };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        //[Route("api/values/{id}"), HttpGet]
        //[Authorize("sdf", Roles = "sadf")]
        public string Get(int id)
        {
            return _systemStatus.Magic;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
