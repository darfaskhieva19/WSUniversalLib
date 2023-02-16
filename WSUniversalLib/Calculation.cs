using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSUniversalLib
{
    public class Calculation
    {
        public static int GetQuantityForProduct(int productType, int materialType, int count, float width, float length)
        {
            if (count < 0)
            {
                return -1;
            }
            double rez = width * length * count;
            if (rez < 0)
            {
                return -1;
            }
            switch (productType) //коэффициент типа продукции
            {
                case 1:
                    rez = rez * 1.1;
                    break;
                case 2:
                    rez = rez * 2.5;
                    break;
                case 3:
                    rez = rez * 8.43;
                    break;
                    default:
                    return -1;
            }
            switch (materialType) //учитывание % брака материала в зависимости от типа
            {
                case 1:
                    rez += (rez / 100) * 0.3;
                    break;
                case 2:
                    rez += (rez / 100) * 0.12;
                    break;
                default:
                    return -1;
            }
            return (int)Math.Round(rez); //округление результата
        }
    }
}
