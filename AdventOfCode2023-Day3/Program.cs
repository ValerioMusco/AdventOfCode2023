using AdventOfCode2023_Day3;

string path = @"C:\Users\Ugo est nul\Desktop\Prog\C#\AdventOfCode2023\AdventOfCode2023-Day3\Sample.txt";

List<string> inputs = GetFileContent(path);

Elements[,] elements = TransformToArray(inputs);

// List<int> numbers = GetNumbersFromArray(elements); // Part1
List<int> numbers = GetNumbersFromArray( elements );

int sum = 0;

foreach( int number in numbers ) {
    sum += number;
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
    List <int> mults = new();
    int mult = 1;

    foreach( Elements element in elements ) {

        //if( element.IsSymbol ) // Part1
            //numbers.AddRange( GetNeighborsNumber( element, elements ) );
        if(element.IsGear) // Part2
            numbers.AddRange(GetNeighborsNumber(element, elements));

        if(numbers.Count == 2 ) {

            mult = 1;
            foreach( int number in numbers )
                mult *= number;

            mults.Add( mult );
        }

        numbers.Clear();
    }
    
    return mults;
    
}

List<int> GetNeighborsNumber( Elements element, Elements[,] elements ) {

    List<int> numbers = new();
    int posX = element.PosX;
    int posY = element.PosY;

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
    int jLeft = j - 1;
    int jRight = j + 1;

    number = element;
    elements[i, j].Element = " ";
    elements[i, j].IsNumber = false;

    while( jLeft >= 0 && elements[i, jLeft].IsNumber )
        if( elements[i, jLeft].IsNumber ) {

            number = String.Concat( elements[i, jLeft].Element, number );
            elements[i, jLeft].Element = " ";
            elements[i, jLeft].IsNumber = false;
            jLeft--;
        }

    while( jRight < elements.GetLength( 0 ) && elements[i, jRight].IsNumber )
        if( elements[i, jRight].IsNumber ) {
            number = String.Concat( number, elements[i, jRight].Element );
            elements[i, jRight].Element = " ";
            elements[i, jRight].IsNumber = false;
            jRight++;
        }

    return int.Parse( number );
}

#endregion