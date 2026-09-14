# RPA Selenium Demo - C# + Selenium + Excel

Projeto didático criado para demonstrar, de forma simples, como um **RPA (Robotic Process Automation)** pode utilizar **Selenium WebDriver com C#** para navegar em uma aplicação web, realizar login, ler dados de um grid HTML e gerar um arquivo Excel automaticamente.

> O projeto foi criado como protótipo de estudo. A aplicação web é propositalmente simples e utiliza dados fictícios.

## O que o RPA faz

O fluxo automatizado é:

```text
RPA inicia
   ↓
Abre o Google Chrome
   ↓
Acessa login.html
   ↓
Preenche usuário e senha
   ↓
Clica em Entrar
   ↓
Abre grid.html
   ↓
Localiza #gridPedidos
   ↓
Lê todas as linhas da tabela
   ↓
Extrai ID, Cliente, Produto, Valor e Status
   ↓
Cria Pedidos.xlsx
```

## Tecnologias utilizadas

- C# / .NET
- Selenium WebDriver
- Google Chrome
- ClosedXML
- HTML / CSS / JavaScript
- Python HTTP Server apenas para servir os HTMLs localmente durante a demonstração

O projeto atualmente está configurado no `RpaBot.csproj` para **.NET 10.0**.

## Estrutura do projeto

```text
RPA-Selenium-Demo/
│
├── README.md
│
├── WebDemo/
│   ├── login.html
│   └── grid.html
│
└── RpaBot/
    ├── Program.cs
    ├── RpaBot.csproj
    └── RpaBot.sln
```

### WebDemo

Simula o sistema que será automatizado.

`login.html` possui os campos:

- `#usuario`
- `#senha`
- `#btnEntrar`

Para o protótipo, as credenciais são:

```text
Usuário: admin
Senha: admin
```

Após o login, a página navega para `grid.html`.

`grid.html` possui a tabela:

```html
<table id="gridPedidos">
```

O Selenium lê suas linhas por meio do seletor CSS:

```csharp
By.CssSelector("#gridPedidos tbody tr")
```

## Pré-requisitos

Para executar o exemplo, instale:

1. .NET SDK compatível com o projeto (atualmente .NET 10)
2. Google Chrome
3. Python 3, usado apenas para iniciar um servidor HTTP local simples

Confirme as instalações:

```bash
dotnet --version
python --version
```

## 1. Baixar/restaurar os pacotes .NET

Abra um terminal na pasta do RPA:

```cmd
cd C:\RPA-Selenium-Demo\RpaBot
```

Execute:

```cmd
dotnet restore
```

Os principais pacotes utilizados são:

```text
Selenium.WebDriver
ClosedXML
```

Nas versões atuais do Selenium, o Selenium Manager pode localizar/gerenciar o driver necessário para o Chrome automaticamente, dependendo do ambiente.

## 2. Iniciar a aplicação HTML de demonstração

Abra **um primeiro terminal**:

```cmd
cd C:\RPA-Selenium-Demo\WebDemo
```

Execute:

```cmd
python -m http.server 5500
```

O resultado esperado é semelhante a:

```text
Serving HTTP on 0.0.0.0 port 5500
```

Não feche esse terminal enquanto estiver testando o RPA.

Abra manualmente no navegador, se desejar validar a aplicação antes do robô:

```text
http://localhost:5500/login.html
```

Faça login com:

```text
admin / admin
```

A aplicação deverá navegar para:

```text
http://localhost:5500/grid.html
```

## 3. Executar o RPA

Abra **um segundo terminal**:

```cmd
cd C:\RPA-Selenium-Demo\RpaBot
```

Execute:

```cmd
dotnet run
```

O Selenium deverá:

1. abrir o Chrome;
2. acessar a página de login;
3. preencher `admin`;
4. preencher a senha `admin`;
5. clicar em **Entrar**;
6. acessar o grid;
7. ler os registros;
8. gerar o Excel.

## Resultado esperado no console

