using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DomainTests
{
	public class ValueObjectTests
	{
		[Fact]
		public void When_Compare2DifferentTypesOfValueType_Then_False()
		{
			var a = new TestValueObjectA();
			var b = new TestValueObjectB();

			Assert.False(a.Equals(b));
		}

		[Fact]
		public void When_CompareValueObjectToNull_Then_False()
		{
			var a = new TestValueObjectA();
			Assert.False(a.Equals(null));
		}

		[Fact]
		public void When_CompareValueObjectWithItself_Then_False()
		{
			var a = new TestValueObjectA();
			Assert.False(a.Equals(null));
		}

		[Fact]
		public void When_ValueObjectEqualCalls_Then_EqualCoreInvoked()
		{
			var a = new TestValueObjectA();
			a.Equals(a);
			Assert.True(a.equalsCalled);
		}

		[Fact]
		public void When_ValueObjectCompareToNull_Then_False()
		{
			var a = new TestValueObjectA();
			Assert.False(a == null);
		}

		[Fact]
		public void When_ValueObjectNullCompareToNull_Then_True()
		{
			TestValueObjectA a = null;
			Assert.True(a == null);
		}


	}

	public class TestValueObjectA : Domain.ValueObject<TestValueObjectA>
	{
		public int Prop1;
		public int Prop2;
		public bool equalsCalled = false;
		public override bool EqualsCore(TestValueObjectA other)
		{
			equalsCalled = true;
			return true;
		}

		public override int GetHashCodeCore()
		{
			throw new NotImplementedException();
		}
	}

	public class TestValueObjectB : Domain.ValueObject<TestValueObjectB>
	{
		public override bool EqualsCore(TestValueObjectB other)
		{
			throw new NotImplementedException("EqualsCore not implemented");
		}

		public override int GetHashCodeCore()
		{
			throw new NotImplementedException();
		}
	}
}
