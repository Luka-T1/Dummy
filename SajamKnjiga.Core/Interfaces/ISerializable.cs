using System;

namespace SajamKnjiga.Core.Interfaces
{
    // Prilagodjeno iz: SerializationExample, ISerializable.cs (vezbe)
    public interface ISerializable
    {
        string[] ToCSV();
        void FromCSV(string[] values);
    }
}
