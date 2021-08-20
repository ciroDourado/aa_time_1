using System.Collections.Generic;
using System.Diagnostics;
using System;
using Tabelas;

namespace ES {

class Analise {

    static public
    List<TimeSpan> TempoLista(byte[] procurado, List<string> arquivos) {
        var cronometro    = Stopwatch.StartNew();
        var temposMedidos = new List<TimeSpan>();
        var ultimo        = arquivos.Count - 1;

        for (int n = 0; n < ultimo; n++) {
            var nArquivos = arquivos.GetRange(0, n);
            nArquivos.Add(arquivos[ultimo]);

            cronometro.Restart();
            var res = Diretorio.ArquivoExiste(procurado, nArquivos);
            temposMedidos.Add(cronometro.Elapsed);

            Console.WriteLine($"{n} - {cronometro.Elapsed} - {res}");
        }
        return temposMedidos;
    } // TempoLista


    static public
    List<TimeSpan> TempoTabela<T>(byte[] procurado, List<string> arquivos)
        where T: IHasher, new()
    {
        var cronometro    = Stopwatch.StartNew();
        var temposMedidos = new List<TimeSpan>();
        var ultimo        = arquivos.Count - 1;

        for (int n = 0; n < ultimo; n++) {
            var nArquivos = arquivos.GetRange(0, n);

            var arquivosTabelados = new Tabela<T>(nArquivos.Count + 1);
            arquivosTabelados.Adicionar(nArquivos);
            arquivosTabelados.Adicionar(arquivos[ultimo]);

            cronometro.Restart();
            var res = Diretorio.ArquivoExiste(procurado, arquivosTabelados);
            temposMedidos.Add(cronometro.Elapsed);

            Console.WriteLine($"{n} - {cronometro.Elapsed} - {res}");
        }
        return temposMedidos;
    } // TempoTabela

} // class Analise

} // namespace Diretorios
