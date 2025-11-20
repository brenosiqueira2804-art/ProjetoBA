using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ProjetoBA-master.Views
{
    public class Index.html : PageModel
    {
        private readonly ILogger<Index.html> _logger;

        public Index.html(ILogger<Index.html> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}