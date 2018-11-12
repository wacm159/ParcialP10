using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using static System.Console;

namespace ExamenParcial
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var queryforProduct = new Laptop();
            var computerShop = new Shop();
            var responsibleforCalculation = new CalculateComputerPrice();
            var myAnswer = computerShop.GetMyComputerPrice(responsibleforCalculation, queryforProduct);
            var myAnswer1 = computerShop.GetAvailableColor(queryforProduct);
            //Gift
            var queryforProduct1 = new GiftItem();
            var computerShop1 = new Shop();
            var myAnswer2 = computerShop1.IsThereAnyGiftItem(queryforProduct1);
            Console.WriteLine(myAnswer);
            Console.WriteLine(myAnswer1);
            Console.WriteLine(myAnswer2);
            Console.ReadKey();
        }

        public interface IComputerDescription
        {
            string GetDescription();
            string GetColor();
        }
        public interface IComputerPrice
        {
            double GetPrice();
        }
        public interface IPriceCalculation
        {
            double CalculatePriceAfterTax(IComputerPrice c);
        }

        public class Desktop : IComputerDescription, IComputerPrice
        {
            double desktopPrice = 130;
            public string GetDescription()
            {
                return " Obtienes una Desktop";
            }
            public string GetColor()
            {
                return " El color es Blanco";
            }
            public double GetPrice()
            {
                return desktopPrice;
            }
        }

        public class Laptop : IComputerDescription, IComputerPrice
        {
            double laptopPrice = 200;
            public string GetDescription()
            {
                return " Obtienes una Latop";
            }
            public string GetColor()
            {
                return "El color es Negro";
            }
            public double GetPrice()
            {
                return laptopPrice;
            }
        }

        public class Tablet : IComputerDescription, IComputerPrice
        {
            double tabletPrice = 500;
            public string GetDescription()
            {
                return " Obtienes una Tablet";
            }
            public string GetColor()
            {
                return " El color es Plateado";
            }
            public double GetPrice()
            {
                return tabletPrice;
            }
        }

        public class GiftItem : IComputerDescription
        {
            public string GetDescription()
            {
                return "Sí, obtienes un PenDrive como artículo de regalo.";
            }
            public string GetColor()
            {
                return "Elija cualquier color de rojo blanco y negro";
            }
        }

        // Nueva clase introducida para asumir la responsabilidad del precio de cálculo.
        public class CalculateComputerPrice : IPriceCalculation
        {
            public double CalculatePriceAfterTax(IComputerPrice c)
            {
                return c.GetPrice() + c.GetPrice() * .20;
            }
        }

        public class Shop
        {
            public string GetMyComputer(IComputerDescription cmptype)
            {
                // No importa cuántos tipos de computadora venga
                var myComp = cmptype.GetDescription();
                return myComp;
            }
            public string GetMyComputerPrice(IPriceCalculation cmpCal, IComputerPrice cmpPrice)
            {
                var myCompprice = "El Precio es : " +
                         cmpCal.CalculatePriceAfterTax(cmpPrice).ToString();
                return myCompprice;
            }
            public string GetAvailableColor(IComputerDescription cmptype)
            {
                var myCompcolor = cmptype.GetColor().ToString();
                return myCompcolor;
            }
            public string WhatIsThecolorofGiftItem(IComputerDescription cmptype)
            {
                return GetAvailableColor(cmptype);
            }
            public string IsThereAnyGiftItem(IComputerDescription gftType)
            {
                return GetMyComputer(gftType);
            }
        }
    }
}



