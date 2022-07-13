using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderTrackingManager : IOrderTrackingManager
    {
        private readonly IOrderTrackingDal _trackingDal;

        public OrderTrackingManager(IOrderTrackingDal trackingDal)
        {
            _trackingDal = trackingDal;
        }

        public void Add(OrderTracking orderTracking)
        {
            throw new NotImplementedException();
        }

        public List<OrderTracking> GetAll()
        {
            return _trackingDal.GetAll();
        }

        public OrderTracking GetOrderTrackingById(int id)
        {
            return _trackingDal.Get(x=>x.Id == id);
        }

        public void Remove(OrderTracking orderTracking)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderTracking orderTracking)
        {
            throw new NotImplementedException();
        }
    }
}
