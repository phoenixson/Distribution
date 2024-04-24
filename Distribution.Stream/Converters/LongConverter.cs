using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Distribution.Stream.Converters
{
  public class LongConverter : JsonConverter<long>
  {
    public override bool HandleNull => true;

    public override long Read(
      ref Utf8JsonReader reader,
      Type dataType,
      JsonSerializerOptions options)
    {
      switch (reader.TokenType)
      {
        case JsonTokenType.Null: return 0;
        case JsonTokenType.Number: return reader.GetInt64();
      }

      return long.TryParse(reader.GetString(), out var o) ? o : default;
    }

    public override void Write(
      Utf8JsonWriter writer,
      long modelToWrite,
      JsonSerializerOptions options) =>
      JsonSerializer.Serialize(writer, modelToWrite, modelToWrite.GetType(), options);
  }
}
