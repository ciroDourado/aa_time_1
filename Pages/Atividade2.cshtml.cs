using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace aa_time_1.Pages
{
    public class Atividade2Model : PageModel
    {
        private readonly ILogger<Atividade2Model> _logger;

        public Atividade2Model(ILogger<Atividade2Model> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
