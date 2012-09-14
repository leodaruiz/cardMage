using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cardMage.Models;

namespace cardMage.Controllers
{
    public class JogoApiController : ApiController
    {
        // GET api/jogoapi/5
        public Jogo GetJogo(string gameKey)
        {
            // Return movie by id
            if (gameKey == "testeLeo")
            {
                return new Jogo();
            }

            // Otherwise, movie was not found
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }


        // GET api/jogoapi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/jogoapi
        public void Post([FromBody]string value)
        {
        }

        // PUT api/jogoapi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/jogoapi/5
        public void Delete(int id)
        {
        }
    }
}
