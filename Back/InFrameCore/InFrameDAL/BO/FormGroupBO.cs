using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InFrameInterfaces;
namespace InFrameDAL.Models
{
    public partial class FormGroup:IFormGroup
    {
        public List<IFormField> GetFormFields()
        {
            return this.FormField.Select(s=>(IFormField) s).ToList();
        }

    }
}
