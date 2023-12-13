string path = @"C:\Users\Ugo est nul\Desktop\Prog\C#\AdventOfCode2023\AdventOfCode2023-Day8\input.txt";

string input = GetFileContent(path);
string directions = input.Split("\n")[0];
Dictionary<string, string[]> maps = new();

foreach( string tab in input.Split( "\n" )[2..] )
    if(!string.IsNullOrEmpty(tab))
        maps.Add( tab.Split( " = " )[0], tab.Split( " = " )[1].Replace( "(", "" ).Replace( ")", "" ).Split( ", " ) );

int counter = 0;
int i = 0;
#region Part1

//string currentKey = "AAA";

//while (i < directions.Length && currentKey != "ZZZ") {

//    if( directions[i] == 'L' )
//        currentKey = maps.Where( m => m.Key.Contains( currentKey ) ).Select( m => m.Value ).First()[0];
//    if( directions[i] == 'R' )
//        currentKey = maps.Where( m => m.Key.Contains( currentKey ) ).Select( m => m.Value ).Last()[1];

//    if( i == directions.Length - 1 )
//        i = 0;
//    else
//        i++;
//    counter++;
//}

//Console.WriteLine(counter);

#endregion

List<string> nodesToTravel = maps.Where( m => m.Key.EndsWith( "A" ) ).Select(m => m.Key).ToList();
List<string> nodesToReach = maps.Where( m => m.Key.EndsWith( "Z" ) ).Select(m => m.Key).ToList();

while( nodesToTravel.Except( nodesToReach ).Any() ) {

    List<string> nodesTravelled = new();

    foreach( string node in nodesToTravel ) {

        if( directions[i] == 'L' )
            nodesTravelled.Add( maps.Where( m => m.Key.Contains( node ) ).Select( m => m.Value ).First()[0] );
        if ( directions[i] == 'R' )
            nodesTravelled.Add( maps.Where( m => m.Key.Contains( node ) ).Select( m => m.Value ).Last()[1] );
    }
    
    nodesToTravel = nodesTravelled;
    if( i == directions.Length - 1 )
        i = 0;
    else
        i++;
    counter++;
}

Console.WriteLine(counter);
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