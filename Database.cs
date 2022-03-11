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

    public static IEnumerable<Item> GetItems() {
        const string sql = @"
            SELECT
                i.id, i.name, i.rating,
	            group_concat(t.tag, ',') AS 'tags'
            FROM items i
            LEFT JOIN tags t ON
                t.item = i.id
            GROUP BY i.id";
        SQLiteCommand command = new SQLiteCommand(sql, Connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while(reader.Read()) {
            yield return new Item() {
                ID = reader.GetInt32(0),
                Name = reader.GetString(1),
                Rating = reader.GetInt32(2),
                Tags = reader.GetString(3).Split(',')
            };
        }
        reader.Close();
    }
}
