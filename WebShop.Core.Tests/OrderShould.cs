using Moq;
using WebShop.Core.Entities;
using WebShop.Core.Repositories;
using WebShop.Core.Services;

namespace WebShop.Core.Tests
{
    [TestClass]
    public class OrderShould
    {

        [TestMethod]
        public void TestOrderInitialize()
        {
            var mock = new Mock<IOrderRepository>();
            Order order = new Order();
            mock.Setup(repo => repo.CreateOrder()).Returns(order);
            var stub = mock.Object;

            Assert.AreEqual(order, stub.CreateOrder());
            mock.Verify(repo => repo.CreateOrder(), Times.Once);
        }

        [TestMethod]
        public void TestGetOrderFromRepository()
        {
            var mock = new Mock<IOrderRepository>();
            Order order = new Order();
            mock.Setup(repo => repo.GetOrderWithId(It.IsInRange(0, int.MaxValue, Moq.Range.Inclusive))).Returns(order);
            var stub = mock.Object;

            Assert.AreEqual(order, stub.GetOrderWithId(1));
            mock.Verify(repo => repo.GetOrderWithId(1), Times.Once);

        }

        [TestMethod]
        public void TestGetOrderFromRepositoryProductIdOutOfRange()
        {
            var mock = new Mock<IOrderRepository>();
            mock.Setup(repo => repo.GetOrderWithId(It.IsInRange(int.MinValue, -1, Moq.Range.Inclusive))).Throws<ArgumentOutOfRangeException>();
            var stub = mock.Object;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => stub.GetOrderWithId(-1));
            mock.Verify(repo => repo.GetOrderWithId(-1), Times.Once);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => stub.GetOrderWithId(int.MinValue));
            mock.Verify(repo => repo.GetOrderWithId(int.MinValue), Times.Once);

        }

        [TestMethod]
        public void TestAddProductToOrderProductIdOutOfRange()
        {
            var mock = new Mock<IOrderService>();
            mock.Setup(repo => repo.AddProductToCurrentOrder(It.IsInRange(int.MinValue, -1, Moq.Range.Inclusive))).Throws<ArgumentOutOfRangeException>();
            var stub = mock.Object;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => stub.AddProductToCurrentOrder(-1));
            mock.Verify(service => service.AddProductToCurrentOrder(-1), Times.Once);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => stub.AddProductToCurrentOrder(int.MinValue));
            mock.Verify(service => service.AddProductToCurrentOrder(int.MinValue), Times.Once);

        }

        [TestMethod]
        public void TestAddProductToOrder()
        {
            var mock = new Mock<IOrderService>();
            mock.Setup(repo => repo.AddProductToCurrentOrder(It.IsInRange(0, int.MaxValue, Moq.Range.Inclusive)));
            var stub = mock.Object;

            stub.AddProductToCurrentOrder(1);
            mock.Verify(service => service.AddProductToCurrentOrder(1), Times.Once);

            stub.AddProductToCurrentOrder(int.MaxValue);
            mock.Verify(service => service.AddProductToCurrentOrder(int.MaxValue), Times.Once);

            mock.Verify(service => service.AddProductToCurrentOrder(34), Times.Never);

        }


        [TestMethod]
        public async Task TestRemoveProductFromOrder()
        {
            var mock = new Mock<IOrderService>();
            mock.Setup(repo => repo.RemoveProductFromCurrentOrder(It.IsInRange(0, int.MaxValue, Moq.Range.Inclusive), false)).ReturnsAsync(true);
            var stub = mock.Object;

            var result = await stub.RemoveProductFromCurrentOrder(1, false);
            Assert.IsTrue(result);

            result = await stub.RemoveProductFromCurrentOrder(int.MaxValue, false);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task TestRemoveProductFromOrderButNotExistsTheProductId()
        {
            var mock = new Mock<IOrderService>();
            mock.Setup(repo => repo.RemoveProductFromCurrentOrder(It.IsInRange(0, 10, Moq.Range.Inclusive), false)).ReturnsAsync(true); ;
            var stub = mock.Object;

            var result = await stub.RemoveProductFromCurrentOrder(11, false);
            Assert.IsFalse(result);

            result = await stub.RemoveProductFromCurrentOrder(14, false);
            Assert.IsFalse(result);

            result = await stub.RemoveProductFromCurrentOrder(int.MaxValue, false);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task TestRemoveProductToOrderRepositoryProductIdOutOfRange()
        {
            var mock = new Mock<IOrderService>();
            mock.Setup(repo => repo.RemoveProductFromCurrentOrder(It.IsInRange(int.MinValue, -1, Moq.Range.Inclusive), false)).Throws<ArgumentOutOfRangeException>();
            var stub = mock.Object;

            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () => await stub.RemoveProductFromCurrentOrder(-1));
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () => await stub.RemoveProductFromCurrentOrder(-1));
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () => await stub.RemoveProductFromCurrentOrder(-1));

        }

        [TestMethod]
        public void CreateAnOrder()
        {
            Order order = new Order();
            Assert.AreEqual(0, order.Products.Count);
            Assert.AreEqual(0, order.Total);
        }
    }
}