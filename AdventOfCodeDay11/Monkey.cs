namespace AdventOfCodeDay11
{
    internal class Monkey
    {
        public List<int> items;
        public int inspecteditems;

        private string operation;
        private char operationSign;
        private int test;
        private int throwwhentrue;
        private int throwwhenfalse;
       

        public Monkey()
        {
            items = new List<int>();
            inspecteditems = 0;
        }
        public string Operation => operation;
        public char OperationSign => operationSign;
        public int Test => test;
        public int Throwwhentrue => throwwhentrue;
        public int Throwwhenfalse => throwwhenfalse;

        public void AddItem(int item)
        {
            items.Add(item);
        }
        public void setOperation(string _operation)
        {
            operation = _operation;
        }
        public void setOperationSign(char _operationSign)
        {
            operationSign = _operationSign;
        }
        public void setTest(int _test)
        {
            test = _test;
        }
        public void setThrowTrue(int _throwwhentrue)
        {
            throwwhentrue = _throwwhentrue;
        }
        public void setThrowFalse(int _throwwhenfalse)
        {
            throwwhenfalse = _throwwhenfalse;
        }
    }
}
