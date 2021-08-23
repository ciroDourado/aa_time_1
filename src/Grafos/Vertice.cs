namespace Grafos {
class Vertice {
    private string label;
    private string sexo;

    public Vertice() {
        label = string.Empty;
        sexo  = string.Empty;
    } // new()

    public Vertice(string label) {
        this.label = label;
    } // new(args)

    public Vertice(string label, string sexo) {
        this.label = label;
        this.sexo  = sexo;
    } // new(args)

    public string Label() {
        return label;
    } // get

    public string Sexo() {
        return sexo;
    } // get

    public bool EhIgual(string label) {
        return label.Equals(this.label);
    } // EhIgual

    public override string ToString() {
        return $"{label}";
    } // ToString
} // class Vertice
} // namespace Grafos
