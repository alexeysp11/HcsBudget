namespace HcsBudget.Models
{
    public class Hcs 
    {
        public int HcsId { get; private set; }
        public float Qty { get; private set; }
        public float PriceUsd { get; private set; }
        public int PeriodId { get; private set; }

        public Hcs(int hcsId, float qty, float priceUsd, int periodId)
        {
            HcsId = hcsId; 
            Qty = qty; 
            PriceUsd = priceUsd; 
            PeriodId = periodId; 
        }
    }
}