using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperUpdated
{
    public class GameWithCell
    {
        public Cell[,] Grid { get; }
        private string[,] m_GridHint;
        private readonly int m_GridNumberOfLines;
        private readonly int m_GridNumberOfColumns;

        public GameWithCell(Cell[,] grid)
        {
            Grid = grid;
            m_GridNumberOfLines = Grid.GetLength(0);
            m_GridNumberOfColumns = Grid.GetLength(1);
            m_GridHint = InitializeGridHint();
        }

        public string[,] ProvideGridHint()
        {
            for (var line = 0; line < m_GridNumberOfLines; line++)
            {
                for (var column = 0; column < m_GridNumberOfColumns; column++)
                {
                    if (Grid[line, column] == Cell.Mine)
                    {
                        IncrementNeighboorCells(line, column);
                    }
                }
            }
            return m_GridHint;
        }

        private void IncrementNeighboorCells(int mineLineIndex, int mineColumnIndex)
        {
            for (var line = mineLineIndex - 1; line <= mineLineIndex+1; line++)
            {
                for (var column = mineColumnIndex - 1; column <= mineColumnIndex + 1; column++)
                {
                    if (line >= 0 && column >= 0 && line < m_GridNumberOfLines &&
                        column < m_GridNumberOfColumns)
                    {
                        if (m_GridHint[line, column] != "*")
                        {
                            var numberOfMines = int.Parse(m_GridHint[line, column])+1;
                            m_GridHint[line, column] = numberOfMines.ToString();
                        }
                    }
                }
            }
        }

        private string[,] InitializeGridHint()
        {
            m_GridHint = new string[m_GridNumberOfLines, m_GridNumberOfColumns];
            for (var line = 0; line < m_GridNumberOfLines; line++)
            {
                for (var column = 0; column < m_GridNumberOfColumns; column++)
                {
                    if (Grid[line, column] == Cell.Mine)
                    {
                        m_GridHint[line, column] = "*";
                    }
                    else
                    {
                        m_GridHint[line, column] = ((int)Cell.NoMine).ToString();
                    }
                }
            }
            return m_GridHint;
        }

   
    }
}
