using Application.Common.Interfaces;
using Domain.Entities;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System;
using Application.Features.RealtyFeatures.CreateRealty;
using AutoMapper;
using Application.Features.RealtyFeatures.GetRealties;
using System.Threading;

namespace UnitTest.Application.Features
{
    public class RealtyFeaturesTests
    {
        [Test]
        public void RealtyFeatures_GetRealties() {
            //Arrange
            var contextMock = new Mock<IApplicationDbContext>();
            var mapperMock = new Mock<IMapper>();
            var getRealtiesRequestMock = new Mock<GetRealtiesRequest>();

            var realties = new List<Realty>()
            {
                new Realty()
                {
                    Id = Guid.NewGuid(),
                    Description = "Test",
                },
                new Realty()
                {
                    Id= Guid.NewGuid(),
                    Description = "Test2",
                }
            };




          

            //Act
            var getRealtiesHandler = new GetRealtiesHandler(contextMock.Object, mapperMock.Object);

            var result = getRealtiesHandler.Handle(getRealtiesRequestMock.Object, new CancellationToken());

            //Assert
            Assert.Equals(result, new List<Realty>()
            {
                new Realty()
                {
                    Id = Guid.NewGuid(),
                    Description = "Test",
                },
                new Realty()
                {
                    Id= Guid.NewGuid(),
                    Description = "Test2",
                }
            });
        }
    }
}
