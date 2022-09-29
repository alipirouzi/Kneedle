using Kneedle.Abstractions;

namespace Kneedle;

public static class KneedleAlgorithm
{
    public static IEnumerable<T> ClusterByKneedle<T>(IEnumerable<T> setItems) where T : IProbabilistic
    {
        var kneeProbability = CalculateKneedleValue(setItems);
        return setItems.Where(x => x.Probability >= kneeProbability);
    }
    private static float CalculateKneedleValue<T>(IEnumerable<T> topics) where T : IProbabilistic
    {
        var itemsOrdered = topics.OrderBy(t => t.Probability).ToArray();
        var arraySize = itemsOrdered.Length;
        if (arraySize == 1)
            return itemsOrdered[0].Probability;
        var previousDistanceFromXy = float.MaxValue;
        float xy;
        float currentDistanceFromXy;
        var kneepoint = 0;
        for (var i = 0; i < arraySize; i++)
        {
            xy = (i + 1) / (float)arraySize;
            currentDistanceFromXy = Math.Abs(itemsOrdered[i].Probability - xy);
            if (currentDistanceFromXy < previousDistanceFromXy && i != 0)
            {
                kneepoint = i;
                break;
            }
            previousDistanceFromXy = currentDistanceFromXy;
        }
        return itemsOrdered[kneepoint].Probability;
    }
}
