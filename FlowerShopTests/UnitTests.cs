using NUnit.Framework;
using NSubstitute;
using FlowerShop;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //ARRANGE==========================
            IClient c = Substitute.For<IClient>();
            IOrderDAO y = Substitute.For<IOrderDAO>();
            List<Flower> f = new List<Flower>();
            IOrder o = new Order(y,c,false);
            //ACT==============================
            o.Deliver();
            //ASSERT===========================
            y.Received().SetDelivered(Arg.Any<IOrder>());
        }

        [Test]
        public void Test2()
        {
            //ARRANGE==========================
            IClient c = Substitute.For<IClient>();
            IOrderDAO y = Substitute.For<IOrderDAO>();
            IFlower f = Substitute.For<IFlower>(); 
            IOrder o = new Order(y,c,false);
            //ACT==============================
            o.AddFlowers(f, 3);
            double orderPrice = o.Price;
            //ASSERT===========================
            // Adding 3 flowers with 20% markup each (The way Price should work)
            Assert.AreEqual(orderPrice, 3*1.2*f.Cost); 
        }
    }
}