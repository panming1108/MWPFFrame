using MWPFFrame.Applications;
using MWPFFrame.MyApplication.IViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MWPFFrame.MyApplication.Container
{
    public class Program : ProgramBase
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Program program = new Program();
            string[] assembly = new string[]
            {
                "MWPFFrame.MyApplication.TestModule.ViewModel",
                "MWPFFrame.Utility"
            };
            program.BuildComposeParts(assembly);
            Startup startup = new Startup();
            startup.Run();
        }
    }
}
