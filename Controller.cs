using System.Collections.ObjectModel;

namespace RatingDatabase;
public class Controller : Model {
    public ObservableCollection<Item> Items { get; } = new();
    public Controller() {
        foreach(Item item in Database.GetItems()) {
            Items.Add(item);
        }
    }
}
