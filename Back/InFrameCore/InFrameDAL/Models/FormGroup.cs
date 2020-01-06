using System;
using System.Collections.Generic;

namespace InFrameDAL.Models
{
    public partial class FormGroup
    {
        public long Id { get; set; }
        public long FormId { get; set; }
        public int ColumnIndex { get; set; }
        public int GroupOrder { get; set; }
        public bool Active { get; set; }
        public int Behavior { get; set; }
    }
}
