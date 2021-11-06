using CS21_Ex05.Enums;
using System;
using System.Collections.Generic;
namespace CS21_Ex05.Models
{
    public class GameData
    {
        public string Player1Name { get; set; }

        public string Player2Name { get; set; }

        public eOpponent Opponent { get; set; }

        public int Rows { get; set; }

        public int Cols { get; set; }
    }
}
