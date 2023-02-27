using charp;
using static System.Console;

namespace charp
{
    internal class hw_modul_4_task_1_and_2
    {
        static void Menu()
        {
            int menu_choice;
            Random rand = new();
            int whos_turn = rand.Next(1, 3);
            do
            {
                WriteLine("Выбор режима игры: \n" +
                          "1 - Бот против игрока\n" +
                          "2 - Игрок против игрока\n" +
                          "0 - Выход\n");

                menu_choice = int.Parse(ReadLine() ?? "0");

                switch (menu_choice)
                {
                    case 0:
                        WriteLine("ВЫХОД");
                        break;
                    case 1:
                        WriteLine("Вы выбрали режим игры Бот против Игрока\n\n");
                        Gamemode.PlayerVsBot.Game gameBvP = new();
                        gameBvP.PlayGame(whos_turn);
                        break;
                    case 2:
                        WriteLine("Вы выбрали режим игры Игрок против Игрока\n\n");
                        Gamemode.PlayerVsPlayer.Game gamePvP = new();
                        gamePvP.PlayGame(whos_turn);
                        break;
                    default:
                        break;
                }
            } while (menu_choice != 0);
        }
        static void Main()
        {
            Menu();
        }
    }
}

namespace Gamemode
{
    namespace PlayerVsBot
    {
        class Game
        {
            const int COMPUTER = 1;
            const int HUMAN = 2;

            const int SIDE = 3;

            const char COMPUTER_MOVE = 'X';
            const char HUMAN_MOVE = 'O';

            void ShowBoard(char[,] board)
            {
                WriteLine($"\n\t {board[0, 0]} | {board[0, 1]} | {board[0, 2]} \n" +
                          $"\t-----------\n" +
                          $"\t {board[1, 0]} | {board[1, 1]} | {board[1, 2]} \n" +
                          $"\t-----------\n" +
                          $"\t {board[2, 0]} | {board[2, 1]} | {board[2, 2]} \n\n");
            }
            void HowToPlay()
            {
                WriteLine("\t Игра: Крестики-Нолики\n" +
                          "\t Выберите ячейку от 1 до 9 \n");
                WriteLine("\n\t 1 | 2 | 3 \n" +
                            "\t-----------\n" +
                            "\t 4 | 5 | 6 \n" +
                            "\t-----------\n" +
                            "\t 7 | 8 | 9 \n\n");
            }
            void Initialise(char[,] board)
            {
                for (int i = 0; i < SIDE; i++)
                {
                    for (int j = 0; j < SIDE; j++)
                        board[i, j] = ' ';
                }
            }
            int ReadTurn()
            {
                int input_number = 0;
                do
                {
                    Write(">");
                    try
                    {
                        input_number = int.Parse(ReadLine() ?? "0");
                    }
                    catch (Exception e)
                    {
                        WriteLine(e.Message);
                    }

                } while (input_number < 1 || input_number > 9);

                return input_number - 1;
            }

            void DeclareWinner(int last_turn)
            {
                if (last_turn == COMPUTER)
                    WriteLine("БОТ ОДЕРЖАЛ ПОБЕДУ!\n");
                else
                    WriteLine("ИГРОК ПОБЕДИЛ!\n");
            }

            bool RowCrossed(char[,] board)
            {
                for (int i = 0; i < SIDE; i++)
                {
                    if (board[i, 0] == board[i, 1] &&
                        board[i, 1] == board[i, 2] &&
                        board[i, 0] != ' ')
                        return true;
                }
                return false;
            }
            bool ColumnCrossed(char[,] board)
            {
                for (int i = 0; i < SIDE; i++)
                {
                    if (board[0, i] == board[1, i] &&
                        board[1, i] == board[2, i] &&
                        board[0, i] != ' ')
                        return true;
                }
                return false;
            }
            bool DiagonalCrossed(char[,] board)
            {
                if (board[0, 0] == board[1, 1] &&
                    board[1, 1] == board[2, 2] &&
                    board[0, 0] != ' ')
                    return true;

                if (board[0, 2] == board[1, 1] &&
                    board[1, 1] == board[2, 0] &&
                    board[0, 2] != ' ')
                    return true;

                return false;
            }
            bool GameOver(char[,] board)
            {
                return (RowCrossed(board) || ColumnCrossed(board)
                                          || DiagonalCrossed(board));
            }

