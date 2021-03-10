using System;
using System.Collections.Generic;
using System.Text;

namespace InFrameInterfaces
{
    public interface IFormGroup
    {

        public long Id { get; set; }
        public long FormConfigId { get; set; }
        public string Title { get; set; }
        public int ColumnIndex { get; set; }
        public int GroupOrder { get; set; }
        public bool Active { get; set; }
        public string CssClass { get; set; }
        public int Behavior { get; set; }

        public List<ITicketFormField> GetFormFields();


    }
}
