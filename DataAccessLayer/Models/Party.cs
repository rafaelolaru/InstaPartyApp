namespace DataAccessLayer.Models
{
    public class Party
    {
        public Party()
        {
            Name = "default";
        }
        public int PartyId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}