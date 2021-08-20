using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace aa_time_1.Pages
{
    public class Atividade1Model : PageModel
    {
        private readonly ILogger<Atividade1Model> _logger;

        public Atividade1Model(ILogger<Atividade1Model> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
