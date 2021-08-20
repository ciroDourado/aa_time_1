class Vertice {
    private string label;

    public Vertice() {
        label = string.Empty;
    } // new()

    public Vertice(string label) {
        this.label = label;
    } // new(args)

    public string Label() {
        return label;
    } // get

    public bool EhIgual(string label) {
        return label.Equals(this.label);
    } // EhIgual

    public override string ToString() {
        return $"{label}";
    } // ToString
} // class Vertice
