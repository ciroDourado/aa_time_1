using System.Collections.Generic;
using System.Collections;
using System;

namespace Grafos {
class Vertices: IEnumerable, ICloneable {
    private Queue<Vertice> vertices;
    private int            quantidade;

    public Vertices() {
        vertices   = new Queue<Vertice>();
        quantidade = 0;
    } // new()


    public Vertices(string label) {
        vertices   = new Queue<Vertice>();
        quantidade = 0;
        this.Adicionar(label);
    } // new()


    public int Quantidade() {
        return quantidade;
    } // Quantidade


    public void Adicionar(string label) {
        vertices.Enqueue(new Vertice(label));
        quantidade++;
    } // Adicionar


    public void Adicionar(Vertice vertice) {
        vertices.Enqueue(vertice);
        quantidade++;
    } // Adicionar


    public Vertice Remover() {
        quantidade--;
        return vertices.Dequeue();
    } // Adicionar


    public bool Existe(string label) {
        foreach (var vertice in vertices)
            if ( vertice.EhIgual(label) )
                return true;
        return false;
    } // Existe


    public bool Existe(Vertice buscado) {
        foreach (var vertice in vertices)
            if ( vertice == buscado )
                return true;
        return false;
    } // Existe


    public bool NaoEstaVazio() {
        return vertices.Count != 0;
    } // NaoEstaVazio


    public int BuscarIndice(string label) {
        int indice = 0;
        foreach (var vertice in vertices) {
            if ( vertice.EhIgual(label) )
                return indice;
            else indice++;
        }
        return -1;
    } // BuscarIndice


    public void Exibir(string titulo) {
        Console.WriteLine(titulo);

        int ordem = 1;
        foreach (var vertice in vertices) {
            Console.WriteLine($"{ordem}o: {vertice}");
            ordem++;
        }
    } // Exibir


    public int this[string label] {
        get => BuscarIndice(label);
    } // indexer


    public Vertice NoIndice(int indice) {
        int iterador = 0;
        foreach (var vertice in vertices) {
            if (iterador == indice) return vertice;
            iterador++;
        }
        return new Vertice();
    } // NoIndice


    public Vertices NosIndices(List<int> indices) {
        var selecionados = new Vertices();
        foreach (var indice in indices) {
            var vertice = this.NoIndice(indice);
            selecionados.Adicionar(vertice);
        }
        return selecionados;
    } // NosIndices


    IEnumerator IEnumerable.GetEnumerator() {
        return (IEnumerator)GetEnumerator();
    } // GetEnumerator


    public VerticesEnum GetEnumerator() {
        return new VerticesEnum(vertices);
    } // GetEnumerator


    public object Clone() {
        var copia = new Vertices();
        foreach (var vertice in vertices)
            copia.Adicionar(vertice);
        return copia;
    } // Clone from ICloneable


    public string ToJson() {
        var linhas = new List<string>();
        int key    = 0;

        foreach (var vertice in vertices) {
            var linha = $"\"key\": {key++}, \"nome\": \"{vertice.Label()}\"";
            linhas.Add($"\t\t{{{linha}}}");
        }
        var json = string.Join(",\n", linhas);
        return $"{{\n\t\"nodeDataArray\": [\n{json}\n\t]\n}}";
    } // ToJson

} // class Vertices
} // namespace Grafos
