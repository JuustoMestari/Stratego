using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stratego
{
    public class Player
    {
        private string _name;
        private SpaceType _playerType;
        private PlayerColor _playerColor;

        public string name
        {
            get { return _name; }
        }
        public SpaceType playerType
        {
            get { return _playerType; }
        }
        public PlayerColor playerColor
        {
            get { return _playerColor; }
        }
        public Player(string name,SpaceType playerType,PlayerColor playerColor)
        {
            _name = name;
            _playerType = playerType;
            _playerColor = playerColor;
        }
    }

    public enum PlayerColor { Red=1,Blue=2}
}
