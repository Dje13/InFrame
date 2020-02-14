using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InFrameInterfaces;
namespace InFrameDAL.Models
{
    public partial class TicketFormConfig: ITicketFormConfig
    {


        public List<ITicketFormGroup> GetFormGroups()
        {
            return this.TicketFormGroup.Select(s => (ITicketFormGroup)s).ToList();
        }
    }
}
