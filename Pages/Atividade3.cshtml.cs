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
        VerticesJson = string.Empty;
        ArestasJson  = string.Empty;
    } // new(args)

    public void OnGet() {
        string[] aoArquivo = {"Dados", "Grafos", "olimpianos.txt"};
        var olimpianosTxt  = Diretorio.FormatarCaminho(aoArquivo);
        var olimpianos     = Arquivo.LerLinhas(olimpianosTxt);

        var genealogia  = new GrafoDirecionado();
        genealogia.Adicionar(olimpianos);

        aoArquivo = new string[]{"Dados", "Grafos", "parentescos.txt"};
        var parentescosTxt = Diretorio.FormatarCaminho(aoArquivo);
        var parentescos    = Arquivo.LerLinhas(parentescosTxt);

        foreach (var parentesco in parentescos) {
            var grau  = parentesco.Split(',');
            var pai   = grau[0];
            var filho = grau[1];
            genealogia.Conectar(pai, filho);
        }
        VerticesJson = genealogia.VerticesEmJson();
        ArestasJson  = genealogia.ArestasEmJson();
    }
} // public class Atividade3Model: PageModel
} // namespace aa_time_1.Pages
