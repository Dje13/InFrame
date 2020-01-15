using System;
using System.Collections.Generic;
using System.Text;
using InFrameInterfaces.WorlFlow;
namespace InFrameInterfaces.ObjWithDynProp
{
    public interface IObjWithDynProp
    {

        public long Id { get; set; }
        public long WorkFlowId { get; set; }
        public long typeid { get; set; }
        public long WorkflowStateId { get; set; }

        public IObjType getType();

        public List<IObjDynPropValue> getValues(); 

        

    }
}
