namespace BrrSolver;

public interface ISolver
{
    Solution SelectCandidate(SolutionSet solutions);
}
