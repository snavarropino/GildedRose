using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
    private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
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
        if (item.Name != AgedBrie && item.Name != BackstagePasses)
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

                if (item.Name == BackstagePasses)
                {
                    if (item.SellIn < 11)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }

                    if (item.SellIn < 6)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }
            }
        }

        if (item.Name != SulfurasHandOfRagnaros)
        {
            item.SellIn = item.SellIn - 1;
        }

        if (item.SellIn < 0)
        {
            if (item.Name != AgedBrie)
            {
                if (item.Name != BackstagePasses)
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
                    item.Quality = item.Quality - item.Quality;
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
}