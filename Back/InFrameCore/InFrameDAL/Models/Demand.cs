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
        }

        public long Id { get; set; }
        public long WorkFlowId { get; set; }
        public long DemandTypeid { get; set; }
        public long WorkflowStateId { get; set; }
        public string Author { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual DemandType DemandType { get; set; }
        public virtual WorkFlow WorkFlow { get; set; }
        public virtual WorkflowState WorkflowState { get; set; }
        public virtual ICollection<DemandDynPropValue> DemandDynPropValue { get; set; }
        public virtual ICollection<DemandDynPropValueHisto> DemandDynPropValueHisto { get; set; }
    }
}