            public void PlayGame(int turn)
            {
                char[,] board = new char[SIDE, SIDE];

                Initialise(board);

                HowToPlay();

                int moveIndex = 0, x, y;
                Random rand = new();

                while (GameOver(board) == false &&
                       moveIndex != SIDE * SIDE)
                {
                    if (turn == COMPUTER)
                    {
                        int random;
                        do
                        {
                            random = rand.Next(0, 9);
                            x = random / SIDE;
                            y = random % SIDE;

                            if (board[x, y] == ' ')
                                board[x, y] = COMPUTER_MOVE;
                            else
                                random = -1;

                        } while (random == -1);

                        Write("COMPUTER поместил {0} в клетку {1}\n",
                            COMPUTER_MOVE, random + 1);

                        ShowBoard(board);

                        moveIndex++;
                        turn = HUMAN;
                    }

                    else if (turn == HUMAN)
                    {
                        int input_choice;

                        do
                        {
                            input_choice = ReadTurn();
                            x = input_choice / SIDE;
                            y = input_choice % SIDE;

                            if (board[x, y] == ' ')
                                board[x, y] = HUMAN_MOVE;
                            else
                            {
                                input_choice = -1;
                                Write("Ошибка\n");
                            }

                        } while (input_choice == -1);

                        board[x, y] = HUMAN_MOVE;

                        Write("HUMAN поместил {0} в клетку {1}\n",
                            HUMAN_MOVE, input_choice + 1);

                        ShowBoard(board);

                        moveIndex++;
                        turn = COMPUTER;
                    }
                }

                if (GameOver(board) == false &&
                    moveIndex == SIDE * SIDE)
                    WriteLine("НИЧЬЯ\n");
                else
                {
                    if (turn == COMPUTER)
                        turn = HUMAN;
                    else if (turn == HUMAN)
                        turn = COMPUTER;

                    DeclareWinner(turn);
                }
            }
        }
    }

    namespace PlayerVsPlayer
    {
        class Game
        {
            const int PLAYER1 = 1;
            const int PLAYER2 = 2;

            const int SIDE = 3;

            const char PLAYER1_MOVE = 'X';
            const char PLAYER2_MOVE = 'O';

            void ShowBoard(char[,] board)
            {
                WriteLine($"\n\t {board[0, 0]} | {board[0, 1]} | {board[0, 2]} \n" +
                          $"\t-----------\n" +
                          $"\t {board[1, 0]} | {board[1, 1]} | {board[1, 2]} \n" +
                          $"\t-----------\n" +
                          $"\t {board[2, 0]} | {board[2, 1]} | {board[2, 2]} \n\n");
            }
            void HowToPlay()
            {
                WriteLine("\t Игра: Крестики-Нолики\n" +
                          "\t Выберите ячейку от 1 до 9 \n");
                WriteLine("\n\t 1 | 2 | 3 \n" +
                            "\t-----------\n" +
                            "\t 4 | 5 | 6 \n" +
                            "\t-----------\n" +
                            "\t 7 | 8 | 9 \n\n");
            }
            void Initialise(char[,] board)
            {
                for (int i = 0; i < SIDE; i++)
                {
                    for (int j = 0; j < SIDE; j++)
                        board[i, j] = ' ';
                }
            }
            int ReadTurn(int whose_turn)
            {
                int input_number = 0;
                do
                {
                    if (whose_turn == PLAYER1)
                        Write("PLAYER1 ВАШ ХОД ");
                    else
                        Write("PLAYER2 ВАШ ХОД ");

                    Write("> ");
                    try
                    {
                        input_number = int.Parse(ReadLine() ?? "0");
                    }
                    catch (Exception e)
                    {
                        WriteLine(e.Message);
                    }

                } while (input_number < 1 || input_number > 9);

                WriteLine();

                return input_number - 1;
            }

