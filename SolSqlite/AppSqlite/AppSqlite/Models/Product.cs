using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace AppSqlite.Models
{
    class Product
    {
        [PrimaryKey, AutoIncrement]
        public int VentaId { get; set; }
        [MaxLength(150)]
        public string Producto { get; set; }
        [NotNull]
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
    }
}
