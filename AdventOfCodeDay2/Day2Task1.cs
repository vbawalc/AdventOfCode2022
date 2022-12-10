int Score=0;
Dictionary<char, int> ScoreMap = new Dictionary<char, int>() { { 'X', 1 }, { 'Y', 2 }, { 'Z', 3 }, { 'A', 1 }, { 'B', 2 }, { 'C', 3 } };

foreach (string line in File.ReadLines(@"C:\\Day2Input.txt"))
{
    int Opponent = ScoreMap[line[0]];
    int YourMove = ScoreMap[line[2]];
    //Score for Shape
    Score += YourMove;
    //Score for Win
    int WhoWon = YourMove - Opponent; //-2 1 1 Win 2 5 -1 Lose
    Score += ((WhoWon == 1) || (WhoWon == -2) ? 6 : 0);
    //Score for Draw
    Score += (YourMove == Opponent ? 3 : 0);

}
Console.WriteLine(Score);
Console.ReadLine();