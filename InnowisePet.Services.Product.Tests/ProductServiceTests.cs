using InnowisePet.Services.Product.BLL.Services.Implementations;
using InnowisePet.Services.Product.BLL.Services.Interfaces;
using InnowisePet.Services.Product.DAL.Repository.Interfaces;

namespace InnowisePet.Services.Product.Tests;

public class ProductServiceTests
{
    private readonly IProductService _productService;
    private readonly Mock<IProductRepository> _mockProductRepo = new ();
    private readonly IMapper _mapper;

    public ProductServiceTests()
    {
        MapperConfiguration mockMapper = new(cfg =>
        {
            cfg.AddProfile(new ProductGetProfile());
            cfg.AddProfile(new ProductCreateProfile());
        });
        
        _mapper = mockMapper.CreateMapper();
        
        _productService = new ProductService(_mockProductRepo.Object, _mapper);
    }

    public static IEnumerable<object[]> Uids =>
        new List<object[]>
        {
            new object[] { Guid.Empty },
            new object[] { Guid.NewGuid() },
            new object[] { Guid.NewGuid() },
            new object[] { Guid.NewGuid() },
            new object[] { Guid.NewGuid() },
            new object[] { Guid.NewGuid() },
        };

    [Theory]
    [MemberData(nameof(Uids))]
    public async Task GetProductByIdAsync_WithValidUids_ShouldBeTrue(Guid productId)
    {
        //Arrange
        _mockProductRepo.Setup(x => x.GetProductByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new ProductModel() {Id = productId});
        
        //Act
        ProductGetDto product = await _productService.GetProductByIdAsync(productId);
        
        //Assert
        Assert.Equal(productId, product.Id);
    }
    
    [Theory]
    [MemberData(nameof(Uids))]
    public async Task GetProductByIdAsync_WithNotValidUids_ShouldBeFalse(Guid productId)
    {
        //Arrange
        _mockProductRepo.Setup(x => x.GetProductByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new ProductModel() {Id = Guid.NewGuid()});
        //Act
        ProductGetDto product = await _productService.GetProductByIdAsync(productId);
        
        //Assert
        Assert.NotEqual(productId, product.Id);
    }
    
    public static IEnumerable<object[]> ProductModelList =>
        new List<object[]>
        {
            new object[]
            {
                new List<ProductModel>
                {
                    new() {Id = Guid.NewGuid(), Title = new string('a', 5), CategoryId = Guid.NewGuid()},
                    new() {Id = Guid.NewGuid(), Title = new string('a', 5), CategoryId = Guid.NewGuid()},
                    new() {Id = Guid.NewGuid(), Title = new string('a', 5), CategoryId = Guid.NewGuid()}
                }
            }
        };

    [Theory]
    [MemberData(nameof(ProductModelList))]
    public async Task GetProductsAsync_ShouldReturnMockProductList(List<ProductModel> list)
    {
        //Arrange
        _mockProductRepo.Setup(x => x.GetProductsAsync()).ReturnsAsync(list);

        //Act
        IEnumerable<ProductGetDto> listDto = await _productService.GetProductsAsync();
        IEnumerable<ProductGetDto> mappedResult = _mapper.Map<IEnumerable<ProductGetDto>>(list);
        
        //Assert
        AssertHelper.EqualCollections(listDto, mappedResult);
    }

    public static IEnumerable<object[]> ProductCreateDtoList =>
        new List<object[]>
        {
            new object[] { new ProductCreateDto() },
            new object[] { new ProductCreateDto() },
            new object[] { new ProductCreateDto() }
        };
    
    [Fact]
    public async Task CreateProductAsync_ShouldReturnFalse()
    {
        //Arrange
        _mockProductRepo.Setup(x => x.CreateProductAsync(It.IsAny<ProductModel>())).ReturnsAsync(Guid.NewGuid);

        //Act
        Guid result = await _productService.CreateProductAsync(new ProductCreateDto());
        
        //Assert
        Assert.NotEqual(result, Guid.Empty);
    }
}