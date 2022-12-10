using System.Collections;
List <Stack> LoadingStacks = new List<Stack>();
List <Stack> RealStacks = new List<Stack>();
//Create Stacks
for (int i=0;i<9;i++)
{
    LoadingStacks.Add (new Stack ());
    RealStacks.Add (new Stack ());
}

string[] lines = File.ReadLines(@"C:\\Day5Input.txt").ToArray();
//Load Starting Stacks Data
for (int i = 0; i < 8; i++)
{
    for (int j = 1; j < lines[i].Length; j += 4)
    {
        if (lines[i][j] != ' ')
        {
            LoadingStacks[(j / 4)].Push(lines[i][j]);
        }
    }
}
//Fill real stacks with data
for (int j=0;j<8;j++)
{
    for (int i = 0; i < 9; i++)
    {
        if (LoadingStacks[i].Count>0)
        {
            RealStacks[i].Push(LoadingStacks[i].Pop());
        }
    }
}
for (int i =10; i<lines.Length;i++)
{
    //remove unneceserry data
    lines[i]=lines[i].Replace("move", "");
    lines[i] = lines[i].Replace("from", "");
    lines[i] = lines[i].Replace("to", "");
    string[] subs = lines[i].Split(' ');
    // 
    int howMany = int.Parse(subs[1]);
    int from = int.Parse(subs[3]);
    int to = int.Parse(subs[5]);
    //Move Crates
    for (int j=0;j<howMany;j++)
    {
        LoadingStacks[to-1].Push(RealStacks[from-1].Pop());
    }
    for(int j=0;j<howMany;j++)
    {
        RealStacks[to-1].Push(LoadingStacks[to - 1].Pop());
    }
}
//Get the Result
for(int i =0;i<9;i++)
{
    Console.WriteLine(RealStacks[i].Pop());
}




