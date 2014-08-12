using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stratego
{
    public struct Position
    {
        private int _row,_col;
        public int row 
        {   get
            {
                return _row;
            }
            set 
            {
                this._row = value;
                if (value > 9) this._row = 9;
                if (value < 0) this._row = 0;
            } 
        }
        public int col 
        { 
            get
            {
                return _col;
            }
            set
            {
                this._col = value;
                if (value > 9) this._col = 9;
                if (value < 0) this._col = 0;
            }
        }

        public static  bool operator ==(Position p1, Position p2)
        {
            if(p1.col==p2.col && p1.row==p2.row)return true;
            return false;
        }
        public static  bool operator !=(Position p1, Position p2)
        {
            if (p1.col != p2.col || p1.row != p2.row) return true;
            return false;
        }
    }
}
