﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HarlemErpDataModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DataModelEntities : DbContext
    {
        public DataModelEntities()
            : base("name=DataModelEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<clientes> clientes { get; set; }
        public DbSet<config> config { get; set; }
        public DbSet<estados> estados { get; set; }
        public DbSet<estoque> estoque { get; set; }
        public DbSet<marcas> marcas { get; set; }
        public DbSet<municipios> municipios { get; set; }
        public DbSet<precos> precos { get; set; }
        public DbSet<produtos> produtos { get; set; }
        public DbSet<produtoscategoria> produtoscategoria { get; set; }
        public DbSet<usuarios> usuarios { get; set; }
        public DbSet<vendas> vendas { get; set; }
        public DbSet<vendasproduto> vendasproduto { get; set; }
    }
}
