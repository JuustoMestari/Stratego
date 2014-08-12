using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stratego
{
    public class Piece
    {
        private piecesTypes _name;
        private bool _canMove;
        private bool _canRun;
        private Player _player;
     
        public piecesTypes pieceName
        {
            get { return _name; }
        }
        public bool pieceCanMove
        {
            get { return _canMove; }
        }
        public bool pieceCanRun
        {
            get { return _canRun; }
        }
        public Player piecePlayer
        {
            get { return _player; }
        }
        

        public Piece(piecesTypes name,Player pl)
        {
            _name = name;
            _player = pl;
            switch(name)
            {
                case piecesTypes.Marshal:
                case piecesTypes.General:
                case piecesTypes.Colonel:
                case piecesTypes.Major:
                case piecesTypes.Captain:
                case piecesTypes.Lieutenant:
                case piecesTypes.Sergeant:
                case piecesTypes.Miner: 
                case piecesTypes.Spy:
                    _canRun = false;
                    _canMove = true;
                    break;
                case piecesTypes.Scout:
                    _canMove = true;
                    _canRun = true;
                    break;
                case piecesTypes.Bomb:
                case piecesTypes.Flag:
                    _canMove = false;
                    _canRun = false;
                    break;
                default: break;
            }

        }

        public void displayPiece()
        {
            Console.WriteLine("NAME : {0}", _name);
            Console.WriteLine("MOVE : {0}", _canMove);
        }
    }
    public enum piecesTypes { Marshal=10,General=9,Colonel=8,Major=7,Captain=6,Lieutenant=5,Sergeant=4,Miner=3,Scout=2,Spy=1,Bomb=20,Flag=50}
}
