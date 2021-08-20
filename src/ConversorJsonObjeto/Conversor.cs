using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConversorJsonObjeto {

    class Conversor {

        public static
        T JsonParaObjeto<T>(string dados) {
            return JsonConvert.DeserializeObject<T>(
                dados
            );
        } // JsonParaObjeto

        public static
        string ObjetoParaJson(object objeto) {
            return JsonConvert.SerializeObject(
                objeto,
                Formatting.Indented
            );
        } // ObjetoParaJson

        public static
        string FormatarComo<T>(string dados) {
            object objeto = JsonParaObjeto<T>(dados);
            return ObjetoParaJson(objeto);
        } // Formatar

    } // class Conversor

} // namespace ConversorJsonObjeto
