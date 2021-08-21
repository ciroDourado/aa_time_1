using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using System;
using ES;

namespace aa_time_1.Pages {

public class Atividade1Model: PageModel {
    private readonly ILogger<Atividade1Model> _logger;
    public string TempoBinaria      { get; set; }
    public string TempoBolha        { get; set; }
    public string TempoFiltro       { get; set; }
    public string TempoLinear       { get; set; }
    public string InstrucoesBinaria { get; set; }
    public string InstrucoesBolha   { get; set; }
    public string InstrucoesFiltro  { get; set; }
    public string InstrucoesLinear  { get; set; }

    public Atividade1Model(ILogger<Atividade1Model> logger) {
        _logger = logger;
    } // new(args)

    public void OnGet() {
        string[] tempo   = {"Dados","Complexidade","Tempo","transferencias"};
        var caminhoTempo = Diretorio.FormatarCaminho(tempo);
        var tempoBinaria = new StreamReader($"{caminhoTempo}Binaria.json");
        var tempoBolha   = new StreamReader($"{caminhoTempo}Bolha.json");
        var tempoFiltro  = new StreamReader($"{caminhoTempo}Filtro.json");
        var tempoLinear  = new StreamReader($"{caminhoTempo}Linear.json");

        string[] instrucoes   = {"Dados","Complexidade","Instrucoes","transferencias"};
        var caminhoInstrucoes = Diretorio.FormatarCaminho(instrucoes);
        var instrucoesBinaria = new StreamReader($"{caminhoInstrucoes}Binaria.json");
        var instrucoesBolha   = new StreamReader($"{caminhoInstrucoes}Bolha.json");
        var instrucoesFiltro  = new StreamReader($"{caminhoInstrucoes}Filtro.json");
        var instrucoesLinear  = new StreamReader($"{caminhoInstrucoes}Linear.json");

        TempoBinaria      = tempoBinaria.ReadToEnd();
        TempoBolha        = tempoBolha.ReadToEnd();
        TempoFiltro       = tempoFiltro.ReadToEnd();
        TempoLinear       = tempoLinear.ReadToEnd();
        InstrucoesBinaria = instrucoesBinaria.ReadToEnd();
        InstrucoesBolha   = instrucoesBolha.ReadToEnd();
        InstrucoesFiltro  = instrucoesFiltro.ReadToEnd();
        InstrucoesLinear  = instrucoesLinear.ReadToEnd();
    }
} // public class Atividade1Model: PageModel
} // namespace aa_time_1.Pages
