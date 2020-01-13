using System;
using System.Linq;
using InFrameDAL.Models;
using Microsoft.EntityFrameworkCore;

namespace InFrameDAL
{
    public static class DataFactory
    {
        public static FormConfig GetFormConfigById(long id)
        {
            FormConfig Result;
            using (InFrameContext db = new InFrameContext())
            {
                Result = db.FormConfig.Include("FormGroup").Include("FormGroup.FormField")
                    .Where(s => s.Id == id && s.Active).FirstOrDefault();
            }
            return Result;
        }

        public static FormConfig GetFormConfigByDemandType(long id)
        {
            FormConfig Result;
            using (InFrameContext db = new InFrameContext())
            {
                Result = db.FormConfig.Include("FormGroup").Include("FormGroup.FormField")
                    .Where(s => s.DemandTypeId == id && s.Active).FirstOrDefault();
            }
            return Result;
        }

    }
}
