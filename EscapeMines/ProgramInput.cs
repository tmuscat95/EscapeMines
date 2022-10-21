using EscapeMines.Exceptions;

namespace EscapeMines
{
    public enum Direction
    {
        North,
        South,
        West,
        East,
    }
    public enum Move
    {
        RightRotate,
        LeftRotate,
        Move
    }
    class ProgramInput
    {

        public ProgramInput()
        {
            var lines = File.ReadAllLines("config.txt");
            if (lines.Length < 5)
            {
                throw new ConfigException("Incorrect Number Of Lines");
            }

            List<Move> moves = new List<Move>();
            for (int i = 0; i < lines.Length; i++)
            {
                try
                {
                    var line = lines[i].Trim();
                    var splitLine = line.Split();
                    switch (i)
                    {
                        case 0:
                            //Board Size


                            if (splitLine.Length < 2)
                            {
                                throw new Exception();
                            }

                            int xDimension = int.Parse(splitLine[0]);
                            int yDimension = int.Parse(splitLine[1]);
                            this.BoardSize = (xDimension, yDimension);
                            break;

                        case 1:
                            //Mines
                            foreach (var coords in splitLine)
                            {
                                var xCoords = int.Parse(coords.Split(",")[0]);
                                var yCoords = int.Parse(coords.Split(",")[1]);
                                this.Mines.Add((xCoords, yCoords));
                            }
                            break;
                        case 2:
                            //Exit
                            {
                                int x = int.Parse(splitLine[0]);
                                int y = int.Parse(splitLine[1]);
                                this.ExitPoint = (x, y);
                            }
                            break;
                        case 3:
                            //Start Position
                            {
                                int x = int.Parse(splitLine[0]);
                                int y = int.Parse(splitLine[1]);
                                Direction direction = Direction.North;
                                switch (splitLine[2].Trim().ToUpper())
                                {
                                    case "N":
                                        direction = Direction.North;
                                        break;
                                    case "S":
                                        direction = Direction.South;
                                        break;
                                    case "W":
                                        direction = Direction.West;
                                        break;
                                    case "E":
                                        direction = Direction.East;
                                        break;
                                    default:
                                        throw new Exception();
                                }

                                this.StartPoint = (x, y, direction);
                            }
                            break;
                    }

                    if (i >= 4)
                    {
                        var moveStrings = line.Split();
                        foreach(var moveString in moveStrings)
                        {
                            switch (moveString.Trim().ToUpper())
                            {
                                case "R":
                                    moves.Add(Move.RightRotate);
                                    break;
                                case "L":
                                    moves.Add(Move.LeftRotate);
                                    break;
                                case "M":
                                    moves.Add(Move.Move);
                                    break;
                            }
                        }
                    }

                }
                catch (Exception)
                {
                    throw new ConfigException(i);
                }

            }

            this.Moves = moves;
        }
        public (int, int) BoardSize { get; set; } = (1, 1);
        public List<(int, int)> Mines { get; set; } = new List<(int, int)>();

        public (int, int) ExitPoint { get; set; } = (0, 0);

        public (int, int, Direction) StartPoint { get; set; } = (0, 0, Direction.North);

        public List<Move> Moves { get; set; } = new List<Move>();

    }
}
