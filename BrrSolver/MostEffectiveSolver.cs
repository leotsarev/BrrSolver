using MoreLinq;

namespace BrrSolver;

public class MostEffectiveSolver : ISolver
{
    public Solution SelectCandidate(SolutionSet solutions)
    {
        return solutions
            .Maxima(s => s.DistinctDigits())
            .MinBy(candidate => solutions.NarrowEffectiveness(candidate))
            ?? throw new InvalidOperationException();
    }
}

