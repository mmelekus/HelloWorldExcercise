using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Linq;

namespace FileAccess
{
    public static class CSVFileParser
    {
        /// <summary>
        /// Reads a delimited file and returns each line as a string array with a yield return
        /// </summary>
        /// <param name="file">Full path and file name of file to read</param>
        /// <param name="delimiter">The delimiter used in the file, default is a comma (,)</param>
        /// <returns>Each line of the file is returned as an enumerable string array</returns>
        public static IEnumerable<string[]> ReadDelimitedFile(string file, char delimiter = ',')
        {
            string line;
            using (var reader = File.OpenText(file))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line.Split(delimiter);
                }
            }
        }

        /// <summary>
        /// Parse a string array into a new instance object of type TModel
        /// </summary>
        /// <typeparam name="TModel">Generic type of object to instantiate</typeparam>
        /// <param name="line">String array of data elements to parse into the object</param>
        /// <param name="header">String array of header/object property names to map data elements to properties in the object</param>
        /// <returns></returns>
        public static TModel ParseLine<TModel>(this string[] line, string[] header)
        {
            TModel item = Activator.CreateInstance<TModel>();
            Type t = item.GetType();

            for (var i = 0; i < line.Length; i++)
            {
                string column = header[i].Trim(' ', '"');
                string value = line[i].Trim(' ', '"');
                PropertyInfo prop = t.GetProperty(column);
                prop?.SetValue(item, value, null);
            }

            return item;
        }
    }
}
