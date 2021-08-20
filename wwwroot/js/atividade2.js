tempoHashMd5    = JSON.parse(document.querySelector("#tempo_hash_md5").innerText);
tempoHashSqm    = JSON.parse(document.querySelector("#tempo_hash_sqm").innerText);
tempoHashLinear = JSON.parse(document.querySelector("#tempo_hash_linear").innerText);

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

charts = [
    new Chart(canvasTempoHash, configTempoHash)
];
