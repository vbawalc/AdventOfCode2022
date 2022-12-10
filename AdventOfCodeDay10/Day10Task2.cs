int x = 1;
char[,] screen = new char[6, 40];

for (int i=0;i<6;i++)
{
    for (int j = 0; j < 40; j++)
    {
        screen[i, j] = '.';
    }
}
List<int> cycle = new List<int>();

string[] lines = File.ReadLines(@"\\Day10Input.txt").ToArray();

// Put all cycles to the list
for(int i =0;i<lines.Length;i++)
{
    string[] instructions = lines[i].Split(' ');
    if (instructions[0]=="noop")
    {
        cycle.Add(x);
    }
    else
    {
        cycle.Add(x);
        cycle.Add(x);
        x += int.Parse(instructions[1]);
    }
}
//Change inputs to drawing
for (int i =0;i<cycle.Count-1;i++)
{
    CheckDrawing(i, cycle);
}
for (int i = 0; i < 6; i++)
{
    for (int j = 0; j < 40; j++)
    {
        Console.Write(screen[i, j]);
    }
    Console.WriteLine();
}

void CheckDrawing(int currentcycle,List<int> cycles)
{

    int possitiony = currentcycle / 40;
    int possitionx = currentcycle <= 39 ? currentcycle : currentcycle - (40*possitiony);
    
    if (possitionx == cycles[currentcycle] || possitionx == cycles[currentcycle]-1 || possitionx == cycles[currentcycle]+1)
    {
        screen[possitiony, possitionx] = '#';
    }

}