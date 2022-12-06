namespace Trivia.Tests;

using UglyTrivia;

public class GameRunnerTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test(Description = "Posso eseguire gameRunner in isolamento attraverso un test")]
    public void PossoLanciareGasmeRunner()
    {
        var args = new []{""};

        GameRunner.Main(args);

        Assert.Pass();
    }

}
