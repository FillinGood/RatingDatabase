using System.Collections.Generic;
using System.Data.SQLite;

namespace RatingDatabase;
public static class Database {
    private const string DATABASE_FILE = "DB.sqlite3";
    private static SQLiteConnection Connection { get; }

    static Database() {
        Connection = new($"Data Source={DATABASE_FILE}; Version=3;");
        Connection.Open();
    }

    public static void AddItem(Item item) {
        const string sql = @"
            INSERT INTO items (name, rating)
            VALUES (?, ?)";
        int id = Execute(sql, item.Name, item.Rating);
        item.ID = id;
    }

    public static IEnumerable<Item> GetItems() {
        const string sql = @"
            SELECT
                i.id, i.name, i.rating,
	            group_concat(t.tag, ',') AS 'tags'
            FROM items i
            LEFT JOIN tags t ON
                t.item = i.id
            GROUP BY i.id";
        foreach (SQLiteDataReader r in Query(sql)) {
            yield return new Item() {
                ID = r.GetInt32(0),
                Name = r.GetString(1),
                Rating = r.GetInt32(2),
                //  Tags = reader.GetString(3)?.Split(',')??System.Array.Empty<string>()
            };
        }
    }

    private static int Execute(string sql, params object[] pars) {
        SQLiteCommand command = new(sql, Connection);
        foreach (object par in pars) {
            command.Parameters.AddWithValue("", par);
        }
        command.ExecuteNonQuery();
        return (int)Connection.LastInsertRowId;
    }

    private static IEnumerable<SQLiteDataReader> Query(string sql, params object[] pars) {
        SQLiteCommand command = new(sql, Connection);
        foreach(object par in pars) {
            command.Parameters.AddWithValue("", par);
        }
        SQLiteDataReader reader = command.ExecuteReader();
        while(reader.Read()) {
            yield return reader;
        }
        reader.Close();
    }
}
