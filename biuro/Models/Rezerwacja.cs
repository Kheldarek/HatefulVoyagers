using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace biuro.Models
{
    public class Rezerwacja
    {
        [Required]
        public Klient klient { get; set; }
        [Required]
        public Nocleg nocleg { get; set; }
        [Required]
        public Pokoje pokoj { get; set; }
        [Required]
        public int oferta { get; set; }
        public List<OsobyTowarzyszace> osoby {get; set;}
        public int liczba_osob { get; set; }
    }
}