using System;
using System.Collections.Generic;

namespace InFrameDAL.Models
{
    public partial class Modalist
    {
        public long Id { get; set; }
        public string ModalistGroup { get; set; }
        public int ModalistRang { get; set; }
        public string ModalistLabel { get; set; }
        public string ModalistAbrev { get; set; }
        public int? ModalistOrdreAffichage { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
