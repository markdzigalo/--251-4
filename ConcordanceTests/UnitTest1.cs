using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using System;
using System.IO;

namespace ConcordanceTests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void Main_ShouldOutputCorrectConcordanceForPeterPiperText()
        {
            var originalOut = Console.Out;

            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                try
                {
                    Program.Main(new string[0]);
                    string actualOutput = stringWriter.ToString();

                    string expectedOutput =
                        "a..................................4: 1 2 3" + Environment.NewLine +
                        "if.................................1: 2" + Environment.NewLine +
                        "is.................................1: 3" + Environment.NewLine +
                        "of.................................2: 1 2" + Environment.NewLine +
                        "peck...............................4: 1 2 3" + Environment.NewLine +
                        "peppers............................2: 1 2" + Environment.NewLine +
                        "peter..............................4: 1 2 3" + Environment.NewLine +
                        "picked.............................4: 1 2 3" + Environment.NewLine +
                        "pickled............................3: 1 2 3" + Environment.NewLine +
                        "piper..............................4: 1 2 3" + Environment.NewLine +
                        "that...............................1: 3" + Environment.NewLine +
                        "the................................1: 3" + Environment.NewLine +
                        "where..............................1: 3" + Environment.NewLine;

                    Assert.That(actualOutput, Is.EqualTo(expectedOutput));
                }
                finally
                {
                    Console.SetOut(originalOut);
                }
            }
        }
    }
}