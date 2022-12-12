
Tuple<int, int> startingPoint = new Tuple<int, int>(0, 0);
List<int> allShortestPaths = new List<int>();
char[,] map;
string[] lines = File.ReadLines(@"C:\Day12Input.txt").ToArray();



CreateMap();
CheckMap();
allShortestPaths.Sort();
Console.WriteLine(allShortestPaths[0]);




int FindShortestPath(int startingpointx, int startingpointy)
{
    Queue<int> depthQ = new Queue<int>();
    int[,] directions = { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };
    Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
    //FILL MAPCHECK WITH FALSE 
    bool[,] mapcheck = new bool[lines.Length, lines[0].Length];
    for (int i = 0; i < lines.Length; i++)
    {
        for (int j = 0; j < lines[i].Length; j++)
        {
            mapcheck[i, j] = false;
        }
    }
    int depth = 0;
    //ADD STARTING POINT
    queue.Enqueue(new Tuple<int,int>(startingpointx,startingpointy));
    depthQ.Enqueue(0);
    //SEARCh FOR DESTINATION UNTIL QUEUE IS EMPTY
    while (queue.Count > 0)
    {
        Tuple<int, int> pair = queue.Dequeue();
        depth = depthQ.Dequeue();
        //MARK VISITED
        mapcheck[pair.Item1, pair.Item2] = true;
        //DESTINATION REACHED
        if (map[pair.Item1, pair.Item2] == 'E')
        {
            return depth;
        }
        //CHECK ALL DIRECTIONS
        for (int i = 0; i < 4; i++)
        {
            int x = pair.Item1 + directions[i, 0];
            int y = pair.Item2 + directions[i, 1];
            //CHECK IF TILE CAN BE REACHED
            if (x >= 0 && y >= 0 && x < lines.Length && y < lines[0].Length && mapcheck[x, y] == false) //IS ON THE BOARD
            {
                //CHECK IF HEIGHT OF NEXT TILE IS < 1
                int result = 0;
                //ALLOW TO MOVE ANYWHERE FROM STARTING POINT
                if (map[pair.Item1, pair.Item2] == 'S')
                {
                    result = map[pair.Item1, pair.Item2] - 115;
                }
                else if (map[x, y] == 'E')
                {
                    result = map[pair.Item1, pair.Item2] - 123;
                }
                else
                {
                    result = (int)map[pair.Item1, pair.Item2] - (int)map[x, y];
                }
                if (result >= -1)
                {
                    mapcheck[x, y] = true;
                    queue.Enqueue(new Tuple<int, int>(x, y));
                    depthQ.Enqueue(depth + 1);
                }
            }
        }
    }
    return 999;
}

void CheckMap()
{
    for (int i = 0; i < lines.Length; i++)
    {
        for (int j = 0; j < lines[i].Length; j++)
        {

            if (map[i,j]=='a')
            {
                //CLEAR MAPCHECK
                allShortestPaths.Add(FindShortestPath(i, j));
            }
        }
    }
}

void CreateMap()
{

    int width = lines[0].Length;
    int height = lines.Length;
    map = new char[height, width];
    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        { 
            map[i, j] = lines[i][j];
        }
    }
}