using System;
using System.Collections.Generic;

namespace InFrameDAL.Models
{
    public partial class DemandDynProp
    {
        public DemandDynProp()
        {
            DemandDynPropValue = new HashSet<DemandDynPropValue>();
            DemandDynPropValueHisto = new HashSet<DemandDynPropValueHisto>();
            DemandTypeDemandDynProp = new HashSet<DemandTypeDemandDynProp>();
        }

        public long Id { get; set; }
        public string DemandDynPropName { get; set; }
        public string DynPropType { get; set; }
        public int Active { get; set; }

        public virtual ICollection<DemandDynPropValue> DemandDynPropValue { get; set; }
        public virtual ICollection<DemandDynPropValueHisto> DemandDynPropValueHisto { get; set; }
        public virtual ICollection<DemandTypeDemandDynProp> DemandTypeDemandDynProp { get; set; }
    }
}
