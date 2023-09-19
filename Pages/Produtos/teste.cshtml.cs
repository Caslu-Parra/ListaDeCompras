using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ListaDeCompras.Pages.Produtos
{
    public class teste : PageModel
    {
        private readonly ILogger<teste> _logger;

        public teste(ILogger<teste> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}