using System;
using Xunit;
using MedicineAccountingAPI.DataLevel;
using MedicineAccountingAPI.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using AutoFixture.Xunit2;
using System.Net;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace MedicineAccountingAPI.Tests
{
    public class MedicineControllerTests
    {
        [Fact]
        public void MedicineGetNotEmptyList()
        {
            //arrange
            MedicineController mc = new MedicineController();
            //act
            var result = mc.Get();
            //assert
            Assert.NotEmpty(result);
        }
        [Fact]
        public void MedicineGetProductList()
        {
            //arrange
            MedicineController mc = new MedicineController();
            //act
            var result = mc.Get();
            //assert
            Assert.All(result, item => Assert.IsType<Product>(item));
        }
        [Fact]
        public void MedicineGetProduct()
        {
            //arrange
            MedicineController mc = new MedicineController();
            Product product = new Product { Id = 1, Name = "Citramon", Amount = 20, Price = 10 };
            //act
            var result = mc.Get();
            //assert
            Assert.Equal(product.ToString(), result[0].ToString());
        }
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void MedicineGetProductById(int id)
        {
            //arrange
            MedicineController mc = new MedicineController();
            Product[] product = {
                                    //new Product { Id=1, Name="Citramon", Amount = 20, Price =10 },
                                    new Product { Id=2, Name="Nimessil", Amount = 50, Price =11.50 },
                                    new Product { Id=3, Name="Nurofen", Amount = 20, Price = 50 }
                                };
            //act
            var result = mc.Get(id);
            //assert
            for (int i = 0; i < 2; i++)
            {
                Assert.Equal(product[i].ToString(), result.ToString());
            }
        }
        [Theory]
        [InlineData(0)]
        public void MedicineGetProductByIdEmptyResult(int id)
        {
            //arrange
            MedicineController mc = new MedicineController();
            //act
            var result = mc.Get(id);
            //assert
            Assert.Null(result);
        }

        [Theory]
        [ClassData(typeof(ProductTest))]
        public void MedicineAddProduct(Product product)
        {
            //arrange
            MedicineController mc = new MedicineController();
            //act
            var result = mc.Add(product);
            //assert
            Assert.True(result);
        }
        [Theory]
        [ClassData(typeof(ProductTest))]
        public void MedicineAddProductWrong(Product product)
        {
            //arrange
            MedicineController mc = new MedicineController();
            product = null;
            //act
            var result = mc.Add(product);
            //assert
            Assert.False(result);
        }
        [Fact]
        public void MedicineUpdateProduct()
        {
            //arrange
            MedicineController mc = new MedicineController();
            int id = 10;
            Product product = new Product { Name="Citramon",Amount = 30, Price=10};
            //act
            var result = mc.Update(id, product);
            //assert
            Assert.Equal(product.Id.ToString(), mc.Get(11).Id.ToString());
            Assert.Equal(product.Name.ToString(), mc.Get(11).Name.ToString());
            Assert.Equal(product.Price.ToString(), mc.Get(11).Price.ToString());
            Assert.Equal(product.Amount.ToString(), mc.Get(11).Amount.ToString());
        }
        [Fact]
        public void MedicineUpdateProductUndefinedId()
        {
            //arrange
            MedicineController mc = new MedicineController();
            int id = 5;
            Product product = new Product { Name = "Citramon", Amount = 30, Price = 10 };
            //act
            var result = mc.Update(id, product);
            //assert
            Assert.True(result is Microsoft.AspNetCore.Mvc.NotFoundObjectResult);
        }

        [Theory]
        [InlineData(7)]
        public void MedicineDeleteProduct(int id)
        {
            //arrange
            MedicineController mc = new MedicineController();
            //act
            var result = mc.Delete(id);
            //assert
            Assert.True(result is List<Product>);
        }
        [Theory]
        [InlineData(0)]
        public void MedicineDeleteProductWrongData(int id)
        {
            //arrange
            MedicineController mc = new MedicineController();
            //act
            var result = mc.Delete(id);
            //assert
            Assert.False(result is List<Product>);
        }
    }
    
    internal class ProductTest: IEnumerable<object[]>
    {
        public IEnumerator<Object[]> GetEnumerator()
        {
            yield return new Product[] { new Product { Name = "Spazmalgon", Amount = 10, Price = 10.5 } }; ;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
