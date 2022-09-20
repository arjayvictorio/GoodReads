using DatabaseService.Models;

namespace GoodReadsAPI.Interfaces
{
    public interface IBookService
    {
        Book Save(Book book);
    }
}
