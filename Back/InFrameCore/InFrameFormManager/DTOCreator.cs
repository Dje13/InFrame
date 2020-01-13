using System;
using System.Collections.Generic;
using System.Linq;
using InFrameFormManager.DTO;
using InFrameInterfaces;
using InFrameTools;
using Newtonsoft.Json;

namespace InFrameFormManager
{
    /// <summary>
    /// 
    /// </summary>
    public static class DTOCreator
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myConfig"></param>
        /// <param name="WorkflowStateId"></param>
        /// <returns></returns>
        public static FormConfigDTO GetFormConfigDTO(IFormConfig myConfig, long WorkflowStateId)
        {
            FormConfigDTO result = new FormConfigDTO();

            ToolBox.MapObject(myConfig, result, true);
            result.formGroups = new List<FormGroupDTO>();
            foreach (IFormGroup curGroup in myConfig.GetFormGroups().Where(g=>g.Active).OrderBy(s=>s.GroupOrder))
            {
                result.formGroups.Add(GetFormGroupDTO(curGroup, WorkflowStateId));
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myGroup"></param>
        /// <param name="WorkflowStateId"></param>
        /// <returns></returns>
        public static FormGroupDTO GetFormGroupDTO(IFormGroup myGroup, long WorkflowStateId)
        {
            FormGroupDTO result = new FormGroupDTO();
            List<string> unMappedField = new List<string> { "fieldParameters" };
            ToolBox.MapObject(myGroup, result, true);
            result.formFields = new List<FormFieldDTO>();
            foreach (IFormField curField in myGroup.GetFormFields().Where(f=>f.WorkflowStateId == WorkflowStateId || f.WorkflowStateId == null) .OrderBy(f => f.WorkflowStateId))
            {
                if (result.formFields.Where(s => s.FieldName == curField.FieldName && s.Active).FirstOrDefault() == null) // Check field not already defined
                {
                    FormFieldDTO curFieldDTO = new FormFieldDTO();
                    ToolBox.MapObject(curField, curFieldDTO, unMappedField: unMappedField);
                    curFieldDTO.FieldParameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(curField.FieldParameters);
                    // TODO Ajouter les traitements pour les parameters
                    result.formFields.Add(curFieldDTO);
                }
            }
            return result;
        }

    }
}
