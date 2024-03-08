using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AstralForum.Services
{
	public class DateTimeJsonConverter : JsonConverter<DateTime>
	{
		public override DateTime Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options) =>
				DateTime.ParseExact(reader.GetString()!,
					"g", CultureInfo.CurrentCulture);

		public override void Write(
			Utf8JsonWriter writer,
			DateTime dateTimeValue,
			JsonSerializerOptions options) =>
				writer.WriteStringValue(dateTimeValue.ToString(
					"g"));
	}
}