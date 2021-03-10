using System;
using System.Collections.Generic;
using System.Linq;
using InFrameDAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InFrameDAL
{
    public static class DataFactory
    {

        #region "Form Management"
        public static TicketFormConfig getTicketFormConfigById(long id)
        {
            TicketFormConfig Result;
            using (InFrameContext db = new InFrameContext())
            {
                Result = db.TicketFormConfig.Include("TicketFormGroup").Include("TicketFormGroup.TicketFormField")
                    .Where(s => s.Id == id && s.Active).FirstOrDefault();
            }
            return Result;
        }

        public static TicketFormConfig getFormConfigByDemandType(long id)
        {
            TicketFormConfig Result;
            using (InFrameContext db = new InFrameContext())
            {
                Result = db.TicketFormConfig.Include("TicketFormGroup").Include("TicketFormGroup.FormField")
                    .Where(s => s.Active).FirstOrDefault();
            }
            return Result;
        }

        public static List<TicketFormConfig> getTicketFormConfigList()
        {
            List<TicketFormConfig> Result;
            using (InFrameContext db = new InFrameContext())
            {
                Result = db.TicketFormConfig.Where(s => s.Active).ToList();
            }
            return Result;
        }

        public static List<string> getFormTypes()
        {
            List<string> Result;
            using (InFrameContext db = new InFrameContext())
            {
                Result = db.TicketFormConfig.Where(s => s.Active).Select(y => y.Title).Distinct().ToList();//.Select(x => new SelectListItem { Value = x.FormNature, Text = x.FormNature});
                // Result = db.TicketFormConfig.Select(y => y.Title).Distinct().ToList();//.Select(x => new SelectListItem { Value = x.FormNature, Text = x.FormNature});
            }
            return Result;
        }

        public static List<TicketType> getTicketTypes()
        {
            List<TicketType> Result;
            using (InFrameContext db = new InFrameContext())
            {
                Result = db.TicketType.Where(s => s.Active ==1).ToList();
            }
            return Result;
        }

        
        #endregion


        #region "Ticket Management"

        public static List<Ticket> getTicketList(long typeId = -1)
        {

            List<Ticket> Result;
            using (InFrameContext db = new InFrameContext())
            {
                if (typeId == -1)
                {
                    Result = db.Ticket.ToList();
                }
                else
                {
                    Result = db.Ticket.Where(t=>t.TypeId == typeId).ToList();
                }
                
            }
            return Result;
        }

        public static Ticket getTicket(int id)
        {

            Ticket Result;
            using (InFrameContext db = new InFrameContext())
            {
                Result = db.Ticket.Where(x => x.Id == id).FirstOrDefault();
            }
            return Result;
        }

        public static void AddTicket(Ticket ticket)
        {

            using (InFrameContext db = new InFrameContext())
            {
                db.Ticket.Add(ticket);
                db.SaveChanges();
            }
        }

        #endregion


    }
}
