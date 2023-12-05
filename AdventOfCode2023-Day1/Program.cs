using AdventOfCode2023_Day1;
using System.Text;

#region Part1

//string path = @"C:\Users\Ugo est nul\Desktop\Prog\C#\AdventOfCode2023\AdventOfCode2023-Day1\Samples.txt";

//List<string> inputs = GetFileContent(path);
//int leftDigit;
//int rightDigit;
//int sum = 0;

//foreach( string input in inputs ) {

//    leftDigit = -1;
//    rightDigit = -1;
//    GetDigits(input.ToArray(), ref leftDigit, ref rightDigit);
//    sum += leftDigit * 10 + ( rightDigit == -1 ? leftDigit : rightDigit );
//}

//Console.WriteLine( sum );

#endregion

#region Part2

string path = @"C:\Users\Ugo est nul\Desktop\Prog\C#\AdventOfCode2023\AdventOfCode2023-Day1\SamplesPartTwo.txt";

List<string> inputs = GetFileContent(path);
int leftDigit;
int rightDigit;
int sum = 0;

foreach( string input in inputs ) {

    string newInput;
    leftDigit = -1;
    rightDigit = -1;

    newInput = ReplaceWithNumericValues( input );

    GetDigits( newInput, ref leftDigit, ref rightDigit );
    sum += leftDigit * 10 + ( rightDigit == -1 ? leftDigit : rightDigit );
}

Console.WriteLine(sum);
#endregion


#region Methods
static List<string> GetFileContent(string path ) {

    List<string>inputs = new();

    if( File.Exists( path ) )
        using( StreamReader sr = new( path ) ) {
            string line;
            while( ( line = sr.ReadLine() ) != null )
                inputs.Add( line.Trim() );
        }
    return inputs;
}

void GetDigits(string input, ref int leftDigit, ref int rightDigit) {

    foreach( char value in input )
        if( int.TryParse( value.ToString(), out int number ) )
            if( leftDigit == -1 )
                leftDigit = number;
            else
                rightDigit = number;
}

string ReplaceWithNumericValues( string input ) {

    foreach( string value in Enum.GetNames( typeof( Numbers ) ) )
        while( input.Contains( value ) )
            input = input.Insert( input.IndexOf( value ) + 1, ( (int)(Numbers)Enum.Parse( typeof( Numbers ), value ) ).ToString() );
    return input;
}

#endregion