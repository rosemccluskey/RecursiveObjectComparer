﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecursiveObjectComparerTool;
using RecursiveObjectComparerTool.Models;

namespace UnitTests
{
    [TestClass]
    public class ComparerTests
    {
        [TestMethod]
        public void BasicEqualityTests()
        {
            Assert.AreEqual(0, true.CompareTo(true), typeof(bool).Name);
            Assert.AreEqual(0, byte.MaxValue.CompareTo(byte.MaxValue), typeof(byte).Name);
            Assert.AreEqual(0, sbyte.MaxValue.CompareTo(sbyte.MaxValue), typeof(sbyte).Name);
            Assert.AreEqual(0, char.MaxValue.CompareTo(char.MaxValue), typeof(char).Name);
            Assert.AreEqual(0, decimal.MaxValue.CompareTo(decimal.MaxValue), typeof(decimal).Name);
            Assert.AreEqual(0, double.MaxValue.CompareTo(double.MaxValue), typeof(double).Name);
            Assert.AreEqual(0, float.MaxValue.CompareTo(float.MaxValue), typeof(float).Name);
            Assert.AreEqual(0, int.MaxValue.CompareTo(int.MaxValue), typeof(int).Name);
            Assert.AreEqual(0, uint.MaxValue.CompareTo(uint.MaxValue), typeof(uint).Name);
            Assert.AreEqual(0, long.MaxValue.CompareTo(long.MaxValue), typeof(long).Name);
            Assert.AreEqual(0, ulong.MaxValue.CompareTo(ulong.MaxValue), typeof(ulong).Name);
            Assert.AreEqual(0, short.MaxValue.CompareTo(short.MaxValue), typeof(short).Name);
            Assert.AreEqual(0, ushort.MaxValue.CompareTo(ushort.MaxValue), typeof(ushort).Name);
            Assert.AreEqual(0, "one".CompareTo("one"), typeof(string).Name);
            Assert.AreEqual(0, ContactMethods.Email.CompareTo(ContactMethods.Email), ContactMethods.Email.GetType().Name);
            Assert.AreEqual(0, new TestObject().CompareTo(new TestObject()), typeof(TestObject).Name);
        }

        [TestMethod]
        public void BasicInequalityTests()
        {
            Assert.AreEqual(1, true.CompareTo(false), typeof(bool).Name);
            Assert.IsTrue(byte.MinValue.CompareTo(byte.MaxValue) < 0, typeof(byte).Name);
            Assert.IsTrue(sbyte.MinValue.CompareTo(sbyte.MaxValue) < 0, typeof(sbyte).Name);
            Assert.IsTrue(char.MinValue.CompareTo(char.MaxValue) < 0, typeof(char).Name);
            Assert.IsTrue(decimal.MinValue.CompareTo(decimal.MaxValue) < 0, typeof(decimal).Name);
            Assert.IsTrue(double.MinValue.CompareTo(double.MaxValue) < 0, typeof(double).Name);
            Assert.IsTrue(float.MinValue.CompareTo(float.MaxValue) < 0, typeof(float).Name);
            Assert.IsTrue(int.MinValue.CompareTo(int.MaxValue) < 0, typeof(int).Name);
            Assert.IsTrue(uint.MinValue.CompareTo(uint.MaxValue) < 0, typeof(uint).Name);
            Assert.IsTrue(long.MinValue.CompareTo(long.MaxValue) < 0, typeof(long).Name);
            Assert.IsTrue(ulong.MinValue.CompareTo(ulong.MaxValue) < 0, typeof(ulong).Name);
            Assert.IsTrue(short.MinValue.CompareTo(short.MaxValue) < 0, typeof(short).Name);
            Assert.IsTrue(ushort.MinValue.CompareTo(ushort.MaxValue) < 0, typeof(ushort).Name);
            Assert.IsTrue("one".CompareTo("two") < 0, typeof(string).Name);
            Assert.IsTrue(ContactMethods.Unknown.CompareTo(ContactMethods.Email) < 0, ContactMethods.Email.GetType().Name);

            var t1 = new TestObject(6, "beluga", new List<string>(), new InternalTestObject(ContactMethods.Email, 'Q'));
            Assert.IsTrue(t1.CompareTo(new TestObject()) > 0, typeof(TestObject).Name);
        }

