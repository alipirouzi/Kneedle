using Kneedle.Abstractions;

namespace Kneedle.Unit.TestModels;

public class ProbabilisticItem : IProbabilistic
{
    private float _probability;
    private string _name;
    public ProbabilisticItem(float probability, string name)
    {
        _probability = probability;
        _name = name;
    }
    public string Name => _name;
    public float Probability => _probability;
}