using System;
using System.Collections.Generic;

namespace InFrameDAL.Models
{
    public partial class DemandDynPropValue
    {
        public long Id { get; set; }
        public long DemandId { get; set; }
        public long DemandDynPropId { get; set; }
        public DateTime? ChangeDate { get; set; }
        public string StringValue { get; set; }
        public long? IntValue { get; set; }
        public DateTime? DateValue { get; set; }
        public double? RealValue { get; set; }
        public decimal? DecimalValue { get; set; }

        public virtual Demand Demand { get; set; }
        public virtual DemandDynProp DemandDynProp { get; set; }
    }
}
