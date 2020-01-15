using System;
using System.Collections.Generic;
using System.Text;

namespace InFrameInterfaces.ObjWithDynProp
{
    public interface IDynProp
    {
        public long Id { get; set; }
        public string DynPropName { get; set; }
        public string DynPropType { get; set; }
        public int Active { get; set; }

    }
}
