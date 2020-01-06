using System;
using System.Collections.Generic;

namespace InFrameDAL.Models
{
    public partial class DemandDynProp
    {
        public DemandDynProp()
        {
            DemandTypeDemandDynProp = new HashSet<DemandTypeDemandDynProp>();
            ValueDemandDynProp = new HashSet<ValueDemandDynProp>();
            ValueDemandDynPropHisto = new HashSet<ValueDemandDynPropHisto>();
        }

        public long Id { get; set; }
        public string DemandDynPropName { get; set; }
        public string DemandType { get; set; }
        public int WorkflowState { get; set; }

        public virtual ICollection<DemandTypeDemandDynProp> DemandTypeDemandDynProp { get; set; }
        public virtual ICollection<ValueDemandDynProp> ValueDemandDynProp { get; set; }
        public virtual ICollection<ValueDemandDynPropHisto> ValueDemandDynPropHisto { get; set; }
    }
}
