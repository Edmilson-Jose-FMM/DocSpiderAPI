# 📄 Docs Spider API
API desenvolvida em .NET 8.0 com acesso a banco de dados PostgreSQL via Entity Framework (Database First).

🚀 Como rodar o projeto
1. Clone o repositório
 ```bash
 git clone https://github.com/Edmilson-Jose-FMM/DocSpiderAPI.git
 cd DocSpiderAPI
```
2. Restaure os pacotes
Na raiz do projeto (onde você clonou o repositório), execute:
```bash
dotnet restore
```
3. Rode a aplicação
Execute a API com o seguinte comando:
 ```bash
 dotnet run --project src/DocSpider.API
 ```
4. Acesse a documentação da API (Swagger)
Abra no navegador:
 ```bash
 https://localhost:7299/swagger
 ```
5. Tecnologias e padrões
   Nesta API utilizei o .NET 8.0 entity framework, tudo feito baseado na arquitetura de projetos "Clean Architecture"
# Vantagens da Clean Architecture
  1. Separação de responsabilidades
     O sistema é dividido em camadas bem definidas (Domínio, Aplicação, Infraestrutura, Apresentação) e cada camada tem uma responsabilidade única e não depende diretamente das outras.
  2. Facilidade para manutenção e evolução
     Como o código está bem organizado, com baixa dependência entre as camadas, fica mais fácil adicionar novas funcionalidades ou alterar comportamentos existentes.
  3. Escalabilidade
     Permite que o sistema cresça de forma organizada, mantendo a arquitetura consistente.   

