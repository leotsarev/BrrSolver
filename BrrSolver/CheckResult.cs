

namespace BrrSolver;

public record class CheckResult(int ErrorChiper, int ErrorPosition)
{
    public static IEnumerable<CheckResult> GetAllPossible()
    {
        yield return new CheckResult(0, 0);
        yield return new CheckResult(0, 1);
        yield return new CheckResult(0, 2);
        yield return new CheckResult(0, 3);
        yield return new CheckResult(0, 4);
        yield return new CheckResult(1, 0);
        yield return new CheckResult(1, 1);
        yield return new CheckResult(1, 2);
        yield return new CheckResult(1, 3);
        yield return new CheckResult(2, 0);
        yield return new CheckResult(2, 1);
        yield return new CheckResult(2, 2);
        yield return new CheckResult(3, 0);
        yield return new CheckResult(3, 1);
        yield return new CheckResult(4, 0);
    }

    internal static CheckResult? FromString(string res)
    {
        var parts = res.Trim().Split(' ');
        if (parts.Length != 2)
        {
            return null;
        }
        if (int.TryParse(parts[0], out var chiper) && int.TryParse(parts[1], out var pos))
        {
            return new CheckResult(chiper, pos);
        }
        return null;
    }
}
