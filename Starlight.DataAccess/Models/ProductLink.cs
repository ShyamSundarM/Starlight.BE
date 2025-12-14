namespace Starlight.DataAccess.Models
{
    public class ProductLink
    {
        public int ProductLinkId { get; set; }
        public int ProductId { get; set; }
        public int PlatformId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
