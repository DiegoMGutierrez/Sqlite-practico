using AppSqlite.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace AppVentas.ViewModel
{
    class ProductViewModel
    {
        private SQLiteConnection conec;
        private static ProductViewModel instance;
        public static ProductViewModel Instance
        {
            get
            {
                if (instance == null) { throw new Exception("Falta inicializar"); }
                return instance;
            }
        }

        public static void Inicializador(String filename) //CAMBIAR NOMBRE DEL FILENAME PARA RECIBIR LA VISTA DE LA APP
        {
            if (filename == null) { throw new ArgumentException(); }
            if (instance != null) { instance.conec.Close(); }
            instance = new ProductViewModel(filename);
        }

        private ProductViewModel(String DbPath)
        {
            conec = new SQLiteConnection(DbPath);
            conec.CreateTable<Product>();
        }
        public String EstadoMensaje;

        public int AddNew(string producto, int cantidad, DateTime fecha)
        {
            int result = 0;

            try
            {
                result = conec.Insert(new Product()
                {
                    Producto = producto,
                    Cantidad = cantidad,
                    Fecha = fecha
                });
                EstadoMensaje = string.Format("Se ingresó corretamente"); //MENSAJE DE QUE SE INGRESO POR LA VISTA DE LA APP
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }

            return result;
        }

        public IEnumerable<Product> GetAll()
        {
            try
            {
                return conec.Table<Product>();
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Product>();
        }


    }
}
