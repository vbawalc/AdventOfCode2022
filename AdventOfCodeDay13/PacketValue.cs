using System.Text.Json;
using System.Text.Json.Nodes;

namespace AdventOfCodeDay13;

public class PacketValues
{
    public JsonElement packets;
    public readonly int index;

    public PacketValues(int index, JsonElement newPair)
    {
        this.index = index;
        packets = newPair;
    }
    public static void CreateList(string filename, List<PacketValues> leftPacketValues, List<PacketValues> rightPacketValues)
    {
        var lines = File.ReadAllLines(filename);

        var left = true;
        var i = 1;

        foreach (var line in lines)
        {
            if (line.Length == 0)
            {
                continue;
            }

            var jason = JsonSerializer.Deserialize<JsonElement>(line); //CREATE OBJECT FROM JSON

            var newPair = new PacketValues(i, jason);

            if (left)
            {
                leftPacketValues.Add(newPair);
            }
            else
            {
                rightPacketValues.Add(newPair); ;

                i++;
            }

            left = !left;
        }
    }

    public int Compare(JsonElement leftPair, JsonElement rightPair)
    {
        JsonElement newPacketValues;

        switch (leftPair.ValueKind, rightPair.ValueKind)
        {
            //1st list runs out of items
            case (JsonValueKind.Null, not JsonValueKind.Null):
                return -1;
            //2nd list runs out of items
            case (not JsonValueKind.Null, JsonValueKind.Null):
                return 1;
            // Both items are ints
            case (JsonValueKind.Number, JsonValueKind.Number):
                return Comparer<int>.Default.Compare(leftPair.GetInt32(), rightPair.GetInt32());
            //Firsr item is int 2nd item is List
            case (JsonValueKind.Number, JsonValueKind.Array):
                newPacketValues = JsonSerializer.Deserialize<JsonElement>("[" + leftPair.GetInt32() + "]");
                return Compare(newPacketValues, rightPair);
            //First item is list 2nd item is int
            case (JsonValueKind.Array, JsonValueKind.Number):
                newPacketValues = JsonSerializer.Deserialize<JsonElement>("[" + rightPair.GetInt32() + "]");
                return Compare(leftPair, newPacketValues);
            //Both items are lists
            case (JsonValueKind.Array, JsonValueKind.Array):
                var leftArray = leftPair.EnumerateArray();
                var rightArray = rightPair.EnumerateArray();

                while (leftArray.MoveNext() && rightArray.MoveNext())
                {
                    var leftPacketValues = leftArray.Current;
                    var rightPacketValues = rightArray.Current;

                    var compare = Compare(leftPacketValues, rightPacketValues);

                    if (compare != 0)
                    {
                        return compare;
                    }
                }

                var currentLeft = leftArray.Count() - rightArray.Count();
                if(currentLeft == 0)
                {
                    return 0;
                }
                else if (currentLeft < 1)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            default:
                return 0;
        };
    }

   

   
    public int Compare(PacketValues pairs)
    {
        return Compare(packets, pairs.packets);
    }

    public static void Sort(List<PacketValues> sorted)
    {
        sorted.Sort(Comparer);
    }

    public static int Comparer(PacketValues x, PacketValues y)
    {
        return x.Compare(y);
    }
}