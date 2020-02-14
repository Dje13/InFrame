using InFrameInterfaces.ObjWithDynProp;
using InFrameInterfaces.WorlFlow;
using System;
using System.Collections.Generic;
using System.Text;

namespace InFrameDAL.Models
{
    public partial class TicketType : IObjType
    {

        public List<IDynProp> GetDynProps()
        {
            return null;
        }

        public IWorkFlow GetWorkFlow()
        {
            return this.Workflow;
        }

    }
}

