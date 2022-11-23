using global::ApprovalTests;
using global::ApprovalTests.Namers;
using global::ApprovalTests.Reporters;
using NUnit.Framework;
using UglyTrivia;

namespace Trivia.Tests;

public class ApprovalTests
{
    [UseApprovalSubdirectory("Approvals")]
    [TestFixture]
    public class SampleTest
    {
        [UseReporter(typeof(QuietReporter))]
        [Test]
        public void TestListWithQuietReporter()
        {
            // Directions:
            // 1) Run the test; it will fail, generating a *.received text file
            // 2) Manually rename the *.received. file to *.approved.
            // 3) Re-run the test: now it will pass

            var names = new[] {"Llewellyn", "James", "Dan", "Jason", "Katrina"};
            Array.Sort(names);

            Approvals.VerifyAll(names, label: "");
        }

        [UseReporter(typeof(QuietReporter))]
        [Test]
        public void GameRunnerApproval()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var random = new Random(0);
            GameRunner.Play(random);

            Approvals.Verify(stringWriter.ToString());
        }

        [UseReporter(typeof(DiffReporter))]
        [Test]
        public void TestListWithDiffReporter()
        {
            // Directions:
            // 1) Run the test; it will fail, opening your default diff tool
            // 2) Move to the destination (usually on the right) the whole output presented (usually in the left)
            // 3) Re-run the test: now it will pass

            var names = new[] {"Llewellyn", "James", "Daniele", "Jason", "Katrina"};
            Array.Sort(names);
            Approvals.VerifyAll(names, label: "");
        }

        [UseReporter(typeof(ClipboardReporter))]
        [Test]
        public void TestListWithClipboardReporter()
        {
            // The ClipboardReporter copies to the clipboard the `move` command you need to run to rename `received` file to `approved` one.
            //
            // Directions:
            // 1) Run the test; it will fail
            // 2) Paste to a command prompt the command in the clipboard
            // 3) Run it to rename the *.received. file to *.approved.
            // 4) Re-run the test: now it will pass

            var names = new[] {"Llewellyn", "James", "Dan", "Jason", "Katrina"};
            Array.Sort(names);
            Approvals.VerifyAll(names, label: "");
        }

        [UseReporter(typeof(FileLauncherReporter))]
        [Test]
        public void TestListWithFileLauncherReporter()
        {
            // The FileLauncherReporter opens `*.received` file into default text editor.
            //
            // Directions:
            // 1) Run the test; it will fail, opening your default text editor
            // 2) Save the file renaming it from *.received. to *.approved.
            // 3) Re-run the test: now it will pass

            var names = new[] {"Llewellyn", "James", "Dan", "Jason", "Katrina"};
            Array.Sort(names);
            Approvals.VerifyAll(names, label: "");
        }

        /* There are of course other Reporters and other ways to use this library to perform snapshot testing.
         *
         * More on:
         * - https://approvaltests.com/
         * - https://github.com/approvals
         * - https://github.com/approvals/ApprovalTests.Net
         *
         * Reporters
         * - https://github.com/approvals/ApprovalTests.Net/blob/master/docs/ApprovalTests/Reporters.md
         * (configuring reporters for classes and even entire assemblies, multiple reporters, custom reporters, etc.)
         *
         * Resources
         * - https://www.pluralsight.com/courses/approval-tests-dotnet
         * - https://cezarypiatek.github.io/post/testing-web-api-with-approval-tests/
         *
         */

    }
}
