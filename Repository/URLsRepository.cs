using System.Collections.Generic;
using System.Linq;
using webdev.Interfaces;
using webdev.Models;
using HashidsNet;


namespace webdev.Repository
{
    public class URLsRepository : IURLsRepository 
    {
        private List<URL> _URLs;

        public URLsRepository()
        {
            

            _URLs = new List<URL>
            {
                new URL { Id = 0, Address = "www.wp.pl" },
                new URL { Id = 1, Address = "www.facebook.com"  }
                
            };
          
        }

        public void AddURL(URL URL) 
        {
            URL.Id = _URLs.Count;
            _URLs.Add(URL);
        }

        public List<URL> GetURLs() 
        {
            var lenghtOfList = _URLs.Count;
            for(var i = 0; i< lenghtOfList; i++)
            {
                     var hashids = new Hashids(_URLs[i].Address);
                     var hash = hashids.Encode(99999213);
                    _URLs[i].HideAddress = hash;
            }
            return _URLs;
        }


        public void Delete(URL URL) 
        {
            var URLToDelete = _URLs
                .SingleOrDefault(element => element.HideAddress == URL.HideAddress && element.Address == URL.Address);
            _URLs.Remove(URLToDelete);
        }

        public void Update(URL URL) 
        {
                var URLToUpdateIndex = _URLs.FindIndex(element => element.Id == URL.Id);
                if(URLToUpdateIndex != -1) 
                _URLs[URLToUpdateIndex] = URL;
        }
    }
}