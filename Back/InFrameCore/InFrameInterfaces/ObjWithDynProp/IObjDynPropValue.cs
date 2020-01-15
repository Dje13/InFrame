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
        public string StringValue { get; set; }
        public long? IntValue { get; set; }
        public DateTime? DateValue { get; set; }
        public double? RealValue { get; set; }
        public decimal? DecimalValue { get; set; }
        public Geometry GeomValue { get; set; }


    }
}
