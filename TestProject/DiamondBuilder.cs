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

            for (int i = 0; i < lengthOfArray; i++)
            {
                char charForI = GetCharForIndex(i);
                result[i] = charForI.ToString();
                if (charForI == value)
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

        private static char GetCharForIndex(int i)
        {
            return ((char)(i + AsciiCodeForA));
        }

        private int GetLengthOfLine(int charIndex)
        {
            //line = {padding}{letter}{middlePadding=totalLengthOfLine-2-(2*padding)}{letter}{padding}"
            /*
             *   22A22
             *   1B1B1   
             *
             */
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
