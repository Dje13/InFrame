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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InFrameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class FormConfigController : ControllerBase
    {
        // Get one generic request by ID


        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        [ResponseType(typeof(TicketFormConfigDTO))]
        public ActionResult GetFormConfig(long id, [FromUri] long workFlowStateId = -1)
        {
            TicketFormConfig myConfig = DataFactory.getTicketFormConfigById(id);
            return this.getTicketFormConfigDTO(myConfig, workFlowStateId);
        }


        [Microsoft.AspNetCore.Mvc.HttpGet("DemandType/{id}")]
        [ResponseType(typeof(TicketFormConfigDTO))]
        public ActionResult GetFormConfigFromFormType(long id, [FromUri] long workFlowStateId = -1)
        {
            TicketFormConfig myConfig = DataFactory.getFormConfigByDemandType(id); 

            return this.getTicketFormConfigDTO(myConfig, workFlowStateId);
        }

        protected ActionResult getTicketFormConfigDTO(TicketFormConfig myConfig,  long WorkflowStateId)
        {
            if (myConfig == null)
            {
                return NotFound();
            }
            return Ok(null);
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("List")]
        [ResponseType(typeof(List<TicketFormConfigDTO>))]
        public ActionResult GetTicketFormConfigList()
        {
            List<TicketFormConfig> listForm = DataFactory.getTicketFormConfigList();
            return Ok(this.getTicketFormConfigListDTO(listForm));
        }

        protected ActionResult getTicketFormConfigListDTO(List<TicketFormConfig> myConfig)
        {
            if (myConfig == null)
            {
                return NotFound();
            }
            
            return Ok(null);
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("FormTypes")]
        [ResponseType(typeof(List<string>))]
        public List<string> GetFormTypes()
        {
           List<string> formTypes = DataFactory.getFormTypes();
           return formTypes;
        }

    }
}