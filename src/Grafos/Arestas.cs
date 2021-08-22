using System.Collections.Generic;
using System.Linq;
using System;

namespace Grafos {
class Arestas {
	private MatrizQuadrada<bool> adjacencias;
	private int                  quantidade;
	private int                  quantidadeMaxima;

	public Arestas(int quantidadeNos) {
		adjacencias = new MatrizQuadrada<bool>(quantidadeNos);
		quantidade  = 0;
	} // new(args)


	public int Quantidade() {
		return quantidade;
	} // Quantidade


	public void AdicionarAdjacencias(int quantidade) {
		if (quantidade > 0) {
			adjacencias.Expandir(quantidade);
			var novaDimensao      = adjacencias.Dimensao();
			this.quantidadeMaxima = (int)Math.Pow(novaDimensao, 2);
		}
	} // AdicionarAdjacencias


	public bool ExisteEntre(int verticeDeSaida, int verticeDeEntrada) {
		return adjacencias.Get(verticeDeSaida, verticeDeEntrada);
	} // ExisteEntre


	public void Adicionar(int verticeDeSaida, int verticeDeEntrada) {
		if ( quantidade < quantidadeMaxima ) {
			if (! ExisteEntre(verticeDeSaida, verticeDeEntrada)) quantidade++;
			adjacencias.Set(verticeDeSaida, verticeDeEntrada, true);
		}
	} // Adicionar


	public void Remover(int verticeDeSaida, int verticeDeEntrada) {
		if ( quantidade > 0 ) {
			if (ExisteEntre(verticeDeSaida, verticeDeEntrada)) quantidade--;
			adjacencias.Set(verticeDeSaida, verticeDeEntrada, false);
		}
	} // Remover


	public void Exibir() {
		if (adjacencias.Dimensao() != 0) {
			var output = adjacencias.ToString();
			var linhas = output.Split('\n').ToList();

			linhas.Insert(0, " Entrada");
			linhas[1] = linhas[1] + " Saida";
			linhas.ForEach(linha => Console.WriteLine(linha));
		}
	} // ExibirArestas


	public List<int> QuePartemDe(int verticeDeSaida) {
		return adjacencias.FiltrarLinha(verticeDeSaida, true);
	} // QuePartemDe

} // class Arestas
} // namespace Grafos
