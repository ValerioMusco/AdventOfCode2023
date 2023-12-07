using AdventOfCode2023_Day4;
using System.Net.WebSockets;

string path = @"C:\Users\Ugo est nul\Desktop\Prog\C#\AdventOfCode2023\AdventOfCode2023-Day4\TestValue.txt";

List<string> inputs = GetFileContent(path);
List<Games> games = new();
int sum = 0;

foreach (string  input in inputs)
    games.Add(new Games(input));

foreach( Games game in games )
    Console.WriteLine(game.GamePoints);

Console.WriteLine(sum);

#region Methods
static List<string> GetFileContent( string path ) {

    List<string>inputs = new();

    if( File.Exists( path ) )
        using( StreamReader sr = new( path ) ) {
            string line;
            while( ( line = sr.ReadLine() ) != null )
                inputs.Add( line.Trim() );
        }
    return inputs;
}

#endregion