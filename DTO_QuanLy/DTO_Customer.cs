using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_Customer
    {
        private string name;
        private string email;
        private int id;
        private string gender;
        private int reward;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }
        public int Reward
        {
            get
            {
                return reward;
            }
            set
            {
                reward = value;
            }
        }
        public DTO_Customer(string name, string email, string gender, int reward, int id)
        {
            this.name = name;
            this.email = email;
            this.gender = gender;
            this.reward = reward;
            this.id = id;
        }

        public DTO_Customer(string email)
        {
            this.email = email;
        }
    }
}
