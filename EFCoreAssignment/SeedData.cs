using EFCoreAssignment.Domain.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace EFCoreAssignment.Infrastructure
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider, AppDbContext context)
        {
            if (context.Authors.Any() && context.Books.Any() && context.Libraries.Any() && context.BorrowRecords.Any()) return;

            var jsonString = File.ReadAllText("json3.json");
            var data = JsonConvert.DeserializeObject<SeedDataModel>(jsonString);

            context.Authors.AddRange(data.Authors.Select(a => new Author
            {
                AuthorId = a.AuthorId,
                Name = a.Name,
                Country = a.Country,
                BirthYear = a.BirthYear,
                DeathYear = a.DeathYear
            }));

            context.Books.AddRange(data.Books.Select(b => new Book
            {
                BookId = b.BookId,
                AuthorId = b.AuthorId,
                Title = b.Title,
                Genre = b.Genre,
                PublicationYear = b.PublicationYear,
                CopiesAvailable = b.CopiesAvailable
            }));

            context.Libraries.AddRange(data.Libraries.Select(l => new Library
            {
                LibraryId = l.LibraryId,
                Name = l.Name,
                Location = l.Location,
                EstablishedYear = l.EstablishedYear
            }));

            context.BorrowRecords.AddRange(data.BorrowRecords.Select(br => new BorrowRecord
            {
                BorrowRecordId = br.BorrowRecordId,
                BookId = br.BookId,
                LibraryId = br.LibraryId,
                BorrowerName = br.BorrowerName,
                BorrowDate = DateTime.Parse(br.BorrowDate),
                ReturnDate = string.IsNullOrEmpty(br.ReturnDate) ? (DateTime?)null : DateTime.Parse(br.ReturnDate)
            }));

            context.SaveChanges();
        }
    }
}
