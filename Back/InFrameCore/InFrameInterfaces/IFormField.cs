using System;
using System.Collections.Generic;
using System.Text;

namespace InFrameInterfaces
{
    public interface ITicketFormField
    {

        public long Id { get; set; }
        public long FormGroupId { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public string FieldLabel { get; set; }
        public bool IsDynamic { get; set; }
        public string FieldParameters { get; set; }
        public int FieldOrder { get; set; }
        public string Tooltip { get; set; }
        public string DefaultValue { get; set; }
        public bool Active { get; set; }
        public long? WorkflowStateId { get; set; }
        public string CssClass { get; set; }
        public int Behavior { get; set; }

    }
}
