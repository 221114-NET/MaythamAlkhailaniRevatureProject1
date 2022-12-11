using ApiUi.Business;
using ApiUi.Models.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace API.Tests
{
    public class AdminTests
    {

        [Fact]
        public async Task Add_ShouldWork()
        {
            var optionsBuilder = new DbContextOptionsBuilder<P1dbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var context = new P1dbContext(optionsBuilder.Options);

            var repository = new AdminBL(context);
            var admin = new Admin()
            {
                Name = "admin",
                Email = "admin@gmail.com",
                Password = "1234",
            };
            await repository.Add(admin);
            Assert.Single(context.Admins);
        }

        [Fact]
        public async Task Verify_ShouldWork()
        {
            var optionsBuilder = new DbContextOptionsBuilder<P1dbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var context = new P1dbContext(optionsBuilder.Options);

            var repository = new AdminBL(context);
            var admin = new Admin()
            {
                Name = "admin",
                Email = "admin@gmail.com",
                Password = "1234",
            };
            await repository.Add(admin);
            Assert.Single(context.Admins);
            bool result = await repository.Verify("admin@gmail.com", "1234");
            Assert.True(result);
        }

        [Fact]
        public async Task Verify_ShouldNotWork()
        {
            var optionsBuilder = new DbContextOptionsBuilder<P1dbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var context = new P1dbContext(optionsBuilder.Options);

            var repository = new AdminBL(context);
            var admin = new Admin()
            {
                Name = "admin",
                Email = "admin@gmail.com",
                Password = "1234",
            };
            await repository.Add(admin);
            Assert.Single(context.Admins);
            bool result = await repository.Verify("admin@gmail.com", "123");
            Assert.False(result);
        }
    }
}
