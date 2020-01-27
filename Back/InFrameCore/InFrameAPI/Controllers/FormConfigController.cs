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
        [ResponseType(typeof(FormConfigDTO))]
        public ActionResult GetFormConfig(long id, [FromUri] long workFlowStateId = -1)
        {
            FormConfig myConfig = DataFactory.getFormConfigById(id);
            return this.getFormConfigDTO(myConfig, workFlowStateId);
        }


        [Microsoft.AspNetCore.Mvc.HttpGet("DemandType/{id}")]
        [ResponseType(typeof(FormConfigDTO))]
        public ActionResult GetFormConfigFromFormType(long id, [FromUri] long workFlowStateId = -1)
        {

            FormConfig myConfig = DataFactory.getFormConfigByDemandType(id); 

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

        [Microsoft.AspNetCore.Mvc.HttpGet("List")]
        [ResponseType(typeof(List<FormConfigDTO>))]
        public ActionResult GetFormConfigList()
        {
            List<FormConfig> listForm = DataFactory.getFormConfigList();
            return this.getFormConfigListDTO(listForm);
        }

        protected ActionResult getFormConfigListDTO(List<FormConfig> myConfig)
        {
            if (myConfig == null)
            {
                return NotFound();
            }
            
            return Ok(DTOCreator.GetFormConfigListDTO(myConfig));
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