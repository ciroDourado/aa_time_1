using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using System;

using Conversores;
using Models;
using Grafos;
using ES;

namespace aa_time_1.Pages {

public class Atividade3Model: PageModel {
    private readonly ILogger<Atividade3Model> _logger;
    private GrafoDirecionado genealogia;
    public  string           json { get; set; }

    public Atividade3Model(ILogger<Atividade3Model> logger) {
        _logger    = logger;
        json       = string.Empty;
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
        genealogia = new GrafoDirecionado();
        AdicionarDeuses(genealogia);
        AdicionarRelacoesHereditarias(genealogia);
        AdicionarRelacoesConjugais(genealogia);
        
        json   = GrafoEmJson();
        Console.WriteLine(json);
    } // OnGet


	public string GrafoEmJson() {
		var nos = new List<NoGenograma>();

		foreach (var tuple in genealogia.Enumerar()) {
			var no = InicializarNo(tuple.index, tuple.vertice);
			nos.Add(no);
		}
		return Json.Serializar(nos);
	} // GrafoEmJson


	private NoGenograma InicializarNo(int key, Vertice vertice) {
		var no = new NoGenograma();

        no.key = key;
        no.n   = vertice.Label();
        no.s   = vertice.Sexo();
        AdicionarConjuges(no);
        AdicionarPais(no);

		return no;
	} // InicializarNo


    private void AdicionarConjuges(NoGenograma no) {
        int indice = no.key ?? 0;
        if (genealogia.VerticeNoIndice(indice).EhMulher()) {
            var vinculo = Familiar.Conjugalidade;
            var marido  = genealogia.ArestasQueChegamEm(indice, vinculo);
            if (marido.Count != 0) no.vir = marido[0];
        }
    } // AdicionarConjuges


    private void AdicionarPais(NoGenograma no) {
        int indice = no.key ?? 0;
        var pais = genealogia.ArestasQueChegamEm(
            indice,
            Familiar.Hereditariedade
        );
        if      (pais.Count >  1) AdicionarAmbosOsPais(no, pais);
        else if (pais.Count == 1) AdicionarPaiOuMae(no, pais);
    } // AdicionarPais


    private void AdicionarAmbosOsPais(NoGenograma no, List<int> pais) {
        if (genealogia.VerticeNoIndice(pais[0]).EhHomem()) {
            no.f = pais[0];
            no.m = pais[1];
        } else {
            no.f = pais[1];
            no.m = pais[0];
        }
    } // AdicionarAmbosOsPais


    private void AdicionarPaiOuMae(NoGenograma no, List<int> pais) {
        if (genealogia.VerticeNoIndice(pais[0]).EhHomem())
            no.f  = pais[0];
        else no.m = pais[0];
    } // AdicionarAmbosOsPais

} // public class Atividade3Model: PageModel
} // namespace aa_time_1.Pages
