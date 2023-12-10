using AdventOfCode2023_Day5;

string path = @"E:\Progra\C#\AdventOfCode2023\AdventOfCode2023-Day5\TestValue.txt";

string input = GetFileContent(path);

List<long> seeds = ParseSeedsFromInput(input);
List<Maps> maps = ParseMapsFromInput( input );

List<long>  locations = new();
long location;

#region Part 1

//foreach( long seed in seeds ) {

//    location = seed;
//    long tempValueToSubstract = seed;

//    foreach(Maps map in maps ) 
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

for(int i = 0; i < seeds.Count / 2; i++ ) {

    for(int j = 0; j < seeds[i+1 * 2]; j++ ) {
        Console.Write( seeds[i * 2] + j  + " ");
    }

    Console.WriteLine();
}

//Console.WriteLine(locations.Min());

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
        seeds.Add(long.Parse(seed));

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