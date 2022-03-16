using System;
using System.ComponentModel;
using System.Globalization;

namespace RatingDatabase;
public sealed class TagsConverter : TypeConverter {
    public override bool CanConvertTo(ITypeDescriptorContext? c, Type? type) {
        return type == typeof(string);
    }
    public override bool CanConvertFrom(ITypeDescriptorContext? c, Type type) {
        return type == typeof(string);
    }
    public override object? ConvertTo(ITypeDescriptorContext? c, CultureInfo? culture, object? value, Type type) {
        if(value is not TagsCollection tc)
            throw new InvalidOperationException("Must be a TagsCollection");
        return tc.ToString();
    }
    public override object? ConvertFrom(ITypeDescriptorContext? c, CultureInfo? culture, object value) {
        if(value is not string s)
            throw new InvalidOperationException("Must be a string");
        return new TagsCollection(s);
    }
}
