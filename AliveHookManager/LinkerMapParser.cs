using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliveHookManager
{
    class LinkerMapParser
    {
        public LinkerMapParser()
        {
            Functions = new List<LinkerMapFunction>();
        }

        public class LinkerMapFunction
        {
            public string Name { get; set; }
            public string Object { get; set; }
            public int Address { get; set; }

            public override string ToString()
            {
                return $"{Name}:{Object}";
            }
        }

        public List<LinkerMapFunction> Functions { get; private set; }

        public void Parse(string linkMapText)
        {
            Functions.Clear();

            string[] splitLines = linkMapText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var l in splitLines)
            {
                if (l.StartsWith(" 0001:"))
                {
                    string[] funcSplit = l.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (funcSplit.Last() != "CODE")
                    {
                        string funcName = funcSplit[1];
                        funcName = funcName.Remove(0, 1);
                        int firstAtIndex = funcName.IndexOf('@');
                        funcName = funcName.Substring(0, (firstAtIndex != -1) ? firstAtIndex : funcName.Length);

                        string[] nameSplit = funcName.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                        int address = 0;
                        if (int.TryParse(nameSplit.Last(), System.Globalization.NumberStyles.HexNumber, null, out address) && address > 0x400000)
                        {
                            string[] funcObjectSplit = funcSplit.Last().Split(':');
                            string functionObject = funcObjectSplit.Last().Split('.').First();

                            var lowerFunc = funcName.ToLower();
                            var sym = funcObjectSplit.First().ToLower();
                            if (!lowerFunc.StartsWith("_") && !lowerFunc.StartsWith("?"))
                            {
                                Functions.Add(new LinkerMapFunction() { Name = funcName, Object = functionObject, Address = address });
                            }
                        }
                    }
                }
            }
        }
    }
}
