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
    
    public partial class Nocleg
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nocleg()
        {
            this.Pokoje = new HashSet<Pokoje>();
        }
    
        public int ID { get; set; }
        public string Adres { get; set; }
        public string Standard { get; set; }
        public int MiejsceID { get; set; }
        public int MiejsceID1 { get; set; }
    
        public virtual Miejsce Miejsce { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pokoje> Pokoje { get; set; }
    }
}
