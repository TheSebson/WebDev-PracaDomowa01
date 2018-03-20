using System.Collections.Generic;
using webdev.Models;

namespace webdev.Interfaces
{
    public interface IURLsRepository
    {
         List<URL> GetURLs();
         void AddURL(URL URL);
         void Delete(URL URL);
         void Update(URL URL);

    }
}