            void DeclareWinner(int last_turn)
            {
                if (last_turn == PLAYER1)
                    WriteLine("PLAYER1 ОДЕРЖАЛ ПОБЕДУ!\n");
                else
                    WriteLine("PLAYER2 ОДЕРЖАЛ ПОБЕДУ!\n");
            }

            bool RowCrossed(char[,] board)
            {
                for (int i = 0; i < SIDE; i++)
                {
                    if (board[i, 0] == board[i, 1] &&
                        board[i, 1] == board[i, 2] &&
                        board[i, 0] != ' ')
                        return true;
                }
                return false;
            }
            bool ColumnCrossed(char[,] board)
            {
                for (int i = 0; i < SIDE; i++)
                {
                    if (board[0, i] == board[1, i] &&
                        board[1, i] == board[2, i] &&
                        board[0, i] != ' ')
                        return true;
                }
                return false;
            }
            bool DiagonalCrossed(char[,] board)
            {
                if (board[0, 0] == board[1, 1] &&
                    board[1, 1] == board[2, 2] &&
                    board[0, 0] != ' ')
                    return true;

                if (board[0, 2] == board[1, 1] &&
                    board[1, 1] == board[2, 0] &&
                    board[0, 2] != ' ')
                    return true;

                return false;
            }
            bool GameOver(char[,] board)
            {
                return (RowCrossed(board) || ColumnCrossed(board)
                                          || DiagonalCrossed(board));
            }

            public void PlayGame(int turn)
            {
                char[,] board = new char[SIDE, SIDE];

                Initialise(board);

                HowToPlay();

                int moveIndex = 0, x, y;

                while (GameOver(board) == false &&
                       moveIndex != SIDE * SIDE)
                {
                    if (turn == PLAYER1)
                    {
                        int input_player1;
                        do
                        {
                            input_player1 = ReadTurn(PLAYER1);
                            x = input_player1 / SIDE;
                            y = input_player1 % SIDE;

                            if (board[x, y] == ' ')
                                board[x, y] = PLAYER1_MOVE;
                            else
                            {
                                input_player1 = -1;
                                Write("Ошибка\n");
                            }

                        } while (input_player1 == -1);

                        Write("PLAYER1 поместил {0} в клетку {1}\n",
                            PLAYER1_MOVE, input_player1 + 1);

                        ShowBoard(board);

                        moveIndex++;
                        turn = PLAYER2;
                    }

                    else if (turn == PLAYER2)
                    {
                        int input_player2;

                        do
                        {
                            input_player2 = ReadTurn(PLAYER2);
                            x = input_player2 / SIDE;
                            y = input_player2 % SIDE;

                            if (board[x, y] == ' ')
                                board[x, y] = PLAYER2_MOVE;
                            else
                            {
                                input_player2 = -1;
                                Write("Ошибка\n");
                            }

                        } while (input_player2 == -1);

                        board[x, y] = PLAYER2_MOVE;

                        Write("PLAYER2 поместил {0} в клтку {1}\n",
                            PLAYER2_MOVE, input_player2 + 1);

                        ShowBoard(board);

                        moveIndex++;
                        turn = PLAYER1;
                    }
                }

                if (GameOver(board) == false &&
                    moveIndex == SIDE * SIDE)
                    WriteLine("НИЧЬЯ\n");
                else
                {
                    if (turn == PLAYER1)
                        turn = PLAYER2;
                    else if (turn == PLAYER2)
                        turn = PLAYER1;

                    DeclareWinner(turn);
                }
            }
        }
    }
}