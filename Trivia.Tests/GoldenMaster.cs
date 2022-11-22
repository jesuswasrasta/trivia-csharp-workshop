namespace Trivia.Tests;

using System.Text;

public class GoldenMaster
{
    private static Encoding ENCODING = Encoding.UTF8;
    private const string GOLDEN_MASTER_FILES_DIRECTORY = "GoldeMaster";
    public static int MAX_SEED = 1000;
    private string baseDirectory;
    private DirectoryInfo goldenMasterFilesDirectory;

    public GoldenMaster()
    {
        baseDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
        goldenMasterFilesDirectory = Directory.CreateDirectory(Path.Combine(this.baseDirectory, GOLDEN_MASTER_FILES_DIRECTORY));
    }

    public string GetGameResult(int seed)
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        GameRunner.Play(new Random(seed));

        return stringWriter.ToString();
    }

    public void GenerateFiles()
    {
        for (var seed = 0; seed < MAX_SEED; seed++)
        {
            var file = this.GetFilenameBySeed(seed);
            var gameResult = this.GetGameResult(seed);

            File.WriteAllText(file.FullName, gameResult);
        }
    }

    public string GetGoldenMasterBySeed(int seed)
    {
        var filename = this.GetFilenameBySeed(seed).FullName;
        return File.ReadAllText(filename, ENCODING);
    }

    private FileInfo GetFilenameBySeed(int seed)
    {
        var file = new FileInfo(Path.Combine(this.goldenMasterFilesDirectory.FullName, $"{seed}.txt"));
        return file;
    }
}
