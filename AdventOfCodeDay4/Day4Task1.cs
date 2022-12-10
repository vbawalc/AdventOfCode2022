int Score = 0;

foreach (string line in File.ReadLines(@"C:\\Day4Input.txt"))
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
Console.WriteLine(Score);