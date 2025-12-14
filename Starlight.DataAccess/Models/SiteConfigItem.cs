namespace Starlight.DataAccess.Models
{
    public class SiteConfigItem
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
