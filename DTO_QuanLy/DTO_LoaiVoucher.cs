using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_LoaiVoucher
    {
        private int Id;
        private float sale;
        private int v;

        public int id
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
            }
        }
        public float Sale
        {
            get
            {
                return sale;
            }
            set
            {
                sale = value;
            }
        }
        public DTO_LoaiVoucher(int id, float Sale)
        {
            this.Id = id;
            this.sale = Sale;
        }
        public DTO_LoaiVoucher(float Sale)
        {
            this.sale = Sale;
        }
        public DTO_LoaiVoucher(int v)
        {
            this.v = v;
        }
    }
}
