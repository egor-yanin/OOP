using System;
using DeliverySystem.OrderBuilder;
using Moq;
using Xunit;

namespace DeliverySystem.OrderBuilder.Tests
{
    public class DefaultOrderBuilderTest
    {
        [Fact]
        public void SetCustomer_ShouldSetCustomer()
        {
            var builder = new DefaultOrderBuilder();
            var user = new User();
            builder.SetCustomer(user);
            var order = builder.Build();
            Assert.Equal(user, order.Customer);
        }

        [Fact]
        public void SetAddress_ShouldSetAddress()
        {
            var builder = new DefaultOrderBuilder();
            var address = "123 Main St";
            builder.SetAddress(address);
            var order = builder.Build();
            Assert.Equal(address, order.Address);
        }

        [Fact]
        public void SetDeliveryDate_ValidDate_ShouldSetDate()
        {
            var builder = new DefaultOrderBuilder();
            var date = DateTime.Now.AddDays(1);
            builder.SetDeliveryDate(date);
            var order = builder.Build();
            Assert.Equal(date, order.DeliveryDate);
        }

        [Fact]
        public void SetDeliveryDate_InvalidDate_ShouldThrow()
        {
            var builder = new DefaultOrderBuilder();
            var date = DateTime.Now.AddDays(-1);
            Assert.Throws<InvalidOperationException>(() => builder.SetDeliveryDate(date));
        }

        [Fact]
        public void SetDiscount_ShouldSetDiscount()
        {
            var builder = new DefaultOrderBuilder();
            var discountMock = new Mock<IDiscount>();
            builder.SetDiscount(discountMock.Object);
            var order = builder.Build();
            Assert.Equal(discountMock.Object, order.Discount);
        }

        [Fact]
        public void AddDish_InvalidDish_ShouldThrow()
        {
            var builder = new DefaultOrderBuilder();
            // Assuming ValidateDishes throws if no customer is set
            var dishMock = new Mock<IDish>();
            Assert.Throws<InvalidOperationException>(() => builder.AddDish(dishMock.Object, 1));
        }

        [Fact]
        public void Build_InvalidOrder_ShouldThrow()
        {
            var builder = new DefaultOrderBuilder();
            // Not setting required fields
            Assert.Throws<InvalidOperationException>(() => builder.Build());
        }

        [Fact]
        public void Build_ShouldSetOrderCode()
        {
            var builder = new DefaultOrderBuilder();
            var user = new User();
            var dishMock = new Mock<IDish>();
            builder.SetCustomer(user)
                   .SetAddress("Test Address")
                   .SetDeliveryDate(DateTime.Now.AddDays(1))
                   .AddDish(dishMock.Object, 1);
            var order = builder.Build();
            Assert.False(string.IsNullOrEmpty(order.Code));
            Assert.Equal(8, order.Code.Length);
        }
    }
}