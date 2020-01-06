using System;
using System.Collections.Generic;

namespace InFrameDAL.Models
{
    public partial class Form
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int ColumnNumber { get; set; }
        public bool Active { get; set; }
        public int Behavior { get; set; }
    }
}
