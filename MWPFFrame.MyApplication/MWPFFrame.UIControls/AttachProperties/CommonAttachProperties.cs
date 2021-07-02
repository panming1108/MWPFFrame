using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace MWPFFrame.UIControls.AttachProperties
{
    public class CommonAttachProperties
    {
        #region 圆角
        public static CornerRadius GetCornerRadius(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(CommonAttachProperties));
        #endregion

        #region 悬浮背景颜色
        public static Brush GetMouseOverBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(MouseOverBackgroundProperty);
        }

        public static void SetMouseOverBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(MouseOverBackgroundProperty, value);
        }

        public static readonly DependencyProperty MouseOverBackgroundProperty =
            DependencyProperty.RegisterAttached("MouseOverBackground", typeof(Brush), typeof(CommonAttachProperties));
        #endregion

        #region 悬浮前景颜色
        public static Brush GetMouseOverForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(MouseOverForegroundProperty);
        }

        public static void SetMouseOverForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(MouseOverForegroundProperty, value);
        }

        public static readonly DependencyProperty MouseOverForegroundProperty =
            DependencyProperty.RegisterAttached("MouseOverForeground", typeof(Brush), typeof(CommonAttachProperties));
        #endregion

        #region 悬浮边框颜色
        public static Brush GetMouseOverBorderBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(MouseOverBorderBrushProperty);
        }

        public static void SetMouseOverBorderBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(MouseOverBorderBrushProperty, value);
        }

        // Using a DependencyProperty as the backing store for MouseOverBorderBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MouseOverBorderBrushProperty =
            DependencyProperty.RegisterAttached("MouseOverBorderBrush", typeof(Brush), typeof(CommonAttachProperties));
        #endregion

        #region 选中背景颜色
        public static Brush GetSelectedBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(SelectedBackgroundProperty);
        }

        public static void SetSelectedBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(SelectedBackgroundProperty, value);
        }

        public static readonly DependencyProperty SelectedBackgroundProperty =
            DependencyProperty.RegisterAttached("SelectedBackground", typeof(Brush), typeof(CommonAttachProperties));
        #endregion

        #region 选中前景颜色
        public static Brush GetSelectedForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(SelectedForegroundProperty);
        }

        public static void SetSelectedForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(SelectedForegroundProperty, value);
        }

        public static readonly DependencyProperty SelectedForegroundProperty =
            DependencyProperty.RegisterAttached("SelectedForeground", typeof(Brush), typeof(CommonAttachProperties));
        #endregion

        #region 选中边框颜色
        public static Brush GetSelectedBorderBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(SelectedBorderBrushProperty);
        }

        public static void SetSelectedBorderBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(SelectedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty SelectedBorderBrushProperty =
            DependencyProperty.RegisterAttached("SelectedBorderBrush", typeof(Brush), typeof(CommonAttachProperties));
        #endregion

        #region 失效背景颜色
        public static Brush GetUnEnabledBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(UnEnabledBackgroundProperty);
        }

        public static void SetUnEnabledBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(UnEnabledBackgroundProperty, value);
        }

        public static readonly DependencyProperty UnEnabledBackgroundProperty =
            DependencyProperty.RegisterAttached("UnEnabledBackground", typeof(Brush), typeof(CommonAttachProperties));
        #endregion

        #region 失效前景颜色
        public static Brush GetUnEnabledForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(UnEnabledForegroundProperty);
        }

        public static void SetUnEnabledForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(UnEnabledForegroundProperty, value);
        }

        public static readonly DependencyProperty UnEnabledForegroundProperty =
            DependencyProperty.RegisterAttached("UnEnabledForeground", typeof(Brush), typeof(CommonAttachProperties));
        #endregion

        #region 失效边框颜色
        public static Brush GetUnEnabledBorderBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(UnEnabledBorderBrushProperty);
        }

        public static void SetUnEnabledBorderBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(UnEnabledBorderBrushProperty, value);
        }

        public static readonly DependencyProperty UnEnabledBorderBrushProperty =
            DependencyProperty.RegisterAttached("UnEnabledBorderBrush", typeof(Brush), typeof(CommonAttachProperties));
        #endregion
    }
}
