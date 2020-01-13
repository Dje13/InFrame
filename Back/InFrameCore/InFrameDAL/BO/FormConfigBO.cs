using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InFrameInterfaces;
namespace InFrameDAL.Models
{
    public partial class FormConfig:IFormConfig
    {


        public List<IFormGroup> GetFormGroups()
        {
            return this.FormGroup.Select(s => (IFormGroup)s).ToList();
        }
    }
}
