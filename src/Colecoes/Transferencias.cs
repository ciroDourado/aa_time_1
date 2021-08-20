using System.Collections.Generic;
using System.Diagnostics;
using System;

using Complexidade.Instrucoes;
using Complexidade.Tempo;
using ConversorJsonObjeto;
using Models;

namespace Colecoes {

    class Transferencias:
        IAlgoritmos<Transferencias, Transferencia>,
        IAnaliseInstrucoes,
        IAnaliseTempo
    {
        private List<Transferencia> transferencias;

        // este construtor cria uma
        // instância vazia de seu atributo
        public Transferencias() {
            this.transferencias = new List<Transferencia>();
        } // construtor padrao


		// este construtor cria uma instância
		// inicializada de seu atributo
        public Transferencias(Transferencia init) {
            this.Adicionar(init);
        } // construtor parametrizado


		// este construtor cria uma instância
		// inicializada de seu atributo
        public Transferencias(Transferencia[] init) {
            this.transferencias = new List<Transferencia>();
            this.AdicionarVarias(init);
        } // construtor parametrizado


		// este construtor cria uma instância
		// inicializada de seu atributo
        public Transferencias(List<Transferencia> init) {
            this.transferencias = init;
        } // construtor parametrizado


		// este metodo insere um valor no conjunto
        public void Adicionar(Transferencia transferencia) {
            this.transferencias.Add(transferencia);
        } // metodo Adicionar


		// este metodo insere um valor no conjunto
        public void AdicionarVarias(Transferencia[] transf) {
            this.transferencias.AddRange(transf);
        } // metodo Adicionar


		// este metodo insere um valor no conjunto
        public void AdicionarVarias(List<Transferencia> transf) {
            this.transferencias = transf;
        } // metodo Adicionar


		// este metodo insere um valor no conjunto
        public void AdicionarVarias(Transferencias transf) {
            this.transferencias.AddRange(transf.ToArray());
        } // metodo Adicionar


		// este metodo insere um valor no conjunto
        public void AdicionarVarias(string json) {
            var transf = Conversor.JsonParaObjeto<List<Transferencia>>(json);
            this.transferencias.AddRange(transf.ToArray());
        } // metodo Adicionar


        public List<Transferencia> Get() {
            return this.transferencias;
        } // metodo get transferencias


        public Transferencia[] ToArray() {
            return this.transferencias.ToArray();
        } // metodo ToArray


        // implementação da BuscaLinear de IAlgoritmos
        public Transferencia BuscaLinear(string codigo) {
            foreach (var transferencia in this.transferencias) {
                if (transferencia.codigoFavorecido.Equals(codigo))
                    return transferencia;
            }
            return null;
        } // metodo BuscaLinear


        // implementacao de InstrucoesLinear de IAnaliseInstrucoes
        public List<int> InstrucoesLinear(string codigo) {
            var instrucoesRelevantes = new List<int>();

            for (int n = 0; n < this.transferencias.Count; n++) {
                int contagemInstrucoes = 0;

                for (int i = 0; i < n; i++) {
                    contagemInstrucoes += 1;
                    contagemInstrucoes += 1;
                }
                contagemInstrucoes += 1;

                instrucoesRelevantes.Add(contagemInstrucoes);
            }
            return instrucoesRelevantes;
        } // metodo InstrucoesLinear


        // implementacao de TempoLinear de IAnaliseTempo
        public List<TimeSpan> TempoLinear(string codigo) {
            var cronometro = Stopwatch.StartNew();
            var temposMedidos = new List<TimeSpan>();

            for (int n = 0; n < this.transferencias.Count; n++) {
                var nDados = this.transferencias.GetRange(0, n);
                var dados  = new Transferencias(nDados);

                cronometro.Restart();
                dados.BuscaLinear(codigo);
                temposMedidos.Add(cronometro.Elapsed);
            }
            return temposMedidos;
        } // metodo TempoLinear


        // implementaçao de Filtro de IAlgoritmos
        public Transferencias Filtro(string funcao) {
            var filtradas = new Transferencias();

            foreach (var transferencia in this.transferencias) {
                if (transferencia.funcao.Equals(funcao))
                    filtradas.Adicionar(transferencia);
            }
            return filtradas;
        } // metodo Filtro


        // implementacao de InstrucoesFiltro de IAnaliseInstrucoes
        public List<int> InstrucoesFiltro(string funcao) {
            var instrucoesRelevantes = new List<int>();

            for (int n = 0; n < this.transferencias.Count; n++) {
                int contagemInstrucoes = 0;

                contagemInstrucoes += 1;
                for (int i = 0; i < n; i++) {
                    contagemInstrucoes += 1;
                    contagemInstrucoes += 1;
                }
                contagemInstrucoes += 1;

                instrucoesRelevantes.Add(contagemInstrucoes);
            }
            return instrucoesRelevantes;
        } // metodo InstrucoesFiltro


        // implementacao de TempoFiltro de IAnaliseTempo
        public List<TimeSpan> TempoFiltro(string funcao) {
            var cronometro = Stopwatch.StartNew();
            var temposMedidos = new List<TimeSpan>();

            for (int n = 0; n < this.transferencias.Count; n++) {
                var nDados = this.transferencias.GetRange(0, n);
                var dados  = new Transferencias(nDados);

                cronometro.Restart();
                dados.Filtro(funcao);
                temposMedidos.Add(cronometro.Elapsed);
            }
            return temposMedidos;
        } // metodo TempoFiltro


        // implementaçao de OrdenacaoBolha de IAlgoritmos
        public Transferencias OrdenacaoBolha() {
            var dados = this.transferencias;

            for (int i = 0; i < dados.Count; i++) {
              for (int j = 0; j < dados.Count; j++) {
                var codigoI = dados[i].codigoFavorecido;
                var codigoJ = dados[j].codigoFavorecido;

                if (string.Compare(codigoI, codigoJ) >= 0) {
                  Transferencia aux = dados[i];
                  dados[i] = dados[j];
                  dados[j] = aux;
                } // condicional
              } // for interno
            } // for externo

            return new Transferencias(dados);
        } // metodo OrdenacaoBolha


        // implementacao de InstrucoesBolha de IAnaliseInstrucoes
        public List<int> InstrucoesBolha() {
            var instrucoesRelevantes = new List<int>();

            for (int n = 0; n < (this.transferencias.Count)/6; n++) {
                int contagemInstrucoes = 0;

                contagemInstrucoes += 1;
                for (int i = 0; i < n; i++) {
                  for (int j = 0; j < n; j++) {
                    contagemInstrucoes += 2;
                    contagemInstrucoes += 4;
                  } // for interno
                } // for externo
                contagemInstrucoes += 1;

                instrucoesRelevantes.Add(contagemInstrucoes);
            }
            return instrucoesRelevantes;
        } // metodo InstrucoesBolha


        // implementacao de TempoBolha de IAnaliseTempo
        public List<TimeSpan> TempoBolha() {
            var cronometro = Stopwatch.StartNew();
            var temposMedidos = new List<TimeSpan>();

            for (int n = 0; n < (this.transferencias.Count)/6; n++) {
                var nDados = this.transferencias.GetRange(0, n);
                var dados  = new Transferencias(nDados);

                cronometro.Restart();
                dados.OrdenacaoBolha();
                temposMedidos.Add(cronometro.Elapsed);
            }
            return temposMedidos;
        } // metodo TempoBolha


        public void FastSort() {
            this.transferencias.Sort(
                delegate(Transferencia x, Transferencia y) {
                    if (x.codigoFavorecido == null && y.codigoFavorecido == null)
                        return 0;
                    else if (x.codigoFavorecido == null)
                        return -1;
                    else if (y.codigoFavorecido == null)
                        return 1;
                    else
                        return x.codigoFavorecido.CompareTo(y.codigoFavorecido);
                }
            );
        } // FastSort


        // implementacao de BuscaBinaria de IAlgoritmos
        public Transferencia BuscaBinaria(string codigo) {
            var dados = this.transferencias;
			int inferior = 0;
			int superior = dados.Count - 1;

			while (inferior <= superior) {
				int meio = (inferior + superior) / 2;
				if (dados[meio].codigoFavorecido.Equals(codigo)) {
					return dados[meio];
				} else if (string.Compare(dados[meio].codigoFavorecido, codigo) > 0) {
					superior = meio - 1;
				} else {
					inferior = meio + 1;
				}
			}
            return null;
        } // metodo BuscaBinaria


        // implementacao de InstrucoesBinaria de IAnaliseInstrucoes
        public List<int> InstrucoesBinaria(string codigo) {
            var instrucoesRelevantes = new List<int>();

            for (int n = 0; n < this.transferencias.Count; n++) {
                int contagemInstrucoes = 0;

                contagemInstrucoes += 1;
                contagemInstrucoes += 1;
                contagemInstrucoes += 2;
                var iteracao = n;

    			while (iteracao >= 1) {
                    iteracao = iteracao / 2;
                    contagemInstrucoes += 3;
                    contagemInstrucoes += 3;
    			}
                contagemInstrucoes += 1;

                instrucoesRelevantes.Add(contagemInstrucoes);
            }
            return instrucoesRelevantes;
        } // metodo InstrucoesBinaria


        // implementacao de TempoBinaria de IAnaliseTempo
        public List<TimeSpan> TempoBinaria(string codigo) {
            var cronometro = Stopwatch.StartNew();
            var temposMedidos = new List<TimeSpan>();

            for (int n = 0; n < this.transferencias.Count; n++) {
                var nDados = this.transferencias.GetRange(0, n);
                var dados  = new Transferencias(nDados);

                dados.FastSort();
                // foreach (var transferencia in dados.Get()) {
                //     Console.WriteLine(transferencia.Formatar());
                // } // mostra os dados ordenados corretamente

                cronometro.Restart();
                dados.BuscaBinaria(codigo);
                temposMedidos.Add(cronometro.Elapsed);
            }
            return temposMedidos;
        } // metodo TempoBinaria

    } // class Transferencias

} // namespace Colecoes
