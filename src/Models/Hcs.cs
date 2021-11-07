namespace HcsBudget.Models
{
    public class Hcs 
    {
        public int HcsId { get; private set; }
        public string Name { get; private set; }
        public float Qty { get; private set; }
        public float PriceUsd { get; private set; }
        public string ParticipantName { get; private set; }
        public float TotalPrice { get; private set; }
        public int Month { get; private set; }
        public int Year { get; private set; }
        public int PeriodId { get; private set; }

        public Hcs(string name, float qty, float priceUsd, 
            string participantName, float totalPrice, int month, int year)
        {
            Name = name; 
            Qty = qty; 
            PriceUsd = priceUsd; 
            ParticipantName = participantName; 
            TotalPrice = totalPrice; 
            Month = month; 
            Year = year; 
        }
    }
}