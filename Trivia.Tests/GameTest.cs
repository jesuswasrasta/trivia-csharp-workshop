namespace Trivia.Tests;

using UglyTrivia;

public class GameTests
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

        Assert.That(result, Is.True);
    }

    [Test(Description = "Verifico che il massimo numero di giocatori è 6")]
    public void Max6Player() {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        Assert.Throws<IndexOutOfRangeException>(() => {
            var game = new Game();
            for (var i = 1; i < 8; i++) {
                game.add($"Giocatore{i}");
            }
        });
    }

    [Test(Description = "Accettiamo fino a 6 giocatori (correggendo un BUG)")]
    public void AdessoRiusciamoAdAccettareFinoa6Giocatori() {
        var game = new Game();
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        for (var i = 1; i < 7; i++) {
            game.add($"Giocatore{i}");
        }
        var expeted = @"Giocatore1 was added
They are player number 1
Giocatore2 was added
They are player number 2
Giocatore3 was added
They are player number 3
Giocatore4 was added
They are player number 4
Giocatore5 was added
They are player number 5
Giocatore6 was added
They are player number 6
";
        var actual = stringWriter.ToString();
        Assert.That(actual, Is.EqualTo(expeted));
    }

    [Test(Description = "Verifico che si possa giocare da soli")]
    public void GiocatoreUnico() {
        var game = new Game();
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        game.add("Giocatore1");
        game.roll(5);
        var expeted = @"Giocatore1 was added
They are player number 1
Giocatore1 is the current player
They have rolled a 5
Giocatore1's new location is 5
The category is Science
Science Question 0";
        var actual = stringWriter.ToString();
        Assert.That(actual, Is.EqualTo(expeted));
    }

    [Test(Description = "Mi aspetto che il numero minimo di giocatori sia 2 (implementando un nuovo comportamento)")]
    public void AlmenoDueGiocatori()
    {
        var game = new Game();
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        game.add("Giocatore1");
        game.roll(5);

        var expeted = @"Giocatore1 was added
They are player number 1
Non si può giocare da soli
";
        var actual = stringWriter.ToString();

        Assert.That(actual, Is.EqualTo(expeted));
    }


    /* Potremmo iniziare a testare Game, ad es. il comportamento del metodo add()
     * Dovremmo però sapere qual è l'obiettivo finale: correggere bug? Implementare funzionalità?
     * la copertura di test per ora è parziale
     *
     */
}
