using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InFrameDAL;
using InFrameFormManager.DTO;
using InFrameDAL.Models;

using InFrameTools;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using InFrameFormManager;
using System.Web.Http.Description;
using System.Web.Http;
using Microsoft.AspNetCore.Cors;

namespace InFrameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class FormConfigController : ControllerBase
    {
        // Get one generic request by ID


        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        [ResponseType(typeof(FormConfigDTO))]
        public ActionResult GetFormConfig(long id, [FromUri] long workFlowStateId = -1)
        {
            FormConfig myConfig = DataFactory.GetFormConfigById(id);
            return this.getFormConfigDTO(myConfig, workFlowStateId);
        }


        [Microsoft.AspNetCore.Mvc.HttpGet("DemandType/{id}")]
        [ResponseType(typeof(FormConfigDTO))]
        public ActionResult GetFormConfigFromFormType(long id, [FromUri] long workFlowStateId = -1)
        {
            FormConfig myConfig = DataFactory.GetFormConfigByDemandType(id); 
            return this.getFormConfigDTO(myConfig, workFlowStateId);
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