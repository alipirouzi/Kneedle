using Kneedle.Abstractions;

namespace Kneedle.Extensions;

public static class KneedleAlgorithmExtensions
{
    public static IEnumerable<T> GetItemsAfterFirstKneeValue<T>(this IEnumerable<T> setItems) where T : IProbabilistic
    {
        return KneedleAlgorithm.ClusterByKneedle(setItems);
    }
}