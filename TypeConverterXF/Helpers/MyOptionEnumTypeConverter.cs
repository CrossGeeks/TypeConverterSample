using System;
using System.ComponentModel;
using System.Globalization;
using TypeConverterXF.Helpers;
using Xamarin.Forms.Xaml;

namespace TypeConverterXF
{
    [TypeConversion(typeof(int))]
    public class MyOptionEnumTypeConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return (int)Enum.Parse(typeof(OptionsEnum), $"{value}");
        }
    }
}
