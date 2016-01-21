using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace biuro.Models
{
    public class History 
    {
        public string nazwa { get; set; }
        public decimal cena { get; set; }
        public string program { get; set; }
        public string opis { get; set; }
        public DateTime start { get; set; }
        public DateTime koniec { get; set; }
        public int MiejsceId { get; set; }

        public History() { }


    }
}