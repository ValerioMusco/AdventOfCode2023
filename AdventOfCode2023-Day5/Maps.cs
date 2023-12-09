using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023_Day5 {
    public class Maps {

        public Maps( string map, long max ) {

            Descriptor = map.Split( ":\n" )[0];
            string mapsInfo = map.Split( ":\n" )[1];
            string[] mapsValues = mapsInfo.Split("\n");

            List<long> destinationRangeStart = new();
            List<long> sourceRangeStart = new();
            List<long> rangeLength = new();

            foreach( string mapValue in mapsValues ) {

                string[] values = mapValue.Split( " " );
                destinationRangeStart.Add( long.Parse( values[0] ) );
                sourceRangeStart.Add( long.Parse( values[1] ) );
                rangeLength.Add( long.Parse( values[2] ) );
            }

            DestinationRangeStart = destinationRangeStart.ToArray();
            SourceRangeStart = sourceRangeStart.ToArray();
            RangeLength = rangeLength.ToArray();

            GenerateMap(max);
        }

        public string Descriptor { get; set; }
        public long[] DestinationRangeStart { get; set; }
        public long[] SourceRangeStart { get; set; }
        public long[] RangeLength { get; set; }

        public long[,] Map { get; set; }

        private void GenerateMap(long max) {

            Map = new long[max > SourceRangeStart.Max() + RangeLength.Max() ? max : SourceRangeStart.Max() + RangeLength.Max(), 2];

            for( long i = 0; i < (Map.LongLength)/2; i++ ) {

                Map[i, 0] = i;
                Map[i, 1] = i;
            }
            

            for(long i = 0; i < RangeLength.Length; i++ )
                for(long j = 0; j < RangeLength[i]; j++ )
                    Map[SourceRangeStart[i] + j, 1] = DestinationRangeStart[i] + j;
        }

        public override string ToString() {
            
            StringBuilder sb = new();

            sb.AppendLine( $"Descriptor : {Descriptor}");
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
