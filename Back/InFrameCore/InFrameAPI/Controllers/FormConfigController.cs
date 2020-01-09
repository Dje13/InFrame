using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InFrameDAL.DTO;
using InFrameDAL.Models;

using InFrameTools;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

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
            FormConfigDTO Resultat = new FormConfigDTO();

            using (InFrameContext db = new InFrameContext())
            {
                FormConfig myConfig = db.FormConfig
                    .Where(s => s.Id == id).FirstOrDefault();
                if (myConfig == null)
                {
                    return NotFound();
                }
                ToolBox.MapObject(myConfig, Resultat,true);

            }
            return Ok(Resultat);
        }

        [HttpGet("DemandType/{id}")]
        [ResponseType(typeof(FormConfigDTO))]
        public ActionResult GetFormConfigFromFormType(long id)
        {
            FormConfigDTO Resultat = new FormConfigDTO();

            using (InFrameContext db = new InFrameContext())
            {
                FormConfig myConfig = db.FormConfig
                    .Where(s => s.DemandTypeId == id).FirstOrDefault();
                if (myConfig == null)
                {
                    return NotFound();
                }
                ToolBox.MapObject(myConfig, Resultat, true);

            }
            return Ok(Resultat);
        }


    }
}