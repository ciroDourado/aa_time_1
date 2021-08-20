using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

using ComunicacaoComServidor;
using ManipulacaoDeArquivos;
using ConversorJsonObjeto;
using Colecoes;
using Models;

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
        var dadosBaixados = new Arquivo();

        if (dadosBaixados.NaoExisteAinda(caminho)) {
            var cliente = InicializarClienteWeb();
            dadosBaixados.Set(await BaixarDados(cliente));
            dadosBaixados.SalvarEm(caminho);
        }
    } // VerificarDadosDaApi


    private static
    ClienteWeb InicializarClienteWeb() {
        var url = new Url(
            "http://api.portaldatransparencia.gov.br",
            "api-de-dados/coronavirus/transferencias"
        );
        var token = "1f644e567ce13bd43ab08bb7871e7739";

        var cliente = new ClienteWeb(url);
        cliente.AdicionarNoHeader("Accept", "application/json");
        cliente.AdicionarNoHeader("chave-api-dados", token);
        return cliente;
    } // InicializarClienteWeb


    private static async
    Task<string> BaixarDados(ClienteWeb cliente) {
        var transferencias = new Transferencias();

        var paginas = Enumerable.Range(1, 800);
        foreach (int pagina in paginas) {
            Console.WriteLine(pagina);
            cliente
                .Url()
                .Queries()
                .TrocarTodasPor($"mesAno=202011&pagina={pagina}");
            var transferenciasJson = await cliente.RequestString();
            transferencias.AdicionarVarias(transferenciasJson);
        }
        return Conversor.ObjetoParaJson(transferencias.Get());
    } // BaixarDados


    private static
    void VerificarResultadosDaAnalise(string dados) {
        var transferenciasJson = new Arquivo()
            .LerTodosOsDadosDe($"Dados/API/{dados}.json")
            .Get(); // como string
        var transferenciaList = Conversor
            .JsonParaObjeto<List<Transferencia>>(
            transferenciasJson);
        var colecao = new Transferencias(
            transferenciaList);

        ResultadosInstrucoes(colecao, dados);
        ResultadosTempo(colecao, dados);
    } // VerificarDadosDaApi


    private static
    void ResultadosInstrucoes(Transferencias resultados, string dados) {
        var arquivo = new Arquivo();
        var instrucoes = $"Dados/Complexidade/Instrucoes/{dados}";

        if (arquivo.NaoExisteAinda($"{instrucoes}Linear.json"))
            Salvar(resultados.InstrucoesLinear("kekw"), $"{instrucoes}Linear.json");

        if (arquivo.NaoExisteAinda($"{instrucoes}Filtro.json"))
            Salvar(resultados.InstrucoesFiltro("kekw"), $"{instrucoes}Filtro.json");

        if (arquivo.NaoExisteAinda($"{instrucoes}Bolha.json"))
            Salvar(resultados.InstrucoesBolha(), $"{instrucoes}Bolha.json");

        if (arquivo.NaoExisteAinda($"{instrucoes}Binaria.json"))
            Salvar(resultados.InstrucoesBinaria("kekw"), $"{instrucoes}Binaria.json");
    } // VerificarResultadosInstrucoes


    private static
    void ResultadosTempo(Transferencias resultados, string dados) {
        var arquivo = new Arquivo();
        var tempo = $"Dados/Complexidade/Tempo/{dados}";

        if (arquivo.NaoExisteAinda($"{tempo}Linear.json"))
            Salvar(resultados.TempoLinear("kekw"), $"{tempo}Linear.json");

        if (arquivo.NaoExisteAinda($"{tempo}Filtro.json"))
            Salvar(resultados.TempoFiltro("kekw"), $"{tempo}Filtro.json");

        if (arquivo.NaoExisteAinda($"{tempo}Bolha.json"))
            Salvar(resultados.TempoBolha(), $"{tempo}Bolha.json");

        if (arquivo.NaoExisteAinda($"{tempo}Binaria.json"))
            Salvar(resultados.TempoBinaria("kekw"), $"{tempo}Binaria.json");
    } // VerificarResultadosInstrucoes


    private static
    void Salvar(object dados, string caminho) {
        var resultados = new Arquivo();
        var instrucoesJson = Conversor
            .ObjetoParaJson(dados);
        resultados.Set(instrucoesJson);
        resultados.SalvarEm(caminho);
    } // Verificar

} // class Atividade1
} // namespace aa_time_1