        [TestMethod]
        public void DoesNotReturnZeroWhenInnerComplexPropertiesDontMatch()
        {
            var o1 = new TestObject();
            var o2 = new TestObject { T = new InternalTestObject(ContactMethods.Email, 'Q') };

            Assert.AreNotEqual(0, o1.CompareTo(o2));
        }

        [TestMethod]
        [DataRow(true)]
        [DataRow(byte.MaxValue)]
        [DataRow(sbyte.MinValue)]
        [DataRow(char.MaxValue)]
        [DataRow(double.MaxValue)]
        [DataRow(float.MaxValue)]
        [DataRow(int.MaxValue)]
        [DataRow(uint.MaxValue)]
        [DataRow(long.MaxValue)]
        [DataRow(ulong.MaxValue)]
        [DataRow(short.MaxValue)]
        [DataRow(ushort.MaxValue)]
        [DataRow(ContactMethods.Facebook)]
        public void ListEqualityTests(object input)
        {
            var l1 = Enumerable.Repeat(input, 5).ToList();
            var l2 = Enumerable.Repeat(input, 5).ToList();
            Assert.AreEqual(0, l1.CompareTo(l2), input.GetType().Name);
        }

        [TestMethod]
        public void MoreListEqualityTests()
        {
            var d1 = Enumerable.Repeat(decimal.MinValue, 5).ToList();
            var d2 = Enumerable.Repeat(decimal.MinValue, 5).ToList();

            Assert.AreEqual(0, d1.CompareTo(d2), d1.GetType().Name);

            var t1 = Enumerable.Repeat(new TestObject(), 5).ToList();
            var t2 = Enumerable.Repeat(new TestObject(), 5).ToList();

            Assert.AreEqual(0, t1.CompareTo(t2));

            var s1 = Enumerable.Repeat("a", 5).ToList();
            var s2 = Enumerable.Repeat("a", 5).ToList();

            Assert.AreEqual(0, s1.CompareTo(s2), typeof(string).Name);
        }

        [TestMethod]
        [DataRow(false, true)]
        [DataRow(byte.MinValue, byte.MaxValue)]
        [DataRow(sbyte.MinValue, sbyte.MaxValue)]
        [DataRow(char.MinValue, char.MaxValue)]
        [DataRow(double.MinValue, double.MaxValue)]
        [DataRow(float.MinValue, float.MaxValue)]
        [DataRow(int.MinValue, int.MaxValue)]
        [DataRow(uint.MinValue, uint.MaxValue)]
        [DataRow(long.MinValue, long.MaxValue)]
        [DataRow(ulong.MinValue, ulong.MaxValue)]
        [DataRow(short.MinValue, short.MaxValue)]
        [DataRow(ushort.MinValue, ushort.MaxValue)]
        [DataRow(ContactMethods.Unknown, ContactMethods.Email)]
        public void ListInequalityTests(object input1, object input2)
        {
            var l1 = Enumerable.Repeat(input1, 5).ToList();
            var l2 = Enumerable.Repeat(input2, 5).ToList();
            Assert.IsTrue(l1.CompareTo(l2) < 0, input1.GetType().Name);
        }

        [TestMethod]
        public void MoreListInequalityTests()
        {
            var d1 = Enumerable.Repeat(decimal.MinValue, 5).ToList();
            var d2 = Enumerable.Repeat(decimal.MaxValue, 5).ToList();

            Assert.AreEqual(-1, d1.CompareTo(d2), d1.GetType().Name);

            var t1 = Enumerable.Repeat(new TestObject(0, "a", new object(), new InternalTestObject()), 5).ToList();
            var t2 = Enumerable.Repeat(new TestObject(1, "z", new object(), new InternalTestObject()), 5).ToList();

            Assert.AreEqual(-1, t1.CompareTo(t2));

            var s1 = Enumerable.Repeat("aaa", 5).ToList();
            var s2 = Enumerable.Repeat("zzz", 5).ToList();

            Assert.IsTrue(s1.CompareTo(s2) < 0, typeof(string).Name);

        }

