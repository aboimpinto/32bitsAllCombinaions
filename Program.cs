using System.Net.Security;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _32bitsAllCombinaions
{
    class Program
    {
        static void Main(string[] args)
        {
            var privateKeyByteArray = new byte[4];
            privateKeyByteArray.RandomPopulate();

            var stringValue = Convert.ToBase64String(privateKeyByteArray);
            Console.WriteLine($"PrivateKey: {stringValue}");

            var generatedPrivateKeys = new List<string>
            {
                stringValue
            };

            var generatedPrivateKeyByteArray = new byte[4];
            generatedPrivateKeyByteArray.EmptyByteArray();

            int nGeneratedKey = 0;
            while(true)
            {
                try
                {
                    NextIteration(generatedPrivateKeyByteArray, privateKeyByteArray);
                    nGeneratedKey ++;
                    Console.WriteLine($"[{nGeneratedKey}] PrivateKey: {Convert.ToBase64String(generatedPrivateKeyByteArray)} ({string.Join(".", generatedPrivateKeyByteArray)})");
                }
                catch (System.Exception ex)
                {
                    break;
                }
            }
                            
            Console.ReadLine();
        }

        public static void NextIteration(byte[] input)
        {
            if (input.All(x => x == 255))
                throw new InvalidOperationException("there is no iteration left");

            var converted = input.Select(x => (int) x).ToArray();
            converted[0]++;
            for (var i = 0; i < converted.Length; i++)
            {
                if (converted[i] == 256)
                {
                    converted[i] = 0;
                    converted[i + 1]++;
                }
            }
            for (var i = 0; i < input.Length; i++)
            {
                input[i] = (byte) converted[i];
            }
        }

        public static void NextIteration(byte[] input, byte[] allowedValues)
        {
            if (input.All(x => x == allowedValues.Last()))
                throw new InvalidOperationException("there is no iteration left");

            int allowedValuesCursor = Array.FindIndex(allowedValues, x => x == input[0]) + 1;

            var converted = input.Select(x => (int) x).ToArray();
            converted[0] = allowedValues[allowedValuesCursor];
            for (var i = 0; i < converted.Length; i++)
            {
                if (converted[i] == allowedValues.Last())
                {
                    converted[i] = 0;

                    var indexNextByteInConverted = Array.FindIndex(allowedValues, x => x == converted[i+1]);
                    converted[i + 1] = allowedValues[indexNextByteInConverted + 1];
                }
            }
            for (var i = 0; i < input.Length; i++)
            {
                input[i] = (byte) converted[i];
            }
        }
    }
}
