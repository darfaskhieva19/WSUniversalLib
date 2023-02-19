using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WSUniversalLib;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetQuantityForProduct_NonExistentProductType() //длина - дробное число
        {
            float length = (float)20.5;
            int width = 10, count = 5, productType = 2, materialType = 2;
            double execept = 381;
            double actual = Calculation.GetQuantityForProduct((int)length, width, count, productType, materialType);
            Assert.AreEqual(execept, actual);
        }
        [TestMethod]
        public void PositivTest() //проверка на то, что результат - положительное число
        {
            int productType = 1;
            int materialType = 2;
            int count = 5;
            float width = 15;
            float length = 20;
            double actual = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            Assert.IsTrue(actual >= 0);
        }
        [TestMethod]
        public void GetQuantityForProduct_Correctly() //подсчет на правильность
        {
            int productType = 3;
            int materialType = 1;
            int count = 10;
            float width = 30;
            float length = 45;
            int except = 341;
            int actual = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            Assert.AreEqual(except, actual);    
        }
        [TestMethod]
        public void GetQuantityForProduct_NoCorrectly() //подсчет на неправильность
        {
            int productType = 2;
            int materialType = 2;
            int count = 10;
            float width = 20;
            float length = 15;
            int except = 10; //неверный ответ
            int actual = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            Assert.AreNotEqual(except, actual);
        }
        [TestMethod]
        public void GetQuantityForProduct_NoExistenProductType() //проверка метода, если указан несуществующий тип продукции
        {
            int productType = 4, materialType = 1, count = 5;
            float width = 10, length = 10;
            int expected = -1;
            int actual = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            Assert.IsFalse(expected != actual);
        }
        [TestMethod]
        public void GetQuantityForProduct_NoExistenMaterialType() //проверка метода, если указан несуществующий тип материала
        {
            int materialType = 5, productType = 1, count = 15;
            float width = 15, length = 15;
            int expect = -1;
            int actual = Calculation.GetQuantityForProduct(materialType, productType, count, width, length);
            Assert.IsFalse(expect != actual);
        }
        [TestMethod]
        public void GetQuantityForProduct_ResultIntType() // Возвращаемый тип данных - int
        {
            int productType = 5, materialType = 1, count = 10;
            float width = 10, length = 5;
            Assert.IsInstanceOfType(Calculation.GetQuantityForProduct(productType, materialType, count, width, length), typeof(int));
        }
        [TestMethod]
        public void GetQuantityForProduct_ResultDoubleType() // Возвращаемый тип данных - double
        {
            int productType = 5, materialType = 1, count = 10;
            float width = 10, length = 5;
            Assert.IsNotInstanceOfType(Calculation.GetQuantityForProduct(productType, materialType, count, width, length), typeof(double));
        }
        [TestMethod]
        public void GetQuantityForProduct_ResultFloatType() // Возвращаемый тип данных - float
        {
            int productType = 5, materialType = 1, count = 10;
            float width = 10, length = 5;
            Assert.IsNotInstanceOfType(Calculation.GetQuantityForProduct(productType, materialType, count, width, length), typeof(float));
        }
        [TestMethod]
        public void GetQuantityForProduct_NoNull() // Возвращаемое значение != null
        {
            int productType = 5, materialType = 1, count = 10;
            float width = 0, length = 0;
            int actual = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            Assert.IsNotNull(actual);
        }
        [TestMethod]
        public void GetQuantityForProduct_OtrNumber() //проверка на отрицательное число
        {
            int productType = 1, materialType = 2, count = -35;
            float width = 25, length = 30;
            int expected = -1;
            int actual = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetQuantityForProduct_VeryCount() //проверка на большое количество деталей
        {
            int productType = 3, materialType = 2, count = 2000500;
            float width = 10, length = 15;
            int expected = 3035559;
            int actual = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetQuantityForProduct_NoToChar() //проверка, что метод не возвращает тип данных char
        {
            int productType = 1, materialType = 1, count = 35;
            float width = 55, length = 60;
            int actual = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            Assert.IsNotInstanceOfType(actual, typeof(char));
        }
        [TestMethod]
        public void GetQuantityForProduct_NumberFloat() //ширина и длина - дробные
        {
            int productType = 3, materialType = 2, count = 35;
            float width = (float)15.5, length = (float)0.5;
            double expected = 3;
            double actual = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetQuantityForProduct_PredToInt() //проверка, что результат не выходит за пределы int
        {
            int productType = 2, materialType = 2, count = 999999999;
            float width = 9999999999999999999, length = 9999999999999999999;
            int actual = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            Assert.IsFalse(actual > -2147483648 && actual < 2147483647);
        }
    }
}
