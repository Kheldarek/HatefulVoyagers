//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace biuro
{
    using System;
    using System.Collections.Generic;
    
    public partial class OsobyTowarzyszace
    {
        public int ID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public System.DateTime DataUrodzenia { get; set; }
        public int RezerwacjeID { get; set; }
    
        public virtual Rezerwacje Rezerwacje { get; set; }
    }
}