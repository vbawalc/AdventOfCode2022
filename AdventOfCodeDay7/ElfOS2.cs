namespace AdventOfCodeDay7
{
    internal class ElfOS2
    {
        Directory currentdir = new Directory("/");
        public List<Directory> root = new List<Directory>();
        int smalldir = 0;
        int updatesmallestsize = 999999999;

        public ElfOS2() //Create system from txt file
        {
            root.Add(currentdir);
            foreach (string line in File.ReadLines(@"C:\Day7Input.txt"))
            {
                string[] subs = line.Split(' ');
                if (subs[0]=="$") 
                {
                    if (subs[1]=="cd")
                    {
                        string targetdir = subs[2];
                        if (targetdir == "..")
                        {
                            currentdir = currentdir.motherdir;
                        }
                        else if (targetdir == "/")
                        {
                            //nothing happens
                        }
                        else
                        {
                            currentdir = currentdir.Directories.GetValueOrDefault(targetdir);
                        }
                    }
                }
                else if (subs[0]=="dir")
                {
                    currentdir.AddDirectory(new Directory(currentdir, subs[1]));
                }
                else
                {
                    currentdir.AddFile(subs[1], int.Parse(subs[0]));
                }
            }

        }
        public int CountSmallDirectories(Directory rootdir)
        {
            foreach (KeyValuePair<string, Directory> kvp in rootdir.Directories)
            {
                if (kvp.Value.GetDirSize()<=100000)
                {
                    smalldir+=kvp.Value.GetDirSize();
                }
                CountSmallDirectories(kvp.Value);
            }
            return smalldir;
        }
        public int HowMuchSpaceForUpdate(Directory rootdir)
        {
            return (30000000-(70000000 - rootdir.GetDirSize())); 
        }                                                             
        public int FindSpaceForUpdate(Directory rootdir,int NeededSpace)
        {
            foreach (KeyValuePair<string, Directory> kvp in rootdir.Directories)
            {
                if (kvp.Value.GetDirSize()>=NeededSpace&& kvp.Value.GetDirSize()<updatesmallestsize)
                {
                    updatesmallestsize=kvp.Value.GetDirSize();
                }
                FindSpaceForUpdate(kvp.Value,NeededSpace);
            }
            return updatesmallestsize;
        }
    }
}
