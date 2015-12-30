using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.strategy_pattern.example_output_string
{
    public interface IOutputStrategy
    {
        string Output(string input);
    }

    public class CSVOutput : IOutputStrategy
    {
        char delimiter = ' ';
        public CSVOutput(char delimiter)
        {
            this.delimiter = delimiter;
        }

        public string Output(string input)
        {
            input = input.Replace(delimiter, ',');
            return input;
        }
    }

    public class EncryptedOutput : IOutputStrategy
    {
        public string Output(string input)
        {
            char[] array = input.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                int number = (int)array[i];

                if (number >= 'a' && number <= 'z')
                {
                    if (number > 'm')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                else if (number >= 'A' && number <= 'Z')
                {
                    if (number > 'M')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                array[i] = (char)number;
            }
            return new string(array);
        }
    }

    public class OutputContext
    {
        IOutputStrategy outputStrategy;
        public OutputContext(IOutputStrategy outputStrategy)
        {
            this.outputStrategy = outputStrategy;
        }

        public string GetOutput(string input)
        {
            return outputStrategy.Output(input);
        }
    }
}
