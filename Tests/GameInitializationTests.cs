using EscapeMines;

namespace Tests
{
    public class GameInitializationTests
    {
        private BoardState BoardState;
        private List<List<Move>> MovesSequences;

        [SetUp]
        public void Setup()
        {
            List<string> lines = new List<string>();
            lines.Add("4 4");//board size
            lines.Add("1,1 3,1 3,3");//mines
            lines.Add("1 1");//exit
            lines.Add("0 0 N");
            lines.Add("R M L");
            lines.Add("M R");
            var programInput = new ProgramInput(lines.ToArray());
            this.BoardState = new BoardState(programInput);
            this.MovesSequences = programInput.MovesSequences;

        }

        [Test]
        [Description("Tests Whether Initial Board State is set properly.")]
        public void TestInitialBoardState()
        {
            Assert.IsTrue(BoardState.BoardSize.Item1 == 4 && BoardState.BoardSize.Item2 == 4);
            Assert.IsTrue(BoardState.ExitPoint.Item1 == 1 && BoardState.ExitPoint.Item2 == 1);
            Assert.IsTrue(BoardState.PlayerPosition.Item1 == 0 && BoardState.PlayerPosition.Item2 == 0);
            Assert.IsTrue(BoardState.PlayerOrientation == Direction.North);
            Assert.IsTrue(BoardState.MineLocations.Count == 3);
            Assert.IsTrue(BoardState.MineLocations.Contains((3, 3)) && BoardState.MineLocations.Contains((1,1)) && BoardState.MineLocations.Contains((3, 1)));

        }

        [Test]
        [Description("Tests whether move sequences are parsed correctly")]
        public void TestMovesSequencesParsing()
        {
            Assert.IsTrue(MovesSequences.Count == 2);
            Assert.IsTrue(MovesSequences[0].Count == 3);
            Assert.IsTrue(MovesSequences[1].Count == 2);
            Assert.IsTrue(MovesSequences[0][0] == Move.RightRotate && MovesSequences[0][1] == Move.Move && MovesSequences[0][2] == Move.LeftRotate);
            Assert.IsTrue(MovesSequences[1][0] == Move.Move && MovesSequences[1][1] == Move.RightRotate);
        }
    }
}