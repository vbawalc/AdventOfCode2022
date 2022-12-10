int MaximumElf = 0;
int CurrentElf = 0;

foreach (string line in File.ReadLines(@"C:\\input.txt"))
{
    if (string.IsNullOrEmpty(line))
    {
        MaximumElf = (CurrentElf > MaximumElf ? CurrentElf : MaximumElf);
        CurrentElf = 0;
    }
    else
        CurrentElf += int.Parse(line);
}
MaximumElf = (CurrentElf > MaximumElf ? CurrentElf : MaximumElf);
Console.WriteLine(MaximumElf);
Console.ReadLine();
