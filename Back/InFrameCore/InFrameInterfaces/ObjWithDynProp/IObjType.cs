using System;
using System.Collections.Generic;
using System.Text;
using InFrameInterfaces.WorlFlow;
namespace InFrameInterfaces.ObjWithDynProp
{
    public interface IObjType
    {

        public long Id { get; set; }
        public string TypeName { get; set; }
        public string TypeInternalName { get; set; }
        public string TypeShortName { get; set; }
        public string TypeDescription { get; set; }
        public string Icon { get; set; }
        public int Active { get; set; }

        public List<IDynProp> GetDynProps();

        public IWorkFlow GetWorkFlow();

    }
}
