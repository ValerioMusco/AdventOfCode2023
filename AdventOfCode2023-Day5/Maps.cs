using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023_Day5 {
    public class Maps {

        public Maps(string map){

            Descriptor = map.Split( ":\n" )[0];
            string mapsInfo = map.Split( ":\n" )[1];
            string[] mapsValues = mapsInfo.Split("\n");

            List<int> destinationRangeStart = new();
            List<int> sourceRangeStart = new();
            List<int> rangeLength = new();

            foreach( string mapValue in mapsValues ) {

                string[] values = mapValue.Split( " " );
                destinationRangeStart.Add( int.Parse( values[0] ));
                sourceRangeStart.Add(int.Parse( values[1] ));
                rangeLength.Add(int.Parse( values[2] ));
            }

            DestinationRangeStart = destinationRangeStart.ToArray();
            SourceRangeStart = sourceRangeStart.ToArray();
            RangeLength = rangeLength.ToArray();

        }

        public string Descriptor { get; set; }
        public int[] DestinationRangeStart { get; set; }
        public int[] SourceRangeStart { get; set; }
        public int[] RangeLength { get; set; }

        public override string ToString() {
            
            StringBuilder sb = new StringBuilder();

            sb.AppendLine( $"Descriptor : {Descriptor}");
            sb.Append( "Destination : " );
            foreach( int destinatioinRangeStart in DestinationRangeStart )
                sb.Append( destinatioinRangeStart + " " );
            sb.AppendLine();
            sb.Append( "Source : " );
            foreach ( int sourceinRangeStart in SourceRangeStart )
                sb.Append( sourceinRangeStart + " " );
            sb.AppendLine();
            sb.Append( "Range : " );
            foreach ( int rangeLength in RangeLength )
                sb.Append( rangeLength + " " );
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
