## Universidade Estadual do Maranhão
## Estrutura de Dados Avançados
## Atividades Assíncronas do Time 1

**Alunos:**

* Ciro Dourado
* Douglas Castro
* Gabriel Câncio
* Jonas Carvalho
* João Gabriel


### Como compilar localmente


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
