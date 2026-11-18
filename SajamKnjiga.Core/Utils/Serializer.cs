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
        
        public List<T> FromCSV(IEnumerable<string> lines)
        {
            List<T> objects = new List<T>();

            foreach (string line in lines)
            {
                // prazne linije na kraju fajla preskacemo
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] values = line.Split(Delimiter);
                T obj = new T();
                obj.FromCSV(values);
                objects.Add(obj);
            }

            return objects;
        }
    }
}