using AmadeusWebAPI.Controllers;
using AmadeusWebAPI.Data;
using AmadeusWebAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmadeusWebAPI.Tests
{
    public class AirlinesControllerTests
    {
        private ApplicationDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public async Task Get_AllAirlines()
        {
            
            var context = GetInMemoryDbContext();
            context.Airlines.Add(new Airline { Id = 1, Name = "Avianca" });
            context.Airlines.Add(new Airline { Id = 2, Name = "LATAM" });
            await context.SaveChangesAsync();

            var controller = new AirlinesController(context);

            var result = await controller.Get();

          
            Assert.Equal(2, result.Count());
        }


        [Fact]
        public async Task GetById_NotExists()
        {
            var context = GetInMemoryDbContext();
            var controller = new AirlinesController(context);
            var result = await controller.Get(19999);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Post_NewAirline()
        {
            var context = GetInMemoryDbContext();
            var controller = new AirlinesController(context);
            var newAirline = new Airline { Id = 3, Name = "Copa" };
            var result = await controller.Post(newAirline);

            var createdResult = Assert.IsType<CreatedAtRouteResult>(result);
            var airline = Assert.IsType<Airline>(createdResult.Value);
            Assert.Equal("Copa", airline.Name);
        }

        [Fact]
        public async Task Delete_RemovesAirline()
        {
            var context = GetInMemoryDbContext();
            var controller = new AirlinesController(context);
            var newAirline = new Airline { Id = 1, Name = "Avianca" };
             await controller.Post(newAirline);

            var result = await controller.Delete(1);

            Assert.IsType<OkResult>(result);
            Assert.Null(await context.Airlines.FindAsync(1));
        }

    }
}