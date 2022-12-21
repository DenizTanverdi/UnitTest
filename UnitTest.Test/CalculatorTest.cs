using Moq;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.APP;
using Xunit;

namespace UnitTest.Test
{
      public class CalculatorTest
    {
        public Calculator calculator { get; set; }
        public Mock<ICalculatorService> mymock { get; set; }
        public CalculatorTest()
        {
            mymock = new Mock<ICalculatorService>(); // Taklit eder.
            this.calculator = new Calculator(mymock.Object);
        }
        #region Fact 
        //[Fact] //Hem paramete almaması hemde test methodu olduğunu belirtiyoruz
        //public void AddTest()
        //{
        //    //Arrange : Değerlerimizi oluşturmak için yani hazırlık evresi

        //    int a = 5;
        //    int b = 20;

        //    //Act Test ettiğimiz methodun çalıştığı evre


        //    var total = calculator.Add(a, b);
        //    //Assert Test ettiğimiz yer

        //    Assert.Equal<int>(25, total);

        //}
        #endregion
        [Theory]
        [InlineData(2,5,7)]
        [InlineData(10, 5, 15)]
        public void Add_simpleValues_ReturnTotalValue(int a ,int b,int sum)
        {
             
            mymock.Setup(x => x.Add(a, b)).Returns(sum);
            var total=calculator.Add(a, b);
            Assert.Equal<int>(sum, total);
            //mymock.Verify(x => x.Add(a, b), Times.Once); // Bu method 1 kere çalışırsa başarılı 1 den fazla çalışırsa hata döner
           // mymock.Verify(x => x.Add(a, b), Times.Never); //Hiç çalışmazsa
            mymock.Verify(x => x.Add(a, b), Times.AtLeast(2)); // En az 2 kere çalışmasını istiyorum
        }
        [Theory]
        [InlineData(0, 5, 0)]
        [InlineData(10, 0, 0)]
        public void Add_zeroValues_ReturnZeroValue(int a, int b, int sum)
        {
            var total = calculator.Add(a, b);

            Assert.Equal<int>(sum, total);
        }
        [Theory]
        [InlineData(3, 5,15)]
        public void Multip_simpleValues_ReturnMultipleValue(int a, int b, int value)
        {
            mymock.Setup(x => x.Multip(a, b)).Returns(value);
            Assert.Equal(15, calculator.Multip(a, b));
        }
    }
}
