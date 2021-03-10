using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InFrameInterfaces;
namespace InFrameDAL.Models
{
    public partial class TicketFormGroup:IFormGroup
    {
        public List<ITicketFormField> GetFormFields()
        {
            return this.TicketFormField.Select(s=>(ITicketFormField) s).ToList();
        }

    }
}
