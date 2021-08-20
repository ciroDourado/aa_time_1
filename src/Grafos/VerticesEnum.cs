using System.Collections.Generic;
using System.Collections;

class VerticesEnum: IEnumerator {
    public Queue<Vertice> vertices;
    int position = -1;

    public VerticesEnum(Queue<Vertice> vertices) {
        this.vertices = vertices;
    } // new(args)

    public bool MoveNext() {
        position++;
        return (position < vertices.Count);
    } // MoveNext

    public void Reset() {
        position = -1;
    } // Reset

    object IEnumerator.Current {
        get { return Current; }
    } // Current

    public Vertice Current {
        get {
            int i = 0;
            foreach (var vertice in vertices) {
                if (i == position) return vertice;
                i++;
            }
            return new Vertice();
        }
    } // Current

} // class VerticesEnum
