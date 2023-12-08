using AdventOfCode2023_Day4;
using System.Net.WebSockets;

string path = @"C:\Users\Ugo est nul\Desktop\Prog\C#\AdventOfCode2023\AdventOfCode2023-Day4\Sample.txt";

List<string> inputs = GetFileContent(path);
List<Games> games = new();
List<Games> totalGames = new();
int sum = 0;

foreach (string  input in inputs)
    games.Add(new Games(input));

totalGames = games.Select(g => g).ToList();

foreach( Games game in games ) {
    List<Games> gamesToDuplicate = games.Where(g => g.GameId <= game.GamePoints + game.GameId && g.GameId > game.GameId).ToList();
    Console.WriteLine($"Game {game.GameId} out of {games.Count()}");
    int timeToDuplicate = totalGames.Count( g => g.GameId == game.GameId );
    for(int i = 0; i < timeToDuplicate; i++)
        totalGames.AddRange( gamesToDuplicate );
    totalGames = totalGames.OrderBy( g => g.GameId ).ToList();
}

Console.WriteLine(totalGames.Count());

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