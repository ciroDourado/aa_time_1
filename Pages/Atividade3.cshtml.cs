using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace aa_time_1.Pages
{
    public class Atividade3Model : PageModel
    {
        private readonly ILogger<Atividade3Model> _logger;

        public Atividade3Model(ILogger<Atividade3Model> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
