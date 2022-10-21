namespace EscapeMines
{

    public class BoardState
    {
        public BoardState(ProgramInput programInput)
        {
            this.BoardSize = programInput.BoardSize;
            this.PlayerPosition = (programInput.StartPoint.Item1, programInput.StartPoint.Item2);
            this.ExitPoint = programInput.ExitPoint;
            this.PlayerOrientation = programInput.StartPoint.Item3;
            this.MineLocations = new HashSet<(int, int)>();
            foreach (var mine in programInput.Mines)
            {
                this.MineLocations.Add(mine);
            }

        }
        public (int, int) BoardSize { get; set; }
        public HashSet<(int, int)> MineLocations { get; set; }

        public (int, int) ExitPoint { get; set; }

        public (int, int) PlayerPosition { get; set; }

        public Direction PlayerOrientation { get; set; }
    }

}
