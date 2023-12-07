using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023_Day3 {
    public class Elements {

        public Elements(char elem, int posX, int posY) {
            
            Element = elem.ToString();
            PosX = posX; 
            PosY = posY;

            switch (elem) {

                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    IsNumber = true;
                    break;
                case ' ':
                    break;
                case '*':
                    IsGear = true;
                    IsSymbol = true;
                    break;
                default:
                    IsSymbol = true; 
                    break;
            }
        }

        public string Element { get; set; }
        public bool IsNumber { get; set; }
        public bool IsSymbol { get; set; }
        public bool IsGear { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

        //public Elements? NorthWest { get; set; }
        //public Elements? North { get; set; }
        //public Elements? NorthEast { get; set; }
        //public Elements? East { get; set; }
        //public Elements? SouthEast { get; set; }
        //public Elements? South { get; set; }
        //public Elements? SouthWest { get; set; }
        //public Elements? West { get; set; }
    }
}
