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
    public class Program
    {
        [Import]
        private ITestViewModel _testViewModel;
        [STAThread]
        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Compose();
            if(program._testViewModel != null)
            {
                program._testViewModel.Print();
            }
        }

        public void Compose()
        {
            string[] assembly = new string[] 
            {
                "MWPFFrame.MyApplication.TestModule.ViewModel",
                "MWPFFrame.Utility"
            };
            AggregateCatalog catalog = new AggregateCatalog();
            foreach (var item in assembly)
            {
                catalog.Catalogs.Add(new AssemblyCatalog(Assembly.Load(item)));
            }
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }
    }
}
