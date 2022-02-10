namespace GildedRoseKata;

public class BackStageItemProcessor : ItemProcessorBase
{
    public BackStageItemProcessor(Item item) : base(item)
    {
    }

    public override void Process()
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

        DecreaseSellIn();

        if (Item.SellingDateReached)
        {
            Item.Quality -= Item.Quality;
        }
    }
}