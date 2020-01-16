using System;
using System.Collections.Generic;
using System.Text;
using NetTopologySuite.Geometries;

namespace InFrameInterfaces.ObjWithDynProp
{
    public interface IObjDynPropValue
    {

        public long Id { get; set; }
        public DateTime ChangeDate { get; set; }
        public string ValueString { get; set; }
        public long? ValueInt { get; set; }
        public DateTime? ValueDate { get; set; }
        public double? ValueReal { get; set; }
        public decimal? ValueDecimal { get; set; }
        public Geometry ValueGeom { get; set; }
        public string getValueType();


    }
}
