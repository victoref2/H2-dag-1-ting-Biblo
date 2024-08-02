using Xunit;
using For_tests;


namespace H2_dag_1_ting_Biblo
{
    public class Tests
    {

        [Fact]
        public void NewUserTest()
        {
            var user = new User { Name = "John Doe", UserId = "123" };
            Assert.Equal("John Doe", user.Name);
            Assert.Equal("123", user.UserId);
            Assert.Empty(user.BorrowedBooks);
        }

        [Fact]
        public void BorrowBookTest()
        {
            var book = new Book { Title = "C# Basics", Author = "Author A", ISBN = "123-456" };
            var user = new User { Name = "John Doe", UserId = "123" };

            var result = user.BorrowBook(book);

            Assert.True(result);
            Assert.False(book.IsAvailable);
            Assert.Contains(book, user.BorrowedBooks);
        }

        [Fact]
        public void ReturnBookTest()
        {
            var book = new Book { Title = "C# Basics", Author = "Author A", ISBN = "123-456" };
            var user = new User { Name = "John Doe", UserId = "123" };

            user.BorrowBook(book);
            user.ReturnBook(book);

            Assert.True(book.IsAvailable);
            Assert.DoesNotContain(book, user.BorrowedBooks);
        }

        [Fact]
        public void AddAndRemoveBookTest()
        {
            var library = new Library();
            var book = new Book { Title = "C# Basics", Author = "Author A", ISBN = "123-456" };

            library.AddBook(book);
            Assert.Contains(book, library.Books);

            library.RemoveBook(book);
            Assert.DoesNotContain(book, library.Books);
        }

        [Fact]
        public void RegisterUserTest()
        {
            var library = new Library();
            var user = new User { Name = "John Doe", UserId = "123" };

            library.RegisterUser(user);
            Assert.Contains(user, library.Users);
        }

        [Fact]
        public void FindBookByISBNTest()
        {
            var library = new Library();
            var book = new Book { Title = "C# Basics", Author = "Author A", ISBN = "123-456" };

            library.AddBook(book);
            var foundBook = library.FindBookByISBN("123-456");

            Assert.Equal(book, foundBook);
        }

        [Fact]
        public void PremiumUserBorrowLimitTest()
        {
            var book1 = new Book { Title = "Book 1", Author = "Author A", ISBN = "123-001" };
            var book2 = new Book { Title = "Book 2", Author = "Author B", ISBN = "123-002" };
            var book3 = new Book { Title = "Book 3", Author = "Author C", ISBN = "123-003" };
            var book4 = new Book { Title = "Book 4", Author = "Author D", ISBN = "123-004" };
            var book5 = new Book { Title = "Book 5", Author = "Author E", ISBN = "123-005" };
            var book6 = new Book { Title = "Book 6", Author = "Author F", ISBN = "123-006" };

            var user = new PremiumUser { Name = "John Doe", UserId = "123" };

            user.BorrowBook(book1);
            user.BorrowBook(book2);
            user.BorrowBook(book3);
            user.BorrowBook(book4);
            user.BorrowBook(book5);

            var result = user.BorrowBook(book6);
            Assert.False(result);
        }



    }

}
