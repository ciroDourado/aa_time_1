const dados = JSON.parse(
  document.querySelector("span#vertices-json").innerText)
    .map(vertice => ({
      ...vertice,
      s: "M"
    })
);

console.log(dados);