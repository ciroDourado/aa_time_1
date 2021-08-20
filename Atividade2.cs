using System.Collections.Generic;
using System.IO;
using System;

using ManipulacaoDeArquivos;
using ConversorJsonObjeto;
using Diretorios;
using Tabelas;

namespace aa_time_1 {
    class Atividade2 {

    public static
    void Executar() {
        VerificarResultadosBusca();
    } // Executar


    private static
    void VerificarResultadosBusca() {
        string[] pastas = {"Dados", "Complexidade", "Tempo"};
        string  caminho =  Diretorio.FormatarCaminho(pastas);

        ResultadoBuscaLinear(caminho);
        ResultadoBuscaPorHash(caminho);
    } // VerificarResultadosBusca


    public delegate List<TimeSpan>
    MetodoDeAnalise(byte[] buscado, List<string> arquivos);


    private static
    void ResultadoBuscaLinear(string caminho) {
        string[] aoArquivo  = {caminho, "diretorioLinear.json"};
        var resultadoLinear = Diretorio.FormatarCaminho(aoArquivo);

        if (Arquivo.NaoExiste(resultadoLinear)) {
            var metodo    = new MetodoDeAnalise(Analise.TempoLista);
            var resultado = IniciarAnalise(metodo);
            Salvar(resultado, resultadoLinear);
        }
    } // ResultadoBuscaLinear


    private static
    void ResultadoBuscaPorHash(string caminho) {
        string[] aoArquivo = {caminho, "diretorioHashMd5.json"};
        var resultadoHash  = Diretorio.FormatarCaminho(aoArquivo);

        if (Arquivo.NaoExiste(resultadoHash)) {
            var metodo    = new MetodoDeAnalise(Analise.TempoTabela<Md5>);
            var resultado = IniciarAnalise(metodo);
            Salvar(resultado, resultadoHash);
        }
    } // ResultadoBuscaPorHash


    private static
    List<TimeSpan> IniciarAnalise(MetodoDeAnalise metodo) {
        string[] aoArquivo = {"images", "target.jpg"};
        var imagemBuscada  = Diretorio.FormatarCaminho(aoArquivo);
        var bytesDaImagem  = File.ReadAllBytes(imagemBuscada);

        var arquivos = Diretorio.TodosOsArquivos("images");
        return metodo(bytesDaImagem, arquivos);
    } // IniciarAnalise


    private static
    void Salvar(object dados, string caminho) {
        var resultados = new Arquivo();
        var instrucoesJson = Conversor
            .ObjetoParaJson(dados);
        resultados.Set(instrucoesJson);
        resultados.SalvarEm(caminho);
    } // Salvar

} // class Atividade2
} // namespace aa_time_1
