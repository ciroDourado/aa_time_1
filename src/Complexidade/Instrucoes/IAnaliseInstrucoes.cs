using System.Collections.Generic;

namespace Complexidade.Instrucoes {

    public interface IAnaliseInstrucoes {

        List<int> InstrucoesLinear(string codigo);
        List<int> InstrucoesFiltro(string funcao);
        List<int> InstrucoesBolha();
        List<int> InstrucoesBinaria(string codigo);

    } // interface IAnaliseInstrucoes

} // namespace Complexidade.Instrucoes
