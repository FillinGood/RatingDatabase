using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace RatingDatabase;
[TypeConverter(typeof(TagsConverter))]
public class TagsCollection : IEnumerable<string>, IComparable, IComparable<TagsCollection> {
    public static TagsCollection Empty { get; } = new(Array.Empty<string>());
    private string[] Values { get; }

    public TagsCollection(string values) {
        Values = values.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    }
    public TagsCollection(string[] values) {
        Values = new string[values.Length];
        values.CopyTo(Values, 0);
    }

    public IEnumerator<string> GetEnumerator() {
        return ((IEnumerable<string>)Values).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return Values.GetEnumerator();
    }

    public int CompareTo(object? obj) {
        if(obj is TagsCollection other)
            return CompareTo(other);
        return -1;
    }

    public int CompareTo(TagsCollection? other) {
        if(other is null)
            return -1;
        string a = string.Join(',', Values);
        string b = string.Join(',', other.Values);
        return a.CompareTo(b);
    }

    public override string ToString() {
        return string.Join(", ", Values);
    }
}
