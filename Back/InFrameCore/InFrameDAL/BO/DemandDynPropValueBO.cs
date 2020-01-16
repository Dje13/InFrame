using System;
using System.Collections.Generic;
using System.Text;
using InFrameInterfaces.ObjWithDynProp;
namespace InFrameDAL.Models
{
    public partial class DemandDynPropValue:IObjDynPropValue
    {
        public string getValueType()
        {
            return this.DynProp.DynPropType;
        }
    }
}
