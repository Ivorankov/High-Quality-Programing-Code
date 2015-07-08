namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;
    /// <summary>
    /// Class that provides extention methods for string
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts a string into a byte array and hashes it using MD5
        /// </summary>
        /// <param name="input">The string that is to be converted</param>
        /// <returns>A string representation of the hash code converted in hexadecimal format</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }
        /// <summary>
        /// Converts a string value to a boolean value
        /// </summary>
        /// <param name="input">The string that is to be converted</param>
        /// <returns>The boolean representation of the string</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }
        /// <summary>
        /// Converts the string representation of a number to its 16-bit signed intiger equivalent
        /// </summary>
        /// <param name="input">The string that is to be parsed</param>
        /// <returns>The 16-bit integer representation of the string</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }
        /// <summary>
        /// Converts the string representation of a number to its 32-bit signed intiger equivalent
        /// </summary>
        /// <param name="input">The string that is to be parsed</param>
        /// <returns>The 32-bit integer representation of the string</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }
        /// <summary>
        /// Converts the string representation of a number to its 64-bit signed intiger equivalent
        /// </summary>
        /// <param name="input">The string that is to be parsed</param>
        /// <returns>The 64-bit integer representation of the string</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }
        /// <summary>
        /// Converts the specified string representation to its DateTime equivalent
        /// </summary>
        /// <param name="input">The string that is to be parsed</param>
        /// <returns>The DateTime representation of the string</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }
        /// <summary>
        /// Capitalises the first letter from the string
        /// </summary>
        /// <param name="input">The string that is to be alterated</param>
        /// <returns>A new string with a capitalised first letter
        /// or the input string if its null or empty</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }
        /// <summary>
        /// Extracts a substring for a string within a specifyed range
        /// </summary>
        /// <param name="input">The string that will be extracted from</param>
        /// <param name="startString">The start of the substring</param>
        /// <param name="endString">The end of the substring</param>
        /// <param name="startFrom">The starting index to search from</param>
        /// <returns>The substring or an empty string if no match is found</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }
        /// <summary>
        /// Replaces cyrillic chars in a string with theyr cyrillic latin
        /// </summary>
        /// <param name="input">The string that is to be converted</param>
        /// <returns>The new string with latin chars</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }
        /// <summary>
        /// Replaces latin chars in a string with theyr cyrillic representation
        /// </summary>
        /// <param name="input">The string that is to be converted</param>
        /// <returns>The new string with cyrillic chars</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }
        /// <summary>
        /// Converts a string into a valid user name
        /// </summary>
        /// <param name="input">The string that is to be parsed</param>
        /// <returns>The string after its chars are converted into latin
        /// and any chars that are not letters or numbers are removed</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }
        /// <summary>
        /// Converts a string into a valid user name
        /// </summary>
        /// <param name="input">The string that is to be parsed</param>
        /// <returns>The string after its chars are converted into cyrillic
        /// and any chars that are not letters or numbers are removed</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }
        /// <summary>
        /// Returns the speficied amount of chars from the beginning of a string
        /// </summary>
        /// <param name="input">The string that is used for extraction</param>
        /// <param name="charsCount">The amount of chars that wll be extracted</param>
        /// <returns>The specified ammount of chars from left to right in a string format</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }
        /// <summary>
        /// Returns the file extention from a file name
        /// </summary>
        /// <param name="fileName">The file name in string format</param>
        /// <returns>The file extention in string format</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }
        /// <summary>
        /// Returns the content type of a file depending on its extention
        /// </summary>
        /// <param name="fileExtension">The file extention</param>
        /// <returns>The content ascosiated with the extention</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }
        /// <summary>
        /// Converts a string value to a byte array
        /// </summary>
        /// <param name="input">The string that is to be converted</param>
        /// <returns>The string represented as a byte array</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
