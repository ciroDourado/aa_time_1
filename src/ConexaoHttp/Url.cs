namespace ConexaoHttp {

	class Url {
		private Dominio dominio;
		private Caminho caminho;
		private Query   queries;

		// este construtor cria instâncias
		// vazias de cada um de seus atributos
		public Url() {
			this.dominio = new Dominio();
			this.caminho = new Caminho();
			this.queries = new Query();
		} // construtor padrão

		// este construtor inicializa seus
		// atributos com instâncias já criadas
		public Url(Dominio dmn, Caminho cmn, Query qrs) {
			this.dominio = dmn;
			this.caminho = cmn;
			this.queries = qrs;
		} // construtor parametrizado

		// este construtor inicializa os atributos
		// dominio e caminho, criando instâncias
		// inicializadas, e uma instância vazia de queries
		public Url(string dmn, string cmn) {
			this.dominio = new Dominio(dmn);
			this.caminho = new Caminho(cmn);
			this.queries = new Query();
		} // construtor parametrizado

		// este construtor inicializa seus atributos,
		// criando instâncias inicializadas
		public Url(string dmn, string cmn, string qry) {
			this.dominio = new Dominio(dmn);
			this.caminho = new Caminho(cmn);
			this.queries = new Query(qry);
		} // construtor parametrizado

		// este método retorna a referência ao
		// atributo domínio, para que os métodos
		// de sua classe possam ser chamados
		// Ex.: var url = new Url();
		// 		url.Dominio.Set("exemplo.com");
		public Dominio Dominio() {
			return this.dominio;
		} // get dominio

		// este método retorna a referência ao
		// atributo caminho, para que os métodos
		// de sua classe possam ser chamados
		// Ex.: var url = new Url();
		// 		url.Caminho.Set("aqui/perto/");
		public Caminho Caminho() {
			return this.caminho;
		} // get caminho

		// este método retorna a referência ao
		// atributo caminho, para que os métodos
		// de sua classe possam ser chamados
		// Ex.: var url = new Url();
		// 		url.Queries.Adicionar("key=value");
		public Query Queries() {
			return this.queries;
		} // get queries

		// método que formata todos os
		// atributos/objetos em uma só string
		public string Format() {
			string _dominio = this.Dominio().Get();
			string _caminho = this.Caminho().Get();
			string _queries = this.Queries().ToString();

			return $"{_dominio}/{_caminho}?{_queries}";
		} // método Format

	} // class Url

} // namespace ConexaoHttp
