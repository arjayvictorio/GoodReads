using DatabaseService.Models;
using GoodReadsAPI.Controllers;
using GoodReadsAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Tester
{
    [TestClass]
    public class UnitTest1
    {
        private ApiContext _context;

        [TestMethod]
        public void test_Save_Pass()
        {
            var book = new Book() { Id = 1, Name = "Book 1", Description = "Description 1" };

            var dbContextOptions = new DbContextOptionsBuilder<ApiContext>().UseInMemoryDatabase("Test");
            _context = new ApiContext(dbContextOptions.Options);
            _context.Database.EnsureCreated();

            Book result = new ReadController(_context).Save(book);

            Assert.AreEqual(result.Error, "");

            _context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void test_Save_Fail()
        {
            var book = new Book() { Id = 0, Name = "Book 1", Description = "Description 1" };

            var dbContextOptions = new DbContextOptionsBuilder<ApiContext>().UseInMemoryDatabase("Test");
            _context = new ApiContext(dbContextOptions.Options);
            _context.Database.EnsureCreated();

            Book result = new ReadController(_context).Save(book);

            Assert.AreNotEqual(result.Error, "");

            _context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void test_Fetch_3()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApiContext>().UseInMemoryDatabase("Test");
            _context = new ApiContext(dbContextOptions.Options);
            _context.Database.EnsureCreated();

            new ReadController(_context).Save(new Book()
            {
                Id=1,
                Name="Name 1",
                Description="Description 1"
            });

            new ReadController(_context).Save(new Book()
            {
                Id = 2,
                Name = "Name 2",
                Description = "Description 2"
            });

            new ReadController(_context).Save(new Book()
            {
                Id = 3,
                Name = "Name 3",
                Description = "Description 3"
            });

            List<Book> result = new ReadController(_context).GetAll();

            Assert.AreEqual(result.Count, 3);

            _context.Database.EnsureDeleted();

        }

        [TestMethod]
        public void test_Fetch_0()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApiContext>().UseInMemoryDatabase("Test");
            _context = new ApiContext(dbContextOptions.Options);
            _context.Database.EnsureCreated();


            List<Book> result = new ReadController(_context).GetAll();

            Assert.AreEqual(result.Count, 0);

            _context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void test_Fetch_Book_1()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApiContext>().UseInMemoryDatabase("Test");
            _context = new ApiContext(dbContextOptions.Options);
            _context.Database.EnsureCreated();

            new ReadController(_context).Save(new Book()
            {
                Id = 1,
                Name = "Name 1",
                Description = "Description 1"
            });

            new ReadController(_context).Save(new Book()
            {
                Id = 2,
                Name = "Name 2",
                Description = "Description 2"
            });

            new ReadController(_context).Save(new Book()
            {
                Id = 3,
                Name = "Name 3",
                Description = "Description 3"
            });

            Book result = new ReadController(_context).Fetch("Name 2");

            Assert.AreEqual(result.Name, "Name 2");

            _context.Database.EnsureDeleted();

        }

        [TestMethod]
        public void test_Fetch_Book_0()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApiContext>().UseInMemoryDatabase("Test");
            _context = new ApiContext(dbContextOptions.Options);
            _context.Database.EnsureCreated();

            new ReadController(_context).Save(new Book()
            {
                Id = 1,
                Name = "Name 1",
                Description = "Description 1"
            });

            new ReadController(_context).Save(new Book()
            {
                Id = 2,
                Name = "Name 2",
                Description = "Description 2"
            });

            new ReadController(_context).Save(new Book()
            {
                Id = 3,
                Name = "Name 3",
                Description = "Description 3"
            });

            Book result = new ReadController(_context).Fetch("Name 4");

            Assert.AreEqual(result.Id, 0);

            _context.Database.EnsureDeleted();
        }
    }
}