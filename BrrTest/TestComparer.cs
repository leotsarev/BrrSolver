using BrrSolver;

namespace BrrTest;

public class TestComparer
{
    [Fact]
    public void TestEqual()
    {
        var candidate = new Solution(0);
        Assert.Equal(candidate.CompareWithCandidate(candidate), new CheckResult(0, 0));
    }

    [Fact]
    public void Test8692()
    {
        var candidate = new Solution(8692);
        Assert.Equal(candidate.CompareWithCandidate(candidate), new CheckResult(0, 0));
    }

    [Fact]
    public void Test1234()
    {
        var candidate = new Solution(0);
        Assert.Equal(new Solution(1234).CompareWithCandidate(candidate), new CheckResult(4, 0));
    }
}