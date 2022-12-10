using AdventOfCodeDay9;

Coordinates[] currentRopeLocation = new Coordinates[11];
Coordinates[] lastRopeLocation = new Coordinates[11];
HashSet<Coordinates> allTailLocation = new HashSet<Coordinates>();

//Add starting possitions
for (int i = 0; i < 11; i++)
{
    currentRopeLocation[i] = new Coordinates(0, 0);
    lastRopeLocation[i] = new Coordinates(0, 0);
}

allTailLocation.Add(currentRopeLocation[10]);

string[] lines = File.ReadLines(@"C:\\Day9Input.txt").ToArray();

for (int i = 0; i < lines.Length; i++)
{
    string[] move = lines[i].Split(" ");
    string movedirection = move[0];
    int movextimes = int.Parse(move[1]);

    if (movedirection.Equals("U"))
    {
        for (int j = 0; j < movextimes; j++)
        {
            lastRopeLocation[0] = currentRopeLocation[0];
            currentRopeLocation[0] = currentRopeLocation[0] + new Coordinates(0, 1);
            MoveTail();
            allTailLocation.Add(currentRopeLocation[1]);
        }
    }
    if (movedirection.Equals("D"))
    {
        for (int j = 0; j < movextimes; j++)
        {
            lastRopeLocation[0] = currentRopeLocation[0];
            currentRopeLocation[0] = currentRopeLocation[0] + new Coordinates(0, -1);
            MoveTail();
            allTailLocation.Add(currentRopeLocation[1]);
        }
    }
    if (movedirection.Equals("R"))
    {
        for (int j = 0; j < movextimes; j++)
        {
            lastRopeLocation[0] = currentRopeLocation[0];
            currentRopeLocation[0] = currentRopeLocation[0] + new Coordinates(1, 0);
            MoveTail();
            allTailLocation.Add(currentRopeLocation[1]);
        }
    }
    if (movedirection.Equals("L"))
    {
        for (int j = 0; j < movextimes; j++)
        {

            lastRopeLocation[0] = currentRopeLocation[0];
            currentRopeLocation[0] = currentRopeLocation[0] + new Coordinates(-1, 0);
            MoveTail();
            allTailLocation.Add(currentRopeLocation[1]);
        }
    }
}

HashSet<string> distinctcoordinates = new HashSet<string>();
foreach (Coordinates coord in allTailLocation)
{
    distinctcoordinates.Add(coord.X + " " + coord.Y);
}
int score = distinctcoordinates.Distinct().Count();
Console.WriteLine(score);

void MoveTail()
{

    for (int i = 1; i < 11; i++)
    {

        Coordinates distance = currentRopeLocation[i - 1] - currentRopeLocation[i];
        if (distance.X > 1 || distance.Y > 1 || distance.X < -1 || distance.Y < -1)
        {
            lastRopeLocation[i] = currentRopeLocation[i];
            currentRopeLocation[i] = lastRopeLocation[i - 1];
        }

    }
}
