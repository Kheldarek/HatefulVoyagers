﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BiuroPodrozyContainer : DbContext
    {
        public BiuroPodrozyContainer()
            : base("name=BiuroPodrozyContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<OsobyTowarzyszace> OsobyTowarzyszaceSet { get; set; }
        public virtual DbSet<Klient> KlientSet { get; set; }
        public virtual DbSet<Program> ProgramSet { get; set; }
        public virtual DbSet<PunktWyjazdu> PunktWyjazduSet { get; set; }
        public virtual DbSet<Rezerwacje> RezerwacjeSet { get; set; }
        public virtual DbSet<Oferta> OfertaSet { get; set; }
        public virtual DbSet<Miejsce> MiejsceSet { get; set; }
        public virtual DbSet<Nocleg> NoclegSet { get; set; }
        public virtual DbSet<Pokoje> PokojeSet { get; set; }
        public virtual DbSet<Uzytkownik> UzytkownikSet { get; set; }
        public virtual DbSet<HistoriaRezerwacji> HistoriaRezerwacjiSet { get; set; }
        public virtual DbSet<Opinie> OpinieSet { get; set; }
    }
}
