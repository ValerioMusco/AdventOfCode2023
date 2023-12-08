using AdventOfCode2023_Day5;

string path = @"C:\Users\Ugo est nul\Desktop\Prog\C#\AdventOfCode2023\AdventOfCode2023-Day5\TestValue.txt";

string input = GetFileContent(path);

List<int> seeds = ParseSeedsFromInput(input);
List<Maps> maps = ParseMapsFromInput(input);
List<int> location = new();

foreach(int seed in seeds ) {

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

List<int> ParseSeedsFromInput( string input ) {

    List<int> seeds = new();
    string[] seedsValue = input.Split("\n")[0].Split(": ")[1].Split(' ');

    foreach( string seed in seedsValue )
        seeds.Add(int.Parse(seed));

    return seeds;
}

List<Maps> ParseMapsFromInput( string input ) {

    List<Maps> maps = new();
    string[] mapsToParse = input[input.Split("\n")[0].Length..].Trim().Split("\n\n");

    foreach( string mapToParse in mapsToParse )
        maps.Add( new( mapToParse ) );

    return maps;
}

int GetLocation(List<Maps> maps, int source) {

    int location = source;
    foreach(Maps map in maps )
        location = map.Map[location, 1];

    return location;
}

#endregion