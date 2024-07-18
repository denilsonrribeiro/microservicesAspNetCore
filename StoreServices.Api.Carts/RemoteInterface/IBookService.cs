using StoreServices.Api.Carts.RemoteModel;

namespace StoreServices.Api.Carts.RemoteInterface
{
    public interface IBookService
    {
        Task<(bool resultado, BookRemote, string ErrorMessage)> GetBook(Guid bookId);
    }
}
