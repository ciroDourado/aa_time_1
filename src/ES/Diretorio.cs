using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Tabelas;
using System;

namespace ES {
// classe Diretorio
// Todos os métodos desta classe são responsáveis em varrer um
// diretório, pegando seus arquivos, ou buscar algum em específico
// Autor: Ciro
class Diretorio {

	// método FormatarCaminho
	// recebe
	// |> um array de strings, que representa o caminho até o arquivo
	// retorna
	// |> um path numa string só
	// Autor: Jonas
    static public
    string FormatarCaminho(string[] pastasAteArquivo) {
		return Path.Combine(pastasAteArquivo);
    } // Método FormatarCaminho


	// método ListaDeArquivos
	// recebe
	// |> uma string, indicando o caminho até o diretório
	// retorna
	// |> uma lista com os nomes de todos os arquivos dentro dele
	// Autor: Jonas
    static public
    List<string> TodosOsArquivos(string caminho) {
        var listaDeArquivos = new List<string>();
        var arquivos        = Directory.GetFiles(caminho);
        Array.Sort(arquivos);

        foreach (var arquivo in arquivos) {
            listaDeArquivos.Add(arquivo);
        }
        return listaDeArquivos;
    } // Método TodosOsArquivos


	// método ArquivoExiste
	// recebe
	// |> um array de bytes, representando o arquivo procurado
	// |> uma lista de strings, indicando os arquivos que serão varridos
	// retorna
	// |> true : caso o arquivo exista
	// |> false: caso não seja encontrado até o fim
	// Autor: João Gabriel
    static public
    bool ArquivoExiste(byte[] procurado, List<string> arquivos) {
		foreach(string foto in arquivos) {
            if(SaoIguais(procurado, foto))
                return true;
        }
        return false;
    } // Método ArquivoExiste


	// método ArquivoExiste
	// recebe
	// |> um array de bytes, representando o arquivo procurado
	// |> uma hashtable strings, indicando os arquivos que serão varridos
	// retorna
	// |> true : caso o arquivo exista
	// |> false: caso não seja encontrado até o fim
	// Autor: Ciro Dourado
    static public
    bool ArquivoExiste<T>(byte[] procurado, Tabela<T> arquivos)
        where T: IHasher, new()
    {
        var relacionados = arquivos.Get(procurado);
        foreach (var arquivo in relacionados) {
            if (SaoIguais(procurado, arquivo))
                return true;
        }
        return false;
    } // Método ArquivoExiste


	// método SaoIguais
	// recebe
	// |> um array de bytes, representando o arquivo procurado
	// |> uma string, indicando o arquivo a ser aberto
	// retorna
	// |> true : caso sejam iguais
	// |> false: caso contrário
    // Autor: Douglas Castro
	static private
    bool SaoIguais(byte[] procurado, string atual){
    	var bytesAtual = File.ReadAllBytes(atual);
        return ComparacaoPorBytes(procurado, bytesAtual);
    } // Método SaoIguais


	// método ComparacaoPorBytes
	// recebe
	// |> um array de bytes, representando todos do procurado
	// |> um array de bytes, representando todos do comparado
	// retorna
	// |> true : caso todos os bytes sejam iguais até o fim
	// |> false: caso algum byte diferente seja encontrado
	// Autor: Gabriel Câncio
    static private
    bool ComparacaoPorBytes(byte[] procurado, byte[] atual) {
        for (int i = 0; i < procurado.Length; i++) {
            if (i >= atual.Length)        return false;
            if (procurado[i] != atual[i]) return false;
        }
        return true;
    } // ComparacaoPorBytes


	// método TempoLista
	// recebe
	// |> um array de bytes, representando todos do procurado
	// |> uma lista de arquivos, que pode conter o procurado
	// retorna
	// |> as medidas de tempo
	// Autor: ?
    static public
    List<TimeSpan> TempoLista(byte[] procurado, List<string> arquivos) {
        var ultimo        = arquivos.Count - 1;
        var cronometro    = Stopwatch.StartNew();
        var temposMedidos = new List<TimeSpan>();

        for (int n = 0; n < ultimo; n++) {
            var nArquivos = arquivos.GetRange(0, n);
            nArquivos.Add(arquivos[ultimo]);

            cronometro.Restart();
            Diretorio.ArquivoExiste(procurado, nArquivos);
            temposMedidos.Add(cronometro.Elapsed);
        }
        return temposMedidos;
    } // TempoLista


	// método TempoTabela
	// recebe
	// |> um array de bytes, representando todos do procurado
	// |> uma lista de arquivos, que pode conter o procurado
	// retorna
	// |> as medidas de tempo
	// Autor: ?
    static public
    List<TimeSpan> TempoTabela<T>(byte[] procurado, List<string> arquivos)
        where T: IHasher, new()
    {
        var ultimo        = arquivos.Count - 1;
        var cronometro    = Stopwatch.StartNew();
        var temposMedidos = new List<TimeSpan>();

        for (int n = 0; n < ultimo; n++) {
            var arquivosTabelados = CriarTabela<T>(arquivos, n);
            arquivosTabelados.Adicionar(arquivos[ultimo]);

            cronometro.Restart();
            Diretorio.ArquivoExiste(procurado, arquivosTabelados);
            temposMedidos.Add(cronometro.Elapsed);
        }
        return temposMedidos;
    } // TempoTabela


	// método CriarTabela
	// recebe
	// |> uma lista de arquivos, que serão transferidos para a tabela
	// |> um inteiro n, que representa a quantidade de transferências
	// retorna
	// |> uma tabela hash com todos os arquivos indexados
	// Autor: Ciro
    static private
    Tabela<T> CriarTabela<T>(List<string> arquivos, int n)
        where T: IHasher, new()
    {
        var nArquivos         = arquivos.GetRange(0, n);
        var arquivosTabelados = new Tabela<T>(nArquivos.Count + 1);
        arquivosTabelados.Adicionar(nArquivos);
        return arquivosTabelados;
    } // CriarTabela

} // class Diretorio
} // namespace ES
