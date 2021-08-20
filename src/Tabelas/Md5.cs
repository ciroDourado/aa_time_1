using System.Security.Cryptography;
using System.Linq;
using System;

namespace Tabelas {

class Md5: IHasher {
	private int capacidade;

	public Md5() { } // construtor

	public void Set(int novaCapacidade) {
		this.capacidade = novaCapacidade;
	} // Set capacidade

	// aplica os bytes na função de hash do md5
	// converte todos para inteiro
	// e então, com o somatório destes, pegamos o índice dentro do
	// intervalo da capacidade da tabela
	public int Indexar(byte[] input) {
        var bytes     = MD5.HashData(input);
		var numeros   = bytes.Select(cadaByte => (int)cadaByte);
		return numeros.Sum() % capacidade;
	} // Indexar

} // class Md5

} // namespace Tabelas
