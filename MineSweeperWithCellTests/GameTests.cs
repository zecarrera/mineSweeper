using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MineSweeperUpdated;
using NUnit.Framework;

namespace MineSweeperUpdatedTests
{
    public class GameWithCellTests
    {
        private GameWithCell m_TestGame;
        private Cell[,] m_TestInput;

        [Test]
        public void GridOfMinesCanBeBuilt()
        {
            m_TestInput = new Cell[3, 4]
            {
                { Cell.Mine, Cell.NoMine, Cell.NoMine , Cell.NoMine }, 
                { Cell.Mine, Cell.NoMine, Cell.NoMine, Cell.NoMine }, 
                { Cell.Mine, Cell.NoMine, Cell.NoMine, Cell.NoMine }
            };
            m_TestGame = new GameWithCell(m_TestInput);
            Assert.That(m_TestGame.Grid, Is.EqualTo(m_TestInput));
        }

        [Test]
        public void GetGridHint_WhenMineInTheCenter_ProducesExpectedGridHint()
        {
            m_TestInput = new Cell[3, 3]
            {
                { Cell.NoMine, Cell.NoMine , Cell.NoMine },
                { Cell.NoMine, Cell.Mine, Cell.NoMine },
                { Cell.NoMine, Cell.NoMine, Cell.NoMine }
            };
            m_TestGame = new GameWithCell(m_TestInput);
            var expectedGridHint = new string[3, 3]
            {
                { "1", "1", "1" },
                { "1", "*", "1" },
                { "1", "1", "1" }
            };

            var resultingGridHint = m_TestGame.ProvideGridHint();
            ConsolePrinter.Print(resultingGridHint);
            Assert.That(resultingGridHint, Is.EqualTo(expectedGridHint));
        }

        [Test]
        public void GetGridHint_WhenMineInTopLine_ProducesExpectedGridHint()
        {
            m_TestInput = new Cell[3, 3]
            {
                {Cell.NoMine, Cell.Mine, Cell.NoMine},
                {Cell.NoMine, Cell.NoMine, Cell.NoMine},
                {Cell.NoMine, Cell.NoMine, Cell.NoMine}
            };
            m_TestGame = new GameWithCell(m_TestInput);
            var expectedGridHint = new string[3, 3]
            {
                { "1", "*", "1" },
                { "1", "1", "1" },
                { "0", "0", "0" }
            };

            var resultingGridHint = m_TestGame.ProvideGridHint();
            ConsolePrinter.Print(resultingGridHint);
            Assert.That(resultingGridHint, Is.EqualTo(expectedGridHint));
        }

        [Test]
        public void GetGridHint_WhenMineInBottomLine_ProducesExpectedGridHint()
        {
            m_TestInput = new Cell[3, 3]
            {
                {Cell.NoMine, Cell.NoMine, Cell.NoMine},
                {Cell.NoMine, Cell.NoMine, Cell.NoMine},
                {Cell.NoMine, Cell.Mine, Cell.NoMine}
            };
            m_TestGame = new GameWithCell(m_TestInput);
            var expectedGridHint = new string[3, 3]
            {
                { "0", "0", "0" },
                { "1", "1", "1" },
                { "1", "*", "1" }
            };

            var resultingGridHint = m_TestGame.ProvideGridHint();
            ConsolePrinter.Print(resultingGridHint);
            Assert.That(resultingGridHint, Is.EqualTo(expectedGridHint));
        }

        [Test]
        public void GetGridHint_WhenMineInLeftColumn_ProducesExpectedGridHint()
        {
            m_TestInput = new Cell[3, 3]
               {
                {Cell.Mine, Cell.NoMine, Cell.NoMine},
                {Cell.NoMine, Cell.NoMine, Cell.NoMine},
                {Cell.NoMine, Cell.NoMine, Cell.NoMine}
               };
            m_TestGame = new GameWithCell(m_TestInput);
            var expectedGridHint = new string[3, 3]
            {
                { "*", "1", "0" },
                { "1", "1", "0" },
                { "0", "0", "0" }
            };

            var resultingGridHint = m_TestGame.ProvideGridHint();
            ConsolePrinter.Print(resultingGridHint);
            Assert.That(resultingGridHint, Is.EqualTo(expectedGridHint));
        }

        [Test]
        public void GetGridHint_WhenMineInRightColumn_ProducesExpectedGridHint()
        {
            m_TestInput = new Cell[3, 3]
               {
                {Cell.NoMine, Cell.NoMine, Cell.NoMine},
                {Cell.NoMine, Cell.NoMine, Cell.Mine},
                {Cell.NoMine, Cell.NoMine, Cell.NoMine}
               };
            m_TestGame = new GameWithCell(m_TestInput);
            var expectedGridHint = new string[3, 3]
            {
                { "0", "1", "1" },
                { "0", "1", "*" },
                { "0", "1", "1" }
            };

            var resultingGridHint = m_TestGame.ProvideGridHint();
            ConsolePrinter.Print(resultingGridHint);
            Assert.That(resultingGridHint, Is.EqualTo(expectedGridHint));
        }

        [Test]
        public void GetGridHint_WhenMultipleMinesArePlotted_ProducesExpectedGridHint()
        {
            m_TestInput = new Cell[3, 4]
               {
                {Cell.Mine, Cell.NoMine, Cell.NoMine, Cell.NoMine},
                {Cell.NoMine, Cell.NoMine,Cell.Mine, Cell.NoMine},
                {Cell.NoMine, Cell.NoMine, Cell.NoMine, Cell.NoMine}
               };
           // string [] input = new string[] {"*...","..*.","...."};
            //m_TestInput = StringToArrayOfCell(input);
            m_TestGame = new GameWithCell(m_TestInput);
            var expectedGridHint = new string[3, 4]
            {
                { "*", "2", "1", "1" },
                { "1", "2", "*", "1"},
                { "0", "1", "1", "1" }
            };

            var resultingGridHint = m_TestGame.ProvideGridHint();
            ConsolePrinter.Print(resultingGridHint);
            Assert.That(resultingGridHint, Is.EqualTo(expectedGridHint));
        }

   /*     private Cell[,] StringToArrayOfCell(string[] gridInput)
        {
            Cell[,] gridInCellFormat = new Cell[,] {};

            for (int line = 0; line < gridInput.GetLength(0); line++)
            {
                var element = gridInput[line];
                if (element.Equals("*"))
                {
                    gridInCellFormat[line,]
                }
            }
        }*/
    }
}
