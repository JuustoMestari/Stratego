using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stratego
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player("David", SpaceType.Player1, PlayerColor.Red);
            Player p2 = new Player("Paul", SpaceType.Player2, PlayerColor.Blue);
            Game plop = new Game(p1,p2);
            

            Position pos1 = new Position();
            pos1.row = 3;
            pos1.col = 4;

            Position pos2 = new Position();
            pos2.row = 6;
            pos2.col = 4;

            plop.setPieceOnGrid(plop.player2Pieces[2], pos1);
            plop.setPieceOnGrid(plop.player1Pieces[0], pos2);

            plop.start();

            plop.initialGrid.displayGrid();


            for (int i = 1; i <8;i++ )
            {
                Position nextPos = new Position();
                nextPos.row = pos1.row+1;
                nextPos.col = pos1.col;
                switch (plop.movePiece(pos1, nextPos))
                {
                    case 1: Console.WriteLine("Piece MOVED !");
                        break;
                    case 10: Console.WriteLine("WIN !!!");
                        break;
                    case 20: Console.WriteLine("TIE !");
                        break;
                    case 30: Console.WriteLine("LOST !!!");
                        break;
                    case 50: Console.WriteLine("You found the flag !");
                        break;
                    default: Console.WriteLine("Move not allowed !");
                        break;
                }
                pos1.row++;
                plop.initialGrid.displayGrid();
            }
            Console.ReadLine();
        }
    }
}