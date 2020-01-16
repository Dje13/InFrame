using System;
using System.Collections.Generic;

namespace InFrameDAL.Models
{
    public partial class DemandTypeDemandDynProp
    {
        public long Id { get; set; }
        public long DynPropId { get; set; }
        public long TypeId { get; set; }
        public int Active { get; set; }

        public virtual DemandDynProp DynProp { get; set; }
        public virtual DemandType Type { get; set; }
    }
}
