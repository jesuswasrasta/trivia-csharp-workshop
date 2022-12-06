namespace Trivia.Tests;

using UglyTrivia;

public class GameTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test(Description = "Posso istanziare Game()")]
    public void PossoIstanziareGame()
    {
        Game game = new Game();

        Assert.Pass();
    }

    [Test(Description = "Posso aggiungere giocatori")]
    public void PossoAggiungereGiocatori()
    {
        var game = new Game();

        var actual = game.add("Nando");

        Assert.That(actual, Is.True);
    }

    [Test(Description = "Posso aggiungere 2 giocatori con lo stesso nome")]
    public void PossoAggiungere2GiocatoriConLoStessoNome()
    {
        var game = new Game();

        var actual1 = game.add("Nando");
        var actual2 = game.add("Nando");

        Assert.That(actual1 && actual2, Is.True);
    }

    [Test(Description = "Posso aggiungere max 6 giocatori")]
    public void PossoAggiungereMax6Giocatori()
    {
        var game = new Game();

        game.add("Nando");
        game.add("Nando");
        game.add("Nando");
        game.add("Nando");
        game.add("Nando");
        game.add("Nando");

        Assert.Pass();
    }
}
