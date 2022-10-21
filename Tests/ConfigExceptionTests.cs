using EscapeMines;
using EscapeMines.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{

    [Description("Tests Whether An Improperly Formatted config file will result in an exception being thrown.")]
    public class ConfigExceptionTests
    {

        [Test]
        [Description("Test whether a config file with insufficient number of lines will cause an exception to be thrown.")]
        public void InsufficientLinesConfigExceptionThrown()
        {
            List<string> lines = new List<string>();
            lines.Add("4 4");//board size
            lines.Add("1,1 3,1 3,3");//mines
            lines.Add("1 1");//exit

            Assert.Throws<ConfigException>(() => new ProgramInput(lines.ToArray()));

        }

        [Test]
        [Description("Tests whether non-numeric values for coordinates will cause an exception to be thrown.")]
        public void NonNumericCoordinateValuesExceptionThrown()
        {
            List<string> lines = new List<string>();
            lines.Add("A 4");//board size
            lines.Add("1,1 3,1 3,3");//mines
            lines.Add("1 1");//exit
            lines.Add("0 0 N");
            lines.Add("R M L");
            lines.Add("M R");

            Assert.Throws<ConfigException>(() => new ProgramInput(lines.ToArray()));

            lines = new List<string>();
            lines.Add("4 4");//board size
            lines.Add("A,1 3,1 3,3");//mines
            lines.Add("1 1");//exit
            lines.Add("0 0 N");
            lines.Add("R M L");
            lines.Add("M R");

            Assert.Throws<ConfigException>(() => new ProgramInput(lines.ToArray()));

            lines = new List<string>();
            lines.Add("4 4");//board size
            lines.Add("1,1 3,1 3,3");//mines
            lines.Add("1 B");//exit
            lines.Add("0 0 N");
            lines.Add("R M L");
            lines.Add("M R");

            Assert.Throws<ConfigException>(() => new ProgramInput(lines.ToArray()));

            lines = new List<string>();
            lines.Add("4 4");//board size
            lines.Add("1,1 3,1 3,3");//mines
            lines.Add("1 1");//exit
            lines.Add("A 0 N");
            lines.Add("R M L");
            lines.Add("M R");

            Assert.Throws<ConfigException>(() => new ProgramInput(lines.ToArray()));
        }

        [Test]
        [Description("Tests whether invalid characters for directions and move actions cause an exception to be thrown.")]
        public void InvalidCharactersExceptionThrown()
        {
            List<string> lines = new List<string>();
            lines.Add("4 4");//board size
            lines.Add("1,1 3,1 3,3");//mines
            lines.Add("1 1");//exit
            lines.Add("0 0 N");
            lines.Add("$ M L");
            lines.Add("M R");

            Assert.Throws<ConfigException>(() => new ProgramInput(lines.ToArray()));

            lines = new List<string>();
            lines.Add("4 4");//board size
            lines.Add("1,1 3,1 3,3");//mines
            lines.Add("1 1");//exit
            lines.Add("0 0 N");
            lines.Add("R M L");
            lines.Add("% R");

            Assert.Throws<ConfigException>(() => new ProgramInput(lines.ToArray()));

            lines = new List<string>();
            lines.Add("4 4");//board size
            lines.Add("1,1 3,1 3,3");//mines
            lines.Add("1 1");//exit
            lines.Add("0 0 &");
            lines.Add("R M L");
            lines.Add("M R");

            Assert.Throws<ConfigException>(() => new ProgramInput(lines.ToArray()));

        }
    }
}
