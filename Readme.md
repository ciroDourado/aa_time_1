## Universidade Estadual do Maranhão
## Estrutura de Dados Avançados
## Atividades Assíncronas do Time 1

**Alunos:**

* Ciro Dourado
* Douglas Castro
* Gabriel Câncio
* Jonas Carvalho
* João Gabriel

### Diário do projeto:

**17/08/2021** - Apresentação da segunda atividade referente ao assunto de Hashing como requisito para obtenção da segunda nota.

**25/06/2021** - A modelagem está bem encaminhada; e ao mesmo passo que ela foi sendo desenvolvida, parte do programa foi codificado a fim de que se pudesse testar:
- a comunicação com a API; 
- o download de arquivos; 
- e o armazenamento local. 

## Atividade 1:
Todo o código responsável por isso pode ser resumido pelo print a seguir:

![](https://github.com/marcelovidgal/aa_time_1/blob/main/docs/imgs/codigo_principal.png)

E a respectiva árvore de arquivos do projeto está organizada em namespaces, como abaixo:

![](https://github.com/marcelovidgal/aa_time_1/blob/main/docs/imgs/arvore_de_arquivos.png)

### Gráficos Plotados
#### Número de Entradas em relação ao tempo
<img src="https://github.com/marcelovidgal/aa_time_1/blob/main/docs/imgs/grafico1/0Geral.PNG" alt="0Geral" width="550"/>

#### Número de entradas em relação ao número de instruções
<img src="https://github.com/marcelovidgal/aa_time_1/blob/main/docs/imgs/grafico2/0Geral.PNG" alt="0Geral" width="550"/>

#### Linear - Equação: 2n + 1
<img src="https://github.com/marcelovidgal/aa_time_1/blob/main/docs/imgs/grafico1/1Linear.PNG" alt="1Linear" width="550"/>
<img src="https://github.com/marcelovidgal/aa_time_1/blob/main/docs/imgs/grafico2/1Linear.PNG" alt="1Linear" width="550"/>

#### Filtro - Equação: 2n + 2
<img src="https://github.com/marcelovidgal/aa_time_1/blob/main/docs/imgs/grafico1/2Filtro.PNG" alt="2Filtro" width="550"/>
<img src="https://github.com/marcelovidgal/aa_time_1/blob/main/docs/imgs/grafico2/2Filtro.PNG" alt="2Filtro" width="550"/>

#### Bolha - Equação: 6n²+2
<img src="https://github.com/marcelovidgal/aa_time_1/blob/main/docs/imgs/grafico1/3Bolha.PNG" alt="3Bolha" width="550"/>
<img src="https://github.com/marcelovidgal/aa_time_1/blob/main/docs/imgs/grafico2/3Bolha.PNG" alt="3Bolha" width="550"/>

### Binária - Equação: 5 + 6log2(n)
<img src="https://github.com/marcelovidgal/aa_time_1/blob/main/docs/imgs/grafico1/4Binaria.PNG" alt="4Binaria" width="550"/>
<img src="https://github.com/marcelovidgal/aa_time_1/blob/main/docs/imgs/grafico2/4Binaria.PNG" alt="4Binaria" width="550"/>


## Atividade 2:
Com um conjunto de imagens 4K em um diretório, esse trabalho consistiu em buscar a última imagem desse conjunto, através de uma Tabela Hash em dois cenários: utilizando a função de hash do Quadrado Médio e a função de hash MD5. Além disso, foi feita uma Busca Binária para fins de comparação. Em todos os casos, a eficiência de cada algoritmos foi testada e os resultados comparativos foram ilustrados graficamente utilizando o chart.js.

<img src="https://i.ibb.co/5kK07fM/Capturar.png" alt="4Binaria" width="550"/>

Ao observar a linha traçada pelo gráfico da Busca Linear, observa-se que, à medida que o número de entradas aumenta, o tempo de busca cresce proporcionalmente. Isso acontece pelo fato de que o algoritmo compara o elemento procurado comcada elemento do vetor até encontra-lo. No caso do trabalho, encontra-se na última posição. Observa-se que, com um número pequeno de entradas, a Busca Linear é mais eficiente que o Hash SQM. Porém, é bem menos eficiente comparado aos métodos de Hashing quando se trata de um maior número de entradas. Em comparação com o Hashing MD5, a Busca Linear é menos eficiente tanto com um pequeno número de entradas, quanto com um número mais elevado.

## Atividade 3:
A partir de um esquema de relação familiar oriundo da Mitologia Grega, fizemos a plotagem de um grafo que mostra o parentesco entre cada entidade, para isso utilizamos de pesquisa e informações da imagem abaixo:

<img src="https://github.com/ciroDourado/aa_time_1/blob/main/Dados/Grafos/arvore_olimpianos.jpg" alt="Gravo-Atv-3" width="550"/>

Visualização do Grafo:

<img src="https://i.ibb.co/wzpFhsV/Atividade-3.png" alt="Gravo-Atv-3" width="550"/>

Para fazer isso, fizemos a implementação em C# do que foi passado nas aulas que envolviam grafo, junto a isso, utilizamos a lib GoJS, que serviu para a visualização do grafo.
## Como compilar localmente
Caso você esteja em um sistema Linux, é necessário ter as dependências:
1. dotnet-sdk
2. dotnet-host
3. dotnet-runtime
4. dotnet-targeting-pack
5. aspnet-runtime
6. aspnet-targeting-pack


Tendo os pacotes mencionados acima, abra o terminal e clone o projeto localmente:
```
git clone git@github.com:ciroDourado/aa_time_1.git
```


Navegue até o novo diretório, e compile/execute o projeto:
```
cd aa_time_1
dotnet run
```

Caso haja problemas:
Este programa usa uma biblioteca externa chamada Newtonsoft.Json<br>
Para instalar, no terminal faça:<br>
```
dotnet add package Newtonsoft.Json --version 13.0.1 
```
E então repita o processo de compilar/executar
