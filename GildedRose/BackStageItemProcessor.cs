namespace GildedRoseKata;

public class BackStageItemProcessor : ItemProcessorBase
{
    public BackStageItemProcessor(Item item) : base(item)
    {
    }

    public override void Process()
    {
        Item.IncreaseQuality();

        if (TenOrLessDaysLeft())
        {
            Item.IncreaseQuality();
        }

        if (FiveOrLessDaysLeft())
        {
            Item.IncreaseQuality();
        }

        Item.DecreaseSellIn();

        if (Item.SellingDateReached)
        {
            Item.ResetQuality();
        }
    }

    private bool FiveOrLessDaysLeft() => Item.SellIn <= 5;

    private bool TenOrLessDaysLeft() => Item.SellIn <= 10;
}