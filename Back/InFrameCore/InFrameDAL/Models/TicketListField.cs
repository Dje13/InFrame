using System;
using System.Collections.Generic;

namespace InFrameDAL.Models
{
    public partial class TicketListField
    {
        public long Id { get; set; }
        public long? TypeId { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public string FilterType { get; set; }
        public string FieldLabel { get; set; }
        public int? Width { get; set; }
        public bool IsDynamic { get; set; }
        public string FilterParameters { get; set; }
        public int FieldOrder { get; set; }
        public bool Active { get; set; }
        public string CssClass { get; set; }

        public virtual TicketType Type { get; set; }
    }
}
