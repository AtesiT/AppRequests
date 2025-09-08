using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppRequests.Models
{
    public class MyData
    {
        // Класс для хранения данных в таблице базы данных
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [NotNull, MaxLength(30)]
        public string Name { get; set; }

        [NotNull, MaxLength(10)]
        public string Phone { get; set; }

        [NotNull, MaxLength(50)]
        public string Memory { get; set; }

        [NotNull, MaxLength(200)]
        public string Platform { get; set; }

        public string Text { get; set; }
    }
}