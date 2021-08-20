namespace ComunicacaoComServidor {

    class Caminho {
        private string caminho;

		// este construtor cria uma
		// instância vazia de seu atributo
        public Caminho() {
            this.caminho = string.Empty;
        } // construtor padrao

		// este construtor cria uma instância
		// inicializada de seu atributo
        public Caminho(string caminho) {
            this.Set(caminho);
        } // construtor parametrizado

		// este método é responsável por
		// inicializar ou modificar o atributo
        public void Set(string caminho) {
            this.caminho = caminho;
        } // metodo Set

		// este método retorna a informação
		// guardada em seu atributo
        public string Get() {
            return this.caminho;
        } // metodo Get

    } // class Caminho

} // namespace ComunicacaoComServidor
