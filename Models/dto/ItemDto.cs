using dumplingsOrderBackend.Interfaces;

namespace dumplingsOrderBackend.Models
{
    public class ItemDto: IBaseDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public int unit { get; set; }
        public int price { get; set; }
        public string memo { get; set; } 
    }
}