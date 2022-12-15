using System.Text.Json;
using AdventOfCodeDay13;

List<PacketValues> leftPacketValues = new List<PacketValues>();
List<PacketValues> rightPacketValues = new List<PacketValues>();
int sum = 0;
PacketValues.CreateList("C:\\Users\\BartłomiejWalczak\\source\\repos\\AdventOfCodeDay13\\AdventOfCodeDay13\\Day13Input.data", leftPacketValues, rightPacketValues);

var leftArray = leftPacketValues.GetEnumerator();
var rightArray = rightPacketValues.GetEnumerator();


while (leftArray.MoveNext() && rightArray.MoveNext())
{
    var currentleft = leftArray.Current;
    var currentright = rightArray.Current;

    if (currentleft.Compare(currentright) < 0)
    {
        sum += currentleft.index;
    }
}
Console.WriteLine(sum);

