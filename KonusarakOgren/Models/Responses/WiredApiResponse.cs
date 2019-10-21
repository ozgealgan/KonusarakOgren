namespace KonusarakOgren.Models.Responses
{
    public class WiredApiResponse
    {
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public Article[] Articles { get; set; }
    }
}
