using UglyTrivia;

namespace Trivia.Tests;

using NUnit.Framework;

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

    [Test(Description = "add aggiunge due giocatori e poi ritorna true")]
    public void GiocaConUnGiocatore()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        var expected = @"Pippo was added
They are player number 1
Pippo is the current player
They have rolled a 1
Pippo's new location is 1
The category is Science
Science Question 0
";
        var game = new Game();
        game.add("Pippo");

        game.roll(1);
        
        var actual = stringWriter.ToString();

        Assert.AreEqual(actual, expected);
    }
}
