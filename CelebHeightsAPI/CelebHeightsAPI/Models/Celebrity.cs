namespace CelebHeightsAPI.Models
{
    namespace CelebHeightsAPI.Models
    {
        public class Celebrity
        {
            public Guid Id { get; set; }
            public string FullName { get; set; }
            public int HeightCm { get; set; }
            public byte[] ImageUrl { get; set; }
        }
    }

}
