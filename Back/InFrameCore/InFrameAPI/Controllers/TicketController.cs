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
using System.Net.Http;
using InFrameDAL.DTO;

namespace InFrameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        [HttpGet("List")]
        [ResponseType(typeof(List<Ticket>))]
        public ActionResult GetTicketList()
        {
            List<Ticket> ticketList = DataFactory.getTicketList();

            return Ok(ticketList);
        }

        [HttpGet("{id}")]
        [ResponseType(typeof(Ticket))]
        public ActionResult GetTicket(int id)
        {
            Ticket ticket = DataFactory.getTicket(id);

            return Ok(ticket);
        }

        [HttpPost]
        public ActionResult CreateTicket(TicketDTO ticket)
        {
            //DataFactory.AddTicket(ticket);
            TicketDTO resultat = new TicketDTO();
            return Ok(resultat);
        }


    }
}
