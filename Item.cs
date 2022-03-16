using System.Windows;

namespace RatingDatabase;
public class Item : Model {
    public int ID { get => Get<int>(); set => Set(value); }
    public string Name { get => Get<string>(); set => Set(value); } 
    public int Rating { 
        get => Get<int>();
        set {
            int v = value;
            if (value < 0) v = 0;
            else if (value > 10) v = 10;
            Set(v);
            Application.Current.Dispatcher.Invoke(() => Notify(nameof(Rating)));
        }
    }
    public string[] Tags { get => Get<string[]>(); set => Set(value); }

    public Item() { 
        ID = 0;
        Name = "";
        Rating = 0;
        Tags = System.Array.Empty<string>();
    }

    public override string ToString() {
        return $"{ID}, {Name}, {Rating}, [{string.Join(",", Tags)}]";
    }
}
