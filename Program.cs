using System.Linq;
using System;
using System.Collections.Generic;

namespace _32bitsAllCombinaions
{
    class Program
    {
        static void Main(string[] args)
        {
            var privateKeyByteArray = new byte[32];
            privateKeyByteArray.RandomPopulate();

            var generatedPrivateKeys = new List<byte[]>
            {
                privateKeyByteArray
            };

            generatedPrivateKeys.AddRange(privateKeyByteArray.EachPosition256Values());

            Console.ReadLine();
        }
    }

    internal static class ByteArrayExtensions
    {
        public static void RandomPopulate(this byte[] byteArray)
        {
            for (var i = 0; i < 32; i++)
            {
                byteArray[i] = (byte)i;
            }
        }

        public static IList<byte[]> EachPosition256Values(this byte[] byteArray)
        {
            var listRET = new List<byte[]>();

            for (var i = 0; i < 32; i++)
            {
                listRET.AddRange(byteArray.ByteArrayPosition256Values(i));
            }

            return listRET;
        }

        public static IList<byte[]> ByteArrayPosition256Values(this byte[] byteArray, int position)
        {
            var listRET = new List<byte[]>();

            for (var i = 0; i < 256; i++)
            {
                var clonedByteArray = byteArray.ToArray();

                clonedByteArray[position] = (byte)i; 
                listRET.Add(clonedByteArray);
            }

            return listRET;
        }
    }
}
