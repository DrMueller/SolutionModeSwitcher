using System.Windows;

namespace Mmu.Sms.WpfUI.Infrastructure.Areas.Informations.UserControls
{
    public partial class InformationBarControl
    {
        public static readonly DependencyProperty InformationTextProperty =
            DependencyProperty.Register(
                "InformationText",
                typeof(string),
                typeof(InformationBarControl));

        public InformationBarControl()
        {
            InitializeComponent();
        }

        public string InformationText
        {
            get => (string)GetValue(InformationTextProperty);
            set => SetValue(InformationTextProperty, value);
        }
    }
}