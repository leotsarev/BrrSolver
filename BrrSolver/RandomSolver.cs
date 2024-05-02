namespace BrrSolver;

public class RandomSolver : ISolver
{
    public Solution SelectCandidate(SolutionSet solutions)
    {
        return solutions.ToList().SelectRandom();
    }
}

