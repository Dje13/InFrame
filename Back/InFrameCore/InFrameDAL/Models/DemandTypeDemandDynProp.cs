using System;
using System.Collections.Generic;

namespace InFrameDAL.Models
{
    public partial class DemandTypeDemandDynProp
    {
        public long Id { get; set; }
        public long DemandDynPropId { get; set; }
        public long DemandTypeId { get; set; }
        public int Active { get; set; }

        public virtual DemandDynProp DemandDynProp { get; set; }
        public virtual DemandType DemandType { get; set; }
    }
}
