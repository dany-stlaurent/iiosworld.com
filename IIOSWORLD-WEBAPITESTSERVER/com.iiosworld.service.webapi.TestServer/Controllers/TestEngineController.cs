using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using com.iiosworld.service.webapi.models;

namespace com.iiosworld.service.webapi.TestServer.Controllers
{
    [Route("api/[controller]")]
    public class TestEngineController : Controller
    {
        // GET api/TestEngine
        [HttpGet]
        public IEnumerable<UniqueIdentifier> Get()
        {
            const int MAX_IDS = 10;
            return GenerateIds(MAX_IDS);
        }

        // GET api/TestEngine/5
        [HttpGet("{pNumIds}")]
        public IEnumerable<UniqueIdentifier> Get(int pNumIds)
        {
            const int MIN_ID_BATCH = 1;
            const int MAX_ID_BATCH = 500;
            const string P1NAME = @"pNumIds";
            const string P1MSG = @"The batch size must be between 1 and 500.";

            if(pNumIds <= MIN_ID_BATCH || pNumIds > MAX_ID_BATCH)
            {
                throw new ArgumentOutOfRangeException(P1NAME, P1MSG);
            }

            return GenerateIds(pNumIds);
        }
        [HttpGet("{pUniqueId}")]
        public UniqueIdentifier Get(UniqueIdentifier pUniqueId)
        {
            return GenerateId(pUniqueId.IdValue);
        }
        private UniqueIdentifier GenerateId(string pUId)
        {
            return new UniqueIdentifier(pUId);
        }
        private IEnumerable<UniqueIdentifier> GenerateIds(int pNumIds)
        {
            UniqueIdentifier[] newIds = new UniqueIdentifier[pNumIds];

            for (int i = 0; i < pNumIds; i++)
            {
                newIds[i] = new UniqueIdentifier();
            }
            return newIds.ToList<UniqueIdentifier>();
        }
        // POST api/TestEngine
        [HttpPost]
        public void Post([FromBody]string value)
        {
            
        }

        // PUT api/TestEngine/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/TestEngine/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
