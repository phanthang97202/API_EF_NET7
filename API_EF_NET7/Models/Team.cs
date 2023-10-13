namespace API_EF_NET7.Models
{
    public class Team
    {
        public int TeamId { set; get; }
        public required string CountryName { set; get; }
        public int ConfederationId { set; get; }
        public Confederation? Confederation { set; get; }
    }
}
