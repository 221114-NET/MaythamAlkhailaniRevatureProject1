using ApiUi.Business;
using ApiUi.Models;
using ApiUi.Models.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace API.Tests
{
    public class UserTests
    {

        [Fact]
        public async Task Add_ShouldWork()
        {
            var optionsBuilder = new DbContextOptionsBuilder<P1dbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var context = new P1dbContext(optionsBuilder.Options);

            var repository = new UserBL(context);
            var user = new User()
            {
                Name = "user",
                Email = "user@gmail.com",
                Password = "1234",
            };
            await repository.Add(user);
            Assert.Single(context.Users);
        }

        [Fact]
        public async Task Verify_ShouldWork()
        {
            var optionsBuilder = new DbContextOptionsBuilder<P1dbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var context = new P1dbContext(optionsBuilder.Options);

            var repository = new UserBL(context);
            var user = new User()
            {
                Name = "user",
                Email = "user@gmail.com",
                Password = "1234",
            };
            await repository.Add(user);
            Assert.Single(context.Users);
            bool result = await repository.Verify("user@gmail.com", "1234");
            Assert.True(result);
        }

        [Fact]
        public async Task Verify_ShouldNotWork()
        {
            var optionsBuilder = new DbContextOptionsBuilder<P1dbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var context = new P1dbContext(optionsBuilder.Options);

            var repository = new UserBL(context);
            var user = new User()
            {
                Name = "user",
                Email = "user@gmail.com",
                Password = "1234",
            };
            await repository.Add(user);
            Assert.Single(context.Users);
            bool result = await repository.Verify("user@gmail.com", "123");
            Assert.False(result);
        }
    }
}
