# RPA Selenium Demo — C# + .NET 8 + Selenium + Excel

Projeto didático criado para demonstrar, de forma simples e prática, como um **RPA (Robotic Process Automation)** pode utilizar **Selenium WebDriver com C# e .NET 8** para navegar em uma aplicação web, realizar login, consultar informações de um grid HTML e gerar automaticamente um arquivo Excel.

> Este projeto foi desenvolvido como protótipo de estudo. A aplicação web utilizada na demonstração é propositalmente simples e contém somente dados fictícios.

---

## 🎯 Objetivo

O objetivo deste projeto é apresentar os conceitos básicos envolvidos na construção de um RPA utilizando tecnologias do ecossistema .NET.

O robô executa automaticamente o seguinte processo:

```text
RPA inicia
      ↓
Abre o Google Chrome
      ↓
Acessa login.html
      ↓
Localiza os campos da página
      ↓
Preenche usuário
      ↓
Preenche senha
      ↓
Clica em Entrar
      ↓
Acessa grid.html
      ↓
Localiza #gridPedidos
      ↓
Lê todas as linhas
      ↓
Extrai os dados
      ↓
ID
Cliente
Produto
Valor
Status
      ↓
Cria Pedidos.xlsx
      ↓
RPA finalizado
```

Esse fluxo representa, de maneira simplificada, uma situação encontrada em automações corporativas:

```text
Sistema Web
     ↓
RPA
     ↓
Login
     ↓
Consulta
     ↓
Extração
     ↓
Tratamento
     ↓
Excel / API / Banco de Dados
```

---

# 🛠 Tecnologias utilizadas

O projeto utiliza:

- C#
- .NET 8
- Selenium WebDriver
- Selenium.Support
- Google Chrome
- Selenium Manager / ChromeDriver
- ClosedXML
- HTML
- CSS
- JavaScript
- Python 3 — opcional, somente para disponibilizar os HTMLs através de um servidor HTTP local

O projeto está configurado para:

```xml
<TargetFramework>net8.0</TargetFramework>
```

O .NET 8 foi escolhido para manter o exemplo em uma versão LTS do .NET e facilitar sua execução em diferentes ambientes de desenvolvimento.

---

# 📁 Estrutura do projeto

A estrutura básica é:

```text
RpaBot/
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

Existem duas partes importantes.

### WebDemo

Simula o sistema web que será automatizado.

Possui:

```text
login.html
grid.html
```

### RpaBot

Contém o RPA desenvolvido em C#.

O arquivo principal é:

```text
Program.cs
```

É nele que o Selenium:

- inicia o Chrome;
- acessa o sistema;
- realiza o login;
- localiza o grid;
- lê os dados;
- cria o Excel.

---

# 🌐 Aplicação WebDemo

O arquivo:

```text
login.html
```

possui os elementos:

```text
#usuario
#senha
#btnEntrar
```

As credenciais utilizadas somente nesta demonstração são:

```text
Usuário: admin
Senha: admin
```

Após o login, o JavaScript redireciona para:

```text
grid.html
```

O `grid.html` possui uma tabela:

```html
<table id="gridPedidos">
```

O Selenium consegue localizar suas linhas utilizando:

```csharp
By.CssSelector("#gridPedidos tbody tr")
```

---

# ⚙️ Pré-requisitos

Para executar o projeto são necessários:

1. .NET 8 SDK
2. Google Chrome
3. Python 3 somente caso seja utilizada a opção de servidor HTTP com Python

> Python não é necessário para o funcionamento do Selenium. Ele é utilizado neste exemplo somente como uma maneira simples de disponibilizar `login.html` e `grid.html` através de `http://localhost:5500`.

---

# 🔎 Verificar se o .NET está instalado

Abra o CMD ou PowerShell:

```powershell
dotnet --version
```

O resultado deve ser semelhante a:

```text
8.0.xxx
```

Também é possível visualizar todos os SDKs instalados:

