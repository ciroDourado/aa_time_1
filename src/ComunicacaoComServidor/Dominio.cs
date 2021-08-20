namespace ComunicacaoComServidor {

	class Dominio {
		private string dominio;

		// este construtor cria uma
		// instância vazia de seu atributo
		public Dominio() {
			this.dominio = string.Empty;
		} // construtor padrão

		// este construtor cria uma instância
		// inicializada de seu atributo
		public Dominio(string dominio) {
			this.Set(dominio);
		} // construtor parametrizado

		// este método é responsável por
		// inicializar ou modificar o atributo
		public void Set(string dominio) {
			this.dominio = dominio;
		} // método Set

		// este método retorna a informação
		// guardada em seu atributo
		public string Get() {
			return this.dominio;
		} // método Get

	} // class Dominio

} // namespace ComunicacaoComServidor
