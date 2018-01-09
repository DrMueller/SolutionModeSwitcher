using System.Collections.ObjectModel;
using System.Windows;
using Mmu.Sms.Application.Areas.App.Informations.Models;

namespace Mmu.Sms.WpfUI.Infrastructure.Areas.Informations.UserControls
{
    public partial class InformationGridControl
    {
        public static readonly DependencyProperty InformationEntriesProperty =
            DependencyProperty.Register(
                "InformationEntries",
                typeof(ObservableCollection<Information>),
                typeof(InformationGridControl));

        public InformationGridControl()
        {
            InitializeComponent();
        }

        public ObservableCollection<Information> InformationEntries
        {
            get => (ObservableCollection<Information>)GetValue(InformationEntriesProperty);
            set => SetValue(InformationEntriesProperty, value);
        }
    }
}