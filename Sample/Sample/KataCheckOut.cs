using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    [TestFixture]
    public class TestSample
    {
        [Test]
        public void VerifyQtyIsOneItemSkuISAPriceShouldBeFifty()
        {
            //Arrange
            var expectedPrice = 50M;
            var itemName = 'A';
            var calculator = new PriceCalculator();
            //Act
            calculator.Scan(itemName);

            //Assert
            Assert.AreEqual(expectedPrice,calculator.Total);
        }

        [Test]
        public void VerifyQtyIsOneItemSkuIsBPriceShouldBeThirty()
        {
            //Arrange
            var expectedPrice = 30M;
            var skuName = 'B';
            var calcu = new PriceCalculator();

            //Act
            calcu.Scan(skuName);

            //Assert
            Assert.AreEqual(expectedPrice,calcu.Total);

        }

        [Test]
        public void VerifyQtyIsOneItemSkuIsCPriceShouldBeTwenty()
        {
            //Arrange
            var expectedPrice = 20M;
            var skuName = 'C';
            var calcu = new PriceCalculator();

            //Act
            calcu.Scan(skuName);

            //Assert
            Assert.AreEqual(expectedPrice, calcu.Total);

        }

        [Test]
        public void VerifyQtyIsOneItemSkuIsDPriceShouldBeFifteen()
        {
            //Arrange
            var expectedPrice = 15M;
            var skuName = 'D';
            var calcu = new PriceCalculator();

            //Act
            calcu.Scan(skuName);

            //Assert
            Assert.AreEqual(expectedPrice, calcu.Total);

        }

        [Test]
        public void ScanAandBitemsAndVerifyPrice()
        {
            //Arrange
            var expectedTotalPrice = 80M;
            var skuItem1 = 'A';
            var skuItem2 = 'B';
            var priceCalcu = new PriceCalculator();

            //Act
            priceCalcu.Scan(skuItem1);
            priceCalcu.Scan(skuItem2);

            //Assert
            Assert.AreEqual(expectedTotalPrice,priceCalcu.Total,"Expected total price to be the same as actual total price combined for item A and B");
        }

        [Test]
        public void ScanABCitemsAndVerifyTotalPrice()
        {
            //Arrange
            var expectedTotalPrice = 100M;
            var skuItemA = 'A';
            var skuItemB = 'B';
            var skuItemC = 'C';
            var priceCalcu = new PriceCalculator();

            //Act
            priceCalcu.Scan(skuItemA);
            priceCalcu.Scan(skuItemB);
            priceCalcu.Scan(skuItemC);

            //Assert
            Assert.AreEqual(expectedTotalPrice, priceCalcu.Total, "Expected total price to be the same as actual total price combined for item A,B and C");
        }


        [Test]
        public void ScanABCandDitemsAndVerifyTotalPrice()
        {
            //Arrange
            var expectedTotalPrice = 115M;
            var skuItemA = 'A';
            var skuItemB = 'B';
            var skuItemC = 'C';
            var skuItemD = 'D';
            var priceCalcu = new PriceCalculator();

            //Act
            priceCalcu.Scan(skuItemA);
            priceCalcu.Scan(skuItemB);
            priceCalcu.Scan(skuItemC);
            priceCalcu.Scan(skuItemD);

            //Assert
            Assert.AreEqual(expectedTotalPrice, priceCalcu.Total, "Expected total price to be the same as actual total price combined for item A,B,C and D");
        }

        [Test]
        public void ScanThreeItemsOfAAndVerifySpecifyTotalPrice()
        {
            //Arrange
            var expectedTotalPrice = 130M;
            var skuItemA = 'A';

            var priceCalc = new PriceCalculator();

            //Act
            priceCalc.Scan(skuItemA);
            priceCalc.Scan(skuItemA);
            priceCalc.Scan(skuItemA);

            //Assert
            Assert.AreEqual(expectedTotalPrice,priceCalc.Total,"Expected total price to be the same as actual price, the special price for item A did not match expected total price");
        }

        [Test]
        public void ScanSixItemsOfBAndVerifySpecifyTotalPrice()
        {
            //Arrange
            var expectedTotalPrice = 135M;
            var skuItem = 'B';

            var priceCalc = new PriceCalculator();

            //Act
            priceCalc.Scan(skuItem);
            priceCalc.Scan(skuItem);
            priceCalc.Scan(skuItem);
            priceCalc.Scan(skuItem);
            priceCalc.Scan(skuItem);
            priceCalc.Scan(skuItem);

            //Assert
            Assert.AreEqual(expectedTotalPrice, priceCalc.Total, "Expected total price to be the same as actual price, the special price for item B did not match expected total price");
        }

        [Test]
        public void ScanMultipleItemsAndVerifyTotalPrice()
        {
            //Arrange
            var expectedTotalPrice = 230M;
            var priceCalc = new PriceCalculator();

            //Act
            priceCalc.Scan('A');
            priceCalc.Scan('A');
            priceCalc.Scan('A');
            priceCalc.Scan('B');
            priceCalc.Scan('B');
            priceCalc.Scan('C');
            priceCalc.Scan('D');
            priceCalc.Scan('C');

            //Assert
            Assert.AreEqual(expectedTotalPrice, priceCalc.Total, "Expected total price to be the same as actual price for multiple items");
        }

    }


    public class Item
    {
        public int NumberOfItems { get; set; }
        public int DiscountedRule { get; set; }
        public int DiscountedValue { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }

    public class NormalRule
    {
        private List<Item> _listOfItems;
        public NormalRule(List<Item> items)
        {
            _listOfItems = items;
        }


        public int CalculatePrice()
        {
            var totalPrice = 0;
            foreach (var listOfItem in _listOfItems)
            {
                totalPrice = listOfItem.NumberOfItems * listOfItem.Price;
                totalPrice -= listOfItem.NumberOfItems / listOfItem.DiscountedRule * listOfItem.DiscountedValue;
            }

            return totalPrice;
        }
    }
    

    public class PriceCalculator
    {
        private Dictionary<char, int> _skuItems;

        public PriceCalculator()
        {
            _skuItems = new Dictionary<char, int> {{'A', 0}, {'B', 0}, {'C', 0}, {'D', 0}};
        }

        public decimal Total => calculateTotal();

        private decimal calculateTotal()
        {
            var total = 0M;
            foreach (var skuItem in _skuItems)
            {
                if (skuItem.Key == 'A')
                {
                    if (skuItem.Value % 3 == 0)
                    {
                        var result = skuItem.Value / 3;
                        total += result * 130M;
                    }
                    else
                    {
                        total += skuItem.Value * 50M;
                    }
                }
                if (skuItem.Key == 'B')
                {
                    if (skuItem.Value % 2 == 0)
                    {
                        var result = skuItem.Value / 2;
                        total += result * 45M;
                    }
                    else
                    {
                        total += skuItem.Value * 30M;
                    }
                }
                if (skuItem.Key == 'C')
                {
                    total += skuItem.Value * 20M;
                }
                if (skuItem.Key == 'D')
                {
                    total += skuItem.Value * 15M;
                }
            }

            return total;
        }

        public void Scan(char skuItem)
        {
            var item = _skuItems[skuItem];
            item += 1;
            _skuItems[skuItem] = item;
        }
    }

    public interface IPriceRule
    {
        bool IsMatch(char sku);
        decimal GetPrice(int qty);
    }

    public class SkuA : IPriceRule
    {
        public bool IsMatch(char sku)
        {
            return sku == 'A';
        }

        public decimal GetPrice(int qty)
        {
            return qty * 50M;
        }
    }

    public class SkuB : IPriceRule
    {
        public bool IsMatch(char sku)
        {
            return sku == 'B';
        }

        public decimal GetPrice(int qty)
        {
            return qty * 30M;
        }
    }

    public class SkuC : IPriceRule
    {
        public bool IsMatch(char sku)
        {
            return sku == 'C';
        }

        public decimal GetPrice(int qty)
        {
            return qty * 20M;
        }
    }

    public class SkuD : IPriceRule
    {
        public bool IsMatch(char sku)
        {
            return sku == 'D';
        }

        public decimal GetPrice(int qty)
        {
            return qty * 15M;
        }
    }
}
