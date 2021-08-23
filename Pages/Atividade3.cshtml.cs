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
    private GrafoDirecionado genealogia;
    public string VerticesJson { get; set; }
    public string ArestasJson  { get; set; }

    public Atividade3Model(ILogger<Atividade3Model> logger) {
        _logger      = logger;
        ArestasJson  = string.Empty;
        VerticesJson = string.Empty;
        genealogia   = new GrafoDirecionado();

        AdicionarDeuses(genealogia);
        AdicionarRelacoesHereditarias(genealogia);
        AdicionarRelacoesConjugais(genealogia);
    } // new(args)

    private void AdicionarDeuses(GrafoDirecionado grafo) {
        string[] aoArquivo = {"Dados", "Grafos", "olimpianos.txt"};
        var olimpianosTxt  = Diretorio.FormatarCaminho(aoArquivo);
        var olimpianos     = Arquivo.LerLinhas(olimpianosTxt);
        //
        foreach (var olimpiano in olimpianos) {
            var infos = olimpiano.Split(',');
            var nome  = infos[0];
            var sexo  = infos[1];
            grafo.Adicionar(new Vertice(nome, sexo));
        }
    } // AdicionarDeuses

    private void AdicionarRelacoesHereditarias(GrafoDirecionado grafo) {
        string[] aoArquivo = {"Dados", "Grafos", "hereditariedades.txt"};
        var hereditariedadesTxt = Diretorio.FormatarCaminho(aoArquivo);
        var hereditariedades    = Arquivo.LerLinhas(hereditariedadesTxt);
        //
        foreach (var hereditariedade in hereditariedades) {
            var grau  = hereditariedade.Split(',');
            var pai   = grau[0];
            var filho = grau[1];
            grafo.Conectar(pai, filho, Familiar.Hereditariedade);
        }
    } // AdicionarRelacoesHereditarias

    private void AdicionarRelacoesConjugais(GrafoDirecionado grafo) {
        string[] aoArquivo = {"Dados", "Grafos", "conjugalidades.txt"};
        var conjugalidadesTxt = Diretorio.FormatarCaminho(aoArquivo);
        var conjugalidades    = Arquivo.LerLinhas(conjugalidadesTxt);
        //
        foreach (var conjugalidade in conjugalidades) {
            var papel  = conjugalidade.Split(',');
            var marido = papel[0];
            var mulher = papel[1];
            grafo.Conectar(marido, mulher, Familiar.Conjugalidade);
        }
    } // AdicionarRelacoesConjugais

    public void OnGet() {
        genealogia.ExibirArestas();
        // VerticesJson = genealogia.VerticesEmJson();
        // ArestasJson  = genealogia.ArestasEmJson();
    }
} // public class Atividade3Model: PageModel
} // namespace aa_time_1.Pages
