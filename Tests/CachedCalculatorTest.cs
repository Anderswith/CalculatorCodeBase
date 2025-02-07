using Calculator;

namespace Tests;

public class CachedCalculatorTest
{
    [Test]
    public void Add()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 2;
        var b = 3;

        // Act
        var result = calc.Add(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(5));
    }
    [Test]
    public void Subtract()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 5;
        var b = 3;

        // Act
        var result = calc.Subtract(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void Multiply()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 4;
        var b = 3;

        // Act
        var result = calc.Multiply(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(12));
    }

    [Test]
    public void Divide()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 10;
        var b = 2;

        // Act
        var result = calc.Divide(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Factorial()
    {
        // Arrange
        var calc = new CachedCalculator();
        var n = 5;

        // Act
        var result = calc.Factorial(n);

        // Assert
        Assert.That(result, Is.EqualTo(120));
    }

    [Test]
    public void IsPrime_WhenNumberIsPrime()
    {
        // Arrange
        var calc = new CachedCalculator();
        var candidate = 7;

        // Act
        var result = calc.IsPrime(candidate);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void IsPrime_WhenNumberIsNotPrime()
    {
        // Arrange
        var calc = new CachedCalculator();
        var candidate = 8;

        // Act
        var result = calc.IsPrime(candidate);

        // Assert
        Assert.That(result, Is.False);
    }
    [Test]
    public void GetCachedResult_WhenResultIsCached()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 2;
        var b = 3;
        calc.Add(a, b); // Store in cache

        // Act
        var cachedResultObj = calc.GetType()
            .GetMethod("GetCachedResult", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.MakeGenericMethod(typeof(int))
            .Invoke(calc, new object[] { a, b, "Add" });

        var resultProperty = cachedResultObj?.GetType().GetProperty("Result")?.GetValue(cachedResultObj);

        // Assert
        Assert.That(resultProperty, Is.EqualTo(5));
    }
}