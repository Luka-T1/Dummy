using System;
using System.Collections.Generic;
using System.Text;
using SajamKnjiga.Core.Interfaces;

namespace SajamKnjiga.Core.Utils
{
    // Prilagodjeno iz: SerializationExample, Serializer.cs (vezbe)
    public class Serializer<T> where T : ISerializable, new()
    {
        private const char Delimiter = '|';

        public string ToCSV(List<T> objects)
        {
            StringBuilder csv = new StringBuilder();

            foreach (T obj in objects)
            {
                string line = string.Join(Delimiter.ToString(), obj.ToCSV());
                csv.AppendLine(line);
            }

            return csv.ToString();
        }
    }
}