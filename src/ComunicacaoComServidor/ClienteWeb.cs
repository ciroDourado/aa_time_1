using System.Threading.Tasks;
using System.Net.Http;
using System.IO;

namespace ComunicacaoComServidor {

    class ClienteWeb {
        private Url        url;
        private HttpClient client;

		// este construtor cria uma
		// instância vazia de seus atributos
        public ClienteWeb() {
            this.url    = new Url();
            this.client = new HttpClient();
        } // construtor padrão

		// este construtor cria uma
		// instância inicializada seus atributos
        public ClienteWeb(Url url) {
            this.url    = url;
            this.client = new HttpClient();
        } // construtor parametrizado

		// este método retorna a
		// instância de seu atributo Url
        public Url Url() {
            return this.url;
        } // get url

		// este método retorna adiciona um par
        // de chave-valor ao header, para satisfazer
        // alguma condição do endpoint
        public void AdicionarNoHeader(string key, string value) {
            this.client.DefaultRequestHeaders.Add(key, value);
        } // AdicionarNoHeader

        // faz uma requisição para o servidor
        public async Task<string> RequestString() {
            var _client  = this.client;
            var _fromUrl = this.url.Format();

            return await _client.GetStringAsync(_fromUrl);
        } // RequestString

    } // class ClienteWeb

} // namespace ComunicacaoComServidor
