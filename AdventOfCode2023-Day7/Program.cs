using AdventOfCode2023_Day7;

string path = @"C:\Users\Ugo est nul\Desktop\Prog\C#\AdventOfCode2023\AdventOfCode2023-Day7\TestValue.txt";

string input = GetFileContent(path);
string[] games = input.Split('\n');
Dictionary<Hands, int> hands = new();
int answer = 0;

foreach(string game in games ) {

    if( game == "" )
        continue;
    string hand = game.Split(" ")[0];
    int bid = int.Parse(game.Split(" ")[1]);
    hands.Add( new(hand), bid );
}

hands = hands.OrderBy( h => h.Key.State )
            //.OrderBy( h => h.Key.Hand )
            .ToDictionary(h => h.Key, h => h.Value);

int i = 1;
foreach(int value in hands.Values) {
    Console.WriteLine(value);
    answer += value * i;
    i++;
}

Console.WriteLine(answer);

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

#endregion