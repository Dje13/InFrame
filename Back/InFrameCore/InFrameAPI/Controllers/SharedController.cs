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
    public class SharedController : ControllerBase
    {
        // GET: api/Shared
        [Microsoft.AspNetCore.Mvc.HttpGet("TicketTypes")]
        [ResponseType(typeof(List<string>))]
        public List<string> GetTicketTypes()
        {
            List<string> tickets = DataFactory.getDropdownItems("TicketTypes");

            return tickets;
        }

    }
}
