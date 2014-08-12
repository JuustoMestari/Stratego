using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stratego
{
    public class Game
    {
        public List<Piece> player1Pieces, player2Pieces;
        public List<Piece> player1Lost, player2Lost;

        public Grid initialGrid;
        public Game(Player p1, Player p2)
        {
            initPlayerPieces(p1,p2);
            initGrid();     
        }
        private void initPlayerPieces(Player p1, Player p2)
        {
            player1Pieces = new List<Piece>();
            player2Pieces = new List<Piece>();

            player1Pieces.Add(new Piece(piecesTypes.Marshal,p1));
            player1Pieces.Add(new Piece(piecesTypes.General, p1));
            player1Pieces.Add(new Piece(piecesTypes.Spy, p1));
            player1Pieces.Add(new Piece(piecesTypes.Flag, p1));
            for (int i = 0; i < 2; i++) player1Pieces.Add(new Piece(piecesTypes.Colonel, p1));
            for (int i = 0; i < 3; i++) player1Pieces.Add(new Piece(piecesTypes.Major, p1));
            for (int i = 0; i < 4; i++) player1Pieces.Add(new Piece(piecesTypes.Captain, p1));
            for (int i = 0; i < 4; i++) player1Pieces.Add(new Piece(piecesTypes.Lieutenant, p1));
            for (int i = 0; i < 4; i++) player1Pieces.Add(new Piece(piecesTypes.Sergeant, p1));
            for (int i = 0; i < 5; i++) player1Pieces.Add(new Piece(piecesTypes.Miner, p1));
            for (int i = 0; i < 8; i++) player1Pieces.Add(new Piece(piecesTypes.Scout, p1));
            for (int i = 0; i < 6; i++) player1Pieces.Add(new Piece(piecesTypes.Bomb, p1));

            player2Pieces.Add(new Piece(piecesTypes.Marshal, p2));
            player2Pieces.Add(new Piece(piecesTypes.General, p2));
            player2Pieces.Add(new Piece(piecesTypes.Spy, p2));
            player2Pieces.Add(new Piece(piecesTypes.Flag, p2));
            for (int i = 0; i < 2; i++) player2Pieces.Add(new Piece(piecesTypes.Colonel, p2));
            for (int i = 0; i < 3; i++) player2Pieces.Add(new Piece(piecesTypes.Major, p2));
            for (int i = 0; i < 4; i++) player2Pieces.Add(new Piece(piecesTypes.Captain, p2));
            for (int i = 0; i < 4; i++) player2Pieces.Add(new Piece(piecesTypes.Lieutenant, p2));
            for (int i = 0; i < 4; i++) player2Pieces.Add(new Piece(piecesTypes.Sergeant, p2));
            for (int i = 0; i < 5; i++) player2Pieces.Add(new Piece(piecesTypes.Miner, p2));
            for (int i = 0; i < 8; i++) player2Pieces.Add(new Piece(piecesTypes.Scout, p2));
            for (int i = 0; i < 6; i++) player2Pieces.Add(new Piece(piecesTypes.Bomb, p2));
           
        }
       
        private void initGrid()
        {
            initialGrid = new Grid();
        }

        //method used by players to set up the game
        //they can only set up their pieces in spaces defined in initGrid().
        public bool setPieceOnGrid(Piece p,Position pos)
        {
            if (p.piecePlayer.playerType != initialGrid.mainGrid[pos.row,pos.col]._type) return false;
            initialGrid.mainGrid[pos.row, pos.col]._piece = p;
            return true;
        }
        public List<Position> getMoves(Position pos, out int returnCode)
        {
            List<Position> listPos = new List<Position>();
            GridSpace gs = new GridSpace();
            gs=initialGrid.mainGrid[pos.row,pos.col];

            //check if it is not an unplayed grid space and that there is a piece on the space
            if (gs._piece != null && gs._isPlayable)
            {
                //check if the piece can move
                if (gs._piece.pieceCanMove)
                {
                    int max = 1;
                    if (gs._piece.pieceCanRun) max = 10;

                    //find below positions
                    for (int i = pos.row + 1; i < pos.row + max + 1; i++)
                    {
                        if (i > 9 || !initialGrid.mainGrid[i, pos.col]._isPlayable) break;
                        //make sure to stop before if same-team piece
                        if (initialGrid.mainGrid[i, pos.col]._piece != null && initialGrid.mainGrid[i, pos.col]._piece.piecePlayer.playerType == initialGrid.mainGrid[pos.row, pos.col]._piece.piecePlayer.playerType) break;
                        Position p = new Position();
                        p.row = i;
                        p.col = pos.col;
                        listPos.Add(p);
                        if (initialGrid.mainGrid[i, pos.col]._piece != null) break;
                    }

                    //find up positions
                    for (int i = pos.row - 1; i > pos.row - max-1; i--)
                    {
                        if (i < 0 || !initialGrid.mainGrid[i, pos.col]._isPlayable) break;
                        if (initialGrid.mainGrid[i, pos.col]._piece != null && initialGrid.mainGrid[i, pos.col]._piece.piecePlayer.playerType == initialGrid.mainGrid[pos.row, pos.col]._piece.piecePlayer.playerType) break;
                        Position p = new Position();
                        p.row = i;
                        p.col = pos.col;
                        listPos.Add(p);
                        if (initialGrid.mainGrid[i, pos.col]._piece != null) break;

                    }


                    //find left positions
                    for (int i = pos.col - 1; i > pos.col - max - 1; i--)
                    {
                        if (i < 0 || !initialGrid.mainGrid[pos.row, i]._isPlayable) break;
                        if (initialGrid.mainGrid[pos.row, i]._piece != null && initialGrid.mainGrid[pos.row, i]._piece.piecePlayer.playerType == initialGrid.mainGrid[pos.row, pos.col]._piece.piecePlayer.playerType) break;
                        Position p = new Position();
                        p.row = pos.row;
                        p.col = i;
                        listPos.Add(p);
                        if (initialGrid.mainGrid[pos.row, i]._piece != null) break;

                    }

                    //find right positions
                    for (int i = pos.col + 1; i < pos.col + max + 1; i++)
                    {
                        if (i > 9 || !initialGrid.mainGrid[pos.row, i]._isPlayable) break;
                        if (initialGrid.mainGrid[pos.row, i]._piece != null && initialGrid.mainGrid[pos.row, i]._piece.piecePlayer.playerType == initialGrid.mainGrid[pos.row, pos.col]._piece.piecePlayer.playerType) break;
                        Position p = new Position();
                        p.row = pos.row;
                        p.col = i;
                        listPos.Add(p);
                        if (initialGrid.mainGrid[pos.row, i]._piece != null) break;

                    }

                    returnCode = 1;

                }
                else
                {
                    //piece can't move
                    returnCode = 20;
                }
            }
            else
            {
                //not a piece
                returnCode = 30;
            }
            return listPos;
        }

        //method used when the players have set up all their pieces on the grid
        public bool start()
        {
            int count=0;
            //check the grid has 80pieces on it
            for (int row = 0; row < 10;row++ )
            {
                for(int col=0;col<10;col++)
                {
                    if (initialGrid.mainGrid[row,col]._piece!=null)count++;
                }
            }
           // if (count != 80) return false;
            initialGrid.startUpGrid();
            return true;
        }
    
        public int movePiece(Position now,Position next)
        {
            bool isAllowed=false;
            int returnValue;
            Piece nowPiece=initialGrid.mainGrid[now.row, now.col]._piece;
            Piece nextPiece=initialGrid.mainGrid[next.row, next.col]._piece;

            //check the piece is moving to an allowed location
            foreach(Position p in getMoves(now,out returnValue))
            {
                if (p == next) isAllowed = true;
            }
           if(!isAllowed)return 0;

           //1. empty space
            if(nextPiece==null)
            {
                updateMoveGrid(now,next);
                return 1;
            }
            else
            {
                if(nextPiece.piecePlayer.playerType!=nowPiece.piecePlayer.playerType)
                { 
                    //opponent piece
                    //if flag -> win
                    if(nextPiece.pieceName==piecesTypes.Flag)return 50;

                    //in case bomb vs miner
                    if(nextPiece.pieceName==piecesTypes.Bomb && nowPiece.pieceName==piecesTypes.Miner)
                    {
                        updateWinGrid(now,next);
                        return 10;
                    }

                    //in case spy vs Marshal
                    if (nextPiece.pieceName == piecesTypes.Marshal && nowPiece.pieceName == piecesTypes.Spy)
                    {
                        updateWinGrid(now, next);
                        return 10;
                    }

                    //in case of a tie
                    if ((int)nextPiece.pieceName == (int)nowPiece.pieceName)
                    {
                        updateTieGrid(now, next);
                        return 20;
                    }

                    //if opponent piece better
                    if((int)nextPiece.pieceName>(int)nowPiece.pieceName)
                    {
                        updateLoseGrid(now, next);
                        return 30;
                    }
                    else
                    {
                        updateWinGrid(now, next);
                        return 10;
                    }
                }
                else
                {
                    //both pieces are in the same team (shouldn't happen tho...)
                    return 4;
                }
            }
            
        }
        private void updateMoveGrid(Position p1, Position p2)
        {
            initialGrid.mainGrid[p2.row, p2.col]._piece = initialGrid.mainGrid[p1.row, p1.col]._piece;
            initialGrid.mainGrid[p1.row, p1.col]._piece = null;
        }
        private void updateWinGrid(Position p1, Position p2)
        {
            //add piece to lost pieces
            switch(initialGrid.mainGrid[p2.row, p2.col]._piece.piecePlayer.playerType)
            {
                case SpaceType.Player1: break;
                case SpaceType.Player2: break;
                default: break;
            }
            initialGrid.mainGrid[p2.row, p2.col]._piece = initialGrid.mainGrid[p1.row, p1.col]._piece;
            initialGrid.mainGrid[p1.row, p1.col]._piece = null;
        }
        private void updateLoseGrid(Position p1, Position p2)
        {
            //add piece to lost pieces
            switch (initialGrid.mainGrid[p1.row, p1.col]._piece.piecePlayer.playerType)
            {
                case SpaceType.Player1: break;
                case SpaceType.Player2: break;
                default: break;
            }
            initialGrid.mainGrid[p1.row, p1.col]._piece = null;
        }
        private void updateTieGrid(Position p1, Position p2)
        {
            //add piece to lost pieces
            switch (initialGrid.mainGrid[p1.row, p1.col]._piece.piecePlayer.playerType)
            {
                case SpaceType.Player1: break;
                case SpaceType.Player2: break;
                default: break;
            }
            initialGrid.mainGrid[p2.row, p2.col]._piece = null;
            initialGrid.mainGrid[p1.row, p1.col]._piece = null;
        }
    }
}