```text
Iniciando RPA...
Abrindo: http://localhost:5500/login.html
Página de login aberta.
Login realizado.

Registros encontrados: 4

1001 | Empresa Alpha | Motor | 1250.50 | Aprovado
1002 | Empresa Beta | Sensor | 850.90 | Pendente
1003 | Empresa Gamma | CLP | 3890.00 | Aprovado
1004 | Empresa Delta | Inversor | 2750.00 | Processando

Excel gerado com sucesso!
Arquivo: ...\Pedidos.xlsx
```

## Arquivo Excel gerado

O arquivo é chamado:

```text
Pedidos.xlsx
```

Ele é criado na pasta corrente usada para executar o RPA, normalmente:

```text
RPA-Selenium-Demo\RpaBot\Pedidos.xlsx
```

O conteúdo esperado é:

| ID | Cliente | Produto | Valor | Status |
|---|---|---|---:|---|
| 1001 | Empresa Alpha | Motor | 1250.50 | Aprovado |
| 1002 | Empresa Beta | Sensor | 850.90 | Pendente |
| 1003 | Empresa Gamma | CLP | 3890.00 | Aprovado |
| 1004 | Empresa Delta | Inversor | 2750.00 | Processando |

## Como o Selenium encontra os elementos

O conceito central deste exemplo é o uso de **seletores**.

### Campo usuário

HTML:

```html
<input id="usuario" type="text">
```

C#:

```csharp
var usuario = driver.FindElement(By.Id("usuario"));
```

### Campo senha

```csharp
var senha = driver.FindElement(By.Id("senha"));
```

### Botão Entrar

```csharp
var entrar = driver.FindElement(By.Id("btnEntrar"));
entrar.Click();
```

### Linhas da tabela

```csharp
var linhas = driver.FindElements(
    By.CssSelector("#gridPedidos tbody tr")
);
```

### Colunas de uma linha

```csharp
var colunas = linha.FindElements(By.TagName("td"));
```

Esse mesmo conceito é aplicado em sistemas reais. A diferença é que os seletores são adaptados ao HTML da aplicação que será automatizada.

## Selenium x RPA

O Selenium é uma biblioteca de automação de navegadores. Ele pode ser usado como parte de um RPA quando o processo automatizado envolve aplicações web.

Exemplo real:

```text
Sistema corporativo
      ↓
Selenium
      ↓
Login
      ↓
Consulta
      ↓
Leitura de tabela
      ↓
Tratamento dos dados
      ↓
Excel / API / Banco / outro sistema
```

## Pontos importantes para um projeto corporativo

Este projeto é propositalmente simples. Antes de levar o mesmo padrão para produção, é recomendado evoluir alguns pontos:

- não deixar usuário e senha fixos no código;
- armazenar configurações em `appsettings.json` ou variáveis de ambiente;
- usar `WebDriverWait` no lugar de `Thread.Sleep`;
- adicionar logs;
- adicionar tratamento de exceções;
- salvar screenshot quando ocorrer erro;
- implementar retentativas controladas;
- usar Page Object Model para separar páginas e seletores;
- validar paginação do grid;
- tratar downloads e uploads;
- observar autenticação corporativa, MFA e políticas de segurança;
- não tentar contornar CAPTCHA ou mecanismos de segurança;
- executar somente automações autorizadas pelo proprietário do sistema.

## Próxima evolução sugerida

Uma estrutura mais próxima de um RPA corporativo poderia ser:

```text
RpaBot/
│
├── Models/
│   └── Pedido.cs
│
├── Pages/
│   ├── LoginPage.cs
│   └── PedidosPage.cs
│
├── Services/
│   ├── SeleniumService.cs
│   └── ExcelService.cs
│
├── appsettings.json
└── Program.cs
```

Esse modelo facilita manutenção quando URLs, campos ou telas do sistema mudarem.

## Objetivo do repositório

O objetivo deste repositório é permitir que outros desenvolvedores executem um exemplo pequeno e visual para entender como Selenium pode participar de um processo de RPA em aplicações .NET.

O exemplo não depende de sistemas corporativos externos e pode ser executado localmente para estudo e experimentação.
