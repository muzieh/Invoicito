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
			var a = new TestEntityA() { Id = 1 };
			var b = new TestEntityB() { Id = 1 };
			Assert.False(a == b);
		}

		[Fact]
		public void When_Entity_Compared_To_SameTypeEntity_DifferentId_Then_False()
		{
			var a1 = new TestEntityA() { Id = 1 };
			var a2 = new TestEntityA() { Id = 2 };
			Assert.False(a1 == a2);
		}

		[Fact]
		public void When_Entity_Compared_To_SameTypeEntity_SameId_Then_True()
		{
			var a1 = new TestEntityA() { Id = 1 };
			var a2 = new TestEntityA() { Id = 1 };
			Assert.True(a1 == a2);
		}
	}

	public class TestEntityA : Entity
	{

	}
	public class TestEntityB : Entity
	{

	}
}
