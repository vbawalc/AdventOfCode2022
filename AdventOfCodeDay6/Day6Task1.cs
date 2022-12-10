char[] input = File.ReadAllText(@"C:\\Day6Input.txt").ToArray();
List<char> marker = new List<char>();

for (int i = 0; i < input.Length; i++)
{
    if (marker.Count == 4)
    {
        marker.RemoveAt(0);
        marker.Add(input[i]);
        if (marker.Count() == marker.Distinct().Count())
        {
            Console.WriteLine(i + 1);
            break;
        }
    }
    else
    {
        marker.Add(input[i]);
    }
}
