using Kneedle.Abstractions;
using Kneedle.Extensions;

Console.WriteLine("Testing first knee point.");

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
Console.ReadLine();

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
