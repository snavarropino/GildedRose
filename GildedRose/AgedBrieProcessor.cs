namespace GildedRoseKata;

public class AgedBrieProcessor: ItemProcessorBase
{
    public AgedBrieProcessor(Item item) : base(item)
    {
    }

    public override void Process()
    {
        if (Item.Quality < 50)
        {
            Item.Quality += 1;
        }
        DecreaseSellIn();

        if (Item.SellingDateReached)
        {
            
            if (Item.Quality < 50)
            {
                Item.Quality += 1;
            }
        }
    }
}