using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infraestructure.FileStorage
{
    public interface IAzureStorage
    {
        Task<string> SaveFile(string container, IFormFile file);
        Task<string> EditFile(string container, IFormFile file, string route);
        Task RemoveFile(string container, string route);

    }
}
