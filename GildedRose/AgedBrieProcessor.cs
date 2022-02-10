namespace GildedRoseKata;

public class AgedBrieProcessor: ItemProcessorBase
{
    public AgedBrieProcessor(Item item) : base(item)
    {
    }

    public override void Process()
    {
        if (!Item.MaxQualityReached)
        {
            Item.IncreaseQuality();
            
        }
        Item.DecreaseSellIn();

        if (Item.SellingDateReached)
        {
            if (!Item.MaxQualityReached)
            {
                Item.IncreaseQuality();
            }
        }
    }
}