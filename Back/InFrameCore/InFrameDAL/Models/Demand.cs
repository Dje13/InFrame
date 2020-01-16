using System;
using System.Collections.Generic;

namespace InFrameDAL.Models
{
    public partial class Demand
    {
        public Demand()
        {
            DemandDynPropValue = new HashSet<DemandDynPropValue>();
            DemandDynPropValueHisto = new HashSet<DemandDynPropValueHisto>();
            DemandTransitionHisto = new HashSet<DemandTransitionHisto>();
        }

        public long Id { get; set; }
        public long WorkFlowId { get; set; }
        public long TypeId { get; set; }
        public long WorkflowStateId { get; set; }
        public string Author { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual DemandType Type { get; set; }
        public virtual WorkFlow WorkFlow { get; set; }
        public virtual WorkflowState WorkflowState { get; set; }
        public virtual ICollection<DemandDynPropValue> DemandDynPropValue { get; set; }
        public virtual ICollection<DemandDynPropValueHisto> DemandDynPropValueHisto { get; set; }
        public virtual ICollection<DemandTransitionHisto> DemandTransitionHisto { get; set; }
    }
}
