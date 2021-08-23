using System.Collections.Generic;
using System.Linq;
using System;

namespace Grafos {
class Arestas {
	private MatrizQuadrada<Familiar> adjacencias;
	private int quantidade;
	private int quantidadeMaxima;

	public Arestas(int quantidadeNos) {
		adjacencias = new MatrizQuadrada<Familiar>(quantidadeNos);
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
		var vinculo = adjacencias.Get(verticeDeSaida, verticeDeEntrada);
		return vinculo != Familiar.Nenhum;
	} // ExisteEntre


	public void Adicionar(int verticeDeSaida, int verticeDeEntrada) {
		if ( quantidade < quantidadeMaxima ) {
			if (! ExisteEntre(verticeDeSaida, verticeDeEntrada)) quantidade++;
			adjacencias.Set(
				verticeDeSaida,
				verticeDeEntrada,
				Familiar.Hereditariedade
			); // Set
		}
	} // Adicionar


	public void Adicionar(int verticeDeSaida, int verticeDeEntrada, Familiar vinculo) {
		if ( quantidade < quantidadeMaxima ) {
			if (! ExisteEntre(verticeDeSaida, verticeDeEntrada)) quantidade++;
			adjacencias.Set(
				verticeDeSaida,
				verticeDeEntrada,
				vinculo
			); // Set
		}
	} // Adicionar


	public void Remover(int verticeDeSaida, int verticeDeEntrada) {
		if ( quantidade > 0 ) {
			if (ExisteEntre(verticeDeSaida, verticeDeEntrada)) quantidade--;
			adjacencias.Set(
				verticeDeSaida,
				verticeDeEntrada,
				Familiar.Nenhum
			); // Set
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
		return adjacencias.FiltrarLinha(
			verticeDeSaida,
			Familiar.Hereditariedade
		); // FiltrarLinha
	} // QuePartemDe


    public string ToJson() {
        // var linhas = new List<string>();
		//
        // for (int saida = 0; saida < adjacencias.Dimensao(); saida++) {
		// 	for (int entrada = 0; entrada < adjacencias.Dimensao(); entrada++) {
		// 		if (ExisteEntre(saida, entrada)) {
		// 			var linha = $"\"from\": {saida}, \"to\": {entrada}";
		// 			linhas.Add($"\t\t{{{linha}}}");
		// 		}
		// 	} // for entrada
        // } // for saida
		//
        // var json = string.Join(",\n", linhas);
        // return $"{{\n\t\"linkDataArray\": [\n{json}\n\t]\n}}";
		return string.Empty;
    } // ToJson

} // class Arestas
} // namespace Grafos
