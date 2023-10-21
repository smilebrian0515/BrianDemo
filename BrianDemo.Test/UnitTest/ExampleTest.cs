namespace BrianDemo.Test.UnitTest;

using FluentAssertions;
using FluentAssertions.Execution;

public class ExampleTests
{
    [Test]
    public void Hard_Assertion()
    {
        // Arrange
        string str = "123";
        string expected = "2";

        // Act
        string actual = str.Substring(1, 1);

        // Assert
        // 使用 FluentAssertions 提升可讀性
        actual.Should().Be(expected);
    }
    
    [Test]
    public void Soft_Assertion()
    {
        // Arrange
        string str = "123";

        // Act
        string actual1 = str.Substring(1, 1);
        string actual2 = str.Substring(1, 2);

        // Assert
        // 使用 FluentAssertions 提升可讀性
        using (new AssertionScope())
        {
            actual1.Should().Be("2");
            actual2.Should().Be("23");
        }
    }

    [Test]
    public void Throwing_Exception()
    {
        // Arrange

        // Act

        // Assert
        // 使用 FluentAssertions 提升可讀性
        Action actual = () => throwException();
        actual.Should().Throw<Exception>().WithMessage("*Magic*");
    }

    private void throwException()
    {
        throw new Exception("Magic");
    }
}