using week9exercise.services;
using week9exercise.models.requests;
using week9exercise.models.responses;

LiveApiService apiService = new LiveApiService();


// Call for our books, and await this calls completion.
List<BookResponse> books = await apiService.RetrieveBooks();
// Iterate through our books and display them to the console.
books.ForEach(book => {
Console.WriteLine("-----------");
Console.WriteLine($"{book.id} | {book.title} | {book.publicationDate}");
Console.WriteLine("\t" + book.synopsis);
Console.WriteLine("\tAuthors: ");
book.authors.ForEach(author => {
Console.WriteLine($"\t\t{author.id} | {author.firstName} | {author.lastName}");
});
Console.WriteLine("\t\tGenres: ");
book.genres.ForEach(genre => {
Console.WriteLine($"\t\t{genre.id} | {genre.name} | {genre.description}");
});
Console.WriteLine("-----------");
});




Book request = new Book{title = "The Hobbit", synopsis = "A hobbit goes on an adventure", publicationDate = new DateOnly(1937, 9, 21), isbn = "9786546541", authorIds = new List<int>{1, 2}, genreIds = new List<int>{1, 2}};

BookResponse newBook = await apiService.CreateBook(request);
Console.WriteLine($"New book created with id: {newBook.id}");









// Book? myBook = await apiService.RetrieveBookById(1);

// Console.WriteLine($"book id: {myBook.id}");
// Console.WriteLine($"book title: {myBook.title}");
// Console.WriteLine($"book synopsis: {myBook.synopsis}");
// Console.WriteLine($"book publication date: {myBook.publicationDate}");
// Console.WriteLine($"book isbn: {myBook.isbn}");
// Console.WriteLine($"book authors: {myBook.authors}");
// Console.WriteLine($"book genres: {myBook.genres}");

// Task<Book?> bookTask1 = apiService.RetrieveBookById(1);
// Task<Book?> bookTask2 = apiService.RetrieveBookById(2);
// Task<Book?> bookTask3 = apiService.RetrieveBookById(3);
// Task<Book?> bookTask4 = apiService.RetrieveBookById(4);
// Task<Book?> bookTask5 = apiService.RetrieveBookById(5);

// List<Task<Book?>> bookTasks = [bookTask1, bookTask2, bookTask3, bookTask4, bookTask5];

// await Task.WhenAll(bookTasks);

// bookTasks.ForEach(task => {
//     Book? book = task.Result;
//     Console.WriteLine($"book id: {book.id}");
//     Console.WriteLine($"book title: {book.title}");
//     Console.WriteLine($"book synopsis: {book.synopsis}");
//     Console.WriteLine($"book publication date: {book.publicationDate}");
//     Console.WriteLine($"book isbn: {book.isbn}");
//     Console.WriteLine($"book authors: {book.authors}");
//     Console.WriteLine($"book genres: {book.genres}");
// });

// List<Book>> bookTask1 = await apiService.RetrieveBooks();
// books.ForEach(Book => {
//     Console.WriteLine($"book id: {book.id}");
//     Console.WriteLine($"book title: {book.title}");
//     Console.WriteLine($"book synopsis: {book.synopsis}");
//     Console.WriteLine($"book publication date: {book.publicationDate}");
//     Console.WriteLine($"book isbn: {book.isbn}");
//     Console.WriteLine($"book authors: {book.authors}");
//     Console.WriteLine($"book genres: {book.genres}");
// });

// await apiService.DeleteBookById(1);
// Console.WriteLine("Book with id 1 deleted");

// Book request = new Book{UserId = 1, title = "The Hobbit", synopsis = "A hobbit goes on an adventure", publicationDate = new DateOnly(1937, 9, 21), isbn = "978-0-395-08254-1", authorIds = new List<int>{1, 2}, genreIds = new List<int>{1, 2}};

// await apiService.UpdateBook(request, 1);
// Console.WriteLine("Book with id 1 updated");