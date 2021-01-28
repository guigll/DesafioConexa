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
            var okResult = _controller.BuscarTemperaturaPorCidade(NOME);
            // Assert
            Assert.NotNull(okResult);
        }
        [Fact]
        public void Get_WhenCalledByLatLong_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.BuscarTemperaturaPorGeolocalizacao(LAT,LONG);
            // Assert
            Assert.NotNull(okResult);
        }
        [Fact]
        public void GetHistoric_WhenCalledByLatLong_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.BuscarHistoricoPorGeolocalizacao(LAT, LONG);            
            // Assert
            
        }
    }
}
