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

            Board[y][x] = v;

            CheckIndexDidWin(RowSelector, y);
            CheckIndexDidWin(ColomnSelector, x);
            CheckIndexDidWin(BoxSelector, x / CellCount + CellCount * (y / CellCount)); 

        }

        public bool DidWin()
        {
            //Board not not contain any 0. 
            return CheckDidWin(RowSelector)  //row 
                && CheckDidWin(ColomnSelector)  //colomn
                && CheckDidWin(BoxSelector);
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
            return (e % CellCount) + (Size * (e / CellCount)) + (i * CellCount) + ((i / CellCount) * CellCount * Size)));
        }
        #endregion
        private int SelectRow(int i, int e)
        {
           return  (i * Size) + e;
        }

        private bool CheckDidWin(Func<int, int, int> selector)
        {
            for (int i = 0; i < Size; i++)
            {
                if (!CheckIndexDidWin(selector,i))
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckIndexDidWin(Func<int,int,int> selector, int i)
        {
            List<Pair> numbersFound = new List<Pair>(); //UniqueList

            for (int e = 0; e < Size; e++)
            {
                int PairNumber = selector(i, e); 

                Pair pair = new Pair(Size, PairNumber);

                int value = Board[pair.Y][pair.X];

                foreach (Pair p in numbersFound)
                {
                    if (p.Y == value)
                    {
                        return false; 
                    }
                }

                numbersFound.Add(new Pair(Size, e, value)); // e => x, value -> y
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

    }

}
