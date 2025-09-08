using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppRequests.Models
{
    public class MyDatabase
    {
        // Класс для работы с базой данных:
        private SQLiteConnection database;

        public MyDatabase(string dbPath)
        {
            database = new SQLiteConnection(dbPath);
            database.CreateTable<MyData>();
        }

        public List<MyData> GetAllData()
        {
            return database.Table<MyData>().ToList();
        }

        public void AddData(string name, string phone, string memory, string platform, string text)
        {
            var newData = new MyData
            {
                Name = name,
                Phone = phone,
                Memory = memory,
                Platform = platform,
                Text = text
            };
            database.Insert(newData);
        }

        public void DeleteData(int id)
        {
            database.Delete<MyData>(id);
        }
    }
}