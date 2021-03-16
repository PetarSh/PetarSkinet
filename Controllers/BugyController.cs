using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Structura.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetarSkinet.Controllers
{

    public class BugyController : BaseApiController
    {
        private readonly StoreContext store;

        public BugyController(StoreContext storeContext)
        {
            store = storeContext;
        }
        [HttpGet("not found")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = store.Products.Find(42);
            if (thing==null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("server error")]
        public ActionResult GetServerError()
        {
            var thing = store.Products.Find(42);
            var x = thing.ToString();

           
            return Ok();
        }
        [HttpGet("bad request")]
        public ActionResult GetBadRequest()
        {
            return BadRequest();
        }
        [HttpGet("bad request/{id}")]
        public ActionResult GetBadRequestId(int id)
        {
           
            return Ok();
        }
    }
}

