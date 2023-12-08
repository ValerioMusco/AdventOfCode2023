using AdventOfCode2023_Day5;

string path = @"C:\Users\Ugo est nul\Desktop\Prog\C#\AdventOfCode2023\AdventOfCode2023-Day5\TestValue.txt";

string input = GetFileContent(path);

IEnumerable<int> seeds = ParseSeedsFromInput(input);
IEnumerable<int> location;

foreach(int seed in seeds ) {

    location = GetLocation(ParseMapsFromInput(input), seed);
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

IEnumerable<int> ParseSeedsFromInput( string input ) {

    string[] seedsValue = input.Split("\n")[0].Split(": ")[1].Split(' ');

    foreach( string seed in seedsValue )
        yield return int.Parse(seed);
}

IEnumerable<Maps> ParseMapsFromInput( string input ) {

    string[] mapsToParse = input[input.Split("\n")[0].Length..].Trim().Split("\n\n");

    foreach( string mapToParse in mapsToParse )
        yield return new( mapToParse );
}

IEnumerable<int> GetLocation(IEnumerable<Maps> maps, int source) {

    
}

#endregion