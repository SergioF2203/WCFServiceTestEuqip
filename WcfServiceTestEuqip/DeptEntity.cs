
namespace WcfServiceTestEuqip
{
    using System;
    using System.Collections.Generic;
    
    public partial class DeptEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeptEntity()
        {
            this.Equip = new HashSet<EquipEntity>();
        }
    
        public int Id { get; set; }
        public string DeptName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipEntity> Equip { get; set; }
    }
}
