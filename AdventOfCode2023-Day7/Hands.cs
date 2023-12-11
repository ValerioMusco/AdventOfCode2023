using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023_Day7 {
    public class Hands {

        public Hands(string hand){

            Hand = new() {
                GetEnumValue( hand[0] ),
                GetEnumValue( hand[1] ),
                GetEnumValue( hand[2] ),
                GetEnumValue( hand[3] ),
                GetEnumValue ( hand[4] )
            };

            State = GetWinningState();
        }


        public List<Cards> Hand { get; set; }

        public WinningState State { get; set; }
        private static Cards GetEnumValue( char card ) {

            return card switch {
                '2' => Cards.Two,
                '3' => Cards.Three,
                '4' => Cards.Four,
                '5' => Cards.Five,
                '6' => Cards.Six,
                '7' => Cards.Seven,
                '8' => Cards.Eight,
                '9' => Cards.Nine,
                'T' => Cards.Ten,
                'J' => Cards.Jack,
                'Q' => Cards.Queen,
                'K' => Cards.King,
                'A' => Cards.Ace,
                _ => throw ( new ArgumentOutOfRangeException( "GetEnumValue" ) ),
            };
        }
        private WinningState GetWinningState() {

            switch(Hand.Distinct().Count()) {

                case 1:
                    return WinningState.FiveOfAKind;
                case 2:
                    foreach( Cards card in Hand.Distinct() ) {
                        if( Hand.Where( c => c == card ).Count() == 1 )
                            return WinningState.FourOfAKind;
                        return WinningState.FullHouse;
                    }
                    break;
                case 3:
                    foreach( Cards card in Hand.Distinct() ) {
                        if( Hand.Where( c => c == card ).Count() == 3 )
                            return WinningState.ThreeOfAKind;
                        return WinningState.TwoPair;
                    }
                    break;
                case 4:
                    return WinningState.OnePair;
                default:
                    return WinningState.HighCard;
            }
            throw ( new ArgumentOutOfRangeException("Winning State") );
        }
    }
}
