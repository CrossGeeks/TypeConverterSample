using Xamarin.Forms;

namespace TypeConverterXF.Controls
{
    public class IndicatorView: ContentView
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(IndicatorView), null, propertyChanged: OnTextPropertyChanged);

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
                
        private static void OnTextPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var view = bindable as ContentView;
            view.Content = new Label() { Text = $"{newvalue}" };
        }
    }
}
