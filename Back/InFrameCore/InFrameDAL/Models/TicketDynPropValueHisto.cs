using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace InFrameDAL.Models
{
    public partial class TicketDynPropValueHisto
    {
        public long Id { get; set; }
        public long TicketId { get; set; }
        public long DynPropId { get; set; }
        public DateTime ChangeDate { get; set; }
        public string ValueString { get; set; }
        public long? ValueInt { get; set; }
        public DateTime? ValueDate { get; set; }
        public double? ValueReal { get; set; }
        public decimal? ValueDecimal { get; set; }
        public Geometry ValueGeom { get; set; }

        public virtual TicketDynProp DynProp { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
