using ShortURLAPI.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortURLAPI
{
    public interface IShortLinkService
    {
        ShortLink AddShortLink(ShortLink shortLink);
        ShortLink GetShortLink(string shortUrl);
        string GenerateShortLink(string longUrl);
        string GetLongLink(string shortUrl);
    }
}
