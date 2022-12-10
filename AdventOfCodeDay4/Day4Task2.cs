int Score = 0;
int LinesCount = 0;
foreach (string line in File.ReadLines(@"C:\\Day4Input.txt"))
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

