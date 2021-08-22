using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using System;

using Grafos;
using ES;

namespace aa_time_1.Pages {

public class Atividade3Model: PageModel {
    private readonly ILogger<Atividade3Model> _logger;
    public string VerticesJson { get; set; }
    public string ArestasJson  { get; set; }

    public Atividade3Model(ILogger<Atividade3Model> logger) {
        _logger = logger;
    } // new(args)

    public void OnGet() {
        string[] aoArquivo = {"Dados", "Grafos", "olimpianos.txt"};
        var olimpianosTxt  = Diretorio.FormatarCaminho(aoArquivo);
        var genealogia  = new GrafoDirecionado();
        var olimpianos  = Arquivo.LerLinhas(olimpianosTxt);

        genealogia.Adicionar(olimpianos);
        VerticesJson = genealogia.VerticesEmJson();
    }
} // public class Atividade3Model: PageModel
} // namespace aa_time_1.Pages
