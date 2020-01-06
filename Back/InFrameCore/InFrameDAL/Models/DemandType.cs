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
        public string DemandTypeName { get; set; }
        public string DemandTypeInternalName { get; set; }
        public string DemandTypeShortName { get; set; }
        public string DemandTypeDescription { get; set; }
        public string Icon { get; set; }
        public int WorkflowState { get; set; }
        public long WorkflowId { get; set; }

        public virtual WorkFlow Workflow { get; set; }
        public virtual ICollection<Demand> Demand { get; set; }
        public virtual ICollection<DemandTypeDemandDynProp> DemandTypeDemandDynProp { get; set; }
    }
}
