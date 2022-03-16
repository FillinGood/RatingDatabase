using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

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
        Database.UpdateItem(item);
    }

    private void Items_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e) {
        if(e.Action == NotifyCollectionChangedAction.Add) {
            if(e.NewItems is null)
                return;
            Item item = (Item)e.NewItems[0]!;
            Database.AddItem(item);
            item.PropertyChanged += OnItemChanged;
        } else if(e.Action == NotifyCollectionChangedAction.Remove) {
            if(e.OldItems is null)
                return;
            Item item = (Item)e.OldItems[0]!;
            Database.RemoveItem(item.ID);
            item.PropertyChanged -= OnItemChanged;
        }
    }

    public Controller() {
        DeleteCommand = new(Delete);
        foreach(Item item in Database.GetItems()) {
            Items.Add(item);
            item.PropertyChanged += OnItemChanged;
        }
        Items.CollectionChanged += Items_CollectionChanged;
    }
}
