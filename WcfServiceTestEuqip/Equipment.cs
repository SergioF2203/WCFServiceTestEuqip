namespace WcfServiceTestEuqip
{
    public class Equipment
    {
        public int Id { get; set; }
        public int? ManId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string PartNumber { get; set; }
        public string SerialNumber { get; set; }
        public decimal? Price { get; set; }
        public int? DepId { get; set; }
        public string DateIn { get; set; }
    }
}