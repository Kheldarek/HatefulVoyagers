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
    
    public partial class Rezerwacje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rezerwacje()
        {
            this.OsobyTowarzyszace = new HashSet<OsobyTowarzyszace>();
        }
    
        public int ID { get; set; }
        public int KlientID { get; set; }
        public int PokojeID { get; set; }
        public int OfertaID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OsobyTowarzyszace> OsobyTowarzyszace { get; set; }
        public virtual Klient Klient { get; set; }
        public virtual Pokoje Pokoje { get; set; }
        public virtual Oferta Oferta { get; set; }
    }
}
