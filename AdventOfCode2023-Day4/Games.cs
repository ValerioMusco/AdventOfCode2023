using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023_Day4 {
    public class Games {

        public Games( string input ) {

            string gameInfo = input.Split(": ")[0];
            gameInfo = gameInfo.Split( "d" )[1];
            GameId = int.Parse(gameInfo.Trim());

            string game = input.Split(": ")[1];
            string Winning = game.Split(" | ")[0];
            string Owned = game.Split(" | ")[1];

            string[] Winnings = Winning.Split(" ");
            string[] Owneds = Owned.Split(" ");

            WinningNumbers = new();
            OwnedNumbers = new();

            foreach(string win in  Winnings )
                if(win != String.Empty)
                    WinningNumbers.Add(int.Parse(win.Trim()));
            
            foreach(string own in Owneds)
                if(own != String.Empty)
                    OwnedNumbers.Add(int.Parse(own.Trim()));

            // Part 1
            // GamePoints = (int)Math.Pow(2, WinningNumbers.Intersect(OwnedNumbers).Count() - 1);

            //Part 2
            GamePoints = WinningNumbers.Intersect( OwnedNumbers ).Count();
        }

        public int GameId { get; set; }
        public List<int> WinningNumbers { get; set; }
        public List<int> OwnedNumbers { get; set; }
        public int GamePoints { get; set; }
    }
}
