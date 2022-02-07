using FakeItEasy;
using LibraryWebApp.Controllers;
using LibraryWebApp.Data;
using LibraryWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        private readonly BooksController _controller;
        private readonly ApplicationDbContext _context;        

        public UnitTest1()
        {
            _controller = new BooksController(_context);
        }
        [Fact]
        public void Test1()
        {
            // Act
            var okResult = _controller.Index();
            // Assert
            Assert.IsAssignableFrom<Task<IActionResult>>(okResult);
        }

        [Fact]
        public async Task Create_ReturnsBadRequest()
        {
            // Arrange & Act
            var mockRepo = new Mock<ApplicationDbContext>();
            var controller = new BooksController(mockRepo.Object);
            // Act
            var result = await controller.Create(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

    }
}
