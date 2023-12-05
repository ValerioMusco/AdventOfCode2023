using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_Day2 {
    public class Games {

        public Games(string input){

            GameSet = new();
            SetValuesFromInput(input);
        }

        public int Id { get; set; }
        public bool IsPossible { get; set; }

        public List<GameSet> GameSet { get; set; }

        private void SetValuesFromInput(string input ) {

            string gameInfo = input.Split( ": " )[0];
            Id = int.Parse(gameInfo.Split( " " )[1]);

            IsPossible = true;

            string games = input.Split(": ")[1];
            List<string> gameList = games.Split( "; " ).ToList();

            foreach ( string game in gameList ) {

                List<string> set = game.Split(", ").ToList();
                foreach( string gameSet in set )
                    GameSet.Add( new GameSet( gameSet ) );
            }
        }

        public override string ToString() {

            StringBuilder sb = new();

            sb.AppendLine( $"Game : {Id}" );
            sb.AppendLine( $"Is possible : {IsPossible}" );
            foreach ( GameSet game in GameSet )
                sb.AppendLine( game.ToString() );

            return sb.ToString();
        }
    }
}
