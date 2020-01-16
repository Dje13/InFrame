using System;
using System.Collections.Generic;
using System.Text;

using InFrameInterfaces.ObjWithDynProp;
using InFrameInterfaces.WorlFlow;

namespace InFrameDAL.Models
{
    public partial class DemandType:IObjType
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
