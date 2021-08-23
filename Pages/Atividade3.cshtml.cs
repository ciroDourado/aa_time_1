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
    public  string           json { get; set; }

    public Atividade3Model(ILogger<Atividade3Model> logger) {
        _logger    = logger;
        json       = string.Empty;
        genealogia = new GrafoDirecionado();

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
        json   = GrafoEmJson();
        Console.WriteLine(json);
    } // OnGet


	public string GrafoEmJson() {
		var linhas = new List<string>();

		foreach (var dupla in genealogia.Enumerar()) {
			var linha = LinhaJson(dupla.index, dupla.vertice);
			linhas.Add(linha);
		}
		return $"[\n{string.Join(",\n", linhas)}\n]";
	} // GrafoEmJson


	private string LinhaJson(int key, Vertice vertice) {
		var linha = new List<string>();

        AdicionarKey(linha, key);
        AdicionarNome(linha, vertice.Label());
        AdicionarConjuges(linha, key);
        AdicionarPais(linha, key);

		return $"\t{{{string.Join(", ", linha)}}}";
	} // LinhaJson


    private void AdicionarKey(List<string> linha, int key) {
        linha.Add($"key: {key}");
    } // AdicionarKey


    private void AdicionarNome(List<string> linha, string n) {
        linha.Add($"n: \"{n}\"");
    } // AdicionarNome


    private void AdicionarConjuges(List<string> linha, int key) {
        if (genealogia.VerticeNoIndice(key).EhMulher()) {
            var vinculo = Familiar.Conjugalidade;
            var marido  = genealogia.ArestasQueChegamEm(key, vinculo);
            if (marido.Count != 0)
                linha.Add($"vir: {marido[0]}");
        }
    } // AdicionarConjuges


    private void AdicionarPais(List<string> linha, int key) {
        var pais = genealogia.ArestasQueChegamEm(
            key,
            Familiar.Hereditariedade
        );
        if (pais.Count > 1) {
            if (genealogia.VerticeNoIndice(pais[0]).EhHomem())
                linha.Add($"f: {pais[0]}, m: {pais[1]}");
            else linha.Add($"f: {pais[1]}, m: {pais[0]}");
        }
        else if (pais.Count == 1) {
            if (genealogia.VerticeNoIndice(pais[0]).EhHomem())
                linha.Add($"f: {pais[0]}");
            else linha.Add($"m: {pais[0]}");
        }
    } // AdicionarPais

} // public class Atividade3Model: PageModel
} // namespace aa_time_1.Pages
