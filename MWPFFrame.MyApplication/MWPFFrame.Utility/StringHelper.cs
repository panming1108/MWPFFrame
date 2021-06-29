using MWPFFrame.IUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace MWPFFrame.Utility
{
    [Export(typeof(IStringHelper))]
    public class StringHelper : IStringHelper
    {
        public void PrintString()
        {
            Console.WriteLine("PrintString");
        }
    }
}
