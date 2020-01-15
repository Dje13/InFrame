using System;
using System.Collections.Generic;
using System.Text;
using InFrameInterfaces.ObjWithDynProp;
namespace InFrameFormManager
{
    public abstract class ObjWithDynProp : IObjWithDynProp
    {
        public abstract long Id { get; set; }
        public abstract long WorkFlowId { get; set; }
        public abstract long typeid { get; set; }
        public abstract long WorkflowStateId { get; set; }

        public abstract IObjType getType();
        public abstract List<IObjDynPropValue> getValues();

        public object this[string propName]
        {
            get { return null; }

        }
    }
}
