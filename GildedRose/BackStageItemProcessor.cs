namespace GildedRoseKata;

public class BackStageItemProcessor 
{
    public Item Item { get; }

    public BackStageItemProcessor(Item item) => Item = item;
    public void Process()
    {
        if (Item.Quality < 50)
        {
            Item.Quality += 1;

            if (Item.SellIn < 11)
            {
                if (Item.Quality < 50)
                {
                    Item.Quality += 1;
                }
            }

            if (Item.SellIn < 6)
            {
                if (Item.Quality < 50)
                {
                    Item.Quality += 1;
                }
            }
        }

        Item.SellIn -= 1;

        if (Item.SellingDateReached)
        {
            Item.Quality -= Item.Quality;
        }
    }
}