using System.Collections.Generic;
using System.IO;
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
        ResultadoBuscaPorHash(caminho);
    } // VerificarResultadosBusca


    public delegate List<TimeSpan>
    MetodoDeAnalise(byte[] buscado, List<string> arquivos);


    private static
    void ResultadoBuscaLinear(string caminho) {
        string[] aoArquivo  = {caminho, "diretorioLinear.json"};
        var resultadoLinear = Diretorio.FormatarCaminho(aoArquivo);

        if (Arquivo.NaoExiste(resultadoLinear)) {
            var metodo    = new MetodoDeAnalise(Diretorio.TempoLista);
            var resultado = IniciarAnalise(metodo);
            Salvar(resultado, resultadoLinear);
        }
    } // ResultadoBuscaLinear


    private static
    void ResultadoBuscaPorHash(string caminho) {
        string[] aoArquivo = {caminho, "diretorioHashMd5.json"};
        var resultadoHash  = Diretorio.FormatarCaminho(aoArquivo);

        if (Arquivo.NaoExiste(resultadoHash)) {
            var metodo    = new MetodoDeAnalise(Diretorio.TempoTabela<Md5>);
            var resultado = IniciarAnalise(metodo);
            Salvar(resultado, resultadoHash);
        }
    } // ResultadoBuscaPorHash


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
