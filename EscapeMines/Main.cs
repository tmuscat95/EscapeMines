using EscapeMines.Exceptions;
using EscapeMines.Types;

namespace EscapeMines
{
    public class EscapeMinesMain
    {
        public static Result PlayGame(BoardState boardState, List<Move> moves)
        {
            //try
            //{
                Result result = Result.StillInDanger;

                foreach (var move in moves)
                {
                   

                    if (move == Move.Move)
                    {
                        switch (boardState.PlayerOrientation)
                        {
                            case Direction.North:
                                boardState.PlayerPosition = (boardState.PlayerPosition.Item1, boardState.PlayerPosition.Item2 + 1);
                                break;
                            case Direction.South:
                                boardState.PlayerPosition = (boardState.PlayerPosition.Item1, boardState.PlayerPosition.Item2 - 1);
                                break;
                            case Direction.East:
                                boardState.PlayerPosition = (boardState.PlayerPosition.Item1 + 1, boardState.PlayerPosition.Item2);
                                break;
                            case Direction.West:
                                boardState.PlayerPosition = (boardState.PlayerPosition.Item1 - 1, boardState.PlayerPosition.Item2);
                                break;
                        }
                    }
                    else if (move == Move.RightRotate)
                    {
                        switch (boardState.PlayerOrientation)
                        {
                            case Direction.North:
                                boardState.PlayerOrientation = Direction.East;
                                break;
                            case Direction.East:
                                boardState.PlayerOrientation = Direction.South;
                                break;
                            case Direction.South:
                                boardState.PlayerOrientation = Direction.West;
                                break;
                            case Direction.West:
                                boardState.PlayerOrientation = Direction.North;
                                break;
                        }
                    }
                    else if (move == Move.LeftRotate)
                    {
                        switch (boardState.PlayerOrientation)
                        {
                            case Direction.North:
                                boardState.PlayerOrientation = Direction.West;
                                break;
                            case Direction.East:
                                boardState.PlayerOrientation = Direction.North;
                                break;
                            case Direction.South:
                                boardState.PlayerOrientation = Direction.East;
                                break;
                            case Direction.West:
                                boardState.PlayerOrientation = Direction.South;
                                break;
                        }
                    }

                if (boardState.PlayerPosition.Item1 == boardState.ExitPoint.Item1 && boardState.PlayerPosition.Item2 == boardState.ExitPoint.Item2)
                {
                    result = Result.Success;
                    break;
                }
                else if (boardState.PlayerPosition.Item1 < 0 || boardState.PlayerPosition.Item2 < 0 || boardState.PlayerPosition.Item1 >= boardState.BoardSize.Item1 || boardState.PlayerPosition.Item2 >= boardState.BoardSize.Item2)
                {
                    result = Result.IllegalMove;
                    break;
                }
                else if (boardState.MineLocations.Contains((boardState.PlayerPosition.Item1, boardState.PlayerPosition.Item2)))
                {
                    result = Result.MineHit;
                    break;
                }
            }

                //bool moveToNextSequence = false;
                switch (result)
                {
                    case Result.Success:
                        Console.WriteLine("Success. Turtle Has Reached the end of the maze.");
                        break;
                    case Result.MineHit:
                        Console.WriteLine("Failure. Turtle Has Hit A Mine.");
                        break;
                    case Result.StillInDanger:
                        //moveToNextSequence = true;
                        Console.WriteLine("Turtle has not reached the end of the maze.");
                        break;
                    default:
                        Console.WriteLine("Illegal Move Detected (Out Of Bounds)");
                        break;
                }
                return result;

            //}
            //catch (ConfigException e)
            //{
            //    Console.Error.WriteLine(e.Message);
            //    return Result.;
            //}
        }

        public static void Main(string[] args)
        {
            var lines = File.ReadAllLines("config.txt");
            var programInput = new ProgramInput(lines);

            BoardState boardState = new BoardState(programInput);
            var movesSequences = programInput.MovesSequences;

            foreach (var moves in movesSequences)
            {
                if(!(PlayGame(boardState, moves) == Result.StillInDanger))
                {
                    break;
                }
                Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
}
