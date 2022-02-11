namespace GildedRoseKata;

public class AgedBrieProcessor: ItemProcessorBase
{
    public AgedBrieProcessor(Item item) : base(item)
    {
    }

    public override void Process()
    {
        Item.IncreaseQuality();
        Item.DecreaseSellIn();
        if (Item.SellingDateReached)
        {
            Item.IncreaseQuality();
        }
    }
}