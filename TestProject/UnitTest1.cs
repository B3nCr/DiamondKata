using System;
using Xunit;
using Xunit.Abstractions;

namespace TestProject
{
    public class UnitTest1
    {
        DiamondBuilder _diamondBuilder;

        public UnitTest1(ITestOutputHelper outputHelper)
        {
            _diamondBuilder = new DiamondBuilder(outputHelper);
        }

        [Fact]
        public void Build_NonAlpha_ReturnsEmpty()
        {
            var result = _diamondBuilder.Build('1');
            Assert.Equal(0, result.Length);
        }

        [Fact]
        public void Build_A_ReturnsExpected()
        {
            var result = _diamondBuilder.Build('A');
            Assert.Equal("A", result[0]);
        }

        [Fact]
        public void Build_a_ConvertsToUppercase()
        {
            var result = _diamondBuilder.Build('a');
            Assert.Equal("A", result[0]);
        }

        [Fact]
        public void Build_B_AddsOuterPadding()
        {
            var result = _diamondBuilder.Build('B');
            Assert.Equal(" A ", result[0]);
            Assert.Equal("B B", result[1]);
        }

        [Fact]
        public void Build_B_ReturnsAllRows()
        {
            var result = _diamondBuilder.Build('B');
            Assert.Equal(" A ", result[0]);
            Assert.Equal("B B", result[1]);
            Assert.Equal(" A ", result[2]);
        }

        [Fact]
        public void Build_C_ReturnsAllRows()
        {
            var result = _diamondBuilder.Build('C');
            Assert.Equal("  A  ", result[0]);
            Assert.Equal(" B B ", result[1]);
            Assert.Equal("C   C", result[2]);
            Assert.Equal(" B B ", result[3]);
            Assert.Equal("  A  ", result[4]);
        }

        [Fact]
        public void Build_B_ReturnsExpected()
        {
            var result = _diamondBuilder.Build('B');
            Assert.Equal(3, result.Length);
            Assert.Equal(" A ", result[0]);
            Assert.Equal("B B", result[1]);
            Assert.Equal(" A ", result[2]);
        }
    }
}
