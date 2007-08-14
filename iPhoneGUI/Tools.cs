// Tools.cs - Hex and Text tools for C#
//
// Copyright (C) 2007  James C. Baker
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
using System;
using System.Text;

namespace Tools
{
    /// <summary>
    /// Creates.
    /// </summary>
    public class Hex
    {
        public Hex() {
            //
            // TODO: Add constructor logic here
            //
        }

        public static int GetByteCount(string hexString) {
            int numHexChars = 0;
            char c;
            // remove all none A-F, 0-9, characters
            for ( int i = 0; i < hexString.Length; i++ ) {
                c = hexString[i];
                if ( IsHexDigit(c) )
                    numHexChars++;
            }
            // if odd number of characters, discard last character
            if ( numHexChars % 2 != 0 ) {
                numHexChars--;
            }
            return numHexChars / 2; // 2 characters per byte
        }
        /// <summary>
        /// Creates a byte array from the hexadecimal string. Each two characters are combined
        /// to create one byte. First two hexadecimal characters become first byte in returned array.
        /// Non-hexadecimal characters are ignored. 
        /// </summary>
        /// <param name="hexString">string to convert to byte array</param>
        /// <returns>byte array, in the same left-to-right order as the hexString</returns>
        public static byte[] ToBytes(string hexString) {
            int discarded;
            return ToBytes(hexString, out discarded);
        }
        /// <summary>
        /// Creates a byte array from the hexadecimal string. Each two characters are combined
        /// to create one byte. First two hexadecimal characters become first byte in returned array.
        /// Non-hexadecimal characters are ignored. 
        /// </summary>
        /// <param name="hexString">string to convert to byte array</param>
        /// <param name="discarded">number of characters in string ignored</param>
        /// <returns>byte array, in the same left-to-right order as the hexString</returns>
        public static byte[] ToBytes(string hexString, out int discarded) {
            discarded = 0;
            string newString = "";
            char c;
            // remove all none A-F, 0-9, characters
            for ( int i = 0; i < hexString.Length; i++ ) {
                c = hexString[i];
                if ( IsHexDigit(c) )
                    newString += c;
                else
                    discarded++;
            }
            // if odd number of characters, discard last character
            if ( newString.Length % 2 != 0 ) {
                discarded++;
                newString = newString.Substring(0, newString.Length - 1);
            }

            int byteLength = newString.Length / 2;
            byte[] bytes = new byte[byteLength];
            string hex;
            int j = 0;
            for ( int i = 0; i < bytes.Length; i++ ) {
                hex = new String(new Char[] { newString[j], newString[j + 1] });
                bytes[i] = HexToByte(hex);
                j = j + 2;
            }
            return bytes;
        }
        public static string ToString(byte[] bytes) {
            string hexString = "";
            for ( int i = 0; i < bytes.Length; i++ ) {
                hexString += bytes[i].ToString("X2");
            }
            return hexString;
        }
        /// <summary>
        /// Determines if given string is in proper hexadecimal string format
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static bool InHexFormat(string hexString) {
            bool hexFormat = true;

            foreach ( char digit in hexString ) {
                if ( !IsHexDigit(digit) ) {
                    hexFormat = false;
                    break;
                }
            }
            return hexFormat;
        }

        /// <summary>
        /// Returns true is c is a hexadecimal digit (A-F, a-f, 0-9)
        /// </summary>
        /// <param name="c">Character to test</param>
        /// <returns>true if hex digit, false if not</returns>
        public static bool IsHexDigit(Char c) {
            int numChar;
            int numA = Convert.ToInt32('A');
            int num1 = Convert.ToInt32('0');
            c = Char.ToUpper(c);
            numChar = Convert.ToInt32(c);
            if ( numChar >= numA && numChar < (numA + 6) )
                return true;
            if ( numChar >= num1 && numChar < (num1 + 10) )
                return true;
            return false;
        }
        /// <summary>
        /// Converts 1 or 2 character string into equivalant byte value
        /// </summary>
        /// <param name="hex">1 or 2 character string</param>
        /// <returns>byte</returns>
        private static byte HexToByte(string hex) {
            if ( hex.Length > 2 || hex.Length <= 0 )
                throw new ArgumentException("hex must be 1 or 2 characters in length");
            byte newByte = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            return newByte;
        }
    }

    public class TextString
    {
        public TextString() {
        }

        public static Byte[] ToByte(String text) {
            Char[] charArray = text.ToCharArray();
            Byte[] retVal = new Byte[charArray.Length];
            for ( Int32 i = 0; i < charArray.Length; i++ ) {
                retVal[i] = Convert.ToByte(charArray[i]);
            }
            return retVal;
        }

        public static String GetFileExtension(String fileName) {
            String extension;
            Int32 startLocation = fileName.LastIndexOf(".");
            if ( startLocation > 0 ) {
                extension = fileName.Substring(startLocation).ToLower();
            } else {
                extension = "";
            }
            return extension;
        }
    }
}