```powershell
dotnet --list-sdks
```

Procure uma versão:

```text
8.0.xxx
```

---

# 📥 Caso o .NET não esteja instalado

É necessário instalar o:

```text
.NET 8 SDK
```

Acesse o site oficial da Microsoft:

https://dotnet.microsoft.com/download/dotnet/8.0

Selecione:

```text
.NET 8 SDK
```

Escolha o instalador correspondente ao seu Windows.

Na maioria dos computadores Windows atuais:

```text
Windows x64
```

> IMPORTANTE: instale o **SDK**, e não somente o Runtime.

O SDK é necessário para executar comandos como:

```powershell
dotnet restore
dotnet build
dotnet run
```

Depois da instalação, feche o terminal e abra novamente.

Execute:

```powershell
dotnet --version
```

O resultado esperado é semelhante a:

```text
8.0.xxx
```

---

# 🖥 Visual Studio

Caso utilize Visual Studio, certifique-se de possuir uma versão compatível com .NET 8.

O arquivo:

```text
RpaBot.csproj
```

deve possuir:

```xml
<TargetFramework>net8.0</TargetFramework>
```

Exemplo:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>

    <OutputType>Exe</OutputType>

    <TargetFramework>net8.0</TargetFramework>

    <ImplicitUsings>enable</ImplicitUsings>

    <Nullable>enable</Nullable>

  </PropertyGroup>

</Project>
```

Se aparecer um erro relacionado ao `.NET 10`, verifique novamente o `.csproj`.

O projeto deste repositório utiliza:

```text
.NET 8
```

---

# 🌐 Google Chrome

O Selenium deste projeto utiliza Google Chrome.

Para verificar se está instalado, procure:

```text
Google Chrome
```

no menu Iniciar do Windows.

Caso não esteja instalado, utilize o site oficial:

https://www.google.com/chrome/

Depois da instalação, abra o Chrome pelo menos uma vez para validar que o navegador está funcionando corretamente.

---

# 🐍 Verificar se o Python está instalado

Python é opcional.

Execute:

```powershell
python --version
```

ou:

```powershell
py --version
```

Exemplo de resultado:

```text
Python 3.12.x
```

Se algum desses comandos funcionar, você poderá utilizar o servidor HTTP do Python.

---

# 📥 Caso o Python não esteja instalado

Existem duas possibilidades.

## Opção A — instalar Python

Acesse:

https://www.python.org/downloads/

Baixe uma versão atual do:

```text
Python 3
```

Durante a instalação é importante marcar:

```text
Add Python to PATH
```

Depois da instalação, feche o terminal e abra novamente.

Execute:

```powershell
python --version
```

ou:

```powershell
py --version
```

---

## Opção B — não instalar Python

O Python não faz parte do RPA.

Ele está sendo utilizado somente para disponibilizar:

```text
login.html
grid.html
```

através de:

```text
http://localhost:5500
```

Portanto, também é possível utilizar:

- Live Server do Visual Studio Code;
- IIS;
- IIS Express;
- ASP.NET Core;
- qualquer servidor HTTP local.

Para manter todo o ambiente dentro do ecossistema .NET, uma evolução recomendada deste projeto é utilizar um pequeno servidor ASP.NET Core.

---

# 📦 Restaurar os pacotes NuGet

Depois de instalar o .NET 8, entre na pasta do RPA.

Exemplo:

```powershell
cd C:\RPA_NET\RpaBot\RpaBot
```

Execute:

```powershell
dotnet restore
```

Depois:

```powershell
dotnet build
```

Se tudo estiver correto, deverá aparecer:

```text
Build succeeded.
```

ou:

```text
Construção bem-sucedida.
```

---

# 📦 Pacotes utilizados

Os principais pacotes utilizados pelo projeto são:

```text
Selenium.WebDriver
Selenium.Support
Selenium.WebDriver.ChromeDriver
ClosedXML
```

Normalmente eles serão restaurados automaticamente através do:

```powershell
dotnet restore
```

Caso seja necessário adicioná-los manualmente, execute **um comando de cada vez**:

```powershell
dotnet add package Selenium.WebDriver
```

Depois:

```powershell
dotnet add package Selenium.Support
```

Depois:

```powershell
dotnet add package Selenium.WebDriver.ChromeDriver
```

Finalmente:

```powershell
dotnet add package ClosedXML
```

Execute novamente:

```powershell
dotnet restore
```

> Não coloque todos os comandos `dotnet add package` na mesma linha.

---

# 🚀 Executando o projeto

A execução possui duas partes.

Primeiro precisamos disponibilizar a aplicação web.

Depois executamos o RPA.

---

# 1️⃣ Iniciar a aplicação WebDemo

Abra um primeiro terminal.

Entre na pasta:

```powershell
cd C:\RPA_NET\RpaBot\WebDemo
```

Execute:

```powershell
python -m http.server 5500
```

Caso sua instalação utilize o comando `py`:

```powershell
py -m http.server 5500
```

O resultado deverá ser semelhante a:

```text
Serving HTTP on 0.0.0.0 port 5500
```

### IMPORTANTE

Não feche esse terminal.

Enquanto o RPA estiver sendo executado, esse servidor precisa continuar funcionando.

---

# 2️⃣ Testar a aplicação manualmente

Antes de executar o Selenium, abra o navegador.

Acesse:

```text
http://localhost:5500/login.html
```

A página de login deverá aparecer.

Digite:

```text
Usuário: admin
Senha: admin
```

Clique em:

```text
Entrar
```

A aplicação deverá navegar para:

```text
http://localhost:5500/grid.html
```

Se esse teste funcionar, o WebDemo está corretamente configurado.

---

# 3️⃣ Executar o RPA

Mantenha o primeiro terminal aberto.

Abra um **segundo terminal**.

Execute:

```powershell
cd C:\RPA_NET\RpaBot\RpaBot
```

Depois:

```powershell
dotnet run
```

O Selenium deverá automaticamente:

1. iniciar o Google Chrome;
2. acessar `login.html`;
3. localizar o campo usuário;
4. preencher `admin`;
5. localizar o campo senha;
6. preencher `admin`;
7. clicar em Entrar;
8. aguardar a página do grid;
9. localizar `#gridPedidos`;
10. ler suas linhas;
11. extrair os dados;
12. gerar o Excel.

