using System.Collections.Generic;
using System;

namespace Grafos {
class MatrizQuadrada<T> {
    private T[,] elementos;
    private int  dimensao;

    public MatrizQuadrada(int dimensao) {
        elementos = new T[dimensao, dimensao];
        this.dimensao = dimensao;
    } // new()


    public void Expandir(int quantidade) {
        var novaDimensao = dimensao + quantidade;

        var novosElementos = new T[novaDimensao, novaDimensao];
        for (int x = 0; x < dimensao; x++)
            for (int y = 0; y < dimensao; y++)
                novosElementos[x, y] = elementos[x, y];

        elementos = novosElementos;
        dimensao  = novaDimensao;
    } // Expandir


    public int Dimensao() {
        return dimensao;
    } // Dimensao


    private bool IndiceEhValido(int x) {
        return (x >= 0) && (x < dimensao);
    } // IndiceEhValido


    // serve para setar um valor na posição dada
    public bool Set(int x, int y, T valor) {
        if (IndiceEhValido(x) && IndiceEhValido(y)) {
            elementos[x,y] = valor;
            return true;
        } else return false;
    } // metodo Set


    // serve para obter o valor na posição dada
    public T Get(int x, int y) {
        if (IndiceEhValido(x) && IndiceEhValido(y))
            return GetValido(x, y);
        else return GetInvalido(x, y);
    } // metodo Get

    private T GetValido(int x, int y) {
        return elementos[x, y];
    } // GetValido

    private T GetInvalido(int x, int y) {
        Console.WriteLine("Índice fora das dimensões");
        Console.WriteLine($"Dimensao: {dimensao}");
        Console.WriteLine($"x dado: {x}");
        Console.WriteLine($"y dado: {y}");
        return default(T);
    } // GetValido


    // serve para que se possa passar um objeto
    // desta classe em Console.WriteLine, e vi-
    // sualizar todos os dados armazenados
    public override string ToString() {
        var numeros = new List<string>();

        for (int i = 0; i < dimensao; i++) {
            for (int j = 0; j < dimensao; j++) {
                var valor = Convert.ToInt32(elementos[i,j]);
                numeros.Add($" {valor}");
            }
            if (i < dimensao - 1) numeros.Add("\n");
        }
        return string.Join("", numeros);
    } // ToString


    public T[] Linha(int x) {
        return IndiceEhValido(x)?
            CopiarLinha(x):
            new T[0];
    } // Linha


    private T[] CopiarLinha(int x) {
        var linha = new T[dimensao];
        for (int i = 0; i < dimensao; i++)
            linha[i] = elementos[x, i];
        return linha;
    } // CopiarLinha


    public List<int> FiltrarLinha(int x, T valor) {
        var indices = new List<int>();

        var linha   = Linha(x);
        for (int i = 0; i < dimensao; i++)
            if (linha[i].Equals(valor)) indices.Add(i);
        return indices;
    } // FiltrarLinha


} // class MatrizQuadrada<T>
} // namespace Grafos
