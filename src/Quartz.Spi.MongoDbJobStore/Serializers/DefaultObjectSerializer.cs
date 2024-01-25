using System.Text;
using System.Text.Json;
using Quartz.Spi;

namespace Quartz.Simpl
{
    /// <summary>
    /// Default object serialization strategy that uses <see cref="JsonSerializer" /> 
    /// under the hood.
    /// </summary>
    /// <author>Marko Lahma</author>
    public class DefaultObjectSerializer : IObjectSerializer
    {
        public void Initialize()
        {
        }

        /// <summary>
        /// Serializes given object as bytes 
        /// that can be stored to permanent stores.
        /// </summary>
        /// <param name="obj">Object to serialize.</param>
        public byte[] Serialize<T>(T obj) where T : class
        {
            var resultString = JsonSerializer.Serialize(obj);
            var bytes = Encoding.UTF8.GetBytes(resultString);

            return bytes;
        }

        /// <summary>
        /// Deserializes object from byte array presentation.
        /// </summary>
        /// <param name="data">Data to deserialize object from.</param>
        public T DeSerialize<T>(byte[] data) where T : class
        {
            var dataString = Encoding.UTF8.GetString(data);
            var obj = JsonSerializer.Deserialize<T>(dataString);
            
            return obj;
        }
    }
}
