namespace Models {
    class NoGenograma {
        public int?     key { get; set; } // id único
        public string   n   { get; set; } // nome
        public string   s   { get; set; } // sexo
        public int?     m   { get; set; } // id mãe
        public int?     f   { get; set; } // id pai
        public int?     ux  { get; set; } // id esposa
        public int?     vir { get; set; } // id marido
        public string[] a   { get; set; } // atributos do nó

        public NoGenograma() {
            key = null;
            n   = null;
            s   = null;
            m   = null;
            f   = null;
            ux  = null;
            vir = null;
            a   = null;
        } // new()

        public override string ToString() {
            string[] partes = {
                $"key: {key}",
                $"n: \"{n}\"",
                $"s: \"{s}\"",
                $"m: {m}",
                $"f: {f}",
                $"ux: {ux}",
                $"vir: {vir}"
            };
            return $"{{{string.Join(", ", partes)}}}";
        } // metodo ToString
    } // class NoGenograma
} // namespace models
