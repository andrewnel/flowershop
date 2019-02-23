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
    }
}