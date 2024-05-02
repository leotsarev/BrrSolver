using BrrSolver;
using MoreLinq;

namespace BrrTest;

public class SolverTest
{
    private const int ProbeCount = 1;

    [Fact]
    public void TestMaxDistinct()
    {
        var totalAttemps = TrySolver(new MaxDistinctDigitsSolver());
        Assert.Equal(1, totalAttemps);
    }

    [Fact]
    public void TestRandom()
    {
        var totalAttemps = TrySolver(new RandomSolver());
        Assert.Equal(1, totalAttemps);
    }

    [Fact(Skip = "Too long")]
    public void TestMostEffective()
    {
        var totalAttemps = TrySolver(new MostEffectiveSolver());
        Assert.Equal(1, totalAttemps);
    }

    private static double TrySolver(ISolver solver)
    {
        var allSolutions = new SolutionSet();
        var totalAttemps = allSolutions.Shuffle().Take(ProbeCount).Sum(s => solver.TrySolve(s));
        return 1.0 * totalAttemps / ProbeCount;
    }
}

public static class SolverTestExtensions
{
    public static int TrySolve(this ISolver solver, Solution target)
    {
        var attempts = 0;
        var solutions = new SolutionSet();

        while (true)
        {
            attempts++;
            Solution candidate = solver.SelectCandidate(solutions);
            var checkResult = target.CompareWithCandidate(candidate);

            solutions = solutions.NarrowSolutionWith(candidate, checkResult);

            if (solutions.Count == 0)
            {
                throw new InvalidOperationException();
            }
            if (solutions.Count == 1)
            {
                break;
            }
        }

        return attempts;
    }
}
