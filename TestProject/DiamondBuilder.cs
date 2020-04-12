using System;
using Xunit.Abstractions;

namespace TestProject
{
    public class DiamondBuilder
    {
        private const int AsciiCodeForA = 65;
        private readonly ITestOutputHelper outputHelper;

        public DiamondBuilder(ITestOutputHelper outputHelper)
        {
            this.outputHelper = outputHelper;
        }

        public string[] Build(char value)
        {
            int charIndex = GetCharIndex(value);
            int lengthOfArray = GetLengthOfArray(charIndex);
            var result = new string[lengthOfArray];

            for (int i = 0; i < charIndex + 1; i++)
            {
                result[i] = GetStringForIndex(i, charIndex);

                if (i == charIndex)
                {
                    break;
                }
            }

            if (charIndex != 0)
            {
                for (int i = 0; i < charIndex; i++)
                {
                    result[lengthOfArray - (i + 1)] = result[i];
                }
            }

            return result;
        }

        private static string GetStringForIndex(int i, int valueIndex)
        {
            var paddingLength = valueIndex - i;
            var paddingString = new string(' ', paddingLength);
            var characterForI = ((char)(i + AsciiCodeForA));
            string innerPadding = string.Empty;
            if (i > 0)
                innerPadding = new string(' ', i * 2 - 1);
            return $"{paddingString}{characterForI}{innerPadding}{(i > 0 ? characterForI.ToString() : string.Empty) }{paddingString}";
        }

        private int GetLengthOfLine(int charIndex)
        {
            return (2 * (1 + charIndex)) - 1;
        }

        private static int GetLengthOfArray(int charIndex)
        {
            return 1 + (2 * charIndex);
        }

        private static int GetCharIndex(char value)
        {
            int charIndex = (int)value;
            charIndex -= AsciiCodeForA;
            return charIndex;
        }
    }
}
//value = B

// 0  A
// 1  B
// 2  null
