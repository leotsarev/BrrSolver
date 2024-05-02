namespace BrrSolver;

public static class RandomExts
{
    public static T SelectRandom<T>(this IReadOnlyList<T> solutions)
    {
        return solutions.Skip(Random.Shared.Next(solutions.Count - 1)).First();
    }
}
