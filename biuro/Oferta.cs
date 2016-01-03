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
    
    public partial class Oferta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Oferta()
        {
            this.Rezerwacje = new HashSet<Rezerwacje>();
        }
    
        public int ID { get; set; }
        public decimal Cena { get; set; }
        public System.DateTime DataWyjazdu { get; set; }
        public System.DateTime DataPowrotu { get; set; }
        public int ProgramID { get; set; }
        public int PunktWyjazduID { get; set; }
        public int MiejsceID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rezerwacje> Rezerwacje { get; set; }
        public virtual Program Program { get; set; }
        public virtual PunktWyjazdu PunktWyjazdu { get; set; }
        public virtual Miejsce Miejsce { get; set; }
    }
}