using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProgram
{
    internal class Order
    {
        private string addresss;
        private string num;
        private int time = -1;
        private char company = 'n';
        private int state = -1;

        public Order(string addresss, string num)
        {
            this.addresss = addresss;
            this.num = num;
        }

        public string getAdrress()
        {
            return this.addresss;
        }

        public string getNum() { 
            return this.num; 
        }

        public string toString()
        {
            return $"주소: {addresss}, 전화번호: {num}, 배달 예정 시간: {time}, 업체: {company}";
        }
    }
}
