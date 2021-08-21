using System.Collections.Generic;
using System;

using Conversores;
using Tabelas;
using ES;

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
        ResultadoBuscaPorHashMd5(caminho);
        ResultadoBuscaPorHashSqm(caminho);
    } // VerificarResultadosBusca


    public delegate List<TimeSpan>
    MetodoDeAnalise(byte[] buscado, List<string> arquivos);


    private static
    void ResultadoBuscaLinear(string caminho) {
        string[] aoArquivo  = {caminho, "diretorioLinear.json"};
        var resultadoLinear = Diretorio.FormatarCaminho(aoArquivo);

        if (Arquivo.NaoExiste(resultadoLinear)) {
            Console.WriteLine("Log: medindo tempo de Busca em Lista");
            var metodo    = new MetodoDeAnalise(Diretorio.TempoLista);
            var resultado = IniciarAnalise(metodo);
            Salvar(resultado, resultadoLinear);
        }
    } // ResultadoBuscaLinear


    private static
    void ResultadoBuscaPorHashMd5(string caminho) {
        string[] aoArquivo = {caminho, "diretorioHashMd5.json"};
        var resultadoHash  = Diretorio.FormatarCaminho(aoArquivo);

        if (Arquivo.NaoExiste(resultadoHash)) {
            Console.WriteLine("Log: medindo tempo de Busca em MD5");
            var metodo    = new MetodoDeAnalise(Diretorio.TempoTabela<Md5>);
            var resultado = IniciarAnalise(metodo);
            Salvar(resultado, resultadoHash);
        }
    } // ResultadoBuscaPorHashMd5


    private static
    void ResultadoBuscaPorHashSqm(string caminho) {
        string[] aoArquivo = {caminho, "diretorioHashSqm.json"};
        var resultadoHash  = Diretorio.FormatarCaminho(aoArquivo);

        if (Arquivo.NaoExiste(resultadoHash)) {
            Console.WriteLine("Log: medindo tempo de Busca em SQM");
            var metodo    = new MetodoDeAnalise(Diretorio.TempoTabela<Sqm>);
            var resultado = IniciarAnalise(metodo);
            Salvar(resultado, resultadoHash);
        }
    } // ResultadoBuscaPorHashSqm


    private static
    List<TimeSpan> IniciarAnalise(MetodoDeAnalise metodo) {
        string[] aoArquivo = {"images", "target.jpg"};
        var imagemBuscada  = Diretorio.FormatarCaminho(aoArquivo);
        var bytesDaImagem  = Arquivo.LerBytes(imagemBuscada);

        var arquivos = Diretorio.TodosOsArquivos("images");
        return metodo(bytesDaImagem, arquivos);
    } // IniciarAnalise


    private static
    void Salvar(object dados, string caminho) {
        Arquivo.SalvarDadosEm(
            Json.Serializar(dados),
            caminho
        );
    } // Salvar

} // class Atividade2
} // namespace aa_time_1
