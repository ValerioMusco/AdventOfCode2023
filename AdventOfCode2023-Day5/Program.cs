using AdventOfCode2023_Day5;

string path = @"E:\Progra\C#\AdventOfCode2023\AdventOfCode2023-Day5\Sample.txt";

string input = GetFileContent(path);

List<long> seeds = ParseSeedsFromInput(input);
List<Maps> maps = ParseMapsFromInput( input, seeds.Max() );

List<long> location = new();

foreach(long seed in seeds ) {

    location.Add(GetLocation(maps, seed));
}

Console.WriteLine(location.Min());

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

List<Maps> ParseMapsFromInput( string input, long max ) {

    List<Maps> maps = new();
    string[] mapsToParse = input[input.Split("\n")[0].Length..].Trim().Split("\n\n");

    foreach( string mapToParse in mapsToParse )
        maps.Add( new( mapToParse, max ) );

    return maps;
}

long GetLocation(List<Maps> maps, long source) {

    long location = source;
    foreach(Maps map in maps )
        location = map.Map[location, 1];

    return location;
}

#endregion