using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InFrameDAL.Models;
using InFrameFormManager;
using System.Web.Http.Description;
using InFrameDAL;

namespace InFrameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        // GET: api/Ticket
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Ticket/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Ticket
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Ticket/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}


        [Microsoft.AspNetCore.Mvc.HttpGet("List")]
        [ResponseType(typeof(List<Ticket>))]
        public List<Ticket> GetTicketList()
        {
            List<Ticket> ticketList = DataFactory.getTicketList();

            return ticketList;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        [ResponseType(typeof(Ticket))]
        public Ticket GetTicket(int id)
        {

            Ticket ticket = DataFactory.getTicket(id);

            return ticket;
        }

        //protected ActionResult getTicketListDTO(List<Ticket> tickets)
        //{
        //    if (tickets == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(DTOCreator.GetTicketListDTO(tickets));
        //}

    }
}
