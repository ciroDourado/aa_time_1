using System;

namespace ColecoesApi {

    public interface IAlgoritmos<Colecao, Elemento> {

        Elemento BuscaLinear(string codigo);
        Colecao Filtro(string funcao);
        Colecao OrdenacaoBolha();
        Elemento BuscaBinaria(string codigo);

    } // interface IAlgoritmos

} // namespace ColecoesApi
