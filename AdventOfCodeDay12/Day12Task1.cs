Queue<int> depthQ = new Queue<int>();
Tuple<int, int> startingPoint = new Tuple<int, int>(0, 0);
int depth = 0;
char[,] map;
bool[,] mapcheck;

string[] lines = File.ReadLines(@"C:\Day12Input.txt").ToArray();



CreateMap();
FindShortestPath(startingPoint.Item1,startingPoint.Item2);
Console.WriteLine(depth);

//CheckMap();
bool FindShortestPath(int startingpointx,int startingpointy)
{
    int[,] directions = { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };
    Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
    //ADD STARTING POINT
    queue.Enqueue(startingPoint);
    depthQ.Enqueue(0);
    //SEARCh FOR DESTINATION UNTIL QUEUE IS EMPTY
    while(queue.Count>0)
    {
        Tuple<int, int> pair = queue.Dequeue();
        depth = depthQ.Dequeue();
        //MARK VISITED
        mapcheck[pair.Item1, pair.Item2] = true; 
        //DESTINATION REACHED
        if (map[pair.Item1,pair.Item2] == 'E')
        {
            return true;
        }
        //CHECK ALL DIRECTIONS
        for (int i=0;i<4;i++)
        {
            int x = pair.Item1 + directions[i,0];
            int y = pair.Item2 + directions[i,1];
            //CHECK IF TILE CAN BE REACHED
            if (x >= 0 && y >= 0 && x < lines.Length && y < lines[0].Length && mapcheck[x,y]==false) //IS ON THE BOARD
            {
                //CHECK IF HEIGHT OF NEXT TILE IS < 1
                int result = 0;
                //ALLOW TO MOVE ANYWHERE FROM STARTING POINT
                if (map[pair.Item1,pair.Item2]=='S')
                {
                    result = 0;
                }
                else if (map[x,y]=='E')
                {
                    result = map[pair.Item1, pair.Item2] - 123;
                }
                else
                {
                     result = (int)map[pair.Item1, pair.Item2] - (int)map[x, y];
                }
                if (result >= -1)
                {
                    Console.WriteLine(map[pair.Item1, pair.Item2] + " " + map[x, y] + " " + result);
                    mapcheck[x, y] = true;
                    queue.Enqueue(new Tuple<int, int>(x, y));
                    depthQ.Enqueue(depth + 1);
                }
            }
        }
    }
    return false;
}

void CheckMap()
{
    for (int i = 0; i < lines.Length; i++)
    {
        for (int j = 0; j < lines[i].Length; j++)
        {
            Console.Write(map[i, j]);
        }
        Console.WriteLine();
    }
}

void CreateMap()
{
    
    int width = lines[0].Length;
    int height = lines.Length;
    map = new char[height,width];
    mapcheck = new bool[height, width];
    for (int i=0;i< height; i++)
    {
        for(int j=0;j<width;j++)
        {
            if (lines[i][j] == 'S')
            {
                Tuple<int, int> start = new Tuple<int, int>(i, j);
                startingPoint = start;
            }
            map[i, j] = lines[i][j];
            mapcheck[i, j] = false;
        }
    }
}