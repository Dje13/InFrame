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
        public static TicketFormConfigDTO GetTicketFormConfigDTO(ITicketFormConfig myConfig, long WorkflowStateId)
        {
            TicketFormConfigDTO result = new TicketFormConfigDTO();

            ToolBox.MapObject(myConfig, result, true);
            result.formGroups = new List<TicketFormGroupDTO>();
            foreach (ITicketFormGroup curGroup in myConfig.GetFormGroups().Where(g=>g.Active).OrderBy(s=>s.GroupOrder))
            {
                result.formGroups.Add(GetFormGroupDTO(curGroup, WorkflowStateId));
            }
            return result;
        }


        public static List<TicketFormConfigDTO> GetTicketFormConfigListDTO(IEnumerable<ITicketFormConfig> listForm)
        {
            List<TicketFormConfigDTO> result = new List<TicketFormConfigDTO>();

            foreach (ITicketFormConfig formulaire in listForm)
            {
                TicketFormConfigDTO resultTemp = new TicketFormConfigDTO();

                ToolBox.MapObject(formulaire, resultTemp, true);
                resultTemp.formGroups = null;

                result.Add(resultTemp);
            }
        
            return result;
        }

        //public static List<ITicket> GetTicketListDTO(IEnumerable<ITicket> listTickets)
        //{
        //    List<ITicket> result = new List<ITicket>();

        //    foreach (ITicket ticket in listTickets)
        //    {
        //        ITicket resultTemp = new ITicket();

        //        ToolBox.MapObject(ticket, resultTemp, true);

        //        result.Add(resultTemp);
        //    }

        //    return result;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myGroup"></param>
        /// <param name="WorkflowStateId"></param>
        /// <returns></returns>
        public static TicketFormGroupDTO GetFormGroupDTO(ITicketFormGroup myGroup, long WorkflowStateId)
        {
            TicketFormGroupDTO result = new TicketFormGroupDTO();
            List<string> unMappedField = new List<string> { "fieldParameters" };
            ToolBox.MapObject(myGroup, result, true);
            result.formFields = new List<TicketFormFieldDTO>();
            foreach (ITicketFormField curField in myGroup.GetFormFields().Where(f=>f.WorkflowStateId == WorkflowStateId || f.WorkflowStateId == null) .OrderBy(f => f.WorkflowStateId))
            {
                if (result.formFields.Where(s => s.FieldName == curField.FieldName && s.Active).FirstOrDefault() == null) // Check field not already defined
                {
                    TicketFormFieldDTO curFieldDTO = new TicketFormFieldDTO();
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
