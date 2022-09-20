using FluentAssertions;
using Kneedle.Extensions;
using Kneedle.Unit.TestModels;

namespace Kneedle.Unit;

public class KneedleAlgorithmTests
{
    List<ProbabilisticItem> testItems;

    public KneedleAlgorithmTests()
    {
        testItems = new List<ProbabilisticItem>();
        var random = new Random(41);
        testItems.AddRange(Enumerable.Range(1, 45).Select(i =>
             new ProbabilisticItem((float)random.Next(1, 100) / 100, $"item {i}")
        ));
    }

    [Fact]
    public void Should_retuen_items_after_the_knee_point()
    {
        var classifiedItems = testItems.GetItemsAfterFirstKneeValue();
        classifiedItems.Should().HaveCount(i => i > 0);
    }
    [Fact]
    public void Should_retuen_item_if_only_one()
    {
        var onlyItemName = "only item";
        var items = new List<ProbabilisticItem> { new ProbabilisticItem(0.1f, onlyItemName) };
        var classifiedItems = items.GetItemsAfterFirstKneeValue();
        classifiedItems.Should().HaveCount(1);
        classifiedItems.Single().Name.Should().Be(onlyItemName);
    }

    [Fact]
    public void Should_retuen_all_items_if_probabilities_are_the_same()
    {
        var items = new List<ProbabilisticItem>
        {
            new ProbabilisticItem(0.1f, "only item"),
            new ProbabilisticItem(0.1f, "only item")
        };
        var classifiedItems = items.GetItemsAfterFirstKneeValue();
        classifiedItems.Should().HaveCount(2);
    }
}
