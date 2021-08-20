using System.IO;
using System;

namespace ES {

    class wipArquivo {
        private string dados;

		// este construtor cria uma
		// instância vazia de seu atributo
        public wipArquivo() {
            this.dados = string.Empty;
        } // construtor padrao

		// este construtor cria uma instância
		// inicializada de seu atributo
        public wipArquivo(string _dados) {
            this.dados = _dados;
        } // construtor padrao

		// este método retorna a informação
		// guardada em seu atributo
        public string Get() {
            return this.dados;
        } // metodo get

		// este método retorna a informação
		// guardada em seu atributo
        public void Set(string _dados) {
            this.dados = _dados;
            GC.Collect();
        } // metodo set

		// este método limpa os dados
		// guardados em memoria
        public void LimparDados() {
            this.dados = string.Empty;
            GC.Collect();
        } // metodo get

        // verifica se o arquivo existe
        public bool Existe(string caminho) {
            return File.Exists(caminho);
        } // Existe

        // verifica se o arquivo nao existe
        public bool NaoExisteAinda(string caminho) {
            return ! File.Exists(caminho);
        } // NaoExisteAinda

        // verifica se o arquivo nao existe
        public static
        bool NaoExiste(string caminho) {
            return ! File.Exists(caminho);
        } // NaoExiste

        // este metodo salva todos os dados
        // no caminho especificado
        public void SalvarEm(string caminho) {
            File.WriteAllText(caminho, this.dados);
        } // SalvarEm

        // este metodo le todos os dados
        // do arquivo especificado e deixa na memoria
        public wipArquivo LerTodosOsDadosDe(string caminho) {
            this.dados = File.ReadAllText(caminho);
            return this;
        } // JsonParaObjeto

    } // class Arquivo

} // namespace ManipulacaoDeArquivos
