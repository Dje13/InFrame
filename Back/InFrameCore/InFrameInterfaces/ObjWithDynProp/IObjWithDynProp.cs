using System;
using System.Collections.Generic;
using System.Text;
using InFrameInterfaces.WorlFlow;
namespace InFrameInterfaces.ObjWithDynProp
{
    public interface IObjWithDynProp
    {

        public long Id { get; set; }
       

        public IObjType getType();

        public Dictionary<string, IObjDynPropValue> getValues(); 

        

    }
}
