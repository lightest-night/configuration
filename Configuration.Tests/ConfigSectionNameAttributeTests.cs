using Shouldly;
using Xunit;

namespace LightestNight.Configuration.Tests;

public class ConfigSectionNameAttributeTests
{
    [ConfigSectionName("MyName")]
    private class TestClassA {}

    private class TestClassB {}

    private class TestClassConfig {}

    [Fact]
    public void Should_Read_From_Attribute()
    {
        // Act
        var result = ConfigSectionNameAttribute.ReadFrom(typeof(TestClassA));

        // Assert
        result.ShouldBe("MyName");
    }

    [Fact]
    public void Should_Read_From_ClassName()
    {
        // Act
        var result = ConfigSectionNameAttribute.ReadFrom(typeof(TestClassB));

        // Assert
        result.ShouldBe("TestClassB");
    }

    [Fact]
    public void Should_Read_From_ClassName_Ignoring_Suffix()
    {
        // Act
        var result = ConfigSectionNameAttribute.ReadFrom(typeof(TestClassConfig));

        // Assert
        result.ShouldBe("TestClass");
    }
}