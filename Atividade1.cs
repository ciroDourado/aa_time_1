using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

using ComunicacaoComServidor;
using Conversores;
using Colecoes;
using Models;
using ES;

namespace aa_time_1 {
    class Atividade1 {

    public static async
    Task Executar() {
        await    VerificarDadosDaApi("transferencias");
        VerificarResultadosDaAnalise("transferencias");
    } // Executar


    private static async
    Task VerificarDadosDaApi(string dados) {
        string caminho = $"Dados/API/{dados}.json";

        if (Arquivo.NaoExiste(caminho)) {
            var cliente = InicializarClienteWeb();
            var json    = await BaixarDados(cliente, 800);
            Arquivo.SalvarDadosEm(json, caminho);
        }
    } // VerificarDadosDaApi


    private static
    ClienteWeb InicializarClienteWeb() {
        var url = new Url(
            "http://api.portaldatransparencia.gov.br",
            "api-de-dados/coronavirus/transferencias"
        );
        var token   = "1f644e567ce13bd43ab08bb7871e7739";
        var cliente = new ClienteWeb(url);

        cliente.AdicionarNoHeader("Accept", "application/json");
        cliente.AdicionarNoHeader("chave-api-dados", token);
        return cliente;
    } // InicializarClienteWeb


    private static async
    Task<string> BaixarDados(ClienteWeb cliente, int quantidade) {
        var transferencias = new Transferencias();
        var paginas        = Enumerable.Range(1, quantidade);

        foreach (var pagina in paginas) {
            cliente
                .Url()
                .Queries()
                .TrocarTodasPor($"mesAno=202011&pagina={pagina}");
            var transferenciasJson = await cliente.RequestString();
            transferencias.AdicionarVarias(transferenciasJson);
        }
        return Json.Serializar(transferencias.Get());
    } // BaixarDados


    private static
    void VerificarResultadosDaAnalise(string dados) {
        var caminho        = $"Dados/API/{dados}.json";
        var transferencias = Json.Deserializar<List<Transferencia>>
            (Arquivo.LerDados(caminho));

        var colecao = new Transferencias(transferencias);
        ResultadosInstrucoes(colecao, dados);
        ResultadosTempo(colecao, dados);
    } // VerificarDadosDaApi


    private static
    void ResultadosInstrucoes(Transferencias resultados, string dados) {
        var pastas = $"Dados/Complexidade/Instrucoes/{dados}";

        if (Arquivo.NaoExiste($"{pastas}Linear.json"))
            Salvar(resultados.InstrucoesLinear("kekw"), $"{pastas}Linear.json");
        if (Arquivo.NaoExiste($"{pastas}Filtro.json"))
            Salvar(resultados.InstrucoesFiltro("kekw"), $"{pastas}Filtro.json");
        if (Arquivo.NaoExiste($"{pastas}Bolha.json"))
            Salvar(resultados.InstrucoesBolha(), $"{pastas}Bolha.json");
        if (Arquivo.NaoExiste($"{pastas}Binaria.json"))
            Salvar(resultados.InstrucoesBinaria("kekw"), $"{pastas}Binaria.json");
    } // VerificarResultadosInstrucoes


    private static
    void ResultadosTempo(Transferencias resultados, string dados) {
        var pastas = $"Dados/Complexidade/Tempo/{dados}";

        if (Arquivo.NaoExiste($"{pastas}Linear.json"))
            Salvar(resultados.TempoLinear("kekw"), $"{pastas}Linear.json");
        if (Arquivo.NaoExiste($"{pastas}Filtro.json"))
            Salvar(resultados.TempoFiltro("kekw"), $"{pastas}Filtro.json");
        if (Arquivo.NaoExiste($"{pastas}Bolha.json"))
            Salvar(resultados.TempoBolha(), $"{pastas}Bolha.json");
        if (Arquivo.NaoExiste($"{pastas}Binaria.json"))
            Salvar(resultados.TempoBinaria("kekw"), $"{pastas}Binaria.json");
    } // VerificarResultadosInstrucoes


    private static
    void Salvar(object dados, string caminho) {
        Arquivo.SalvarDadosEm(
            Json.Serializar(dados),
            caminho
        );
    } // Salvar

} // class Atividade1
} // namespace aa_time_1
