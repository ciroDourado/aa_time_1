using System.Collections.Generic;
using System;

namespace Complexidade.Tempo {

    public interface IAnaliseTempo {

        List<TimeSpan> TempoLinear(string codigo);
        List<TimeSpan> TempoFiltro(string funcao);
        List<TimeSpan> TempoBolha();
        List<TimeSpan> TempoBinaria(string codigo);

    } // interface IAnaliseTempo

} // namespace Complexidade.Tempo
