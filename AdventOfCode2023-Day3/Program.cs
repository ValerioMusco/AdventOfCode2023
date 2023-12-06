using AdventOfCode2023_Day3;

string path = @"C:\Users\Ugo est nul\Desktop\Prog\C#\AdventOfCode2023\AdventOfCode2023-Day3\TestValue.txt";

List<string> inputs = GetFileContent(path);

Elements[,] elements = TransformToArray(inputs);

List<int> numbers = GetNumbersFromArray(elements);

int sum = 0;

foreach( int number in numbers ) {

    sum += number;
    Console.WriteLine(number);
}

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

Elements[,] TransformToArray( List<string> inputs ) {

    int stringNumber = inputs.Count;
    int stringLength = inputs[0].Length;

    Elements[,] elements = new Elements[stringNumber, stringLength];

    for( int i = 0; i < stringNumber; i++ )
        for( int j = 0; j < stringLength; j++ )
            elements[i, j] = new( inputs[i][j] == '.' ? ' ' : inputs[i][j], i, j );

    return elements;
}

List<int> GetNumbersFromArray( Elements[,] elements ) {

    List <int> numbers = new();

    foreach( Elements element in elements )
        if( element.IsSymbol )
            try {
                numbers.AddRange( GetNeighborsNumber( element, elements ) );
            }
            catch( Exception ex ) {
                Console.WriteLine( "Out of bound : " + ex.ToString() );
            }

    return numbers;
}

List<int> GetNeighborsNumber( Elements element, Elements[,] elements ) {

    List<int> numbers = new();
    int posX = element.PosX;
    int posY = element.PosY;

    //if( elements[posX - 1, posY - 1].IsNumber ) //NW
    //    numbers.Add( GetNumber( elements[posX - 1, posY - 1].Element, elements, posX - 1, posY - 1 ) );

    //if( elements[posX - 1, posY].IsNumber ) // N
    //    numbers.Add( GetNumber( elements[posX - 1, posY].Element, elements, posX - 1, posY ) );

    if( posX - 1 >= 0 && posY - 1 >= 0 && elements[posX - 1, posY - 1].IsNumber ) // NW
        numbers.Add( GetNumber( elements[posX - 1, posY - 1].Element, elements, posX - 1, posY - 1 ) );

    if( posX - 1 >= 0 && elements[posX - 1, posY].IsNumber ) // N
        numbers.Add( GetNumber( elements[posX - 1, posY].Element, elements, posX - 1, posY ) );

    if( posX - 1 >= 0 && posY + 1 < elements.GetLength( 1 ) && elements[posX - 1, posY + 1].IsNumber ) // NE
        numbers.Add( GetNumber( elements[posX - 1, posY + 1].Element, elements, posX - 1, posY + 1 ) );

    if( posY + 1 < elements.GetLength( 1 ) && elements[posX, posY + 1].IsNumber ) // E
        numbers.Add( GetNumber( elements[posX, posY + 1].Element, elements, posX, posY + 1 ) );

    if( posX + 1 < elements.GetLength( 0 ) && posY + 1 < elements.GetLength( 1 ) && elements[posX + 1, posY + 1].IsNumber ) // SE
        numbers.Add( GetNumber( elements[posX + 1, posY + 1].Element, elements, posX + 1, posY + 1 ) );

    if( posX + 1 < elements.GetLength( 0 ) && elements[posX + 1, posY].IsNumber ) // S
        numbers.Add( GetNumber( elements[posX + 1, posY].Element, elements, posX + 1, posY ) );

    if( posX + 1 < elements.GetLength( 0 ) && posY - 1 >= 0 && elements[posX + 1, posY - 1].IsNumber ) // SW
        numbers.Add( GetNumber( elements[posX + 1, posY - 1].Element, elements, posX + 1, posY - 1 ) );

    if( posY - 1 >= 0 && elements[posX, posY - 1].IsNumber ) // W
        numbers.Add( GetNumber( elements[posX, posY - 1].Element, elements, posX, posY - 1 ) );

    return numbers;
}

static int GetNumber( string element, Elements[,] elements, int i, int j ) {

    string number;

    number = element;
    while( elements[i - 1, j].IsNumber || elements[i, j + 1].IsNumber ) {

        if( elements[i - 1, j].IsNumber ) {

            number = String.Concat( elements[i - 1, j].Element, number );
            i--;
        }
        if( elements[i, j + 1].IsNumber ) {
            number = String.Concat( number, elements[i, j + 1].Element);
            j++;
        }
    }
    return int.Parse( number );
}

#endregion