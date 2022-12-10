
namespace AdventOfCodeDay7
{
    internal class Directory
    {
        public Directory? motherdir; //nullable 
        private string name;
        public string Name => name;

        public Dictionary<string,Directory> Directories = new Dictionary<string, Directory>();
        public Dictionary<string,int> Files = new Dictionary<string,int>();

        public int GetDirSize()
        {
            int DirSize=0;
            foreach (KeyValuePair<string, Directory> kvp in Directories)
            {
                DirSize += kvp.Value.GetDirSize();
            }
            foreach (KeyValuePair<string,int> file in Files)
            {
                DirSize += file.Value;
            }
            return DirSize;
        }
        public void AddFile(string filename, int size)
        {

            Files.Add(filename, size);
        }
        public void AddDirectory(Directory dir)
        {
            Directories.Add(dir.Name,dir);
        }
        //Constructors
        public Directory(Directory dir, string dirname)
        {
            motherdir = dir;
            name = dirname;
        }
        public Directory(string dirname) => name = dirname;

       

    }
}
