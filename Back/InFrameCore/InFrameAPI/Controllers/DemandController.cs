using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using InFrameDAL;
using InFrameDAL.DTO;
using InFrameDAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InFrameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandController : ControllerBase
    {

        // Get one generic request by ID
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        [ResponseType(typeof(DemandDTO))]
        public ActionResult GetDemand(long id)
        {
            Demand myDemand = DataFactory.getDemandById(id);

            return Ok(DTOFactory.getDemandConfigDTO( myDemand) );
        }

    }
}