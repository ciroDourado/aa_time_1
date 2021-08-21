using System.Collections.Generic;
using System.Text;
using System;

namespace ConexaoHttp {

    class Query {
        private Stack<string> queries;

		// este construtor cria uma
		// instância vazia de seu atributo
        public Query() {
            this.queries = new Stack<string>();
        } // construtor padrao

		// este construtor cria uma instância
		// inicializada de seu atributo
        public Query(string query) {
            this.queries = new Stack<string>();
            this.Adicionar(query);
        } // construtor parametrizado

		// este método é responsável por
		// adicionar um item ao atributo
        public void Adicionar(string query) {
            this.queries.Push(query);
        } // metodo Adicionar

		// este método é responsável por
		// remover um item do atributo
        public string RemoverUltima() {
            return this.queries.Pop();
        } // metodo RemoverUltima

		// este método é responsável por
		// trocar todos os itens do atributo por um
        public void TrocarTodasPor(string query) {
            this.queries = new Stack<string>();
            this.Adicionar(query);
        } // metodo TrocarTodasPor

		// este método é responsável por trocar
		// todos os itens do atributo por nenhum ou mais
        public void TrocarTodasPor(Query novas) {
            this.queries = novas.queries;
        } // metodo TrocarTodasPor

        // remove todas as ocorrências da query dada
        // apenas se ela estiver entre todas as queries
        // retorna:
        // |> true se havia alguma
        // |> false não houver nenhuma
        public bool Filtrar(string query) {
            bool resultado = this.queries.Contains(query);

            switch( resultado ) {
                case true : this._Filtrar(query); break;
                case false: break;
            }
            return resultado;
        } // metodo Filtrar

        // remove todas as ocorrências da query dada
        // criando uma nova estrutura de queries sem ela
        private void _Filtrar(string queryProcurada) {
            var novasQueries = new Query();

            foreach (string query in this.queries) {
                if( query.Equals(queryProcurada) )
                    novasQueries.Adicionar(query);
            } // foreach

            this.queries = novasQueries.queries;
        } // metodo _Filtrar


        override
        public string ToString() {
            var queriesFormatadas = new StringBuilder();

            foreach (string query in this.queries) {
                queriesFormatadas.Append($"{query}&");
            } // foreach
            int ultimoIndice = queriesFormatadas.Length - 1;
            queriesFormatadas.Remove(ultimoIndice, 1);

            return queriesFormatadas.ToString();
        } // ToString

    } // class Query

} // namespace ConexaoHttp
