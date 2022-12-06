namespace Trivia.Tests;

using global::ApprovalTests;
using global::ApprovalTests.Namers;
using global::ApprovalTests.Reporters;
using UglyTrivia;

[UseApprovalSubdirectory("Approvals")]
[TestFixture]
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

    [Test(Description = "Non si può giocare con un solo giocatore")]
    public void NonSiPuoGiocareConUnSoloGiocatore()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

       var expected = @"Nando was added
They are player number 1
Can not play with a single player
";
        var game = new Game();

        game.add("Nando");
        game.roll(1);

        var actual = stringWriter.ToString();
        Assert.AreEqual(expected, actual);
    }

    [Test(Description = "Se Vai In Prigione Ci Rimani finchè non esce un numero dispari")]
    public void SeVaiInPrigioneCiRimaniFincheNonEsceUnNUmeroDispari()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        var game = new Game();

        game.add("Pippo");
        game.add("Pluto");

        //primo turno 1 - Pippo SBAGLIA
        game.roll(1);
        game.wrongAnswer();

        //secondo turno 1- Pluto CORRETTO
        game.roll(1);
        game.wasCorrectlyAnswered();


        //secondo turno 3- Pippo
        game.roll(2);
        game.wasCorrectlyAnswered();

        var isInPenalityBox = stringWriter.ToString().Contains("Pippo is not getting out of the penalty box");

        Assert.That(isInPenalityBox, Is.True);
    }

    [Test(Description = "Se Vai In Prigione Ci Rimani finchè non esce un numero dispari")]
    [UseReporter(typeof(QuietReporter))]
    public void TestPenalityBoxEven()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        var game = new Game();

        game.add("Pippo");
        game.add("Pluto");

        //primo turno 1 - Pippo SBAGLIA
        game.roll(1);
        game.wrongAnswer();

        //secondo turno 1- Pluto CORRETTO
        game.roll(1);
        game.wasCorrectlyAnswered();


        //secondo turno 3- Pippo
        game.roll(2);
        game.wasCorrectlyAnswered();


        Approvals.Verify(stringWriter.ToString());
    }

    [Test(Description = "Se Vai In Prigione Ci Rimani finchè non esce un numero dispari")]
    [UseReporter(typeof(QuietReporter))]
    public void TestPenalityBoxOdd()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        var game = new Game();

        game.add("Pippo");
        game.add("Pluto");

        //primo turno 1 - Pippo SBAGLIA
        game.roll(1);
        game.wrongAnswer();

        //secondo turno 1- Pluto CORRETTO
        game.roll(1);
        game.wasCorrectlyAnswered();


        //secondo turno 3- Pippo
        game.roll(3);
        game.wasCorrectlyAnswered();


        Approvals.Verify(stringWriter.ToString());
    }
}
