const dados = JSON.parse(
  document.querySelector("span#vertices-json").innerText)
    .map(vertice => ({
      ...vertice,
      s: "M"
    })
);


// Funções de configuração do grafo segundo documentação da lib

// create and initialize the Diagram.model given an array of node data representing people
function setupDiagram(diagram, array, focusId) {
  diagram.model =
    go.GraphObject.make(go.GraphLinksModel,
      { // declare support for link label nodes
        linkLabelKeysProperty: "labelKeys",
        // this property determines which template is used
        nodeCategoryProperty: "s",
        // if a node data object is copied, copy its data.a Array
        copiesArrays: true,
        // create all of the nodes for people
        nodeDataArray: array
      });
  setupMarriages(diagram);
  setupParents(diagram);

  var node = diagram.findNodeForKey(focusId);
  if (node !== null) {
    diagram.select(node);
  }
}

function findMarriage(diagram, a, b) {  // A and B are node keys
  var nodeA = diagram.findNodeForKey(a);
  var nodeB = diagram.findNodeForKey(b);
  if (nodeA !== null && nodeB !== null) {
    var it = nodeA.findLinksBetween(nodeB);  // in either direction
    while (it.next()) {
      var link = it.value;
      // Link.data.category === "Marriage" means it's a marriage relationship
      if (link.data !== null && link.data.category === "Marriage") return link;
    }
  }
  return null;
}