using Syncfusion.XForms.Buttons;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LightingsPanel.Views.CustomViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LightButton : SfButton
    {
        public static readonly BindableProperty BtnBackgroundColorProperty = BindableProperty.Create("BtnBackgroundColor", typeof(Color), typeof(LightButton));

        public Color BtnBackgroundColor
        {
            get { return (Color)GetValue(BtnBackgroundColorProperty); }
            set { SetValue(BtnBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty LabelProperty = BindableProperty.Create("Label", typeof(string), typeof(LightButton));
        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public static readonly BindableProperty BtnImageProperty = BindableProperty.Create("BtnImage", typeof(string), typeof(LightButton));
        public string BtnImage
        {
            get { return (string)GetValue(BtnImageProperty); }
            set { SetValue(BtnImageProperty, value); }
        }

        public LightButton()
        {
            InitializeComponent();

            BindingContext = this;
        }
    }
}