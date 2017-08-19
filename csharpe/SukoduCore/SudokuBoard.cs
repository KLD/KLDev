using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SukoduCore
{
    //9x9 with boxes 3x3 
    public class SudokuBoard
    {
        public const int DEFAULT_BOARD_SIZE = 9;
        public const int DEFAULT_CELL_COUNT = 3;

        public int[][] Board { private set; get; }

        //holds the number of errors 
        public int[][] ErrorBoard { private set; get; }

        private int Size;
        private int CellCount;

        public SudokuBoard(int boardSize = DEFAULT_BOARD_SIZE, int cellCount = DEFAULT_CELL_COUNT)
        {
            Size = boardSize;
            CellCount = cellCount; 

            Board = Enumerable.Repeat(new int[Size], Size).ToArray();
            ErrorBoard = Enumerable.Repeat(new int[Size], Size).ToArray();
        }

        public void Set(int x, int y, int v)
        {
            if (v < 0 || v > 9)
            {
                return; //error; 
            }

            if (Board[y][x] < 0)
            {
                return; //throw Exception 
            }

            if(Board[y][x] == v)
            {
                return; //duplicate number exeption 
            }

            VerifyErrors(x, y, v); 

            Board[y][x] = v;



            //CheckIndexDidWin(RowSelector, y);
            //CheckIndexDidWin(ColomnSelector, x);
            //CheckIndexDidWin(BoxSelector, GetBoxIndex(x,y)); 
        }

        public bool DidWin()
        {
            //Board not not contain any 0. 
            return CheckDidWin(RowSelector)  //row 
                && CheckDidWin(ColomnSelector)  //colomn
                && CheckDidWin(BoxSelector);
        }

        private void VerifyErrors(int x, int y, int newValue)
        {
            //reset error 
            ErrorBoard[y][x] = 0;

            int prev = Board[y][x]; 

            Func<int, bool> ErrorOut = n =>
            {
                Pair p = new Pair(Size, n);
                int cellValue = Board[p.Y][p.X]; 

                //don't compare yourself 
                if(p.X == x && p.Y == y)
                {
                    return true; 
                }

                if(cellValue == prev)
                {
                    ErrorBoard[p.Y][p.X]--; 
                }
                else if(cellValue == newValue)
                {
                    ErrorBoard[p.Y][p.X]++;
                    ErrorBoard[y][x]++;
                }

                return true;
            };
        }


        #region Selectors 
        private int RowSelector(int i, int e)
        {
            return i * Size + e; 
        }
        private int ColomnSelector(int i, int e)
        {
            return e * Size + i; 
        }
        private int BoxSelector(int i,int e)
        {
            return (e % CellCount) + (Size * (e / CellCount)) + (i * CellCount) + ((i / CellCount) * CellCount * Size);
        }
        #endregion

        private int GetBoxIndex(int x, int y)
        {
            return x / CellCount + CellCount * (y / CellCount); 
        }

        private bool CheckDidWin(Func<int, int, int> selector)
        {
            List<int> numbersFound = new List<int>(); //UniqueList

            //TODO move to func
            Func<int, bool> CheckUnique = n =>
            {
                Pair pair = new Pair(Size, n);

                int value = Board[pair.Y][pair.X];

                foreach (int number in numbersFound)
                {
                    if (number == value)
                    {
                        return false;
                    }
                }

                numbersFound.Add(value); // e => x, value -> y
                
                //continue 
                return true; 
            }; 


            for (int i = 0; i < Size; i++)
            {
                if (!CheckIndexDidWin(selector,i, CheckUnique))
                {
                    return false;
                }
                numbersFound.Clear(); 
            }
            return true;
        }

        private bool CheckIndexDidWin(Func<int,int,int> selector, int selectorIndex, Func<int,bool> itterator)
        {
            for (int i = 0; i < Size; i++)
            {
                int PairIndexNumber = selector(selectorIndex, i); 
               
                if(itterator(PairIndexNumber) == false)
                {
                    return false; 
                }
            }

            return true;
        }



    }

    struct Pair : IEqualityComparer
    {
        public int Size; 

        public int X;
        public int Y;

        public int NumberValue
        {
            set
            {
                X = value % Size;
                Y = value / Size;
            }

            get
            {
                return Y * Size + X; 

            }
        }
        
        /// <summary>
        /// Creates a pair with x, y  coordenates 
        /// </summary>
        /// <param name="n"></param>
        public Pair(int size,int x, int y)
        {
            Size = size; 

            X = x;
            Y = y; 
        }

        /// <summary>
        /// Creates a pair with a number value. 
        /// </summary>
        /// <param name="n"></param>
        public Pair(int size, int n)
        {
            Size = size;

            X = n % size;
            Y = n / size; 
        }

        public new bool Equals(object x, object y)
        {
            if(!(x is Pair))
            {
                return false; 
            }

            if (!(y is Pair))
            {
                return false;
            }

            Pair pX = (Pair)x;
            Pair pY = (Pair)y;


            return pX.X == pY.X && pY.Y == pX.Y; 
        }

        public int GetHashCode(object obj)
        {
            return X.GetHashCode() & Y.GetHashCode(); 
        }
    }
}
