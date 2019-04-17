using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain
{
	public abstract class Entity
	{
		public Entity()
			:this(ObjectId.GenerateNewId())
		{
		}

		public Entity(ObjectId id)
		{
			this.Id = id;
		}
		//TODO: shouldn't be private set? would break test
		[BsonId]
		public ObjectId Id { get; private set; }

		public override bool Equals(object obj)
		{
			var other = obj as Entity;
			if(other == null)
			{
				return false;
			}
			if(ReferenceEquals(this, other))
			{
				return true;
			}

			if(GetType() != other.GetType())
			{
				return false;
			}

			if(this.Id == ObjectId.Empty|| other.Id == ObjectId.Empty)
			{
				return false;
			}

			return this.Id == other.Id;
		}

		public static bool operator ==(Entity a, Entity b)
		{
			if( ReferenceEquals(a, null) && ReferenceEquals(b, null))
			{
				return true;
			}

			if( ReferenceEquals(a, null) || ReferenceEquals(b, null))
			{
				return false;
			}
			

			return a.Equals(b);
		}

		public static bool operator !=(Entity a, Entity b)
		{
			return !(a == b);
		}

		public override int GetHashCode()
		{
			return (GetType().ToString() + Id.ToString()).GetHashCode();
		}
	}
}
