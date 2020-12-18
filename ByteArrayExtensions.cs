using System.Linq;
using System.Collections.Generic;

namespace _32bitsAllCombinaions
{
    public static class ByteArrayExtensions
    {
        public static void RandomPopulate(this byte[] byteArray)
        {
            for (var i = 0; i < byteArray.Length; i++)
            {
                byteArray[i] = (byte)(i+1);
            }
        }

        public static void EmptyByteArray(this byte[] byteArray)
        {
            for (var i = 0; i < byteArray.Length; i++)
            {
                byteArray[i] = (byte)0;
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
