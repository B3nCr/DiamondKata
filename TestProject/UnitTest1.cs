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

        [Theory]
        [InlineData('1')]
        [InlineData(' ')]
        [InlineData('£')]
        [InlineData(new char())]
        public void Build_NonAlpha_ReturnsEmpty(char nonAlpha)
        {
            var result = _diamondBuilder.Build(nonAlpha);
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

        [Fact]
        public void Build_Z_ReturnsExpected()
        {
            var result = _diamondBuilder.Build('Z');

            Assert.StartsWith("                         A", result[0]);
            Assert.StartsWith("                        B ", result[1]);
            Assert.StartsWith("                       C  ", result[2]);
            Assert.StartsWith("                      D   ", result[3]);
            Assert.StartsWith("                     E    ", result[4]);
            Assert.StartsWith("                    F     ", result[5]);
            Assert.StartsWith("                   G      ", result[6]);
            Assert.StartsWith("                  H       ", result[7]);
            Assert.StartsWith("                 I        ", result[8]);
            Assert.StartsWith("                J         ", result[9]);
            Assert.StartsWith("               K          ", result[10]);
            Assert.StartsWith("              L           ", result[11]);
            Assert.StartsWith("             M            ", result[12]);
            Assert.StartsWith("            N             ", result[13]);
            Assert.StartsWith("           O              ", result[14]);
            Assert.StartsWith("          P               ", result[15]);
            Assert.StartsWith("         Q                ", result[16]);
            Assert.StartsWith("        R                 ", result[17]);
            Assert.StartsWith("       S                  ", result[18]);
            Assert.StartsWith("      T                   ", result[19]);
            Assert.StartsWith("     U                    ", result[20]);
            Assert.StartsWith("    V                     ", result[21]);
            Assert.StartsWith("   W                      ", result[22]);
            Assert.StartsWith("  X                       ", result[23]);
            Assert.StartsWith(" Y                        ", result[24]);
            Assert.StartsWith("Z                         ", result[25]);
        }
    }
}
