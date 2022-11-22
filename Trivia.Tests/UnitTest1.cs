namespace Trivia.Tests;

using UglyTrivia;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test(Description = "Riesco a istanziare un Game")]
    public void RiescoAIstanziareGame()
    {
        var game = new Game();

        Assert.Pass();
    }

    [Test(Description = "Riesco a aggiungere un giocatore")]
    public void AggiungoGiocatore()
    {
        var game = new Game();
        var result = game.add("Nando");

        Assert.IsTrue(result);
    }

}
