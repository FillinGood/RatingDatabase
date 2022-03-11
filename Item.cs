namespace RatingDatabase;
public class Item : Model {
    public int ID { get => Get<int>(); set => Set(value); }
    public string Name { get => Get<string>(); set => Set(value); }
    public int Rating { get => Get<int>(); set => Set(value); }
    public string[] Tags { get => Get<string[]>(); set => Set(value); }
}
