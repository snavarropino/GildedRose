using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
    public const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
    private const string AgedBrie = "Aged Brie";
    readonly IList<Item> _items;
    public GildedRose(IList<Item> items) => _items = items;

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            ProcessItem(item);
        }
    }

    private static void ProcessItem(Item item)
    {
        var processor = GetProcessor(item);
        processor.Process();
    }

    private static ItemProcessorBase GetProcessor(Item item)
    {
        var processors = new Dictionary<string, ItemProcessorBase>
        {
            {BackstagePasses, new BackStageItemProcessor(item)},
            {AgedBrie, new AgedBrieProcessor(item)},
            {SulfurasHandOfRagnaros, new SulfurasHandOfRagnarosProcessor(item)},
        };

        if (processors.TryGetValue(item.Name, out var processor))
        {
            return processor;
        }

        return new ItemProcessor(item);
    }
}