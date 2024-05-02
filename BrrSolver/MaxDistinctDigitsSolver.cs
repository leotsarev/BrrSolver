using MoreLinq;

namespace BrrSolver;

public class MaxDistinctDigitsSolver : ISolver
{
    public Solution SelectCandidate(SolutionSet solutions)
    {
        return solutions.Maxima(x => x.DistinctDigits()).ToList().SelectRandom();
    }
}

