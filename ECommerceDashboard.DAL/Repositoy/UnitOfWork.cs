using ECommerceDashboard.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDashboard.DAL.Repositoy
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; set; }
        public ICollectionRepository CollectionRepository { get; set; }
        public IDeliveryRepository DeliveryRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IReviewRepository ReviewRepository { get; set; }

        public UnitOfWork(
                    ICategoryRepository categoryRepository,
                    ICollectionRepository collectionRepository,
                    IDeliveryRepository deliveryRepository,
                    IOrderRepository orderRepository,
                    IProductRepository productRepository,
                    IReviewRepository reviewRepository)
        {
            CategoryRepository = categoryRepository;
            CollectionRepository = collectionRepository;
            DeliveryRepository = deliveryRepository;
            OrderRepository = orderRepository;
            ProductRepository = productRepository;
            ReviewRepository = reviewRepository;
        }

    }
}
