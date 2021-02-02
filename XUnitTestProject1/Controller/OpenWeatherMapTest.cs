using ApiTests.Model;
using DesafioHubConexa.Controllers;
using DesafioHubConexa.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Net.Http;
using System.Xml;
using Xunit;

namespace ApiTests
{
    public class OpenWeatherMapTest
    {
        private OpenWeatherMapController _controller;
        private IOpenWeatherService _service;

        private const string NOME = "New York";
        private const float LAT = 33.44F;
        private const float LONG = -94.04F;

        public OpenWeatherMapTest()
        {
            _service = new CityModelMock();
            _controller = new OpenWeatherMapController(_service);
        }
        [Fact]
        public void Get_WhenCalledByValidCityName_ReturnsOkResult()
        {
            // Act
            var result = _controller.BuscarTemperaturaPorCidade(NOME);
            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void Get_WhenCalledByLatLong_ReturnsOkResult()
        {
            // Act
            var result = _controller.BuscarTemperaturaPorGeolocalizacao(LAT,LONG);
            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetHistoric_WhenCalledByLatLong_ReturnsOkResult()
        {
            // Act
            var result = _controller.BuscarHistoricoPorGeolocalizacao(LAT, LONG);
            
            // Assert
            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact]
        public void Get_WhenCalledByValidCityName_ReturnsBadRequestObjectResult()
        {
            // Act
            var result = _controller.BuscarTemperaturaPorCidade("Washington");
            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void Get_WhenCalledByLatLong_ReturnsBadRequestObjectResult()
        {
            // Act
            var result = _controller.BuscarTemperaturaPorGeolocalizacao(1, 2);
            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void GetHistoric_WhenCalledByLatLong_ReturnsBadRequestObjectResult()
        {
            // Act
            var result = _controller.BuscarHistoricoPorGeolocalizacao(1, 2);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);

        }
    }
}
