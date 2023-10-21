using System.Text.Json;
using BrianDemo.Config;
using BrianDemo.Models.Dto;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace BrianDemo.Test.IntegrationTest;

public class UserIntegrationTests
{
    private TestDbContext _context;
    
    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseSqlite("DataSource=:memory:")
            .Options;

        _context = new TestDbContext(options);
        _context.Database.OpenConnection(); // This is important for in-memory database
        _context.Database.EnsureCreated();
    }
    
    [TearDown]
    public void TearDown()
    {
        _context.Database.CloseConnection();
        _context.Dispose();
    }

    [Test]
    public void Save_One_Row_Data()
    {
        // Arrange
        var account = "TestAccount";
        var entity = new User(){Account = account,Password = ""};

        // Act
        _context.User.Add(entity);
        _context.SaveChanges();
        
        var actual  = _context.User.Find(entity.Id);

        // Assert
        // 使用 FluentAssertions 提升可讀性
        actual.Should().NotBeNull();
        actual!.Id.Should().Be(1);
        actual!.Account.Should().Be(account);
    }
    
    [Test]
    public void Save_Two_Row_Data()
    {
        // Arrange
        var account = "TestAccount";
        var entity = new User(){Account = account,Password = ""};
        var entity1 = new User(){Account = account,Password = ""};
        
        // Act
        _context.User.Add(entity);
        _context.User.Add(entity1);
        _context.SaveChanges();
        
        var actual  = _context.User.Find(entity.Id);

        // Assert
        // 使用 FluentAssertions 提升可讀性
        actual.Should().NotBeNull();
        actual!.Account.Should().Be(account);
        entity.Id.Should().Be(1);
        entity1.Id.Should().Be(2);
    }
    
    [Test]
    public void Save_Two_Row_Data_By_List()
    {
        // Arrange
        var account = "TestAccount";
        var list = new List<User>();
        list.Add(new User(){Account = account,Password = ""});
        list.Add(new User(){Account = account,Password = ""});

        // Act
        _context.User.AddRange(list);
        _context.SaveChanges();
        
        var actual  = _context.User.Find(list[0].Id);

        // Assert
        // 使用 FluentAssertions 提升可讀性
        actual.Should().NotBeNull();
        actual!.Account.Should().Be(account);
        list[0].Id.Should().Be(1);
        list[1].Id.Should().Be(2);
    }
}