        [TestMethod]
        public void ValueTypeTestReturnsZeroWhenMatches()
        {
            var address = new Address
            {
                AddressLine1 = "PO Box 123",
                City = "Morgantown",
                State = "WV",
                PostCode = "26505",
                Country = "USA"
            };

            var address2 = new Address
            {
                AddressLine1 = "PO Box 123",
                City = "Morgantown",
                State = "WV",
                PostCode = "26505",
                Country = "USA"
            };

            var compareResult = address.CompareTo(address2);

            Assert.AreEqual(0, compareResult);
        }

        [TestMethod]
        public void ValueTypeTestReturnsNotZeroWhenDoesNotMatch()
        {
            var addresses = DataFactory.GetAddresses(2);

            Assert.AreNotEqual(0, addresses.First().CompareTo(addresses.Last()));
        }

        [TestMethod]
        public void ValueTypeTestReturnsNegativeWhenComesFirst()
        {
            var address1 = DataFactory.GetAddresses(1).First();
            address1.AddressLine1 = "AAA";

            var address2 = new Address
            {
                AddressLine1 = "ZZZ",
                AddressLine2 = address1.AddressLine2,
                Country = address1.Country,
                City = address1.City,
                PostCode = address1.PostCode,
                State = address1.State
            };

            var compareResult = address1.CompareTo(address2);
            Assert.IsTrue(compareResult < 0);
        }

        [TestMethod]
        public void ValueTypeTestReturnsPositiveWhenComesSecond()
        {
            var address1 = DataFactory.GetAddresses(1).First();
            address1.AddressLine1 = "ZZZ";
            var address2 = new Address
            {
                AddressLine1 = "AAA",
                AddressLine2 = address1.AddressLine2,
                Country = address1.Country,
                City = address1.City,
                PostCode = address1.PostCode,
                State = address1.State
            };

            var compareResult = address1.CompareTo(address2);
            Assert.IsTrue(compareResult > 0);
        }

        [TestMethod]
        public void ComparerRecursesIntoComplexTypes()
        {
            var contactList = DataFactory.GetContactList(2);
            var personOne = contactList.Contacts.First();
            var personTwo = contactList.Contacts.Last();

            Assert.AreNotEqual(personOne.FullName, personTwo.FullName, "Setup failed, contact list contains same people");

            // make basic props match, should not match at list level
            personTwo.LastName = personOne.LastName;
            personTwo.FirstName = personOne.FirstName;

            Assert.AreNotEqual(0, personOne.CompareTo(personTwo));
        }

        [TestMethod]
        public void ComparerReturnsZeroWhenMatches()
        {
            var contactList = DataFactory.GetContactList(1);
            var personOne = contactList.Contacts.First();

            var personTwo = new Person
            {
                FirstName = personOne.FirstName,
                LastName = personOne.LastName,
            };

            foreach (var address in personOne.Addresses)
            {
                personTwo.Addresses.Add(new Address
                {
                    AddressLine1 = address.AddressLine1,
                    AddressLine2 = address.AddressLine2,
                    City = address.City,
                    Country = address.Country,
                    PostCode = address.PostCode,
                    State = address.State
                });
            }

            foreach (var c in personOne.ContactMethods)
            {
                personTwo.ContactMethods.Add(new ContactMethod
                {
                    Info = c.Info,
                    Method = c.Method
                });
            }

            Assert.AreEqual(0, personOne.CompareTo(personTwo));

        }
    }

    public class TestObject
    {
        public TestObject()
        {
            Id = 1;
            S = "Hello";
            T = new InternalTestObject();
            T2 = new InternalTestObject();
        }

        public TestObject(int i, string s, object o, InternalTestObject o2)
        {
            Id = i;
            S = s;
            T = o;
            T2 = o2;
        }

        public int Id { get; set; }
        public string S { get; set; }
        public object T { get; set; }
        public InternalTestObject T2 { get; set; }
    }

    public class InternalTestObject
    {
        public InternalTestObject()
        {
            EnumType = ContactMethods.Unknown;
            MyChar = 'c';
        }

        public InternalTestObject(ContactMethods e, char c)
        {
            EnumType = e;
            MyChar = c;
        }

        public ContactMethods EnumType { get; set; }

        public char MyChar { get; set; }
    }
}