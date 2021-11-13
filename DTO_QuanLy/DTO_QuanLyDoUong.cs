using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_QuanLyDoUong
    {
        private string name;
        private double price;
        private int id_Type;
        private int id_Beverage;
        private string image;

        public DTO_QuanLyDoUong()
        {
        }
        //search
        public DTO_QuanLyDoUong(string name)
        {
            this.name = name;
        }

        public DTO_QuanLyDoUong(int id_Beverage)
        {
            this.id_Beverage = id_Beverage;
        }

        //insert
        public DTO_QuanLyDoUong(string name, double price, int id_Type, string image)
        {
            this.name = name;
            this.price = price;
            this.id_Type = id_Type;
            this.image = image;
        }
        //update
        public DTO_QuanLyDoUong(string name, double price, int id_Type, int id_Beverage, string image)
        {
            this.name = name;
            this.price = price;
            this.id_Type = id_Type;
            this.id_Beverage = id_Beverage;
            this.image = image;
        }
        
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public int Id_Type { get => id_Type; set => id_Type = value; }
        public int Id_Beverage { get => id_Beverage; set => id_Beverage = value; }
        public string Image { get => image; set => image = value; }

       
    }
}
