using BrrSolver;
using Xunit.Abstractions;

namespace BrrTest;

public class EffectivenessCalc
{
    private readonly ITestOutputHelper output;

    public EffectivenessCalc(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void Effective000()
    {
        var solution = new Solution(0);
        TrySolution(solution);
    }

    [Fact]
    public void Effective1234()
    {
        var solution = new Solution(1234);
        TrySolution(solution);
    }

    private void TrySolution(Solution solution)
    {
        var set = new SolutionSet();
        var dict = CheckResult.GetAllPossible().ToDictionary(cr => cr, cr => set.CountNarrowSolutionWith(solution, cr));
        foreach (var item in dict)
        {
            output.WriteLine($"{item.Key} - {item.Value}");
        }
        Assert.Equal(0, new SolutionSet().NarrowEffectiveness(solution));
    }
}
