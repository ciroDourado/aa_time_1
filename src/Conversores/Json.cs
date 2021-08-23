using System.Collections.Generic;
using Newtonsoft.Json;

namespace Conversores {

class Json {

    public static
    T Deserializar<T>(string dados) {
        return JsonConvert.DeserializeObject<T>(
            dados
        );
    } // Deserializar

    public static
    string Serializar(object objeto) {
        var indentado         = Formatting.Indented;
        var ignorarNull       = new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        };
        return JsonConvert.SerializeObject(
            objeto,
            indentado,
            ignorarNull
        );
    } // Serializar

    public static
    string Formatar<T>(string dados) {
        object objeto = Deserializar<T>(dados);
        return Serializar(objeto);
    } // Formatar

} // class Json
} // namespace Conversores
