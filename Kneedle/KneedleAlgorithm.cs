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
        var maxMinValue = float.MaxValue;
        float xY;
        float distanceFromXy;
        var kneepoint = 0;
        for (int i = 0; i < arraySize; i++)
        {
            xY = (i + 1) / (float)arraySize;
            distanceFromXy = Math.Abs(itemsOrdered[i].Probability - xY);
            if (distanceFromXy < maxMinValue)
            {
                maxMinValue = distanceFromXy;
                kneepoint = i;
            }
        }
        return itemsOrdered[kneepoint].Probability;
    }

}