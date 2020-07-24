using System;
using System.IO;
using System.Linq;
using System.Text;
using Angband.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Angband.Console.Test
{
    [TestCategory("Integration")]
    [TestClass]
    public class ProgramTest
    {
        private Action _resetConsoleOutToDefault;
        private readonly StringBuilder _consoleOutput = new StringBuilder();

        [TestInitialize]
        public void CaptureConsole()
        {
            _resetConsoleOutToDefault = () => System.Console.SetOut(System.Console.Out);
            System.Console.SetOut(new StringWriter(_consoleOutput));
        }

        [TestCleanup]
        public void ReleaseConsole()
        {
            _resetConsoleOutToDefault();
            _consoleOutput.Clear();
        }

        [DataTestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(5, -5, 12)]
        [DataRow(40, 18, -9)]
        public void Sum_By_Console_Mimics_Somme_In_Core(params int[] numbers)
        {
            Program.Main(numbers.Select(n => n.ToString()).Prepend("SUM").ToArray());
            var coreCallResult = new Somme(numbers).Resultat;
            var consoleResult = long.Parse(_consoleOutput.ToString());

            Assert.AreEqual(coreCallResult, consoleResult);
        }

        [DataTestMethod]
        [DataRow(0, 0)]
        [DataRow(8, 36)]
        [DataRow(7, -15)]
        public void Add_By_Console_Mimics_Addition_In_Core(int x, int y)
        {
            Program.Main(new []{ "ADD", x.ToString(), y.ToString() });
            var coreCallResult = new Addition(x, y).Resultat;
            var consoleResult = long.Parse(_consoleOutput.ToString());

            Assert.AreEqual(coreCallResult, consoleResult);
        }
    }
}
