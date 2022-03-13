namespace RatingDatabase;
public class Item : Model {
    public int ID { get => Get<int>(); set => Set(value); }
    public string Name { get => Get<string>(); set => Set(value); } 
    public int Rating { get => Get<int>(); set => Set(value); }
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
