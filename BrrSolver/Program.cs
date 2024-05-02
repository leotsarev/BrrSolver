// See https://aka.ms/new-console-template for more information
using BrrSolver;

Console.WriteLine("Hello, World!");

HashSet<Solution> solutions = Solution.GenerateSet();
Console.WriteLine(solutions.Count);

while (true)
{
    Solution candidate = Solver.SelectSolution(solutions);


    var checkResult = ReadResultFromConsole(candidate);

    solutions = Solver.NarrowSolutionWith(solutions, candidate, checkResult);
    if (solutions.Count == 1)
    {
        WriteSolution(solutions.Single());
        break;
    }
    else if (solutions.Count == 0)
    {
        Console.WriteLine("Error");
        break;
    }
    if (solutions.Count < 10)
    {
        Console.WriteLine("Solutions left:");
        Console.WriteLine(string.Join(", ", solutions));
    }
    else
    {
        Console.WriteLine($"Count is {solutions.Count}");
    }
}

void WriteSolution(Solution candidate)
{
    Console.WriteLine($"Solution is {candidate}");
}

CheckResult ReadResultFromConsole(Solution candidate)
{
    Console.WriteLine($"Candidate is {candidate}");
    CheckResult? result = null;
    while (result is null)
    {
        Console.Write("Input chiper and pos:");
        var res = Console.ReadLine();
        if (res is null)
        {
            continue;
        }
        result = CheckResult.FromString(res);
    }
    return result;
}