using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;

namespace RatingDatabase;
public class Controller : Model {
    public ObservableCollection<Item> Items { get; } = new();

    public Command<Item> DeleteCommand { get; }

    private void Delete(Item item) {
        Items.Remove(item);
    }

    private void OnItemChanged(object? sender, PropertyChangedEventArgs e) {
        if(sender is not Item item)
            return;
        Debug.WriteLine($"{item} {e.PropertyName}");
    }

    public Controller() {
        DeleteCommand = new(Delete);
        foreach(Item item in Database.GetItems()) {
            Items.Add(item);
        }
        Items.CollectionChanged += Items_CollectionChanged;
    }

    private void Items_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e) {
        if (e.Action == NotifyCollectionChangedAction.Add) {
            if(e.NewItems is null)
                return;
            Item item = (Item)e.NewItems[0]!;
            Database.AddItem(item);
            item.PropertyChanged += OnItemChanged;
        }
    }
}
