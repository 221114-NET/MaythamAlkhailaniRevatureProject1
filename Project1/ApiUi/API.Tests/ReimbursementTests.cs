using ApiUi.Business;
using ApiUi.Models;
using ApiUi.Models.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace API.Tests
{
    public class ReimbursementTests
    {

        [Fact]
        public async Task Add_ShouldWork()
        {
            var optionsBuilder = new DbContextOptionsBuilder<P1dbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var context = new P1dbContext(optionsBuilder.Options);

            var repository = new ReimbursementBL(context);
            var reimbursement = GetReimbursementObject();
            await repository.Add(reimbursement);
            Assert.Single(context.ReimbursementLists);
        }

        [Fact]
        public async Task Update_ShouldWork()
        {
            var optionsBuilder = new DbContextOptionsBuilder<P1dbContext>()
                   .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var context = new P1dbContext(optionsBuilder.Options);

            var repository = new ReimbursementBL(context);

            var reimbursement = GetReimbursementObject();
            var id = reimbursement.Id;
            await repository.Add(reimbursement);
            Assert.Single(context.ReimbursementLists);
            var reimbursementDb = await repository.Get(id);
            Assert.NotNull(reimbursementDb);
            UpdateReimbursementList updatedReimbursementList = new UpdateReimbursementList()
            {
                Name = "user",
                Email = "user@gmail.com",
                Status = "Pending",
                BusinessTravelCost = 0,
                TimeOff = "123"
            };
            bool result = await repository.Update(reimbursementDb, updatedReimbursementList);
            Assert.True(result);
        }

        [Fact]
        public async Task Get_ShouldWork()
        {
            var optionsBuilder = new DbContextOptionsBuilder<P1dbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var context = new P1dbContext(optionsBuilder.Options);

            var repository = new ReimbursementBL(context);
            var reimbursement = GetReimbursementObject();
            var id = reimbursement.Id;
            await repository.Add(reimbursement);
            Assert.Single(context.ReimbursementLists);
            var reimbursementDb = await repository.Get(id);
            Assert.NotNull(reimbursementDb);
        }

        [Fact]
        public async Task GetAll_ShouldWork()
        {
            var optionsBuilder = new DbContextOptionsBuilder<P1dbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var context = new P1dbContext(optionsBuilder.Options);

            var repository = new ReimbursementBL(context);
            var reimbursement = GetReimbursementObject();
            await repository.Add(GetReimbursementObject());
            await repository.Add(GetReimbursementObject());
            var result = await repository.GetAll();
            Assert.Equal(2, result.Count());
        }

        private ReimbursementList GetReimbursementObject()
        {
            var reimbursement = new ReimbursementList()
            {
                Id = Guid.NewGuid(),
                Name = "user",
                Email = "user@gmail.com",
                Status = "Pending",
                BusinessTravelCost = 0,
                TimeOff = "12"
            };
            return reimbursement;
        }
    }
}
