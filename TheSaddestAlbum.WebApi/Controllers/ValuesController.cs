using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TheSaddestAlbum.Data.Entities;
using TheSaddestAlbum.Data.Services;

namespace TheSaddestAlbum.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly Configuration _configuration;
        private readonly LastfmService _lastfmService;

        public ValuesController(IOptions<Configuration> configurationAccessor, LastfmService lastfmService)
        {
            this._configuration = configurationAccessor.Value;
            this._lastfmService = lastfmService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _lastfmService.FetchAlbumInfo("Radiohead", "Ok Computer");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
