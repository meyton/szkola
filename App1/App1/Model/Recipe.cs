using System;
using SQLite;

namespace App1.Model
{
    public class Recipe : ISqliteModel
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public DateTime DateCreated { get; set; }
        public int CategoryId { get; set; }
    }
}