using System.Text.Json;
using AdventOfCodeDay13;

List<PacketValues> leftPacketValues = new List<PacketValues>();
List<PacketValues> rightPacketValues = new List<PacketValues>();
List<PacketValues> sortedPacketValues = new List<PacketValues>();
int product = 0;
int divisor = 1;
int i = 1;
var two = JsonSerializer.Deserialize<JsonElement>("[[2]]");
var six = JsonSerializer.Deserialize<JsonElement>("[[6]]");


PacketValues.CreateList("C:\\Users\\BartłomiejWalczak\\source\\repos\\AdventOfCodeDay13\\AdventOfCodeDay13\\Day13Input.data", sortedPacketValues, sortedPacketValues);
sortedPacketValues.Add(new PacketValues(2, two));
sortedPacketValues.Add(new PacketValues(4, six));
PacketValues.Sort(sortedPacketValues);

var sortedArray = sortedPacketValues.GetEnumerator();

while (sortedArray.MoveNext())
{
    var sorted = sortedArray.Current;

    product += sorted.Index;

    if (sorted.Compare(two, sorted.packets) == 0 || sorted.Compare(six, sorted.packets) == 0)
    {
        divisor *= i;
    }

    i++;
}
Console.WriteLine(divisor);