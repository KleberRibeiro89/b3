# Cálculo de CDB


## Tecnologias Utilizadas
Angular 13.0.4
.NET 8.0.100-preview.5.23303.2

## Instalação
Clone este repositório: 
```bash
  git clone https://github.com/KleberRibeiro89/b3.git
```

Instale as dependências do Angular: 
```bash
  npm install --ignore-scripts .\b3-front\
```


Instale as dependências do .NET: 
```bash
  dotnet restore .\webApi\B3.Api\
  dotnet build .\webApi\B3.Api\
```

Rote os teste do .NET: 
```bash
  dotnet test .\webApi\B3.Domain.Test\ --collect:"Code Coverage"
```

Para executar o projeto Angular:

Copy code
ng serve
Para executar o projeto .NET:

arduino
Copy code
dotnet run
Estrutura do Projeto
Descreva a estrutura do projeto, destacando os principais diretórios e arquivos.
Testes
Explique como executar os testes automatizados do projeto.
Contribuição
Explique como outros desenvolvedores podem contribuir com o projeto.
Licença
Indique a licença do projeto.
Contato
Forneça informações de contato, como e-mail ou links para redes sociais, para que as pessoas possam entrar em contato com você em caso de dúvidas ou contribuições.
Certifique-se de adaptar as informações acima de acordo com o seu projeto específico. Inclua seções relevantes para o seu projeto, como exemplos de código, requisitos de sistema, capturas de tela ou qualquer outra informação que seja útil para os usuários ou desenvolvedores que interagem com o projeto.

Lembre-se de que o README.md serve como uma documentação inicial do seu projeto e deve ser claro, conciso e fornecer informações relevantes para facilitar a compreensão e utilização do projeto por outras pessoas.