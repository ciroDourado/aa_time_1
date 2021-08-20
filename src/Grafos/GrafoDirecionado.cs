using System;

class GrafoDirecionado {
	private Vertices vertices;
	private Arestas  arestas;

	public GrafoDirecionado() {
		vertices = new Vertices();
		arestas  = new Arestas(0);
	} // new()


	public void AdicionarVertice(string label) {
		if ( vertices.Existe(label) ) {
			string erro = "Já existe um vértice";
			Console.WriteLine($"{erro} {label}");
		} else {
			vertices.Adicionar(label);
			arestas.AdicionarAdjacencias(1);
		}
	} // AdicionarVertice


	public void AdicionarVertices(string[] labels) {
		foreach (var label in labels)
			AdicionarVertice(label);
	} // AdicionarVertices


	public void AdicionarAresta(string saida, string entrada) {
		if ( VerticesExistem(saida, entrada) )
			_AdicionarAresta(saida, entrada);
	} // AdicionarAresta


	// public void AdicionarArestas(string[,] duplas) {
	// 	foreach (var dupla in duplas)
	// 		AdicionarAresta(dupla[0], dupla[1]);
	// } // AdicionarArestas


	private void _AdicionarAresta(string saida, string entrada) {
		if (vertices.Quantidade() != 0)
			arestas.Adicionar(vertices[saida], vertices[entrada]);
	} // _AdicionarAresta


	public void RemoverAresta(string saida, string entrada) {
		if ( VerticesExistem(saida, entrada) )
			_RemoverAresta(saida, entrada);
	} // RemoverAresta


	private void _RemoverAresta(string saida, string entrada) {
		if (vertices.Quantidade() != 0)
			arestas.Remover(vertices[saida], vertices[entrada]);
	} // RemoverAresta


	private bool VerticesExistem(string saida, string entrada) {
		var erro = "Não existe o vértice";
		if (! vertices.Existe(saida)  ) Console.WriteLine($"{erro} {saida  }");
		if (! vertices.Existe(entrada)) Console.WriteLine($"{erro} {entrada}");

		return vertices.Existe(saida) && vertices.Existe(entrada);
	} // VerticesExistem


	public void ExibirArestas() {
		Console.WriteLine("Matriz de arestas:");
		Console.WriteLine("(ou, adjacências)");

		Console.WriteLine();
		arestas.Exibir();
		Console.WriteLine();
	} // ExibirArestas


	// DFS:
	// |> é um algoritmo recursivo (mas pode ser iterativo tambem)
	// |> caso seja iterativo, usa Pilha para percorrer o grafo
	// |> visita os vértices pelas adjacencias
	// |> o usuário ou o programa podem decidir o ponto inicial (é indiferente)
	// |> o algoritmo percorre TODOS os vértices sempre, mesmo que não se liguem
	// public Vertices DFS() {
	// 	var naoVisitados = vertices.Clone();
	//
	// 	while (naoVisitados.NaoEstaVazio()) {
	//
	// 	}
	// 	return new Vertices();
	// } // DFS


	// BFS:
	// |> é um algoritmo iterativo
	// |> faz uso de Fila para percorrer o grafo
	// |> o usuário escolhe o vértice inicial
	// |> visita os vértices por meio das arestas, uma única vez em cada
	// |> este algoritmo não percorre todos os vértices, apenas os que possuem um caminho ao inicial
	public Vertices BFS(string inicial) {
		return vertices.Existe(inicial)?
			ExecutarBFS(inicial):
			new Vertices();
	} // BFS


	private Vertices ExecutarBFS(string inicial) {
		var alcancaveis = new Vertices();
		var iterador    = new Vertices(inicial);

		while (iterador.NaoEstaVazio()) {
			var verticeAtual = iterador.Remover();
			var vizinhos     = Vizinhos(verticeAtual.Label());

			foreach (var vizinho in vizinhos) {
				iterador.Adicionar(vizinho);
				if (! alcancaveis.Existe(vizinho))
					alcancaveis.Adicionar(vizinho);
			}
		}
		return alcancaveis;
	} // ExecutarBFS


	public Vertices Vizinhos(string label) {
		return vertices.Existe(label)?
			ProcurarVizinhos(label):
			new Vertices();
	} // Vizinhos


	private Vertices ProcurarVizinhos(string inicial) {
		var indice  = vertices.BuscarIndice(inicial);
		var indices = arestas.QuePartemDe(indice);
		return vertices.NosIndices(indices);
	} // ProcurarVizinhos

} // class GrafoDirecionado
