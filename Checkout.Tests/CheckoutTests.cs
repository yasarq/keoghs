using System;
using System.Collections.Generic;
using Checkout.Business;
using Checkout.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Checkout.Tests
{
    [TestClass]
    public class CheckoutTests
    {
        // for promotion rules
        private static List<IPricing> GetPromotionRules()
        {
            return new List<IPricing>()
            {
                new PricingProductTypeA(),
                new PricingProductTypeC(),
                new PricingProductTypeB(),
                new PricingProductTypeD()
            };
        }
        /*******************************************/
        /*********** testing product A *************/

        [TestMethod]
        public void Checkout_A_1A_Is10()
        {
            var bkt = new Basket(GetPromotionRules());
            var products = new List<PRODUCT>() { 'A' };

            var totalCheckout = bkt.Checkout(products);

            Assert.AreEqual(10, totalCheckout);
        }

        /*******************************************/
        /*********** testing product B *************/

        [TestMethod]
        public void Checkout_B_1B_Is15()
        {
            /* NO discount applied */
            var bkt = new Basket(GetPromotionRules());
            var products = new List<PRODUCT>() { 'A' };

            var totalCheckout = bkt.Checkout(products);

            Assert.AreEqual(10, totalCheckout);
        }


        [TestMethod]
        public void Checkout_B_2B_Is30()
        {
            /* NO discount applied */
            var bkt = new Basket(GetPromotionRules());
            var products = new List<PRODUCT>() { 'B', 'B' };

            var totalCheckout = bkt.Checkout(products);

            Assert.AreEqual(30, totalCheckout);
        }
        [TestMethod]
        public void Checkout_B_3B_Is40()
        {
            /* discount applied once */
            var bkt = new Basket(GetPromotionRules());
            var products = new List<PRODUCT>() { 'B', 'B', 'B' };

            var totalCheckout = bkt.Checkout(products);

            Assert.AreEqual(40, totalCheckout);
        }


        [TestMethod]
        public void Checkout_B_4B_Is55()
        {
            /* discount applied once and one normal price */
            var bkt = new Basket(GetPromotionRules());
            var products = new List<PRODUCT>() { 'B', 'B', 'B', 'B' };

            var totalCheckout = bkt.Checkout(products);

            Assert.AreEqual(55, totalCheckout);
        }

        [TestMethod]
        public void Checkout_B_6B_Is80()
        {
            /* discount applied twice */
            var bkt = new Basket(GetPromotionRules());
            var products = new List<PRODUCT>() { 'B', 'B', 'B', 'B', 'B', 'B' };

            var totalCheckout = bkt.Checkout(products);

            Assert.AreEqual(80, totalCheckout);
        }


        /*******************************************/
        /*********** testing product C *************/
        [TestMethod]
        public void Checkout_C_1C_Is40()
        {
            /* NO discount applied */
            var bkt = new Basket(GetPromotionRules());
            var products = new List<PRODUCT>() { 'C' };

            var totalCheckout = bkt.Checkout(products);

            Assert.AreEqual(40, totalCheckout);
        }

        [TestMethod]
        public void Checkout_C_2C_Is80()
        {
            /* NO discount applied */
            var bkt = new Basket(GetPromotionRules());
            var products = new List<PRODUCT>() { 'C', 'C' };

            var totalCheckout = bkt.Checkout(products);

            Assert.AreEqual(80, totalCheckout);
        }

        /*******************************************/
        /*********** testing product D *************/
        //Checkout_D_1D_Is55  ** NO discount 
        //Checkout_D_2D_Is82p50 ** discount of 25% for 2 items
        //Checkout_D_3D_Is137p50 ** discount of 25% for 2 items + 1 full price
        //Checkout_D_4D_Is165 ** 2 x discount of 25% for 2 items  
        //Checkout_D_5D_Is220 ** 2 x discount of 25% for 2 items + 1 full price

        [TestMethod]
        public void Checkout_D_1D_Is55()
        {
            /* NO discount applied */
            var bkt = new Basket(GetPromotionRules());
            var products = new List<PRODUCT>() { 'D' };

            var totalCheckout = bkt.Checkout(products);

            Assert.AreEqual(55, totalCheckout);
        }

        [TestMethod]
        public void Checkout_D_2D_Is82p50()
        {
            /* discount of 25 % for 2 items */

            var bkt = new Basket(GetPromotionRules());
            var products = new List<PRODUCT>() { 'D', 'D' };

            var totalCheckout = bkt.Checkout(products);

            Assert.AreEqual(82.50, (double)totalCheckout);
        }

        [TestMethod]
        public void Checkout_D_3D_Is137p50()
        {
            /* discount of 25% for 2 items + 1 full price */
            var bkt = new Basket(GetPromotionRules());
            var products = new List<PRODUCT>() { 'D', 'D', 'D' };

            var totalCheckout = bkt.Checkout(products);

            Assert.AreEqual(137.50, (double)totalCheckout);
        }

        [TestMethod]
        public void Checkout_D_4D_Is165()
        {
            /* 2 x discount of 25% for 2 items   */
            var bkt = new Basket(GetPromotionRules());
            var products = new List<PRODUCT>() { 'D', 'D', 'D', 'D' };

            var totalCheckout = bkt.Checkout(products);

            Assert.AreEqual(165, totalCheckout);
        }

        //Checkout_D_5D_Is220 ** 
        [TestMethod]
        public void Checkout_D_5D_Is220()
        {
            /* 2 x discount of 25% for 2 items + 1 full price  */
            var bkt = new Basket(GetPromotionRules());
            var products = new List<PRODUCT>() { 'D', 'D', 'D', 'D', 'D' };

            var totalCheckout = bkt.Checkout(products);

            Assert.AreEqual(220, totalCheckout);
        }

        /*******************************************/
        /*********** testing products MIX discounts B AND D *************/

        [TestMethod]
        public void Checkout_BD_3B2D_Is122p50()
        {
            /* 1 x discount for 3 B items = 3 for 40*/
            /* 1 x discount of 25% for 2 D items = (55 x 2) + 25% off = 82.50  */

            var bkt = new Basket(GetPromotionRules());
            var products = new List<PRODUCT>() { 'B', 'B', 'B', 'D', 'D' };

            var totalCheckout = bkt.Checkout(products);

            Assert.AreEqual(122.50, (double)totalCheckout);
        }



        [TestMethod]
        public void Checkout_ABCD_1A3B2C5D_Is350()
        {
            /* 1xA = 1 x 10 = 10
             * 3xB = 3 x 15 = 45 >> offer 3 for 40 = 40 
             * 2xC = 2 x 40 = 80
             * 5xD = 5 x 55 = 275 >> 2 x discount applied + 1 full price = 82.5 + 82.5 + 55 = 165+55=220
             * >> total 350
             **/

            var bkt = new Basket(GetPromotionRules());
            var products = new List<PRODUCT>() { 'A', 'B', 'B', 'B', 'C', 'C', 'D', 'D', 'D', 'D', 'D' };

            var totalCheckout = bkt.Checkout(products);

            Assert.AreEqual(350, (double)totalCheckout);
        }


    }
}
