using System.Collections;

namespace BrrSolver;

public class SolutionSet : IReadOnlyCollection<Solution>
{
    private readonly HashSet<Solution> solutions;
    public SolutionSet()
    {
        solutions = new HashSet<Solution>();
        for (int i = 0; i < 10000; i++)
        {
            solutions.Add(new Solution(i));
        }
    }

    private SolutionSet(IEnumerable<Solution> items)
    {
        solutions = items.ToHashSet();
    }

    public SolutionSet NarrowSolutionWith(Solution candidate, CheckResult checkResult)
    {
        return new SolutionSet(solutions.Where(i => i.CompareWithCandidate(candidate) == checkResult));
    }

    public int CountNarrowSolutionWith(Solution candidate, CheckResult checkResult)
    {
        return solutions.Count(i => i.CompareWithCandidate(candidate) == checkResult);
    }

    public int NarrowEffectiveness(Solution candidate)
    {
        return CheckResult.GetAllPossible().Sum(cr => CountNarrowSolutionWith(candidate, cr));
    }

    public int Count => solutions.Count;

    public IEnumerator<Solution> GetEnumerator()
    {
        return ((IEnumerable<Solution>)solutions).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)solutions).GetEnumerator();
    }
}
