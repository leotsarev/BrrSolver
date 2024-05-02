
namespace BrrSolver;

public class Solution
{
    public Solution(int solution)
    {
        if (solution < 0 || solution > 9999)
        {
            throw new ArgumentOutOfRangeException(nameof(solution));
        }
        int dig0 = solution / 1000;
        int dig1 = (solution % 1000) / 100;
        int dig2 = (solution % 100) / 10;
        int dig3 = (solution % 10);
        Arr = [dig0, dig1, dig2, dig3];
    }

    private int[] Arr;
    public IReadOnlyList<int> Digits => Arr;


    public int DistinctDigits()
    {
        return Digits.Distinct().Count();
    }
    public bool ContainsDigit(int c)
    {
        return Digits.Any(t => t == c);
    }

    public override string ToString()
    {
        return string.Join("", Digits.Select(d => d.ToString()));
    }

    public CheckResult CompareWithCandidate(Solution candidate)
    {
        var posErrors = 0;
        var chiperError = 0;
        for (int i = 0; i < 4; i++)
        {
            var targetInt = this.Digits[i];
            var candidateInt = candidate.Digits[i];
            if (ContainsDigit(candidateInt))
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
}
