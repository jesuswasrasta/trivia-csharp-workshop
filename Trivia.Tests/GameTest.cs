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

        Assert.IsTrue(result);
    }


    /* Potremmo iniziare a testare Game, ad es. il comportamento del metodo add()
     * Dovremmo però sapere qual è l'obiettivo finale: correggere bug? Implementare funzionalità?
     * la copertura di test per ora è parziale
     *
     */
}
