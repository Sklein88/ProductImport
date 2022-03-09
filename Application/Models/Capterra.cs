using Application.Utils;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace Application.Models
{
    public class Capterra : IClient
    {
        public int Id { get; set; }
        public string Name { get { return "Capterra"; } }

        public List<IProduct> Deserealize(StreamReader reader)
        {
			var stream = new YamlStream();
			stream.Load(reader);

			var deserializer = new DeserializerBuilder()
				.Build();

			var items = deserializer.Deserialize<List<CapterraProduct>>(new EventStreamParserAdapter(YamlNodeToEventStreamConverter.ConvertToEventStream(stream)));

            return items.ToList<IProduct>();
        }
    }
}
