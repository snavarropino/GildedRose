namespace GildedRoseKata
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public bool SellingDateReached => SellIn < 0;
        public bool MaxQualityReached => Quality == 50;

        public void IncreaseQuality() => Quality += 1;
        public void DecreaseSellIn() => SellIn -= 1;

        public void DecreaseQuality() => Quality -= 1;
    }
}