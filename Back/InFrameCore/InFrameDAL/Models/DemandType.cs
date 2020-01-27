using System;
using System.Collections.Generic;

namespace InFrameDAL.Models
{
    public partial class DemandType
    {
        public DemandType()
        {
            Demand = new HashSet<Demand>();
            DemandTypeDemandDynProp = new HashSet<DemandTypeDemandDynProp>();
        }

        public long Id { get; set; }
        public string TypeName { get; set; }
        public string TypeInternalName { get; set; }
        public string TypeShortName { get; set; }
        public string TypeDescription { get; set; }
        public string Icon { get; set; }
        public int Active { get; set; }
        public long WorkflowId { get; set; }

        public virtual WorkFlow Workflow { get; set; }
        public virtual ICollection<Demand> Demand { get; set; }
        public virtual ICollection<DemandTypeDemandDynProp> DemandTypeDemandDynProp { get; set; }
    }
}