---

# 📊 Resultado esperado

O console deverá apresentar algo semelhante a:

```text
Iniciando RPA...

Abrindo:
http://localhost:5500/login.html

Página de login aberta.

Login realizado.

Registros encontrados: 4

1001 | Empresa Alpha | Motor | 1250.50 | Aprovado
1002 | Empresa Beta | Sensor | 850.90 | Pendente
1003 | Empresa Gamma | CLP | 3890.00 | Aprovado
1004 | Empresa Delta | Inversor | 2750.00 | Processando

Excel gerado com sucesso!

Arquivo:
...\Pedidos.xlsx
```

---

# 📗 Excel gerado

O RPA gera:

```text
Pedidos.xlsx
```

Normalmente localizado em:

```text
C:\RPA_NET\RpaBot\RpaBot\Pedidos.xlsx
```

O conteúdo será semelhante a:

| ID | Cliente | Produto | Valor | Status |
|---|---|---|---:|---|
| 1001 | Empresa Alpha | Motor | 1250.50 | Aprovado |
| 1002 | Empresa Beta | Sensor | 850.90 | Pendente |
| 1003 | Empresa Gamma | CLP | 3890.00 | Aprovado |
| 1004 | Empresa Delta | Inversor | 2750.00 | Processando |

---

# 🧠 Como o Selenium funciona

Selenium controla um navegador através do código.

No nosso exemplo:

```csharp
using var driver =
    new ChromeDriver(options);
```

inicia uma instância do Google Chrome controlada pelo RPA.

Depois:

