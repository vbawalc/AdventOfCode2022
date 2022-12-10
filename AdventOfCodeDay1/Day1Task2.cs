int[] MaximumElves = new int[3];
int CurrentElf =0;

foreach (string line in File.ReadLines(@"C:\\Users\\BartłomiejWalczak\Desktop\Elves.txt"))
{
    if (string.IsNullOrEmpty(line))
    {
        Array.Sort(MaximumElves);
        MaximumElves[0] = (CurrentElf > MaximumElves[0] ? CurrentElf : MaximumElves[0]);
        CurrentElf = 0;
    }
    else
        CurrentElf += int.Parse(line);
}
Array.Sort(MaximumElves);
MaximumElves[0] = (CurrentElf > MaximumElves[0] ? CurrentElf : MaximumElves[0]);
Console.WriteLine(MaximumElves[0] + MaximumElves[1] + MaximumElves[2]);
Console.ReadLine();

