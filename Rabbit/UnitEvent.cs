using Application.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Rabbit
{
    public class UnitEvent
    {
        public int Id { get; set; }
        public string ToJson() => JsonSerializer.Serialize(
            value: this,
            options: new JsonSerializerOptions { WriteIndented = true });

        public static UnitEvent FromJson(string signalAsJson)
        {
            if (string.IsNullOrWhiteSpace(signalAsJson))
            {
                throw new ArgumentException(
                    message: $"'{nameof(signalAsJson)}' cannot be null or whitespace",
                    paramName: nameof(signalAsJson));
            }

            return JsonSerializer.Deserialize<UnitEvent>(signalAsJson) ??
                throw NewDeserializationException(
                    from: $"{nameof(signalAsJson)} {signalAsJson.GetType().Name}",
                    to: $"{typeof(UnitEvent).Name}");
        }

        public static UnitEvent FromBytes(byte[] bytes)
        {
            if (bytes is null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }

            return JsonSerializer.Deserialize<UnitEvent>(Encoding.UTF8.GetString(bytes)) ??
                throw NewDeserializationException(
                    from: $"{nameof(bytes)} {bytes.GetType().Name}",
                    to: $"{typeof(UnitEvent).Name}");
        }

        private static SerializationException NewDeserializationException(string from, string to) =>
            new SerializationException($"Deserialization from '{from}' to '{to}' failed.");
    }
}
