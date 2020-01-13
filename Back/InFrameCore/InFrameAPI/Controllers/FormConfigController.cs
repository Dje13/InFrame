using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InFrameDAL;
using InFrameFormManager.DTO;
using InFrameDAL.Models;

using InFrameTools;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using InFrameFormManager;

namespace InFrameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormConfigController : ControllerBase
    {
        // Get one generic request by ID
        [HttpGet("{id}")]
        [ResponseType(typeof(FormConfigDTO))]
        public ActionResult GetFormConfig(long id)
        {
            FormConfig myConfig = DataFactory.GetFormConfigById(id);
            return getFormConfigDTO(DataFactory.GetFormConfigByDemandType(id),-1);
        }

        [HttpGet("DemandType/{id}")]
        [ResponseType(typeof(FormConfigDTO))]
        public ActionResult GetFormConfigFromFormType(long id)
        {
            return getFormConfigDTO(DataFactory.GetFormConfigByDemandType(id),-1);
        }

        protected ActionResult getFormConfigDTO(FormConfig myConfig,  long WorkflowStateId)
        {
            if (myConfig == null)
            {
                return NotFound();
            }
            return Ok(DTOCreator.GetFormConfigDTO(myConfig,  WorkflowStateId));
        }

    }
}