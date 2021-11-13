using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_LoaiNguyenLieu
    {
        private int id_Type;
        private string name;
        public DTO_LoaiNguyenLieu()
        {

        }
        public DTO_LoaiNguyenLieu(string name)
        {
            this.name = name;
        }
        public DTO_LoaiNguyenLieu(string name, int id_Type)
        {
            this.name = name;
            this.id_Type = id_Type;
        }
        public int Id_Type { get => id_Type; set => id_Type = value; }
        public string Name { get => name; set => name = value; }
    }
}
