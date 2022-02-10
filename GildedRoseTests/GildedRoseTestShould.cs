using Xunit;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GildedRoseKata;

namespace GildedRoseTests;
// [X] Al final de cada día, nuestro sistema decrementa ambos valores para cada artículo mediante el método updateQuality
// [X] Una vez que ha pasado la fecha recomendada de venta, la calidad se degrada al doble de velocidad
// [X] La calidad de un artículo nunca es negativa
// [X] La calidad de un artículo nunca es mayor a 50

// [X] El "Queso Brie envejecido" (Aged brie) incrementa su calidad a medida que se pone viejo.
//    Su calidad aumenta en 1 unidad cada día
// [X] El "Queso Brie envejecido" (Aged brie) incrementa su calidad a medida que se pone viejo.
//    luego de la fecha de venta su calidad aumenta 2 unidades por día
// [X] El artículo "Sulfuras" (Sulfuras), siendo un artículo legendario, no modifica su fecha de venta ni se degrada en calidad
// Una "Entrada al Backstage", incrementa su calidad a medida que la fecha de venta se aproxima.
    // [] si faltan 10 días o menos para el concierto, la calidad se incrementa en 2 unidades
    // [] si faltan 5 días o menos, la calidad se incrementa en 3 unidades
    // [] luego de la fecha de venta la calidad cae a 0
public class GildedRoseTestShould
{
    private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
    private const string AgedBrie = "Aged Brie";
    private const string RandomProduct = "Random Product";

    [Fact]
    public void decrement_quality()
    {
        var items = new List<Item> { new() { Name = RandomProduct, SellIn = 10, Quality = 10 } };
        new GildedRose(items).UpdateQuality();
        items.First().Quality.Should().Be(9);
    }

    [Fact]
    public void decrement_selling_date()
    {
        var items = new List<Item> { new() { Name = RandomProduct, SellIn = 10, Quality = 10 } };
        new GildedRose(items).UpdateQuality();
        items.First().SellIn.Should().Be(9);
    }

    [Fact]
    public void decrement_double_quality_after_selling_date_is_reached()
    {
        var items = new List<Item> { new() { Name = RandomProduct, SellIn = 0, Quality = 10 } };
        new GildedRose(items).UpdateQuality();
        items.First().Quality.Should().Be(8);
    }

    [Fact]
    public void not_decrement_quality_under_zero()
    {
        var items = new List<Item> { new() { Name = RandomProduct, SellIn = 0, Quality = 0 } };
        new GildedRose(items).UpdateQuality();
        items.First().Quality.Should().Be(0);
    }

    [Fact]
    public void not_increment_quality_over_50()
    {
        var items = new List<Item> { new() { Name = AgedBrie, SellIn = 10, Quality = 50 } };
        new GildedRose(items).UpdateQuality();
        items.First().Quality.Should().Be(50);
    }

    [Fact]
    public void increment_aged_brie_quality()
    {
        var items = new List<Item> { new() { Name = AgedBrie, SellIn = 10, Quality = 5 } };
        new GildedRose(items).UpdateQuality();
        items.First().Quality.Should().Be(6);
    }

    [Fact]
    public void increment_aged_brie_quality_by_two_if_selling_date_is_reached()
    {
        var items = new List<Item> { new() { Name = AgedBrie, SellIn = 0, Quality = 5 } };
        new GildedRose(items).UpdateQuality();
        items.First().Quality.Should().Be(7);
    }

    [Fact]
    public void not_modify_sulfuras_quality()
    {
        var items = new List<Item> { new() { Name = SulfurasHandOfRagnaros, SellIn = 6, Quality = 5 } };
        new GildedRose(items).UpdateQuality();
        items.First().Quality.Should().Be(5);
    }

    [Fact]
    public void not_modify_sulfuras_selling_date()
    {
        var items = new List<Item> { new() { Name = SulfurasHandOfRagnaros, SellIn = 6, Quality = 5 } };
        new GildedRose(items).UpdateQuality();
        items.First().SellIn.Should().Be(6);
    }

    [Fact]
    public void increment_backstage_ticket_quality()
    {
        var items = new List<Item> { new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 60, Quality = 5 } };
        new GildedRose(items).UpdateQuality();
        items.First().Quality.Should().Be(6);
    }

    [Fact]
    public void increment_backstage_ticket_quality_by_two_if_there_are_10_or_less_days_left_to_selling_date()
    {
        var items = new List<Item> { new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 5 } };
        new GildedRose(items).UpdateQuality();
        items.First().Quality.Should().Be(7);
    }

    [Fact]
    public void increment_backstage_ticket_quality_by_three_if_there_are_five_or_less_days_left_to_selling_date()
    {
        var items = new List<Item> { new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 5 } };
        new GildedRose(items).UpdateQuality();
        items.First().Quality.Should().Be(8);
    }

    [Fact]
    public void set_backstage_ticket_quality_to_zero_if_selling_date_is_reached()
    {
        var items = new List<Item> { new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 5 } };
        new GildedRose(items).UpdateQuality();
        items.First().Quality.Should().Be(0);
    }

    //[Fact]
    //public void ensure_inmutable_sulfuras_quality()
    //{
    //    var items = new List<Item> { new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 6, Quality = 90 } };
    //    new GildedRose(items).UpdateQuality();
    //    items.First().Quality.Should().Be(80);
    //}
}