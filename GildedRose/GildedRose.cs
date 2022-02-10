using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
    public const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
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

        if (item.Name.Equals(AgedBrie))
        {
            new AgedBrieProcessor(item).Process();
            return;
        }

        if (item.Name.Equals(SulfurasHandOfRagnaros))
        {
            return;
        }

        if (item.Quality > 0)
        {
            item.Quality -= 1;
        }

        DecreaseSellIn(item);

        if (item.SellingDateReached)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }
        }
    }

    private static void DecreaseSellIn(Item item)
    {
        item.SellIn = item.SellIn - 1;
    }
}