using AdventOfCode2023_Day5;
using System.Data;
using System.Data.SqlClient;

string path = @"C:\Users\Ugo est nul\Desktop\Prog\C#\AdventOfCode2023\AdventOfCode2023-Day5\Sample.txt";

string input = GetFileContent(path);

List<long> seeds = ParseSeedsFromInput(input);
List<Maps> maps = ParseMapsFromInput( input );

long  lowestLocation = long.MaxValue;
long location;

#region Part 1

//foreach( long seed in seeds ) {

//    location = seed;
//    long tempValueToSubstract = seed;

//    foreach( Maps map in maps )
//        for( int i = 0; i < map.RangeLength.Count; i++ )
//            if( location > map.SourceRangeStart[i] && location <= map.SourceRangeStart[i] + map.RangeLength[i] - 1 ) {

//                tempValueToSubstract = map.SourceRangeStart[i] + map.RangeLength[i] - 1 - location;
//                location = map.DestinationRangeStart[i] + map.RangeLength[i] - 1;
//                location -= tempValueToSubstract;
//                tempValueToSubstract = location;
//                break;
//            }

//    locations.Add( location );
//}

#endregion

// Fixer la boucle pour avoir les ranges correcte.
// Puis réexecuter l'algo du dessus
for( int i = 0; i <= seeds.Count / 2 - 1; i++ ) {


    Console.WriteLine( $"--- Test item {seeds[i * 2]} ---" );
    for( int j = 0; j < seeds[i * 2 + 1]; j++ ) {

        location = seeds[i * 2] + j;
        long tempValueToSubstract;

        foreach( Maps map in maps )
            for( int k = 0; k < map.RangeLength.Count; k++ )
                if( location > map.SourceRangeStart[k] && location <= map.SourceRangeStart[k] + map.RangeLength[k] - 1 ) {

                    tempValueToSubstract = map.SourceRangeStart[k] + map.RangeLength[k] - 1 - location;
                    location = map.DestinationRangeStart[k] + map.RangeLength[k] - 1;
                    location -= tempValueToSubstract;
                    tempValueToSubstract = location;
                    break;
                }

        lowestLocation = location < lowestLocation ? location : lowestLocation;
    }

}
Console.WriteLine( lowestLocation );

#region Methods
static string GetFileContent( string path ) {

    string inputs = "";

    if( File.Exists( path ) )
        using( StreamReader sr = new( path ) ) {
            string line;
            while( ( line = sr.ReadLine() ) != null )
                inputs += line + "\n";
        }
    return inputs;
}

List<long> ParseSeedsFromInput( string input ) {

    List<long> seeds = new();
    string[] seedsValue = input.Split("\n")[0].Split(": ")[1].Split(' ');

    foreach( string seed in seedsValue )
        seeds.Add( long.Parse( seed ) );

    return seeds;
}

List<Maps> ParseMapsFromInput( string input ) {

    List<Maps> maps = new();
    string[] mapsToParse = input[input.Split("\n")[0].Length..].Trim().Split("\n\n");

    foreach( string mapToParse in mapsToParse )
        maps.Add( new( mapToParse ) );

    return maps;
}

#endregion