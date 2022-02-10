namespace GildedRoseKata;

public abstract class ItemProcessorBase
{
    public Item Item { get; }

    protected ItemProcessorBase(Item item) => Item = item;
    public abstract void Process();

    protected void DecreaseSellIn() => Item.SellIn -= 1;
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
            Item.Quality -= 1;
        }

        DecreaseSellIn();

        if (Item.SellingDateReached)
        {
            if (Item.Quality > 0)
            {
                Item.Quality -= 1;
            }
        }
    }
}