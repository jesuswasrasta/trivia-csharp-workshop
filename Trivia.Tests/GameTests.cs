namespace Trivia.Tests;

using UglyTrivia;

public class GameTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test(Description = "posso istanziare la classe")]
    public void PossoIstanziareGame()
    {
        var game = new Game();

        Assert.Pass();
    }

    [Test(Description = "add aggiunge un giocatore e poi ritorna true")]
    public void IlMetodoAddDaSempreTrue()
    {
        var expected = true;

        var game = new Game();
        var actual = game.add("Pippo");

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test(Description = "puoi aggiungere un giocatore senza nome 🤔")]
    public void IlMetodoAddConStringaVuotaDaSempreTrue()
    {
        var expected = true;

        var game = new Game();
        var actual = game.add("");

        Assert.That(actual, Is.EqualTo(expected));
    }


}
