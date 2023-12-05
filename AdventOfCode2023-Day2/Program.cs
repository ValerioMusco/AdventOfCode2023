using AdventOfCode_Day2;

const int MAXRED = 12;
const int MAXGREEN = 13;
const int MAXBLUE = 14;

string path = @"C:\Users\Ugo est nul\Desktop\Prog\C#\AdventOfCode2023\AdventOfCode2023-Day2\Sample.txt";

List<string> inputs = GetFileContent(path);
List<Games> games = new();
int sum = 0;

foreach( string input in inputs )
    games.Add( new Games( input ) );

#region Part1

//foreach(Games game in games )
//    game.IsPossible = MAXRED >= game.GameSet.Where(g => g.Color == "red").Select(g => g.Count).Max() 
//        && MAXBLUE >= game.GameSet.Where( g => g.Color == "blue" ).Select( g => g.Count ).Max()
//        && MAXGREEN >= game.GameSet.Where( g => g.Color == "green" ).Select( g => g.Count ).Max();

//foreach( Games game in games )
//    if ( game.IsPossible )
//        sum += game.Id;

#endregion

#region Part2

foreach( Games game in games ) {

    int gameScore = game.GameSet.Where( g => g.Color == "red" ).Select( g => g.Count ).Max();
    gameScore *= game.GameSet.Where( g => g.Color == "blue" ).Select( g => g.Count ).Max();
    gameScore *= game.GameSet.Where( g => g.Color == "green" ).Select( g => g.Count ).Max();
    sum += gameScore;
}

#endregion

Console.WriteLine( sum );

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