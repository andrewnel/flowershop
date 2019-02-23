using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShop
{
    public class Order : IOrder, IIdentified
    {
        private List<IFlower> flowers;
        private bool isDelivered = false;
        private IOrderDAO dao;
        public int Id { get; }

        // should apply a 20% mark-up to each flower.
        public double Price {
            get {
                double fCost = 0;
                foreach(IFlower f in flowers)
                    fCost += 1.2*f.Cost;
                return fCost;
            }
        }

        public double Profit {
            get {
                return 0;
            }
        }

        public IReadOnlyList<IFlower> Ordered {
            get {
                return flowers.AsReadOnly();
            }
        }

        public IClient Client { get; private set; }

        public Order(IOrderDAO dao, IClient client)
        {
            Id = dao.AddOrder(client);
        }

        // used when we already have an order with an Id.
        public Order(IOrderDAO dao, IClient client, bool isDelivered = false)
        {
            this.flowers = new List<IFlower>();
            this.isDelivered = isDelivered;
            Client = client;
            Id = dao.AddOrder(client);
            this.dao = dao;
        }

        public void AddFlowers(IFlower flower, int n)
        {
            for(int i = 1; i <= n; i++)
                this.flowers.Add(flower);
        }

        public void Deliver()
        {
            dao.SetDelivered(this);
        }
    }
}
