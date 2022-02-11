namespace GildedRoseKata
{
    public class Item
    {
        public Item(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public string Name { get; }
        public int SellIn { get; private set; }
        public int Quality { get; private set; }

        public bool SellingDateReached => SellIn < 0;
        public bool MaxQualityReached => Quality == 50;

        public void IncreaseQuality()
        {
            if (MaxQualityReached) return;
            Quality += 1;
        }

        public void DecreaseQuality()
        {
            if (Quality > 0)
                Quality -= 1;
        }

        public void ResetQuality() => Quality = 0;

        public void DecreaseSellIn() => SellIn -= 1;
    }
}