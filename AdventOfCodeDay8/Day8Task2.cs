
string[] rows = File.ReadLines(@"C:\\Day8Input.txt").ToArray();

int[,] treesmap = new int[rows.Count(), rows[0].Count()];
int[,] treesmapcheck = new int[rows.Count(), rows[0].Count()];

int[] visibilityoflefttrees = new int[10];
int[] visibilityofrighttrees = new int[10];
int[] visibilityoftoptrees = new int[10];
int[] visibilityofbottrees = new int[10];

int max =0;

LoadMap();
CheckLeftVisibility();
CheckRightVisibility();
CheckTopVisibility();
CheckBotVisibility();

for (int i = 0; i < rows.Count(); i++)
{
    for (int j = 0; j < rows[i].Count(); j++)
    {
        max = treesmapcheck[i,j] > max ? treesmapcheck[i,j] : max;
        Console.Write(treesmapcheck[i, j]);
    }
    Console.WriteLine();
}
Console.WriteLine(max);

void CheckLeftVisibility()
{
    for (int i = 0; i < rows.Count(); i++)
    {
        Array.Clear(visibilityoflefttrees, 0, visibilityoflefttrees.Length);
        for (int j = 0; j < rows[i].Count();j++)
        {
            //Add visibility score to check tab
            treesmapcheck[i, j] += j - visibilityoflefttrees[treesmap[i,j]];
            //Update visibility from left
            for (int k = 0; k <= treesmap[i,j];k++)
            {
                visibilityoflefttrees[k] = j;
            }
        }
    }
}
void CheckTopVisibility()
{
    for (int i = 0; i < rows[0].Count(); i++)
    {
        Array.Clear(visibilityoftoptrees, 0, visibilityoftoptrees.Length);
        for (int j = 0; j < rows.Count(); j++)
        {
            //Add visibility score to check tab
            treesmapcheck[j, i] *= j - visibilityoftoptrees[treesmap[j, i]];
            //Update visibility from left
            for (int k = 0; k <= treesmap[j, i]; k++)
            {
                visibilityoftoptrees[k] = j;
            }
        }
    }
}

void CheckRightVisibility()
{
    for (int i = rows.Count()-1; i >=0; i--)
    {
        // reset table
        for (int x =0;x<10;x++)
        {
            visibilityofrighttrees[x] = rows[i].Count()-1;
        }
        for (int j = rows[i].Count()-1; j >= 0; j--)
        {
            //Add visibility score to checktab
            treesmapcheck[i, j] *= visibilityofrighttrees[treesmap[i, j]] -j;
            //Update visibility from left
            for (int k = 0; k <= treesmap[i,j]; k++)
            {
                visibilityofrighttrees[k] = j;
            }
        }
    }
}

void CheckBotVisibility()
{
    for (int i = rows[0].Count() - 1; i >= 0; i--)
    {
        for (int x = 0; x < 10; x++)
        {
            visibilityofbottrees[x] = rows.Count()-1;
        }
        for (int j = rows.Count()-1; j >= 0; j--)
        {
            //Add visibility score to check tab
            treesmapcheck[j,i] *= visibilityofbottrees[treesmap[j,i]] -j;
            //Update visibility from left
            for (int k = 0; k <= treesmap[j,i]; k++)
            {
                visibilityofbottrees[k] = j;
            }
        }
    }
}

void LoadMap()
{
    for (int i = 0; i < rows.Count(); i++)
    {
        for (int j = 0; j < rows[i].Count(); j++)
        {
            treesmap[i, j] = int.Parse(rows[i][j].ToString());
        }
    }
}
