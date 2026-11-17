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
            // iz bin/Debug/net8.0 idemo 4 foldera gore do korena repoa, tu je folder Data
            string folder = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "Data");
            Directory.CreateDirectory(folder);

            _filePath = Path.Combine(folder, fileName);
            _serializer = new Serializer<T>();
        }
    }
}