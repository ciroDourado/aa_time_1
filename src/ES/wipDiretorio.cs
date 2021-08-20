using System;
using System.IO;
using System.Collections.Generic;
using Tabelas;

namespace ES {
// classe Diretorio
// Todos os métodos desta classe são responsáveis em varrer um
// diretório, pegando seus arquivos, ou buscar algum em específico
// Autor: Ciro
class wipDiretorio {

	// método FormatarCaminho
	// recebe
	// |> um array de strings, que representa o caminho até o arquivo
	// retorna
	// |> um path numa string só
	// Autor: Jonas
    static public
    string FormatarCaminho(string[] arquivos) {
		return Path.Combine(arquivos);
    } // Método FormatarCaminho


	// método ListaDeArquivos
	// recebe
	// |> uma string, indicando o caminho até o diretório
	// retorna
	// |> uma lista com os nomes de todos os arquivos dentro dele
	// Autor: Jonas
    static public
    List<string> TodosOsArquivos(string caminho) {
        List<string> caminho_arquivo = new List<string>();
        var arquivos = Directory.GetFiles(caminho);
        Array.Sort(arquivos);

        foreach (var arquivo in arquivos) {
            caminho_arquivo.Add(arquivo);
        }
        return caminho_arquivo;
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
    	byte[] arquivoAtual = File.ReadAllBytes(atual);
        return ComparacaoPorBytes(procurado, arquivoAtual);

    	// A função tem por dever "pegar" o nome do arquivo que
        // vai ser comparado com a array de bytes, onde tal array
        // é a foto que está sendo procurada
    	// enquanto que a string, que é o segundo parâmetro da
        // função, corresponde a outra foto da pasta.
    	// Para que se possa comparar, deve-se abrir o arquivo
        // passado como bytes, e enviar para a outra função que
        // compara byte a byte.
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

} // class Diretorio

} // namespace Diretorios
