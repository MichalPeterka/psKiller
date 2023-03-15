using System.Diagnostics;

namespace psKillerTests;

public class Tests
{
    readonly string appPath = @"..\..\..\..\psKiller\bin\Debug\net6.0\psKiller.exe";

    [SetUp]
    public void Setup()
    {
    }

    [TestCase("'' 1 1")]
    [TestCase("notepad '' 1")]
    [TestCase("notepad 1 ''")]
    [TestCase("notepad -1 1")]
    [TestCase("notepad 35792 1")]
    [TestCase("notepad 1 -1")]
    [TestCase("notepad 1 35792")]
    public void When_User_Provides_Invalid_Arguments_Test(string args)
    {
        Process process = new()
        {
            StartInfo =
            {
                FileName = appPath,
                Arguments = args,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };
        Console.WriteLine("test");
    }
}