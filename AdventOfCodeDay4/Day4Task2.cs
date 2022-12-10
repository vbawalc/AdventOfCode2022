int Score = 0;
int LinesCount = 0;
foreach (string line in File.ReadLines(@"C:\\Users\\BartłomiejWalczak\Desktop\Elves.txt"))
{
    string[] subs = line.Split('-', ',');
    if (int.Parse(subs[1]) < int.Parse(subs[2]) && int.Parse(subs[0]) < int.Parse(subs[3]))
    {
        Score++;
    }
    else if (int.Parse(subs[1]) > int.Parse(subs[2]) && int.Parse(subs[0]) > int.Parse(subs[3]))
        {
        Score++;
    }
    LinesCount++;
}
Console.WriteLine(LinesCount-Score);

/*foreach (string line in File.ReadLines(@"C:\\Users\\BartłomiejWalczak\Desktop\Elves.txt"))
{
    string[] subs = line.Split('-',',');
    // first Elf assignments fully contain 2nd elf assignments
    if (int.Parse(subs[0]) <= int.Parse(subs[2]) && int.Parse(subs[1]) >= int.Parse(subs[3]))
    {
        Score++;
    }
    // 2nd Elf assignments fully contain 1st elf assignment
    else if (int.Parse(subs[2]) <= int.Parse(subs[0]) && int.Parse(subs[3]) >= int.Parse(subs[1]))
    {
        Score++;
    }
}
Console.WriteLine(Score);*/

