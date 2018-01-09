using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Mmu.Sms.WpfUI.Infrastructure.Wpf.DependencyProperties
{
    public static class DataGridDoubleClickCommandBinding
    {
        public static readonly DependencyProperty DataGridDoubleClickProperty = DependencyProperty.RegisterAttached("DataGridDoubleClickCommand", typeof(ICommand), typeof(DataGridDoubleClickCommandBinding), new PropertyMetadata(AttachOrRemoveDataGridDoubleClickEvent));

        public static void AttachOrRemoveDataGridDoubleClickEvent(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if (!(obj is DataGrid dataGrid))
            {
                return;
            }

            if (args.OldValue == null && args.NewValue != null)
            {
                dataGrid.MouseDoubleClick += ExecuteDataGridDoubleClick;
            }
            else if (args.OldValue != null && args.NewValue == null)
            {
                dataGrid.MouseDoubleClick -= ExecuteDataGridDoubleClick;
            }
        }

        public static ICommand GetDataGridDoubleClickCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(DataGridDoubleClickProperty);
        }

        public static void SetDataGridDoubleClickCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(DataGridDoubleClickProperty, value);
        }

        private static void ExecuteDataGridDoubleClick(object sender, MouseButtonEventArgs args)
        {
            var obj = sender as DependencyObject;
            var cmd = (ICommand)obj?.GetValue(DataGridDoubleClickProperty);
            if (cmd == null)
            {
                return;
            }

            if (cmd.CanExecute(obj))
            {
                cmd.Execute(obj);
            }
        }
    }
}