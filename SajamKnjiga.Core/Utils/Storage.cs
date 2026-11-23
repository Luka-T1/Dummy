using System;
using System.Collections.Generic;
using System.IO;
using SajamKnjiga.Core.Interfaces;

namespace SajamKnjiga.Core.Utils
{
    // Prilagodjeno iz: SerializationExample, Storage.cs (vezbe)
    public class Storage<T> where T : ISerializable, new()
    {
        private readonly string _filePath;
        private readonly Serializer<T> _serializer;

        public Storage(string fileName)
        {
            string folder = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "Data");
            Directory.CreateDirectory(folder);

            _filePath = Path.Combine(folder, fileName);
            _serializer = new Serializer<T>();
        }

        public List<T> Load()
        {
            if (!File.Exists(_filePath))
            {
                FileStream fs = File.Create(_filePath);
                fs.Close();
            }

            IEnumerable<string> lines = File.ReadLines(_filePath);
            return _serializer.FromCSV(lines);
        }

        public void Save(List<T> objects)
        {
            string csv = _serializer.ToCSV(objects);
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                writer.Write(csv);
            }
        }
    }
}