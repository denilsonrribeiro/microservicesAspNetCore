using AutoMapper;
using Castle.Components.DictionaryAdapter;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using StoreServices.Api.Books.Application;
using StoreServices.Api.Books.Application.Dto;
using StoreServices.Api.Books.Data;
using StoreServices.Api.Books.Model;
using Xunit;

namespace StoreServices.Api.Books.Test
{
    public class BookServiceTest
    {
        private IEnumerable<Book> GenerateFakeBookList()
        {
            A.Configure<Book>()
                .Fill(x => x.Title).AsArticleTitle()
                .Fill(x => x.Id, () => { return Guid.NewGuid(); });

            var books = A.ListOf<Book>(30);
            books[0].Id = Guid.Empty;

            return books;
        }

        private Mock<ContextBook> CreateContext()
        {
            var resultBooks = GenerateFakeBookList().AsQueryable();
            var dbSet = new Mock<DbSet<Book>>();
            dbSet.As<IQueryable<Book>>().Setup(x => x.Provider).Returns(resultBooks.Provider);
            dbSet.As<IQueryable<Book>>().Setup(x => x.Expression).Returns(resultBooks.Expression);
            dbSet.As<IQueryable<Book>>().Setup(x => x.ElementType).Returns(resultBooks.ElementType);
            dbSet.As<IQueryable<Book>>().Setup(x => x.GetEnumerator()).Returns(resultBooks.GetEnumerator());

            dbSet.As<IAsyncEnumerable<Book>>().Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
                .Returns(new AsyncEnumerator<Book>(resultBooks.GetEnumerator()));

            dbSet.As<IQueryable<Book>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<Book>(resultBooks.Provider));

            var context = new Mock<ContextBook>();
            context.Setup(x => x.Books).Returns(dbSet.Object);
            return context;
        }

        [Fact]
        public async void GetBookById()
        {
            var mockContext = CreateContext();

            var mapConfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new MappingTest());
            });

            var mapper = mapConfig.CreateMapper();

            var request = new QueryFilter.Execute();
            request.BookId = Guid.Empty;
            
            var handler = new QueryFilter.Handler(mockContext.Object, mapper);
            var book = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.NotNull(book);
            Assert.True(book.Id == Guid.Empty);
        }

        [Fact]
        public async void GetBooks()
        {
            //System.Diagnostics.Debugger.Launch();
            //que metodo dentor de meu microservice Book está encarregado de realizar a
            //consulta dos Books na base de dados, ou seja, qua service(regra de negócio)
            //deve-se adicionar o projeto que contém a regra de negócio como dependência do projeto Test, 
            //ou seja, dentro do projeto Test.
            //1 Temos que emular(simular) o objeto MediatR, neste caso, mas no caso de usar Repository e Context,
            //devemos usar o objeto Mock

            var mockContext = CreateContext();
            //2 Simular o mapping IMapper
            var mapConfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new MappingTest());
            });
            var mapper = mapConfig.CreateMapper();
            //3 Instanciar a classe Handler e passar como parâmetros, os mocks que foram criados
            var handler = new Query.Handler(mockContext.Object, mapper);
            var request = new Query.Execute();

            var listaBooks = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.True(listaBooks.Any());
        }

        [Fact]
        public async void CreateBook()
        {
            var options = new DbContextOptionsBuilder<ContextBook>()
                .UseInMemoryDatabase(databaseName: "dbBooks")
                .Options;

            var context = new ContextBook(options);

            var request = new New.Execute();
            request.Title = "Build Microservices";
            request.AuthorId = Guid.Empty;
            request.PublishDate = DateTime.Now;

            var handler = new New.Handler(context);
            await handler.Handle(request, new System.Threading.CancellationToken());

            //Este método de teste faltou o Assert, então não está completo.

        }
    }
}
