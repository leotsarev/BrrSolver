using BrrSolver;

namespace BrrTest;

public class UnitTest1
{
    [Fact]
    public void TestEqual()
    {
        var candidate = new Solution(0);
        Assert.Equal(Solver.Compare(candidate, candidate), new CheckResult(0, 0));
    }

    [Fact]
    public void Test8692()
    {
        var candidate = new Solution(8692);
        Assert.Equal(Solver.Compare(candidate, candidate), new CheckResult(0, 0));
    }

    [Fact]
    public void Test1234()
    {
        var candidate = new Solution(0);
        Assert.Equal(Solver.Compare(new Solution(1234), candidate), new CheckResult(4, 0));
    }
}