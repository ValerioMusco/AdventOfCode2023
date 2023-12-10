using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023_Day5 {
    public class Maps {

        public Maps( string map ) {

            string mapsInfo = map.Split( ":\n" )[1];
            string[] mapsValues = mapsInfo.Split("\n");

            DestinationRangeStart = new();
            SourceRangeStart = new();
            RangeLength = new();

            foreach( string mapValue in mapsValues ) {

                string[] values = mapValue.Split( " " );
                DestinationRangeStart.Add( long.Parse( values[0] ) );
                SourceRangeStart.Add( long.Parse( values[1] ) );
                RangeLength.Add( long.Parse( values[2] ) );
            }
        }

        public List<long> DestinationRangeStart { get; set; }
        public List<long> SourceRangeStart { get; set; }
        public List<long> RangeLength { get; set; }


        public override string ToString() {
            
            StringBuilder sb = new();

            sb.Append( "Destination : " );
            foreach( long destinatioinRangeStart in DestinationRangeStart )
                sb.Append( destinatioinRangeStart + " " );
            sb.AppendLine();
            sb.Append( "Source : " );
            foreach ( long sourceinRangeStart in SourceRangeStart )
                sb.Append( sourceinRangeStart + " " );
            sb.AppendLine();
            sb.Append( "Range : " );
            foreach ( long rangeLength in RangeLength )
                sb.Append( rangeLength + " " );
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
