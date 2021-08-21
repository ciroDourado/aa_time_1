using System;
using System.IO;

namespace ES {
// classe Arquivo
// Todos os métodos desta classe são responsáveis em varrer um
// abrir arquivos, verificar sua existência, salvar, ou qualquer
// função relacionada
// Autor: Ciro
class Arquivo {

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


    // método Existe
	// recebe
	// |> uma string, que representa o caminho até o arquivo
	// retorna
	// |> true : caso o arquivo exista
	// |> false: caso não seja encontrado
	// Autor: Ciro
    static public
    bool Existe(string caminho) {
        return File.Exists(caminho);
    } // Existe


    // método NaoExiste
	// recebe
	// |> uma string, que representa o caminho até o arquivo
	// retorna
    // |> true : caso não seja encontrado
	// |> false: caso o arquivo exista
	// Autor: Ciro
    static public
    bool NaoExiste(string caminho) {
        return !Existe(caminho);
    } // NaoExiste


    // método SalvarDadosEm
	// recebe
	// |> uma string, que representa os dados a serem salvos
	// |> uma string, que representa o caminho até o arquivo
	// Autor: Ciro
    static public
    void SalvarDadosEm(string dados, string caminho) {
        File.WriteAllText(caminho, dados);
    } // SalvarDadosEm


    // método LerDados
	// recebe
	// |> uma string, que representa o caminho até o arquivo
	// retorna
    // |> string com dados: caso o arquivo exista
    // |> string vazia    : caso o arquivo não exista
	// Autor: Ciro
    static public
    string LerDados(string caminho) {
        return Existe(caminho)?
            File.ReadAllText(caminho):
            string.Empty;
    } // LerDados


    // método LerBytes
	// recebe
	// |> uma string, que representa o caminho até o arquivo
	// retorna
    // |> array de bytes: caso o arquivo exista
    // |> array vazio   : caso o arquivo não exista
	// Autor: Ciro
    static public
    byte[] LerBytes(string caminho) {
        return Existe(caminho)?
            File.ReadAllBytes(caminho):
            new byte[0];
    } // LerBytes


    // método LerLinhas
	// recebe
	// |> uma string, que representa o caminho até o arquivo
	// retorna
    // |> array de strings: caso o arquivo exista
    // |> array vazio     : caso o arquivo não exista
	// Autor: Ciro
    static public
    string[] LerLinhas(string caminho) {
        return Existe(caminho)?
            File.ReadAllLines(caminho):
            new string[0];
    } // LerLinhas

} // class Arquivo
} // namespace ES
