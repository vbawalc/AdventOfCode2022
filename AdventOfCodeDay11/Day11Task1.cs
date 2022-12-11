using AdventOfCodeDay11;
using System.Data.SqlTypes;

List <Monkey> monkeys = new List <Monkey> ();
List<int> monkeybussiness = new List<int>();

LoadMonkeys();
for(int i=0;i<20;i++)
{
    for (int j=0;j<monkeys.Count;j++)
    {
        //CHECK IF MONKEY HOLDS ANY ITEMS
        if (monkeys[j].items.Count > 0)
        {
            //THROW ALL ITEMS 1 BY 1
            for (int k=0;k < monkeys[j].items.Count;k++)
            {
                monkeys[j].inspecteditems++;
                //INSPECT ITEM
                int worrylevel = monkeys[j].items[k];
                Console.WriteLine("Inspecting item:" + worrylevel);
                if (monkeys[j].OperationSign == '+')
                {
                    worrylevel += int.Parse(monkeys[j].Operation);
                }
                else
                {
                    if (monkeys[j].Operation == "old")
                    {
                        worrylevel = worrylevel * worrylevel;
                    }
                    else
                    {
                        worrylevel = worrylevel * int.Parse(monkeys[j].Operation);
                    }
                }
                //GET BORED WITH ITEM 
                worrylevel = worrylevel / 3;
                //DECIDE WHERE TO THROW AN ITEM
                if (worrylevel % monkeys[j].Test == 0)
                {
                    monkeys[monkeys[j].Throwwhentrue].AddItem(worrylevel);
                }
                else
                {
                    monkeys[monkeys[j].Throwwhenfalse].AddItem(worrylevel);
                }
            }
            monkeys[j].items.Clear();
            
        }
    }
}

//FIND MONKEYS THAT INSPECTED MOST ITEMS
foreach(Monkey monkey in monkeys)
{
    monkeybussiness.Add(monkey.inspecteditems);
}
monkeybussiness.Sort();
int result = monkeybussiness[monkeybussiness.Count - 1] * monkeybussiness[monkeybussiness.Count - 2];
Console.WriteLine(result);




void LoadMonkeys()
{
    int currentmonkey = -1;
    string[] lines = File.ReadLines(@"\\Day11Input.txt").ToArray();
    for (int i = 0; i < lines.Length; i++)
    {
        lines[i] = lines[i].Trim();
        string[] line = lines[i].Split(' ', ',');
        if (line[0] == "Monkey")
        {
            currentmonkey++;
            monkeys.Add(new Monkey());
        }
        else if (line[0] == "Starting")
        {
            for (int j = 2; j < line.Length; j += 2)
            {
                monkeys[currentmonkey].AddItem(int.Parse(line[j]));
            }
        }
        else if (line[0] == "Operation:")
        {
            monkeys[currentmonkey].setOperationSign(char.Parse(line[4]));
            monkeys[currentmonkey].setOperation(line[5]);
        }
        else if (line[0] == "Test:")
        {
            monkeys[currentmonkey].setTest(int.Parse(line[3]));
        }
        else if (line[0] == "If")
        {
            if (line[1] == "true:")
            {
                monkeys[currentmonkey].setThrowTrue(int.Parse(line[5]));

            }
            else
            {
                monkeys[currentmonkey].setThrowFalse(int.Parse(line[5]));
            }
        }
    }
}
