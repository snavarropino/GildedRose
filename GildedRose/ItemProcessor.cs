namespace GildedRoseKata;

public abstract class ItemProcessorBase
{
    public Item Item { get; }

    protected ItemProcessorBase(Item item) => Item = item;
    public abstract void Process();
}

public class ItemProcessor : ItemProcessorBase
{
    public ItemProcessor(Item item) : base(item)
    {
    }

    public override void Process()
    {
        if (Item.Quality > 0)
        {
            Item.DecreaseQuality();
        }

        Item.DecreaseSellIn();

        if (Item.SellingDateReached)
        {
            if (Item.Quality > 0)
            {
                Item.DecreaseQuality();
            }
        }
    }
}