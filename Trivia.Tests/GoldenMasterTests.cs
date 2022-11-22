namespace Trivia.Tests;

using UglyTrivia;

public class GoldenMasterTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Ignore("Use this only to (re)generate the Golden Master files")]
    [Test(Description = "I use this test as a workbench to generate a bunch of golden master files")]
    public void GenerateGoldenMasterFiles()
    {
        var goldenMaster = new GoldenMaster();
        goldenMaster.GenerateFiles();
    }

    [Test(Description = "Check the results of GameRunner against 1000 files")]
    public void CheckAgainstGoldenMaster()
    {
        var goldenMaster = new GoldenMaster();

        for (var seed = 0; seed < GoldenMaster.MAX_SEED; seed++)
        {
            var expected = goldenMaster.GetGoldenMasterBySeed(seed);
            var actual = goldenMaster.GetGameResult(seed);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
