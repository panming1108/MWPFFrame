using MWPFFrame.IUtility;
using MWPFFrame.MyApplication.IViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace MWPFFrame.MyApplication.TestModule.ViewModel
{
    [Export(typeof(ITestViewModel))]
    public class TestViewModel : ITestViewModel
    {
        [Import]
        private IStringHelper _stringHelper;
        public void Print()
        {
            _stringHelper.PrintString();
        }
    }
}
