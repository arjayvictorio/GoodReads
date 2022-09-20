
using DatabaseService.Models;
using GoodReadsAPI.ClassObjects;
using GoodReadsAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace GoodReadsAPI.Extended
{
    public static class ExtendedBookService
    {
        public static List<Book> GetAll(this BookService bs, ApiContext apiContext)
        {
            var result = apiContext.Books.ToList();

            if (result == null)
                return new();

            return result;
        }

        public static Book Get(this BookService bs, ApiContext apiContext, string name)
        {
            name ??= "";

            var result = apiContext.Books.Where(i => i.Name.Contains(name)).ToList();

            if (result == null || result.Count==0)
                return new();

            return result[0];
        }
    }
}
