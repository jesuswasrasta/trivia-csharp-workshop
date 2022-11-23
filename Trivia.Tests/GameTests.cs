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


    [Test(Description = "Non giocare con un giocatore")]
    public void NonGiocareConUnGiocatore()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        var expected = @"Pippo was added
They are player number 1
Devi giocare con almeno due giocatori
";
        var game = new Game();
        game.add("Pippo");

        game.roll(1);

        var actual = stringWriter.ToString();

        Assert.AreEqual(actual, expected);
    }

    [Test(Description = "Giocare con due giocatori")]
    public void GiocoConDueGiocatori()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        var expected = @"Pippo was added
They are player number 1
Pluto was added
They are player number 2
Pippo is the current player
They have rolled a 1
Pippo's new location is 1
The category is Science
Science Question 0
";
        var game = new Game();
        game.add("Pippo");
        game.add("Pluto");

        game.roll(1);

        var actual = stringWriter.ToString();

        Assert.AreEqual(actual, expected);
    }

    [Test(Description = "Posso aggiungere massimo 6 giocatori")]
    public void PossoAggiungereMax6Giocatori()
    {
        var game = new Game();
        var expected = 6;

        for (int i = 1; i <= expected; i++)
        {
            game.add($"player {i}");
        }

        Assert.That(game.howManyPlayers(), Is.EqualTo(expected));
    }

    [Test(Description = "Al settimo giocatore ricevo un messaggio di errore")]
    public void AlSettimoGiocatoreErrore()
    {
        var game = new Game();
        var expected = 6;

        for (int i = 1; i <= expected; i++)
        {
            game.add($"player {i}");
        }

        Assert.Throws<IndexOutOfRangeException>(() => game.add("player 7"));

    }

}
