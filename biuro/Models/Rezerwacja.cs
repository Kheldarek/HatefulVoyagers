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
        public Klient klient;
        [Required]
        public Nocleg nocleg;
        [Required]
        public Pokoje pokoj;
    }
}