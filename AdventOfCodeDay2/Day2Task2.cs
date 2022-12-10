int Score=0;
Dictionary<char, int> ScoreMap = new Dictionary<char, int>() { {'X',1}, { 'Y', 2 }, { 'Z', 3 }, { 'A', 1 }, { 'B', 2 }, { 'C', 3 } };

foreach (string line in File.ReadLines(@"C:\\Day2Input.txt"))
{
    int Opponent = ScoreMap[line[0]];
    int YourMove = ScoreMap[line[2]];
    //Score for Shape
    if (YourMove == 1)
    {
        Score+=(Opponent == 1 ? 3 : (Opponent-1));
        //Lose no points
    }
    else if (YourMove == 2)
    {
        Score+=Opponent;
        Score += 3; //Draw
    }
    else if (YourMove==3)
    {
        Score+=(Opponent==3 ? 1 : (Opponent+1));
        Score += 6;//Win
    }

}
Console.WriteLine(Score);
Console.ReadLine();

