using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_NguyenLieu
    {
        private int id_Ingredient;
        private string name;
        private int id_Supplier;
        private int id_Type;
        private float price;
        public DTO_NguyenLieu()
        {

        }
        public DTO_NguyenLieu(string name)
        {
            this.name = name;
        }
        public DTO_NguyenLieu(string name, int id_Supplier, int id_Type, float price)
        {
            this.name = name;
            this.id_Supplier = id_Type;
            this.id_Type = id_Type;
            this.price = price;
        }
        public DTO_NguyenLieu(string name, int id_Supplier, int id_Type, float price, int id_Ingredient)
        {
            this.name = name;
            this.id_Supplier = id_Type;
            this.id_Type = id_Type;
            this.price = price;
            this.id_Ingredient = id_Ingredient;
        }
        public int Id_Ingredient { get => id_Ingredient; set => id_Ingredient = value; }
        public string Name { get => name; set => name = value; }
        public int Id_Supplier { get => id_Supplier; set => id_Supplier = value; }
        public int Id_Type { get => id_Type; set => id_Type = value; }
        public float Price { get => price; set => price = value; }
    }
}
