using System;
using System.Collections.Generic;

namespace InFrameDAL.Models
{
    public partial class Demand
    {
        public Demand()
        {
            ValueDemandDynProp = new HashSet<ValueDemandDynProp>();
            ValueDemandDynPropHisto = new HashSet<ValueDemandDynPropHisto>();
        }

        public long Id { get; set; }
        public long EtatId { get; set; }
        public long WorkFlowId { get; set; }
        public long DemandTypeid { get; set; }
        public string Author { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual DemandType DemandType { get; set; }
        public virtual WorkFlow WorkFlow { get; set; }
        public virtual ICollection<ValueDemandDynProp> ValueDemandDynProp { get; set; }
        public virtual ICollection<ValueDemandDynPropHisto> ValueDemandDynPropHisto { get; set; }
    }
}
