using AdventOfCodeDay7;

ElfOS2 ElfOS = new ElfOS2();
//Console.WriteLine(ElfOS.root[0].GetDirSize());
//Task1
Console.WriteLine(ElfOS.CountSmallDirectories(ElfOS.root[0]));
//Task2
Console.WriteLine(ElfOS.FindSpaceForUpdate(ElfOS.root[0], ElfOS.HowMuchSpaceForUpdate(ElfOS.root[0])));


