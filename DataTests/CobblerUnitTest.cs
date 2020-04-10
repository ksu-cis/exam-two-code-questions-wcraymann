/*
 * Author: K-State CIS 400 Faculty and William Raymann.
 * Class: CobblerUnitTest.
 * Purpose: To test whether the Cobbler object is properly functioning and implementing the 
 *          IOrderItem and INotifyPropertyChanged interfaces.
 */
using System;
using ExamTwoCodeQuestions.Data;
using Xunit;
using System.ComponentModel;

namespace ExamTwoCodeQuestions.DataTests
{
    public class CobblerUnitTests
    {
        [Theory]
        [InlineData(FruitFilling.Cherry)]
        [InlineData(FruitFilling.Blueberry)]
        [InlineData(FruitFilling.Peach)]
        public void ShouldBeAbleToSetFruit(FruitFilling fruit)
        {
            var cobbler = new Cobbler();
            cobbler.Fruit = fruit;
            Assert.Equal(fruit, cobbler.Fruit);
        }

        [Fact]
        public void ShouldBeServedWithIceCreamByDefault()
        {
            var cobbler = new Cobbler();
            Assert.True(cobbler.WithIceCream);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToSetWithIceCream(bool serveWithIceCream)
        {
            var cobbler = new Cobbler();
            cobbler.WithIceCream = serveWithIceCream;
            Assert.Equal(serveWithIceCream, cobbler.WithIceCream);
        }

        [Theory]
        [InlineData(true, 5.32)]
        [InlineData(false, 4.25)]
        public void PriceShouldReflectIceCream(bool serveWithIceCream, double price)
        {
            var cobbler = new Cobbler()
            {
                WithIceCream = serveWithIceCream
            };
            Assert.Equal(price, cobbler.Price);
        }

        [Fact]
        public void DefaultSpecialInstructionsShouldBeEmpty()
        {
            var cobbler = new Cobbler();
            Assert.Empty(cobbler.SpecialInstructions);
        }

        [Fact]
        public void SpecialIstructionsShouldSpecifyHoldIceCream()
        {
            var cobbler = new Cobbler()
            {
                WithIceCream = false
            };
            Assert.Collection<string>(cobbler.SpecialInstructions, instruction =>
            {
                Assert.Equal("Hold Ice Cream", instruction);
            });
        }

        [Fact]
        public void ShouldImplementIOrderItemInterface()
        {
            var cobbler = new Cobbler();
            Assert.IsAssignableFrom<IOrderItem>(cobbler);
        }

        /// <summary>
        /// Tests whether the cobbler class implements the INotifyPropertyChanged interface.
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyPropetyChangedInterface()
        {
            var cobbler = new Cobbler();

            Assert.IsAssignableFrom<INotifyPropertyChanged>(cobbler);
        }

        /// <summary>
        /// Tests whether the Cobbler property "Fruit" invokes the PropertyChanged event
        /// handler for "Fruit" whenever it is changed to a "FruitFilling" value that is not
        /// the default "FruitFilling" value for the "Fruit" property.
        /// </summary>
        /// <param name="fruit"></param>
        [Theory]
        [InlineData(FruitFilling.Cherry)]
        [InlineData(FruitFilling.Blueberry)]
        public void ChangingFruitShouldInvokePropertyChangedForFruit( FruitFilling fruit)
        {
            var cobbler = new Cobbler();

            Assert.PropertyChanged(cobbler, "Fruit", () =>
            {
                cobbler.Fruit = fruit;
            });
        }

        /// <summary>
        /// Tests whether the Cobbler property "Fruit" invokes the PropertyChanged event
        /// handler for "FruitIsPeach" whenever it is changed to a "FruitFilling" value that 
        /// is not the default "FruitFilling" value for the "Fruit" property.
        /// </summary>
        /// <param name="fruit"></param>
        [Theory]
        [InlineData(FruitFilling.Cherry)]
        [InlineData(FruitFilling.Blueberry)]
        public void ChangingFruitShouldInvokePropertyChangedForFruitIsPeach(FruitFilling fruit)
        {
            var cobbler = new Cobbler();

            Assert.PropertyChanged(cobbler, "FruitIsPeach", () =>
            {
                cobbler.Fruit = fruit;
            });
        }

        /// <summary>
        /// Tests whether the Cobbler property "Fruit" invokes the PropertyChanged event
        /// handler for "FruitIsCherry" whenever it is changed to a "FruitFilling" value that 
        /// is not the default "FruitFilling" value for the "Fruit" property.
        /// </summary>
        /// <param name="fruit"></param>
        [Theory]
        [InlineData(FruitFilling.Peach)]
        [InlineData(FruitFilling.Blueberry)]
        public void ChangingFruitShouldInvokePropertyChangedForFruitIsCherry(FruitFilling fruit)
        {
            var cobbler = new Cobbler();
            cobbler.Fruit = FruitFilling.Cherry;

            Assert.PropertyChanged(cobbler, "FruitIsCherry", () =>
            {
                cobbler.Fruit = fruit;
            });
        }

        /// <summary>
        /// Tests whether the Cobbler property "Fruit" invokes the PropertyChanged event
        /// handler for "FruitIsBlueberry" whenever it is changed to a "FruitFilling" value that
        /// is not the default "FruitFilling" value for the "Fruit" property.
        /// </summary>
        /// <param name="fruit"></param>
        [Theory]
        [InlineData(FruitFilling.Peach)]
        [InlineData(FruitFilling.Cherry)]
        public void ChangingFruitShouldInvokePropertyChangedForFruitIsBlueberry(FruitFilling fruit)
        {
            var cobbler = new Cobbler();
            cobbler.Fruit = FruitFilling.Blueberry;

            Assert.PropertyChanged(cobbler, "FruitIsBlueberry", () =>
            {
                cobbler.Fruit = fruit;
            });
        }

        /// <summary>
        /// Tests whether the "WithIceCream" property for the "Cobbler" class invokes the 
        /// PropetyChanged event handler for the "WithIceCream" property when the "WithIceCream"
        /// property is changed.
        /// </summary>
        [Fact]
        public void ChangingWithIceCreamShouldInvokePropertyChangedForWithIceCream()
        {
            var cobbler = new Cobbler();

            Assert.PropertyChanged(cobbler, "WithIceCream", () =>
            {
                cobbler.WithIceCream = false;
            });
        }

        /// <summary>
        /// Tests whether the "WithIceCream" property for the "Cobbler" class invokes the 
        /// PropetyChanged event handler for the "Price" property when the "WithIceCream"
        /// property is changed.
        /// </summary>
        [Fact]
        public void ChangingWithIceCreamShouldInvokePropertyChangedForPrice()
        {
            var cobbler = new Cobbler();

            Assert.PropertyChanged(cobbler, "Price", () =>
            {
                cobbler.WithIceCream = false;
            });
        }

        /// <summary>
        /// Tests whether the "WithIceCream" property for the "Cobbler" class invokes the 
        /// PropetyChanged event handler for the "SpecialInstructions" property when the 
        /// "WithIceCream" property is changed.
        /// </summary>
        [Fact]
        public void ChangingWithIceCreamShouldInvokePropertyChangedForSpecialInstructions()
        {
            var cobbler = new Cobbler();

            Assert.PropertyChanged(cobbler, "SpecialInstructions", () =>
            {
                cobbler.WithIceCream = false;
            });
        }
    }
}
