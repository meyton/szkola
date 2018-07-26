using System;
using SQLite;

namespace App1.Model
{
    public class Category : ISqliteModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}