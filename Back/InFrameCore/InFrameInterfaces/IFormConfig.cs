using System;
using System.Collections.Generic;
using System.Text;

namespace InFrameInterfaces
{
    public interface IFormConfig
    {
        public long Id { get; set; }
        public string FormNature { get; set; }
        public string Title { get; set; }
        public int ColumnNumber { get; set; }
        public bool Active { get; set; }
        public string ValidationMessage { get; set; }
        public string CssClass { get; set; }
        public int Behavior { get; set; }

        public List<IFormGroup> GetFormGroups();



    }
}