```csharp
driver.Navigate().GoToUrl(
    "http://localhost:5500/login.html"
);
```

manda o navegador acessar a aplicação.

---

# 🔍 Como o Selenium encontra os elementos

O conceito central deste exemplo é o uso de **seletores**.

---

## Campo usuário

HTML:

```html
<input id="usuario" type="text">
```

C#:

```csharp
var usuario =
    driver.FindElement(
        By.Id("usuario")
    );
```

---

## Campo senha

HTML:

```html
<input id="senha" type="password">
```

C#:

```csharp
var senha =
    driver.FindElement(
        By.Id("senha")
    );
```

---

## Botão Entrar

HTML:

```html
<button id="btnEntrar">
    Entrar
</button>
```

C#:

```csharp
var entrar =
    driver.FindElement(
        By.Id("btnEntrar")
    );

entrar.Click();
```

---

# 📋 Leitura do Grid

Para localizar todas as linhas:

```csharp
var linhas =
    driver.FindElements(
        By.CssSelector(
            "#gridPedidos tbody tr"
        )
    );
```

Para localizar as colunas:

```csharp
var colunas =
    linha.FindElements(
        By.TagName("td")
    );
```

Depois os dados podem ser obtidos através de:

```csharp
var id = colunas[0].Text;
var cliente = colunas[1].Text;
var produto = colunas[2].Text;
var valor = colunas[3].Text;
var status = colunas[4].Text;
```

---

# ⏱ WebDriverWait

Em sistemas reais, uma página pode levar alguns segundos para carregar.

Por isso é recomendado utilizar:

```csharp
var wait =
    new WebDriverWait(
        driver,
        TimeSpan.FromSeconds(10)
    );
```

Exemplo:

```csharp
var usuario =
    wait.Until(
        d => d.FindElement(
            By.Id("usuario")
        )
    );
```

Essa estratégia é mais confiável do que:

```csharp
Thread.Sleep(2000);
```

---

# 🤖 Selenium x RPA

Selenium não é uma plataforma RPA completa.

Ele é uma biblioteca especializada em automação de navegadores.

Entretanto, pode ser utilizado como um dos componentes de uma solução RPA.

Exemplo:

```text
Processo corporativo
        ↓
RPA .NET
        ↓
Selenium
        ↓
Sistema Web
        ↓
Login
        ↓
Pesquisa
        ↓
Grid
        ↓
Extração
        ↓
Regra de negócio
        ↓
Excel
```

Em uma solução maior:

```text
                    ┌── Sistema Web
                    │
RPA .NET ─ Selenium ┤
                    │
                    └── Portal Corporativo

        ↓

Regra de Negócio

        ↓

 ┌────────┬────────┬──────────┐
 ↓        ↓        ↓          ↓
Excel   SQL      API       Arquivos
```

---

# ❗ Erros comuns

## ERR_CONNECTION_REFUSED

Erro:

```text
OpenQA.Selenium.UnknownErrorException

net::ERR_CONNECTION_REFUSED
```

Isso normalmente significa que o Selenium tentou acessar:

```text
http://localhost:5500
```

mas nenhum servidor estava funcionando nessa porta.

### Como verificar

Abra manualmente:

```text
http://localhost:5500/login.html
```

Se o navegador também mostrar:

```text
ERR_CONNECTION_REFUSED
```

o problema não está no Selenium.

O servidor WebDemo não foi iniciado.

Execute:

```powershell
cd C:\RPA_NET\RpaBot\WebDemo

python -m http.server 5500
```

Depois execute novamente o RPA.

---

# ❗ NoSuchElementException

Exemplo:

```text
Unable to locate element:

#usuario
```

Isso significa que o Selenium abriu uma página, mas não encontrou:

```html
id="usuario"
```

Confirme se:

```text
http://localhost:5500/login.html
```

realmente apresenta a página correta.

Depois verifique se o HTML contém:

```html
<input id="usuario">
```

---

# ❗ PowerShell não executa arquivo BAT

