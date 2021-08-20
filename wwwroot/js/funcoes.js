async function carregarArquivoJson(caminho) {
    const resposta = await fetch(caminho);
    const dados = await resposta.json();

    return dados;
} // carregarArquivoJson


function formatarTempo(datasetData) {
    const tempo = datasetData.y;
    const tempoString = tempo.replace("00:00:00.", "");
    return Number(tempoString);
} // formatarTempo


function configGrafico(tipo, datasets, ylabel) {
    const dados = {
        datasets: datasets
    };
    const eixoX = {
        type: 'linear',
        ticks: {
            stepSize: 100
        },
        title: {
            display: true,
            text: "n (numero de entradas)",
        },
    };
    const eixoY = {
        title: {
            display: true,
            text: ylabel
        }
    };
    const escalas = {
        x: eixoX,
        y: eixoY
    };
    const parsing = {
        xAxisKey: 'x',
        yAxisKey: 'y',
    };

    return {
        type: tipo,
        data: dados,
        options: {
            scales: escalas,
        }
    }; // return
} // configGrafico

function gerarCorAleatoria() {
	const maior = parseInt("666666", 16);
	const menor = parseInt("222222", 16);
	const rand = Math.random();

	const cor = rand * (maior - menor) + menor;
    const corHex = Math.floor(cor);
	
	const asHexDecimal = 16;
    return `#${corHex.toString(asHexDecimal)}`;
} // gerarCorAleatoria


function gerarDataset(identificador, valores) {
    const cor  = gerarCorAleatoria();
    const data = valores.map((valor, index) => {
        return {x: index, y: valor};
    });
    return {
        label: identificador,
        data : data,
        pointRadius: 0.5,
        borderColor    : cor,
        backgroundColor: cor,
    };
} // gerarDataset
