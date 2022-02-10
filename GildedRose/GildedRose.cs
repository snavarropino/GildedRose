using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
    public  const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
    private const string AgedBrie = "Aged Brie";
    readonly IList<Item> _items;
    public GildedRose(IList<Item> Items) => this._items = Items;

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            ProcessItem(item);
        }
    }

    private static void ProcessItem(Item item)
    {
        if (item.Name.Equals(BackstagePasses))
        {
            new BackStageItemProcessor(item).Process();
            return;
        }

        if (item.Name != AgedBrie)
        {
            if (item.Quality > 0)
            {
                if (item.Name != SulfurasHandOfRagnaros)
                {
                    item.Quality = item.Quality - 1;
                }
            }
        }
        else
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }

        DecreaseSellIn(item);

        if (item.SellingDateReached)
        {
            if (item.Name != AgedBrie)
            {
                if (item.Quality > 0)
                {
                    if (item.Name != SulfurasHandOfRagnaros)
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }
        }
    }

    private static void DecreaseSellIn(Item item)
    {
        if (item.Name != SulfurasHandOfRagnaros)
        {
            item.SellIn = item.SellIn - 1;
        }
    }
}