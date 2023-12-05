using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_Day2 {
    public class GameSet {

        public GameSet(string gameSet){

            Count = int.Parse(gameSet.Split( " " )[0]);
            Color = gameSet.Split( " " )[1];
        }

        public string Color { get; set; }
        public int Count { get; set; }

        public override string ToString() {

            StringBuilder sb = new();

            sb.AppendLine( $"   Color : {Color}" );
            sb.AppendLine( $"   Count : {Count}" );
            return sb.ToString();
        }
    }
}
