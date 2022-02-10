namespace GildedRoseKata;

public class AgedBrieProcessor
{
    public Item Item { get; }

    public AgedBrieProcessor(Item item) => Item = item;

    public void Process()
    {
        if (Item.Quality < 50)
        {
            Item.Quality += 1;
        }
        Item.SellIn -= 1;

        if (Item.SellingDateReached)
        {
            
            if (Item.Quality < 50)
            {
                Item.Quality += 1;
            }
        }
    }
}