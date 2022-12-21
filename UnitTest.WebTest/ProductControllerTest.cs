using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Web.Controllers;
using UnitTest.Web.Models;
using UnitTest.Web.Repository;
using Xunit;

namespace UnitTest.WebTest
{
    public class ProductControllerTest
    {
        private readonly Mock<IRepository<Products>> _mockRepos;
        private readonly ProductController _controller;
        private List<Products> products;
        public ProductControllerTest()
        {
            _mockRepos = new Mock<IRepository<Products>>();
            
            _controller = new ProductController(_mockRepos.Object);
           
            products = new List<Products>()
            {
                new Products
                {
                    Id = 1,
                    Name= "Defter",
                    Description="60 yp",
                    Price=50,
                    Stock=30,
                },
                 new Products
                {
                    Id = 2,
                    Name= "Kitap",
                    Description="Okuma",
                    Price=40,
                    Stock=300,
                },
                  new Products
                {
                    Id = 3,
                    Name= "Kalemlik",
                    Description="Siyah",
                    Price=90,
                    Stock=30,
                }
            };
        }
        [Fact]
        public  async void Index_ActionExecute_ReturnView()
        {
            var result =await _controller.Index();
           
            Assert.IsType<ViewResult>(result);

        }
        [Fact]
        public async void Index_ActionExecute_ReturnProductList()
        {
            _mockRepos.Setup(repo => repo.GetAll()).ReturnsAsync(products);

            var result =await _controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            var productList = Assert.IsAssignableFrom<IEnumerable<Products>>(viewResult.Model);

            Assert.Equal<int>(3, products.Count());

        }

        [Fact]
        public async void Details_IdIsNull_RedirectToIndexAciton()
        {
            var result = await _controller.Details(null);
            var redirect=Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirect.ActionName);

        }
        [Fact]
        public async void Details_ProductIsNull_ReturnNotFound()
        {
            Products product= null;
            _mockRepos.Setup(repo => repo.GetById(0)).ReturnsAsync(product);
            var result=await _controller.Details(0);
            var redirect = Assert.IsType<NotFoundResult>(result);
            Assert.Equal<int>(404, redirect.StatusCode);

        }
        [Theory]
        [InlineData(1)]
        public async void Details_ValidId_ReturnProduct(int productId)
        {
            var product = products.First(i => i.Id == productId);

            _mockRepos.Setup(repo => repo.GetById(productId)).ReturnsAsync(product);
            
            var result = await _controller.Details(productId);
            
            var viewResult = Assert.IsType<ViewResult>(result);
            
            var resultProduct = Assert.IsAssignableFrom<Products>(viewResult.Model);

            Assert.Equal(product.Id, resultProduct.Id);

            Assert.Equal(product.Name, resultProduct.Name);

        }
    }
}
