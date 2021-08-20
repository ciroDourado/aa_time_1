indiceInicial = 3;
elementos = 999;

// Pega a string dos dados em json
instrucoesLinear  = JSON.parse(document.querySelector("span#instrucoes_linear").innerText);
instrucoesFiltro  = JSON.parse(document.querySelector("span#instrucoes_filtro").innerText);
instrucoesBolha   = JSON.parse(document.querySelector("span#instrucoes_bolha").innerText);
instrucoesBinaria = JSON.parse(document.querySelector("span#instrucoes_binaria").innerText);

instrucoesLinearDataset  = gerarDataset("Linear",  instrucoesLinear.slice(indiceInicial, elementos));
instrucoesFiltroDataset  = gerarDataset("Filtro",  instrucoesFiltro.slice(indiceInicial, elementos));
instrucoesBolhaDataset   = gerarDataset("Bolha",   instrucoesBolha.slice(indiceInicial, elementos));
instrucoesBinariaDataset = gerarDataset("Binaria", instrucoesBinaria.slice(indiceInicial, elementos));

InstrucoesDatasets = [
    instrucoesLinearDataset,
    instrucoesFiltroDataset,
    instrucoesBolhaDataset,
    instrucoesBinariaDataset
];
configInstrucoes = configGrafico("line", InstrucoesDatasets, "O(n) (instrucoes)");
canvasInstrucoes = document.getElementById("chartInstrucoes").getContext("2d");
// graficoInstrucoes = new Chart(canvasInstrucoes, configInstrucoes);



tempoLinear  = JSON.parse(document.querySelector("span#tempo_linear").innerText);
tempoFiltro  = JSON.parse(document.querySelector("span#tempo_filtro").innerText);
tempoBolha   = JSON.parse(document.querySelector("span#tempo_bolha").innerText);
tempoBinaria = JSON.parse(document.querySelector("span#tempo_binaria").innerText);

tempoLinearDataset  = gerarDataset("Linear",  tempoLinear.slice(indiceInicial, elementos));
tempoFiltroDataset  = gerarDataset("Filtro",  tempoFiltro.slice(indiceInicial, elementos));
tempoBolhaDataset   = gerarDataset("Bolha",   tempoBolha.slice(indiceInicial, elementos));
tempoBinariaDataset = gerarDataset("Binaria", tempoBinaria.slice(indiceInicial, elementos));

TempoDatasets = [
    tempoLinearDataset,
    tempoFiltroDataset,
    tempoBolhaDataset,
    tempoBinariaDataset
].map(dataset => gerarDataset(
    dataset.label,
    dataset.data.map(formatarTempo)
));

configTempo = configGrafico("line", TempoDatasets, "t (tempo em milisegundos)");
canvasTempo = document.getElementById("chartTempo").getContext("2d");

//
tempoHashMd5    = JSON.parse(document.querySelector("span#tempo_hash_md5").innerText);
tempoHashSqm    = JSON.parse(document.querySelector("span#tempo_hash_sqm").innerText);
tempoHashLinear = JSON.parse(document.querySelector("span#tempo_hash_linear").innerText);

tempoHashMd5Dataset    = gerarDataset("MD5",  tempoHashMd5);
tempoHashSqmDataset    = gerarDataset("SQM",  tempoHashSqm);
tempoHashLinearDataset = gerarDataset("Busca Linear", tempoHashLinear);

TempoHashDatasets = [
    tempoHashMd5Dataset,
    tempoHashSqmDataset,
    tempoHashLinearDataset,
].map(dataset => gerarDataset(
    dataset.label,
    dataset.data.map(formatarTempo)
));


configTempoHash = configGrafico("line", TempoHashDatasets, "t (tempo em milisegundos)");
canvasTempoHash = document.getElementById("chartTempoHash").getContext("2d");

// graficoTempo = new Chart(canvasTempo, configTempo);



charts = [
    new Chart(canvasInstrucoes, configInstrucoes),
    new Chart(canvasTempo, configTempo),
    new Chart(canvasTempoHash, configTempoHash)
];
