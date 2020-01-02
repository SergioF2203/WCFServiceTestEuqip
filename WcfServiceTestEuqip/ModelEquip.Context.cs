namespace WcfServiceTestEuqip
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EquipmentsEntities : DbContext
    {
        public EquipmentsEntities()
            : base("name=EquipmentsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DeptEntity> Depts { get; set; }
        public virtual DbSet<EquipEntity> Equip { get; set; }
        public virtual DbSet<ManufactureEntity> Manufactures { get; set; }
    }
}
