# Cálculo de CDB


## Tecnologias Utilizadas
- Angular 13.0.4
- .NET 8.0.100-preview.5.23303.2

## Instalação
Clone este repositório: 
```bash
  git clone https://github.com/KleberRibeiro89/b3.git
  cd .\b3\
```

Instale as dependências do Angular: 
```bash
  npm install --ignore-scripts .\b3-front\
```


Instale as dependências do .NET, estando na pasta principal rodar os comandos: 
```bash
  cd .\webApi\B3.Api\
  dotnet restore 
  dotnet build 
```

Rode os teste do .NET, estando na pasta principal rodar os comandos: 
```bash
  cd .\webApi\B3.Domain.Test\
  dotnet test --collect:"Code Coverage"
```

Rode os teste do angular: 
```bash
  cd .\b3-front\
  ng test --code-coverage
```

Para executar o projeto .NET voltar a pasta principal do projeto e rodar os comandos:
```bash
  cd .\webApi\B3.Api\
  dotnet watch run 
```

Para executar o projeto Angular voltar a pasta principal do projeto e rodar os comandos:
```bash
  cd  .\b3-front\
  ng serve 
```


## Testes
Para visualizar a cobertura de testes do backend existe um arquivo
```bash
  cd  .\coveragereport\index.html
```


## Acessar o projeto
Para acessar basta clicar no link
[Cálculo CDB](https://localhost:4200/).