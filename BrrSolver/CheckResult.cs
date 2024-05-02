
namespace BrrSolver;

public record class CheckResult(int ErrorChiper, int ErrorPosition)
{
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
