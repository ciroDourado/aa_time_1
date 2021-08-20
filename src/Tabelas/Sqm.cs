using System.Linq;
using System;


namespace Tabelas {

class Sqm: IHasher {
	private int capacidade;

	public Sqm() { } // construtor

	public void Set(int novaCapacidade) {
		this.capacidade = novaCapacidade;
	} // Set capacidade

	// Calcula o indice a partir de um array de bytes
	// primeiro pega cada byte e aplica a operação
	// então, todos os bytes operados sao somados
	// para que se tire apenas a parte decimal
	// e então, é gerado o índice, operando o mesmo com a capacidade
	// e retornando apenas a parte inteira desta
	public int Indexar(byte[] bytes) {
		var medias       = bytes.Select(cadaByte => Media(cadaByte));
		var somatorio    = medias.Sum();
		var parteDecimal = somatorio - Math.Floor(somatorio);
		var parteInteira = Math.Floor( parteDecimal * capacidade );
		return (int)parteInteira;
	} // Indexar

	// esta função pega cada byte, converte para inteiro,
	// e então aplica a operação de quadrado do meio
	private double Media(byte _byte) {
		return (int)_byte * (Math.Sqrt(5.0) - 1) / 2;
	} // Media

} // class Sqm

} // namespace Tabelas
