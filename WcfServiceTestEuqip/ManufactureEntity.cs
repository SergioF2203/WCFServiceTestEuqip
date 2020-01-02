namespace WcfServiceTestEuqip
{
    using System.Collections.Generic;
    
    public partial class ManufactureEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ManufactureEntity()
        {
            this.Equip = new HashSet<EquipEntity>();
        }
    
        public int Id { get; set; }
        public string ManufName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipEntity> Equip { get; set; }
    }
}
