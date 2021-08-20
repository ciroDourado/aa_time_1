namespace Models {

    class Transferencia: IFormatacaoModel {
        public string acao                             { get; set; }
        public string codigoAcao                       { get; set; }
        public string codigoElementoDespesa            { get; set; }
        public string codigoFavorecido                 { get; set; }
        public string codigoFuncao                     { get; set; }
        public string codigoGrupoDespesa               { get; set; }
        public string codigoModalidadeAplicacaoDespesa { get; set; }
        public string codigoOrgao                      { get; set; }
        public string codigoPrograma                   { get; set; }
        public string elementoDespesa                  { get; set; }
        public string favorecido                       { get; set; }
        public string funcao                           { get; set; }
        public string grupoDespesa                     { get; set; }
        public int    mesAno                           { get; set; }
        public string modalidadeAplicacaoDespesa       { get; set; }
        public string orgao                            { get; set; }
        public string programa                         { get; set; }
        public string tipoFavorecido                   { get; set; }
        public string tipoTransferencia                { get; set; }
        public string valor                            { get; set; }


        // implementacao de Formatar de IFormatacao
        public string Formatar() {
            var dado1 = $"Código do favorecido: {codigoFavorecido}";
            var dado2 = $"Função da transferência: {funcao}";
            return $"{dado1}\n{dado2}";
        } // metodo Formatar
    } // class Transferencia

} // namespace models
