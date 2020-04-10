/*
 * Authors: K-State CIS 400 Faculty and William Raymann.
 * Class: Cobbler.
 * Purpose: To provide an object for a Cobbler.
 */ 
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExamTwoCodeQuestions.Data
{
    public class Cobbler : IOrderItem, INotifyPropertyChanged
    {
        /// <summary>
        /// Event handler for changes in properties in the current class
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// True if the Fruit property is FruitFilling.Peach.
        /// Changes to Fruit to FruitFilling.Peach if the property is set.
        /// </summary>
        public bool FruitIsPeach
        {
            get { return fruit == FruitFilling.Peach; }
            set
            {
                Fruit = FruitFilling.Peach;
            }
        }

        /// <summary>
        /// True if the Fruit property is FruitFilling.Cherry.
        /// Changes to Fruit to FruitFilling.Cherry if the property is set.
        /// </summary>
        public bool FruitIsCherry
        {
            get { return fruit == FruitFilling.Cherry; }
            set
            {
                Fruit = FruitFilling.Cherry;
            }
        }

        /// <summary>
        /// True if the Fruit property is FruitFilling.Blueberry.
        /// Changes to Fruit to FruitFilling.Blueberry if the property is set.
        /// </summary>
        public bool FruitIsBlueberry
        {
            get { return fruit == FruitFilling.Blueberry; }
            set
            {
                Fruit = FruitFilling.Blueberry;
            }
        }

        private FruitFilling fruit = FruitFilling.Peach;
        /// <summary>
        /// The fruit used in the cobbler
        /// </summary>
        public FruitFilling Fruit
        { 
            get { return fruit; } 
            set
            {
                if (fruit == value) return;
                fruit = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Fruit"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FruitIsPeach"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FruitIsCherry"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FruitIsBlueberry"));
            }
        }

        private bool withIceCream = true;
        /// <summary>
        /// If the cobbler is served with ice cream
        /// </summary>
        public bool WithIceCream 
        { 
            get { return withIceCream; } 
            set
            {
                if (withIceCream == value) return;
                withIceCream = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WithIceCream"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
            }
        }

        /// <summary>
        /// Gets the price of the Cobbler
        /// </summary>
        public double Price
        {
            get
            {
                if (WithIceCream) return 5.32;
                else return 4.25;
            }
        }

        /// <summary>
        /// Gets any special instructions for preparing this dessert
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                if(WithIceCream) { return new List<string>(); }
                else { return new List<string>() { "Hold Ice Cream" }; }
            }
        }
    }
}
