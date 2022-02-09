using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_of_Life
{
    public class Life
    {

        public struct Point
        {
            internal int X { get; set; }
            internal int Y { get; set; }
        }
        
        public class PointWithState
        {
            private int _x;
            private int _y;
            protected int _state;

            public PointWithState(int x, int y, int state)
            {
                _x = x;
                _y = y;
                _state = state;
            }

            public int GetX()
            {
                return _x;
            }

            public int GetY()
            {
                return _y;
            }

            public int GetState()
            {
                return _state;
            }

            public void SetState(int value)
            {
                _state = value;
            }
        }

        public class GameProcessor
        {
            protected static int row = 5;
            protected static int col = 9;
            protected internal static PointWithState[,] arr = new PointWithState[row, col];
            protected internal static List<Point> listOfAlivePoints = new List<Point>();

            public GameProcessor(int i, int j, PointWithState[,] a)
            {
                row = i;
                col = j;
                arr = a;
                
                for(int n=0; n < row; n++)
                {
                    for(int k=0; k < col; k++)
                    {
                        if(arr[i, j].GetState() == 1)
                        {
                            listOfAlivePoints.Add(new Point { X = n, Y = k });
                        }
                    }
                }

            }
            /*
            public GameProcessor(int i, int j, PointWithState[,] a, List<Point> list)
            {
                row = i;
                col = j;
                arr = a;
                listOfAlivePoints = list;
            }
            */

            public Point[] Process()
            {
                bool[,] temp = new bool[row, col];

                int count;

                for (int i = 0; i < temp.GetLength(0); i++)
                {
                    for (int j = 0; j < temp.GetLength(1); j++)
                    {

                        if (i == 0 && j == 0)
                        {
                            count = arr[i, j + 1].GetState() + arr[i + 1, j + 1].GetState() + arr[i + 1, j].GetState();

                        }
                        else if (i == 0 && j == temp.GetLength(1) - 1)
                        {
                            count = arr[i, j - 1].GetState() + arr[i + 1, j - 1].GetState() + arr[i + 1, j].GetState();

                        }
                        else if (i == temp.GetLength(0) - 1 && j == temp.GetLength(1) - 1)
                        {
                            count = arr[i, j - 1].GetState() + arr[i - 1, j - 1].GetState() + arr[i - 1, j].GetState();

                        }
                        else if (i == temp.GetLength(0) - 1 && j == 0)
                        {
                            count = arr[i, j + 1].GetState() + arr[i - 1, j + 1].GetState() + arr[i - 1, j].GetState();

                        }
                        else if (i == 0 && !(j == 0 || j == temp.GetLength(1) - 1))
                        {
                            count = arr[i, j - 1].GetState() + arr[i + 1, j - 1].GetState() +
                                    arr[i + 1, j].GetState() + arr[i + 1, j + 1].GetState() + arr[i, j + 1].GetState();

                        }
                        else if (i == temp.GetLength(0) - 1 && !(j == 0 || j == temp.GetLength(1) - 1))
                        {
                            count = arr[i, j - 1].GetState() + arr[i - 1, j - 1].GetState() +
                                    arr[i - 1, j].GetState() + arr[i - 1, j + 1].GetState() + arr[i, j + 1].GetState();

                        }
                        else if (j == 0 && !(i == 0 || i == temp.GetLength(0) - 1))
                        {
                            count = arr[i - 1, j].GetState() + arr[i - 1, j + 1].GetState() +
                                    arr[i, j + 1].GetState() + arr[i + 1, j + 1].GetState() + arr[i + 1, j].GetState();

                        }
                        else if (j == temp.GetLength(1) - 1 && !(i == 0 || i == temp.GetLength(0) - 1))
                        {
                            count = arr[i - 1, j].GetState() + arr[i - 1, j - 1].GetState() +
                                    arr[i, j - 1].GetState() + arr[i + 1, j - 1].GetState() + arr[i + 1, j].GetState();

                        }
                        else
                        {
                            count = arr[i - 1, j].GetState() + arr[i, j - 1].GetState() + arr[i + 1, j].GetState() + arr[i, j + 1].GetState() +
                                arr[i - 1, j + 1].GetState() + arr[i + 1, j - 1].GetState() + arr[i - 1, j - 1].GetState() + arr[i + 1, j + 1].GetState();

                        }


                        if (arr[i, j].GetState() == 1 && (count == 2 || count == 3))
                        {
                            temp[i, j] = true;
                        }
                        else if (arr[i, j].GetState() == 1 && (count < 2 || count > 3))
                        {
                            temp[i, j] = false;

                        }

                        else if (arr[i, j].GetState() == 0 && count == 3)
                        {
                            temp[i, j] = true;
                        }
                        else
                        {
                            temp[i, j] = false;

                        }

                    }
                }


                var alivePoints = new List<Point>();
                listOfAlivePoints.Clear();

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if (temp[i, j])
                        {
                            arr[i, j].SetState(1);
                            alivePoints.Add(new Point { X = i, Y = j });
                        }
                        else
                        {
                            arr[i, j].SetState(0);
                        }
                    }
                }

                listOfAlivePoints = alivePoints;
                return alivePoints.ToArray();
            }

            public PointWithState[,] GetArr()
            {
                PointWithState[,] otherArray = new PointWithState[row, col];
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        otherArray[i, j] = arr[i, j];
                    }
                }

                return otherArray;
            }

            public List<Point> GetList()
            {
                return listOfAlivePoints;
            }

            public void Print()
            {
                //Console.WriteLine("-------------------");
                for (int row = 0; row < arr.GetLength(0); ++row)
                {
                    Console.Write(arr.GetLength(0) - row);
                    Console.Write(" ");
                    for (int col = 0; col < arr.GetLength(1); ++col)
                    {
                        if (arr[row, col].GetState() == 0) Console.Write("- ");
                        else if (arr[row, col].GetState() == 1) Console.Write("+ ");

                    }
                    Console.WriteLine(" ");
                }
                Console.WriteLine(0 + " " + 1 + " " + 2 + " " + 3 + " " + 4 + " " + 5 +
                                " " + 6 + " " + 7 + " " + 8 + " " + 9);
                Console.WriteLine("-------------------");
            }

        }
    }
}
