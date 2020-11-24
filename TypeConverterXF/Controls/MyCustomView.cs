using System.Collections.Generic;
using Xamarin.Forms;

namespace TypeConverterXF.Controls
{
    public class MyCustomView: StackLayout
    {
        [TypeConverter(typeof(MyOptionEnumTypeConverter))]
        public int OptionSelected
        {
            get => (int)GetValue(OptionSelectedProperty);
            set => SetValue(OptionSelectedProperty, value);
        }

        public static readonly BindableProperty OptionSelectedProperty =
           BindableProperty.Create(nameof(OptionSelected),
                                   typeof(int),
                                   typeof(MyCustomView));
        
        [TypeConverter(typeof(ListStringTypeConverter))]
        public IList<string> OptionsList
        {
            get => (IList<string>)GetValue(OptionsListProperty);
            set => SetValue(OptionsListProperty, value);
        }

        public static readonly BindableProperty OptionsListProperty =
           BindableProperty.Create(nameof(OptionsList),
                                   typeof(IList<string>),
                                   typeof(MyCustomView));

        [TypeConverter(typeof(FontSizeConverter))]
        public double MyElementFontSize
        {
            get => (double)GetValue(MyElementFontSizeProperty);
            set => SetValue(MyElementFontSizeProperty, value);
        }

        public static readonly BindableProperty MyElementFontSizeProperty =
           BindableProperty.Create(nameof(MyElementFontSize),
                                   typeof(double),
                                   typeof(MyCustomView));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly BindableProperty TextProperty =
           BindableProperty.Create(nameof(Text),
                                   typeof(string),
                                   typeof(MyCustomView), defaultBindingMode: BindingMode.TwoWay);

        [TypeConverter(typeof(ReferenceTypeConverter))]
        public IndicatorView IndicatorView
        {
            set => LinkToIndicatorView(this, value);
        }

        private static void LinkToIndicatorView(MyCustomView myView, IndicatorView indicatorView)
        {
            if (indicatorView == null)
            {
                return;
            }

            indicatorView.SetBinding(IndicatorView.TextProperty,
                                        new Binding(MyCustomView.TextProperty.PropertyName,
                                                    BindingMode.TwoWay,
                                                    source: myView));
        }
    }
}
