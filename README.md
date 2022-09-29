# Kneedle
A fast approach to get array items after a knee point (clockwise) for S = 1.0

------------


Based on the work of [Ville Satopää et al](https://raghavan.usc.edu/papers/kneedle-simplex11.pdf "Ville Satopää et al"), this algorithm finds the first knee point and returns the rest of the sequence. This simplified version only checks for the first knee point and could be used to filter out noisy elements off a list of items.

------------


If you have a list of items that have probabilities, and you want to find the knee point and get all the elements from that point onwards (i.e. to filter for most probable results in a cluster of items) you can use this algorithm like this:

```csharp
var topics = new List<Topic>
{
    new Topic("restaurant", 0.8f),
    new Topic("service", 0.76f),
    new Topic("automotive", 0.1f),
    new Topic("iPhone", 0.14f),
    new Topic("technology", 0.02f),
};

var cluster = topics.GetItemsAfterFirstKneeValue().ToList();
cluster.ForEach(x => { Console.WriteLine($"Term = {x.Term} Probability = {x.Probability}"); });

```

This assumes you have a class that implements the interface IProbabilistic which has a float property for probability of the item.

```csharp
public class Topic : IProbabilistic
{
    public Topic(string term, float probability)
    {
        Probability = probability;
        Term = term;
    }

    public string Term { get; }
    public float Probability { get; }
}

```
The sample here will return two items that have probabilities 0.8 and 0.76.

> Testing first knee point.
Term = restaurant Probability = 0.8
Term = service Probability = 0.76


