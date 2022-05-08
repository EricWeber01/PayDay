using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace payday
{
    [Serializable]
    public class Pay
    {
        public int Money { get; set; }
        public int Days { get; set; }
        public int Fine { get; set; }
        public int FineDays { get; set; }

        public int PayWithoutFine { get; set; }
        public int GeneralFine { get; set; }
        public int GeneralPay { get; set; }
        public Pay() { }

        public Pay(int m, int d, int f, int fd)
        {
            Money = m;
            Days = d;
            Fine = f;
            FineDays = fd;

            PayWithoutFine = Money * Days;
            GeneralFine = Fine * FineDays;
            GeneralPay = PayWithoutFine + GeneralPay;


        }
        public override string ToString()
        {
            return $"Плата за день {Money}\n" +
                $"Кол-во дней {Days}\n" +
                $"Штраф {Fine}\n" +
                $"Кол-во дней {FineDays}\n" +
                $"Плата без штрафов {PayWithoutFine} \n" +
                $"Общая сумма штрафов {GeneralFine} \n" +
                $"Общая плата {GeneralPay} \n";
        }
    }
}
