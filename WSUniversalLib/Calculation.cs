using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WSUniversalLib
{
    public class Calculation
    {
        public static double calc;
        public static double rez;
        public static int GetQuantityForProduct(int productType, int materialType, int count, float width, float length)
        {
           
            if (width < 0 || length < 0 || count < 0) //Проверка, что ширина, длина и количество продукции корректны
            {
                return -1;
            }
            else
            {
                switch (productType)
                {
                    case 1:
                        calc = width * length * count * 1.1;
                        switch (materialType)
                        {
                            case 1:
                                rez = (calc * 0.3) / 100;
                                break;
                            case 2:
                                rez = (calc * 0.12) / 100;
                                break;
                            default:
                                return -1;
                                break;
                        }
                        break;
                    case 2:
                        calc = width * length * count * 2.5;
                        switch (materialType)
                        {
                            case 1:
                                rez = (calc * 0.3) / 100;
                                break;
                            case 2:
                                rez = (calc * 0.12) / 100;
                                break;
                            default:
                                return -1;
                                break;
                        }
                        break;
                    case 3:
                        calc = width * length * count * 8.43;
                        switch (materialType)
                        {
                            case 1:
                                rez = (calc * 0.3)/100;
                                break;
                            case 2:
                                rez = (calc * 0.12)/100;
                                break;
                            default:
                                return -1;
                                break;
                        }
                        break;
                }
                return (int)Math.Round(rez); //округление результата
            }
            
        }
    }
}
