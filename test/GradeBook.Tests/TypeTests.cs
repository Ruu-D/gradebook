using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {

        [Fact]
        public void ValueTypeAlsoPassByValue()
        // Looking at the 'public class TypeTests' = Whenever working with something defined as a 'class', we are working with a reference type.

        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref object z)
        // private void SetInt(ref int z)
        {
            // z = 42.3;      // Results in compiler error when 'Assert.Equal(42, x)' is expecting 42.
            z = 42;
        }

        private object GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(out book1, "This is a new name");
            // GetBookSetName(out book1, "This is a new name");

            Assert.Equal("This is a new name", book1.Name);
                // X unit test will fail if = string name inside 'GetBookSetName' != [is not equal to] above 'Assert' instruction. 
        }

        private void GetBookSetName(out Book book, string name)
        //private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
            // this line must be here, forced to 'initialize' the parameter because of the 'out' instruction (equal to 'ref').
        }



        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }


        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }
        

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
