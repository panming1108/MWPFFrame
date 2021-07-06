using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace MWPFFrame.UIControls
{
    public class MBusyIndicator : ContentControl
    {
        public double IconHeight
        {
            get { return (double)GetValue(IconHeightProperty); }
            set { SetValue(IconHeightProperty, value); }
        }
        public double IconWidth
        {
            get { return (double)GetValue(IconWidthProperty); }
            set { SetValue(IconWidthProperty, value); }
        }
        public Thickness IconMargin
        {
            get { return (Thickness)GetValue(IconMarginProperty); }
            set { SetValue(IconMarginProperty, value); }
        }
        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }

        public static readonly DependencyProperty IsBusyProperty =
            DependencyProperty.Register(nameof(IsBusy), typeof(bool), typeof(MBusyIndicator));
        public static readonly DependencyProperty IconMarginProperty =
            DependencyProperty.Register(nameof(IconMargin), typeof(Thickness), typeof(MBusyIndicator));
        public static readonly DependencyProperty IconWidthProperty =
            DependencyProperty.Register(nameof(IconWidth), typeof(double), typeof(MBusyIndicator));
        public static readonly DependencyProperty IconHeightProperty =
            DependencyProperty.Register(nameof(IconHeight), typeof(double), typeof(MBusyIndicator));
    }
}
