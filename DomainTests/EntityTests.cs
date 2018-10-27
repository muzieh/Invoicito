using Domain;
using System;
using Xunit;

namespace DomainTests
{
	public class EntityTests
	{
		[Fact]
		public void When_Entity_Compared_To_NullEntity_Then_False()
		{
			var e = new TestEntityA();
			Assert.False(e == null);
		}
		[Fact]
		public void When_Entity_Compared_To_DifferentTypeEntity_Then_False()
		{
			var aId = Guid.NewGuid();
			var bId = Guid.NewGuid();
			var a = new TestEntityA(aId);
			var b = new TestEntityB(bId);
			Assert.False(a == b);
		}

		[Fact]
		public void When_Entity_Compared_To_SameTypeEntity_DifferentId_Then_False()
		{
			var aId = Guid.NewGuid();
			var bId = Guid.NewGuid();
			var a1 = new TestEntityA(aId);
			var a2 = new TestEntityA(bId);
			Assert.False(a1 == a2);
		}

		[Fact]
		public void When_Entity_Compared_To_SameTypeEntity_SameId_Then_True()
		{
			var id = Guid.NewGuid();
			var a1 = new TestEntityA(id);
			var a2 = new TestEntityA(id);
			Assert.True(a1 == a2);
		}
	}

	public class TestEntityA: Entity
	{
		public TestEntityA()
		{

		}

		public TestEntityA(Guid id)
			:base(id)
		{

		}

	}
	public class TestEntityB : Entity
	{
		public TestEntityB(Guid id)
			:base(id)
		{

		}

	}
}
