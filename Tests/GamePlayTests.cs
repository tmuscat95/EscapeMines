using EscapeMines;

namespace Tests
{
    public class GamePlayTest
    {
        private BoardState BoardState;
        private List<List<Move>> MovesSequences;

        private void InitializeTest(List<string> lines)
        {
            var programInput = new ProgramInput(lines.ToArray());
            this.BoardState = new BoardState(programInput);
            this.MovesSequences = programInput.MovesSequences;
        }
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        [Description("Tests Whether Rotation moves result in the turtle being in the correct orientation")]
        public void RotationTest()
        {
            List<string> lines = new List<string>();
            lines.Add("5 4");//board size
            lines.Add("1,1 3,1 3,3");//mines
            lines.Add("3 2");//exit
            lines.Add("0 1 N");
            lines.Add("R");
            lines.Add("L");
        

            InitializeTest(lines);
            EscapeMinesMain.PlayGame(BoardState, MovesSequences[0]);
            Assert.That(BoardState.PlayerOrientation, Is.EqualTo(Direction.East));
            EscapeMinesMain.PlayGame(BoardState, MovesSequences[0]);
            Assert.That(BoardState.PlayerOrientation, Is.EqualTo(Direction.South));
            EscapeMinesMain.PlayGame(BoardState, MovesSequences[0]);
            Assert.That(BoardState.PlayerOrientation, Is.EqualTo(Direction.West));
            EscapeMinesMain.PlayGame(BoardState, MovesSequences[0]);
            Assert.That(BoardState.PlayerOrientation, Is.EqualTo(Direction.North));
            
            EscapeMinesMain.PlayGame(BoardState, MovesSequences[1]);
            Assert.That(BoardState.PlayerOrientation, Is.EqualTo(Direction.West));
            EscapeMinesMain.PlayGame(BoardState, MovesSequences[1]);
            Assert.That( BoardState.PlayerOrientation, Is.EqualTo(Direction.South));
            EscapeMinesMain.PlayGame(BoardState, MovesSequences[1]);
            Assert.That(BoardState.PlayerOrientation, Is.EqualTo(Direction.East));
            EscapeMinesMain.PlayGame(BoardState, MovesSequences[1]);
            Assert.That(BoardState.PlayerOrientation, Is.EqualTo(Direction.North));

        }

        [Test]
        [Description("Tests Whether 'Move' moves result in the turtle being in the correct position")]
        public void MoveTest()
        {
            List<string> lines = new List<string>();
            lines.Add("5 4");//board size
            lines.Add("4,3");//mines
            lines.Add("4 2");//exit
            lines.Add("0 0 N");
            lines.Add("M");
            lines.Add("R M");
            InitializeTest(lines);

            EscapeMinesMain.PlayGame(BoardState, MovesSequences[0]);
            Assert.That(BoardState.PlayerPosition,Is.EqualTo((0,1)));
            EscapeMinesMain.PlayGame(BoardState, MovesSequences[1]);
            Assert.That(BoardState.PlayerPosition, Is.EqualTo((1, 1)));
            EscapeMinesMain.PlayGame(BoardState, MovesSequences[1]);
            Assert.That(BoardState.PlayerPosition, Is.EqualTo((1, 0)));
            EscapeMinesMain.PlayGame(BoardState, MovesSequences[1]);
            Assert.That(BoardState.PlayerPosition, Is.EqualTo((0, 0)));


        }

        [Test]
        [Description("Correct result is returned when turtle moves onto a square containing a mine.")]
        public void MineHitTest()
        {
            List<string> lines = new List<string>();
            lines.Add("5 4");//board size
            lines.Add("1,1 3,1 3,3");//mines
            lines.Add("3 2");//exit
            lines.Add("0 1 N");
            lines.Add("R M L");

            InitializeTest(lines);

            Assert.That(EscapeMinesMain.PlayGame(BoardState, MovesSequences[0]), Is.EqualTo(EscapeMines.Types.Result.MineHit));
        }

        [Test]
        [Description("Tests Whether Correct Result is returned when end of maze is reached")]
        public void MazeEndTest()
        {
            List<string> lines = new List<string>();
            lines.Add("5 4");//board size
            lines.Add("3,1 3,3");//mines
            lines.Add("1 1");//exit
            lines.Add("0 1 N");
            lines.Add("R M L");

            InitializeTest(lines);

            Assert.That(EscapeMinesMain.PlayGame(BoardState, MovesSequences[0]), Is.EqualTo(EscapeMines.Types.Result.Success));
        }

        [Test]
        [Description("Tests whether correct result is returned when there are no more actions and no win/loss condition has been reached.")]
        public void StillInDangerTest()
        {
            List<string> lines = new List<string>();
            lines.Add("5 4");//board size
            lines.Add("3,1 3,3");//mines
            lines.Add("1 2");//exit
            lines.Add("0 0 N");
            lines.Add("R M L");

            InitializeTest(lines);

            Assert.That(EscapeMinesMain.PlayGame(BoardState, MovesSequences[0]), Is.EqualTo(EscapeMines.Types.Result.StillInDanger));
        }
    }
}