No PowerShell:

```powershell
iniciar-web.bat
```

pode apresentar:

```text
comando não encontrado
```

Execute:

```powershell
.\iniciar-web.bat
```

O `.\` informa ao PowerShell que o arquivo está no diretório atual.

---

# ❗ Python não encontrado

Se aparecer:

```text
Python não foi encontrado
```

execute:

```powershell
python --version
```

e:

```powershell
py --version
```

Se nenhum funcionar, você pode:

1. instalar Python;
2. utilizar Live Server;
3. utilizar ASP.NET Core;
4. utilizar outro servidor HTTP.

---

# ❗ Porta 5500 ocupada

Para verificar:

```powershell
netstat -ano | findstr :5500
```

Se existir algum processo utilizando a porta, será exibido seu PID.

Outra possibilidade é alterar a porta.

Por exemplo:

```powershell
python -m http.server 5501
```

Nesse caso também altere o RPA:

```csharp
const string loginUrl =
    "http://localhost:5501/login.html";
```

---

# 🏢 Evolução para um RPA corporativo

Este projeto foi propositalmente desenvolvido de maneira simples para facilitar o aprendizado.

Uma versão corporativa deve considerar:

- Page Object Model;
- Dependency Injection;
- configuração externa;
- `appsettings.json`;
- variáveis de ambiente;
- logs estruturados;
- WebDriverWait;
- tratamento de exceções;
- retry;
- screenshots;
- auditoria;
- paginação;
- download de arquivos;
- upload de arquivos;
- integração com APIs;
- integração com banco de dados;
- execução agendada;
- monitoramento;
- segurança das credenciais.

---

# 🏗 Estrutura sugerida para evolução

Uma versão mais estruturada poderia utilizar:

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
│   ├── ExcelService.cs
│   ├── ScreenshotService.cs
│   └── LogService.cs
│
├── Configurations/
│
├── appsettings.json
│
└── Program.cs
```

---

# 🔐 Segurança

Este exemplo utiliza:

```text
admin / admin
```

somente para fins didáticos.

Em um ambiente corporativo, **não deixe credenciais diretamente no código-fonte**.

Utilize recursos como:

```text
Variáveis de Ambiente
        ↓
Secret Manager
        ↓
Azure Key Vault
        ↓
Windows Credential Manager
```

Também é importante:

- não tentar contornar CAPTCHA;
- não tentar contornar MFA;
- respeitar políticas de segurança;
- automatizar somente sistemas autorizados;
- proteger informações confidenciais;
- controlar os acessos utilizados pelo robô.

---

# 🚀 Possíveis próximas evoluções

Este projeto pode evoluir para demonstrar:

```text
RPA
 ↓
Selenium
 ↓
Login
 ↓
Consulta
 ↓
Paginação
 ↓
Download
 ↓
Tratamento
 ↓
SQL Server
 ↓
API
 ↓
Excel
 ↓
E-mail
```

Outras possibilidades:

- execução headless;
- screenshots automáticos;
- envio de e-mail ao finalizar;
- armazenamento em SQL Server;
- consumo de API REST;
- leitura de arquivos;
- execução pelo Windows Task Scheduler;
- transformação em Worker Service .NET 8;
- configuração através de `appsettings.json`;
- dashboard para acompanhar execuções.

---

# 📚 Objetivo do repositório

O objetivo deste repositório é permitir que desenvolvedores executem um exemplo pequeno, visual e didático para entender como **C#, .NET 8, Selenium e ClosedXML** podem ser utilizados na construção de uma automação RPA.

O exemplo não depende de sistemas corporativos externos.

Ele pode ser executado completamente em ambiente local para:

- estudo;
- treinamento;
- demonstração;
- experimentação;
- criação de provas de conceito.

---

## Autor

**Jean Paiva da Silva**

Projeto desenvolvido para estudo e demonstração dos conceitos de:

**RPA + C# + .NET 8 + Selenium WebDriver + Excel**
