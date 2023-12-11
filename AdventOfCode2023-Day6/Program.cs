string path = @"C:\Users\Ugo est nul\Desktop\Prog\C#\AdventOfCode2023\AdventOfCode2023-Day6\Sample.txt";

string input = GetFileContent(path);
string[] timesFromInput = input.Split("\n")[0].Split(":")[1].Trim().Split(' ');
string[] distancesFromInput = input.Split("\n")[1].Split(":")[1].Trim().Split(' ');

#region Part1

//int answer = 1;
//List<int> times = new();
//List<int> distances = new();

//foreach( string time in timesFromInput )
//    if(int.TryParse(time, out int temp))
//        times.Add(temp);

//foreach( string distance in distancesFromInput )
//    if(int.TryParse(distance, out int temp))
//        distances.Add(temp);

//for(int i = 0; i < times.Count; i++ ) {

//    int waysOfWinning = 0;

//    for(int j = 0; j < times[i]; j++ )
//        if( distances[i] < j * (times[i] - j))
//            waysOfWinning++;

//    answer *= waysOfWinning;
//}

//Console.WriteLine(answer);

#endregion

#region Part2

long time = GetDecimals(timesFromInput);
long distance = GetDecimals(distancesFromInput);
int waysOfWinning = 0;

for( int i = 0; i < time; i++ )
    if( distance < i * ( time - i ) )
        waysOfWinning++;

Console.WriteLine(waysOfWinning);

#endregion

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

static long GetDecimals(string[] arrayToConvert) {

    string valueToConvert = "";

    foreach( string value in arrayToConvert ) 
        foreach( char c in value ) 
            switch( c ) {

                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    valueToConvert += c;
                    break;
            }

    return long.Parse( valueToConvert );
}

#endregion
