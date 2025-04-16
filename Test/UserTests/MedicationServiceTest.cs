using AstroPharm.Domain.Entities.Products;
using AstroPharm.Service.DTOs.Medications;
using AstroPharm.Service.Interfaces.Medications;
using AstroPharm.Service.Services.Medications;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Test.MedicationTests
{
    public class MedicationServiceTest
    {
        private readonly Mock<IMedicationInterface> _medicationServiceMock;

        public MedicationServiceTest()
        {
            _medicationServiceMock = new Mock<IMedicationInterface>();
        }

        [Fact]
        public async Task AddMedication_Mock_Test()
        {
            var createDto = new MedicationForCreationDto
            {
                MedicationName = "Paracetamol",
                Description = "Pain relief",
                Price = 25,
                CategoryId = 1
            };

            var expected = new MedicationForResultDto
            {
                Id = 1,
                MedicationName = "Paracetamol",
                Description = "Pain relief",
                Price = 25
            };

            _medicationServiceMock
                .Setup(service => service.AddAsync(It.IsAny<MedicationForCreationDto>()))
                .ReturnsAsync(expected);

            var result = await _medicationServiceMock.Object.AddAsync(createDto);

            Assert.NotNull(result);
            Assert.Equal("Paracetamol", result.MedicationName);
            Assert.Equal(25, result.Price);
        }

        [Fact]
        public async Task RetrieveMedicationById_Mock_Test()
        {
            var expected = new MedicationForResultDto
            {
                Id = 1,
                MedicationName = "Aspirin",
                Price = 11
            };

            _medicationServiceMock
                .Setup(service => service.GetByIdAsync(1))
                .ReturnsAsync(expected);

            var result = await _medicationServiceMock.Object.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Aspirin", result.MedicationName);
            Assert.Equal(11, result.Price);
        }

     
        [Fact]
        public async Task ModifyMedication_Mock_Test()
        {
            var updateDto = new MedicationForUpdateDto
            {
                MedicationName = "UpdatedParacetamol",
                Price = 35
            };

            var expected = new MedicationForResultDto
            {
                Id = 1,
                MedicationName = "UpdatedParacetamol",
                Price = 35
            };

            _medicationServiceMock
                .Setup(service => service.ModifyAsync(1, It.IsAny<MedicationForUpdateDto>()))
                .ReturnsAsync(expected);

            var result = await _medicationServiceMock.Object.ModifyAsync(1, updateDto);

            Assert.NotNull(result);
            Assert.Equal("UpdatedParacetamol", result.MedicationName);
            Assert.Equal(35, result.Price);
        }

        [Fact]
        public async Task RemoveMedication_Mock_Test()
        {
            _medicationServiceMock
                .Setup(service => service.DeleteAsync(1))
                .ReturnsAsync(true);

            var result = await _medicationServiceMock.Object.DeleteAsync(1);

            Assert.True(result);
        }
    }
}
