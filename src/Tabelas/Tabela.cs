using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

namespace Tabelas {

class Tabela<Hasher>
	where Hasher: IHasher, new()
{
	// toda hashtable consiste em um array de dados
	// porém, esses dados podem variar entre tipos
	// primitivos (inteiro, string, tipos únicos, etc)
	// ou conjuntos/coleções (listas, arrays, etc)

	// nossa escolha foi usar um array de listas,
	// onde, a cada colisão, o novo elemento é inserido
	// na lista, e não diretamente no array, usando algum
	// método de endereçamento aberto
	private List<string>[] nos;
	private int            capacidade;
	private Hasher         hasher;
	// o Hasher acima nada mais é do que a classe que
	// implementa a função que transforma a chave/dados
	// num índice.

	// para evitar repetição massiva de código
	// (criando varias classes de hashtable, cada
	// uma com um hasher diferente), apenas a classe
	// responsável deve ser implementada e encaixada
	// na tabela

	// este método é importante para criarmos tabelas
	// sempre com uma capacidade sendo um número primo
	// recebe: qualquer número
	// retorna: o primeiro primo depois dele
	private static
	int ProximoPrimo(int capacidade) {
		return EhPrimo(capacidade)?
			capacidade:
			ProximoPrimo(capacidade + 1);
	} // ProximoPrimo


	// método auxiliar
	// recebe um número
	// e retorna se ele é primo ou não
	private static
	bool EhPrimo(int numero) {
		var divisores       = Enumerable.Range(2, numero);
		int divisoesValidas = 1;

		foreach (int divisor in divisores)
			if ((numero % divisor) == 0) divisoesValidas++;
		return divisoesValidas == 2;
	} // EhPrimo


	// construtor, inicializa todos os atributos pertinentes
	// à classe. Recebe como parâmetro uma estimativa do que
	// será a capacidade da tabela
	public Tabela(int capacidade) {
		this.capacidade = ProximoPrimo(capacidade);
		this.nos        = _InicializarNos(this.capacidade);

		this.hasher     = new Hasher();
		this.hasher.Set(this.capacidade);
	} // construtor parametrizado


	// método auxiliar, inicializa todas as listas da tabela
	// pense nela como se fosse um array de listas
	private List<string>[] _InicializarNos(int capacidade) {
		var nos = new List<string>[capacidade];

		for (int i = 0; i < capacidade; i++)
			nos[i] = new List<string>();
		return nos;
	} // _InicializarNos


	// método Get
	// recebe: o nome do arquivo
	// com o nome do arquivo, ele gera os bytes para
	// serem enviados para a função de hash, e com isso
	// retorna: a lista correspondente ao índice calculado
	public List<string> Get(string nome) {
		byte[] bytesArquivo = File.ReadAllBytes(nome);
		int posicao = hasher.Indexar(bytesArquivo);
		List<string> listaNaPosicao = nos[posicao];
		return listaNaPosicao;
		// armazena as informações do arquivo em um array de bytes
		// a partir do array de bytes, é gerado um índice com a função de hash
		// com o índice, armazena elementos naquela posição numa lista
	} // get pelo nome


	// método Get
	// recebe: os bytes do arquivo já aberto
	// com isso, são enviados à função de hash, e então
	// retorna: a lista correspondente ao índice calculado
	public List<string> Get(byte[] bytes) {
		int posicao = hasher.Indexar(bytes);
		List<string> listaNaPosicao = nos[posicao];
		return listaNaPosicao;
		// a partir do array de bytes, é gerado um índice com a função de hash
		// com o índice, armazena elementos naquela posição numa lista
	} // get pelos bytes


	// método Adicionar
	// recebe: um array de strings
	// esse array é transformado numa lista, e então
	// é repassado para a função de adicionar que recebe
	// uma Lista de strings
	public void Adicionar(string[] nomes) {
		List<string> arquivos = new List<string>();
		foreach(string nome in nomes) {
			arquivos.Add(nome);
		}//foreach
		Adicionar(arquivos);
 		//criando uma lista vazia para receber os valores contigs no array
		//percorre todo o array e executa o comando Add para cada string
	} // Adicionar


	// método Adicionar
	// recebe: uma lista de strings
	// cada elemento da lista é inserido de cada vez,
	// sendo enviado para o método que abre o arquivo
	// e calcula o índice
	public void Adicionar(List<string> nomes) {
		foreach(string nome in nomes){
			byte[] bytesArquivo = File.ReadAllBytes(nome);
			int posicao = hasher.Indexar(bytesArquivo);
			nos[posicao].Add(nome);
		}
		// lendo arquivo e armazenando seus bytes em um array
		// a partir do array de bytes, é gerado um índice com a função de hash
		// com o índice calculado, o elemento é adicionado na lista correspondente
		// à posição do array calculada pela função hash
	} // Adicionar


	// método Adicionar
	// recebe: um único arquivo em string
	// este é enviado ao método que abre o arquivo
	// e calcula o índice
	// também printa no console se houve colisão
	public void Adicionar(string nome) {
		_Adicionar(nome);
	} // Adicionar


	// método _Adicionar
	// recebe: um único arquivo em string
	// este é aberto em bytes
	// enviado para a função de hash
	// e com o índice calculado: insere na lista correspondente
	private void _Adicionar(string nome) {
		byte[] bytesArquivo = File.ReadAllBytes(nome);
		int posicao = hasher.Indexar(bytesArquivo);
		nos[posicao].Add(nome);
		//lendo arquivo e armazenando seus bytes em um array
		//a partir do array de bytes, é gerado um índice com a função de hash
		// com o índice calculado, o elemento é adicionado na lista correspondente
		// à posição do array calculada pela função hash
	} // _Adicionar


	// método Colide
	// recebe: o nome do arquivo
	// com isso, ele é aberto em bytes
	// estes são enviados à função de hash
	// e com o índice calculado, verificamos se
	// a lista na posição está vazia
	public bool Colide(string nome) {
		byte[] bytesArquivo = File.ReadAllBytes(nome);
		int posicao = hasher.Indexar(bytesArquivo);
		if(nos[posicao].Count == 0)
			return false;
		else return true;
		// armazena as informações do arquivo em um array de bytes
		// a partir do array de bytes, é gerado um índice com a função de hash
		// se o array estiver vazio na posicão calculada, não há colisao
		// então retorna False, caso contrário, True
	} // Colide


	// método Exibir
	// exibe todos os dados guardados na tabela
	// ela itera, acessando cada lista do array por vez
	public void Exibir() {
		Console.WriteLine($"Listas: {this.capacidade}");

		for (int i = 0; i < this.capacidade; i++)
			_Exibir(i);
	} // Exibir


	// auxiliar do método Exibir
	// apenas verifica se a lista está vazia
	// se não estiver, pode prosseguir no print
	private void _Exibir(int i) {
		if (this.nos[i].Count != 0)
			_ExibirNos(i);
	} // _Exibir


	// auxiliar do método Exibir
	// printa cada um dos elementos da lista acessada
	private void _ExibirNos(int i) {
		Console.WriteLine();
		Console.WriteLine($"Lista {i+1}:");

		foreach (var no in this.nos[i])
			Console.WriteLine(no);
	} // _ExibirNos

} // class Tabela

} // namespace Tabelas
