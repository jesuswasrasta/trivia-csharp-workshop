namespace Trivia.Tests;

using UglyTrivia;

public class GameTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test(Description = "Posso istanziare Game e aggiungere un giocatore")]
    public void PossoAggiungereUnGiocatore()
    {
        var game = new Game();

        var result = game.add("Nando");

        Assert.That(result, Is.True);
    }

    [Test(Description = "Posso aggiungere giocatori con lo stesso nome")]
    public void PossoAggiungereGiocatoriConloStessoNome()
    {
        var game = new Game();

        var result1 = game.add("Nando");
        var result2 = game.add("Nando");
        var result3 = game.add("Nando");

        Assert.That(result1, Is.True);
        Assert.That(result2, Is.True);
        Assert.That(result3, Is.True);
    }


    [Test(Description = "Non posso giocare da solo")]
    public void NonPossoGiocareDaSolo()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        var game = new Game();

        game.add("Nando");

        game.roll(6);

        var expected = @"Nando was added
They are player number 1
Cannot play alone
";


        Assert.AreEqual(expected, stringWriter.ToString());

    }
}
