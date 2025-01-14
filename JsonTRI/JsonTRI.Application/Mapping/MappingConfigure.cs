using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using JsonTRI.Domain.Entities;
using JsonTRI.Application.Mapping.GetDto;
using JsonTRI.Application.Mapping.PutDto;

namespace JsonTRI.Application.Mapping
{
    public static class MappingConfigure
    {
        public static void Configure()
        {
            TypeAdapterConfig<Author, GetAuthorDto>.NewConfig();
            TypeAdapterConfig<Author, PutAuthorDto>.NewConfig();

            TypeAdapterConfig<Book, GetBookDto>.NewConfig();
            TypeAdapterConfig<Book, PutBookDto>.NewConfig();

            TypeAdapterConfig<BorrowRecord, GetBorrowRecordDto>.NewConfig();
            TypeAdapterConfig<BorrowRecord, PutBorrowRecordDto>.NewConfig();

            TypeAdapterConfig<Library, GetLibraryDto>.NewConfig();
            TypeAdapterConfig<Library, PutLibraryDto>.NewConfig();
        }
    }
}
