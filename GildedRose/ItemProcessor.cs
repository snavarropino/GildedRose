namespace GildedRoseKata;

internal class ItemProcessor
{
    public Item Item { get; }

    public ItemProcessor(Item item) => Item = item;

    public void Process()
    {
        if (Item.Quality > 0)
        {
            Item.Quality -= 1;
        }

        Item.SellIn = Item.SellIn - 1;

        if (Item.SellingDateReached)
        {
            if (Item.Quality > 0)
            {
                Item.Quality -= 1;
            }
        }
    }
}