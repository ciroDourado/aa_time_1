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

public class Atividade2Model: PageModel {
    private readonly ILogger<Atividade2Model> _logger;
    public string TempoHashMd5    { get; set; }
    public string TempoHashSqm    { get; set; }
    public string TempoHashLinear { get; set; }

    public Atividade2Model(ILogger<Atividade2Model> logger) {
        _logger = logger;
    } // new(args)

    public void OnGet() {
        string[] tempo   = {"Dados","Complexidade","Tempo","diretorio"};
        var caminhoTempo = Diretorio.FormatarCaminho(tempo);
        var tempoHashMd5    = new StreamReader($"{caminhoTempo}HashMd5.json");
        var tempoHashSqm    = new StreamReader($"{caminhoTempo}HashSqm.json");
        var tempoHashLinear = new StreamReader($"{caminhoTempo}Linear.json");

        TempoHashMd5    = tempoHashMd5.ReadToEnd();
        TempoHashSqm    = tempoHashSqm.ReadToEnd();
        TempoHashLinear = tempoHashLinear.ReadToEnd();
    }
} // public class Atividade2Model: PageModel
} // namespace aa_time_1.Pages
