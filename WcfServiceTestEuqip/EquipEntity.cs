namespace WcfServiceTestEuqip
{
    using System;
    using System.Collections.Generic;
    
    public partial class EquipEntity
    {
        public int Id { get; set; }
        public int? ManufacturesId { get; set; }
        public string EuqipName { get; set; }
        public string EuqipTitle { get; set; }
        public string EuqipPartNumber { get; set; }
        public string EquipSerialNumber { get; set; }
        public decimal? EquipPrice { get; set; }
        public int? DeptsId { get; set; }
        public string DateIn { get; set; }
    
        public virtual DeptEntity Depts { get; set; }
        public virtual ManufactureEntity Manufactures { get; set; }
    }
}
