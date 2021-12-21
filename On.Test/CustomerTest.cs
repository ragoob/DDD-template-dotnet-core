using Moq;
using On.Core.Entites;
using On.Core.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;
using On.Core;
using AutoMapper;

namespace On.Test
{
    public class CustomerTest
    {
        //private Mock<ICustomerRepository> _customerRepository = new Mock<ICustomerRepository>();
        //private Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();
        //private Mock<ILoggingService> _logger = new Mock<ILoggingService>();
        //private ICustomerService _customerService;
        //public CustomerTest()
        //{
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.AddProfile(new CustomerMapper());
        //    });
        //    var mapper = config.CreateMapper();
        //    _customerService = new CustomerService(_unitOfWork.Object, _customerRepository.Object, mapper, _logger.Object);

        //}
  
        
        //[Fact]
        //public async Task GetCustomerById_Should_Return_Customer_when_Customer_Existed()
        //{
        //    //Arrange 
        //    var customerId = Guid.NewGuid();
        //    var customerName = "test customer name";
        //    Customer customer = new Customer()
        //    {
        //        Id = customerId,
        //        Name = customerName,
        //        Address = new CustomerAddress("", "", "", "", "")
        //    };
        //    _customerRepository.Setup(x => x.GetAsync(customerId))
        //        .ReturnsAsync(customer);
           
           
        //    //act
        //    var customerDto = await _customerService.GetCustomerAsync(customerId);

        //    //Assert
        //    Assert.NotNull(customerDto);
        //    Assert.Equal(customerId, customerDto.Id);
        //    Assert.Equal(customer.Name, customerDto.Name);

        //}

        //[Fact]
        //public async Task GetCustomerById_Should_Return_Nothing_when_Customer_Deos_Not_Exist()
        //{
        //    //Arrange
        //   _customerRepository.Setup(x=> x.GetAsync(It.IsAny<Guid>()))
        //        .ReturnsAsync(()=> null);
        //    //Act
        //    var customer = await _customerService.GetCustomerAsync(Guid.NewGuid());

        //    //Assert
        //    Assert.Null(customer);
        //}

        //[Fact]
        //public async Task GetCustomerById_ShouldLogAppropriateMesssage_WhenCustomerExists()
        //{
        //    //Arrange 
        //    var customerId = Guid.NewGuid();
        //    var customerName = "test customer name";
        //    Customer customer = new Customer()
        //    {
        //        Id = customerId,
        //        Name = customerName,
        //        Address = new CustomerAddress("", "", "", "", "")
        //    };
        //    _customerRepository.Setup(x => x.GetAsync(customerId))
        //        .ReturnsAsync(customer);


        //    //act
        //    var customerDto = await _customerService.GetCustomerAsync(customerId);

        //    //Assert

        //    _logger.Verify(x => x.LogInformation("Retrieved a customer with Id: {Id}", customerId), Times.Once);
        //    _logger.Verify(x => x.LogInformation("Unable to find a customer with Id: {Id}", customerId), Times.Never);


        //}

    }
}
