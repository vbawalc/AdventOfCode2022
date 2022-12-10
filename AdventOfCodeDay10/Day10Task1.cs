int score = 0;
int x = 1;
List<int> cycle = new List<int>();
string[] lines = File.ReadLines(@"C:\Users\BartłomiejWalczak\source\repos\AdventOfCodeDay10\AdventOfCodeDay10\Day10Input.txt").ToArray();

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

/*for(int i=0; i<cycle.Count;i++)
{
    Console.WriteLine(cycle[i]);
}*/


score += cycle[19]*20 + cycle[59]*60 + cycle[99]*100 + cycle[139]*140 + cycle[179]*180 + cycle[219]*220;
Console.WriteLine(score);