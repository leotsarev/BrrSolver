
namespace BrrSolver;

public class Solver
{
    internal static Solution SelectSolution(HashSet<Solution> solutions)
    {
        var maxDigits = solutions.Max(x => x.DistinctDigits());
        return SelectRandom([.. solutions.Where(x => x.DistinctDigits() == maxDigits)]);
    }

    private static Solution SelectRandom(IReadOnlyList<Solution> solutions)
    {
        return solutions.Skip(Random.Shared.Next(solutions.Count - 1)).First();
    }

    public static CheckResult Compare(Solution target, Solution candidate)
    {
        var posErrors = 0;
        var chiperError = 0;
        for (int i = 0; i < 4; i++)
        {
            var targetInt = target.Digits[i];
            var candidateInt = candidate.Digits[i];
            if (target.ContainsDigit(candidateInt))
            {
                if (targetInt != candidateInt)
                {
                    posErrors++;
                }

            }
            else
            {
                chiperError++;
            }
        }

        return new CheckResult(chiperError, posErrors);
    }

    public static HashSet<Solution> NarrowSolutionWith(HashSet<Solution> solutions, Solution candidate, CheckResult checkResult)
    {
        return solutions.Where(i => Compare(i, candidate) == checkResult).ToHashSet();
    }

}
