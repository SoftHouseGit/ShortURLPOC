using ShortURLAPI.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortURLAPI.Services
{
    public class ShortLinkService : IShortLinkService
    {
        public ShortURLAPI.Model.MyAppDbContext _DbContext;
        public ShortLinkService(ShortURLAPI.Model.MyAppDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        /// <summary>
        /// Add short Link to database ascoiated with long link
        /// </summary>
        /// <param name="shortLink"></param>
        /// <returns>ShortLink</returns>
        public ShortLink AddShortLink(ShortLink shortLink)
        {
            _DbContext.Add(shortLink);
            _DbContext.SaveChanges();
            return shortLink;
        }

        /// <summary>
        /// Get Long Link
        /// </summary>
        /// <param name="shortUrl"></param>
        /// <returns>string</returns>
        public string GetLongLink(string shortUrl)
        {
            var shortLink = GetShortLink(shortUrl);
            if (shortLink == null)
            {
                return null;
            }
            return GetShortLink(shortUrl).LongUrl;
        }

        /// <summary>
        /// Generate Short Link
        /// </summary>
        /// <param name="longUrl"></param>
        /// <returns>string</returns>
        public string GenerateShortLink(string longUrl)
        {
            string shortURL = "";
            shortURL = ShortUrlGenerator.GetURL();
            if (GetShortLink(shortURL) != null)
            {
                // Generate a new URL because the previous one had a match.  
                shortURL = ShortUrlGenerator.GetURL();
            }
            ShortLink shortLink = new ShortLink
            {
                LongUrl = longUrl,
                ShortUrl = shortURL,
                Date = DateTime.Now
            };
            AddShortLink(shortLink);
            return shortURL;
        }

        /// <summary>
        /// Get Short Link
        /// </summary>
        /// <param name="shortUrl"></param>
        /// <returns>ShortLink</returns>
        public ShortLink GetShortLink(string shortUrl)
        {
           return _DbContext.ShortLinks.Where(x => x.ShortUrl == shortUrl).FirstOrDefault();
        }
    }
}
