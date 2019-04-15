using System.Collections.Generic;

using MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Xunit;

namespace DomainIntegrationTests
{
	public class MongoInfrastructureTests
	{

		[Fact]
		public void ConnectionCanBeEstablished()
		{
			//TODO: based on https://oz-code.com/blog/how-to-mongodb-in-c-part-2/
			var client = new MongoClient("mongodb://localhost:27017");
			var db = client.GetDatabase("documents");
			var collection = db.GetCollection<Developer>("developers");
			collection.InsertOne(new Developer()
			{
				ID = ObjectId.GenerateNewId(),
				Name = "test"
			});
			
		}


	}
	
	public class Developer
	{
		[BsonId]
		public ObjectId ID { get; set; }
		[BsonElement("name")]
		public string Name { get; set; }
		[BsonElement("company_name")]
		public string CompanyName { get; set; }
		[BsonElement("knowledge_base")]
		public List<Knowledge> KnowledgeBase { get; set; }
	}
 
	public class Knowledge
	{
		[BsonElement("langu_name")]
		public string Language { get; set; }
		[BsonElement("technology")]
		public string Technology { get; set; }
		[BsonElement("rating")]
		public ushort Rating { get; set; }
	}
	
}