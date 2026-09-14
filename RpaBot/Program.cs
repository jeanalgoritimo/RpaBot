using ClosedXML.Excel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

Console.WriteLine("Iniciando RPA...");

// -----------------------------------------------------------------------------
// CONFIGURAÇÃO DO CHROME
// -----------------------------------------------------------------------------

var options = new ChromeOptions();
options.AddArgument("--start-maximized");

using var driver = new ChromeDriver(options);

// Espera máxima para elementos e navegações.
// Isso é melhor do que depender apenas de Thread.Sleep.
var wait = new WebDriverWait(
    driver,
    TimeSpan.FromSeconds(10)
);

// -----------------------------------------------------------------------------
// URL DA APLICAÇÃO
// -----------------------------------------------------------------------------

const string loginUrl =
    "http://localhost:5500/login.html";

Console.WriteLine($"Abrindo: {loginUrl}");

driver.Navigate().GoToUrl(loginUrl);

Console.WriteLine("Página carregada.");
Console.WriteLine($"URL atual: {driver.Url}");

// -----------------------------------------------------------------------------
// ETAPA 1 - LOGIN
// -----------------------------------------------------------------------------

Console.WriteLine("Aguardando campos do login...");

// Aguarda até o campo existir no HTML.
var usuario = wait.Until(
    d => d.FindElement(By.Id("usuario"))
);

var senha = wait.Until(
    d => d.FindElement(By.Id("senha"))
);

var entrar = wait.Until(
    d => d.FindElement(By.Id("btnEntrar"))
);

Console.WriteLine("Campos encontrados.");

// Credenciais da aplicação de demonstração.
// Em produção, não deixe usuário e senha fixos no código.
usuario.SendKeys("admin");
senha.SendKeys("admin");

Console.WriteLine("Credenciais preenchidas.");

entrar.Click();

Console.WriteLine("Botão Entrar acionado.");

// -----------------------------------------------------------------------------
// AGUARDA A NAVEGAÇÃO PARA O GRID
// -----------------------------------------------------------------------------

wait.Until(
    d => d.Url.Contains("grid.html")
);

Console.WriteLine("Login realizado.");
Console.WriteLine($"URL atual: {driver.Url}");

// -----------------------------------------------------------------------------
// ETAPA 2 - LOCALIZAR O GRID
// -----------------------------------------------------------------------------

Console.WriteLine();
Console.WriteLine("Aguardando grid de pedidos...");

var linhas = wait.Until(d =>
{
    var registros = d.FindElements(
        By.CssSelector("#gridPedidos tbody tr")
    );

    return registros.Count > 0
        ? registros
        : null;
});

Console.WriteLine(
    $"Registros encontrados: {linhas.Count}"
);

Console.WriteLine();

// -----------------------------------------------------------------------------
// ETAPA 3 - PREPARAR O EXCEL
// -----------------------------------------------------------------------------

var caminhoExcel = Path.Combine(
    Directory.GetCurrentDirectory(),
    "Pedidos.xlsx"
);

using var workbook = new XLWorkbook();

var planilha =
    workbook.Worksheets.Add("Pedidos");

// Cabeçalho
planilha.Cell(1, 1).Value = "ID";
planilha.Cell(1, 2).Value = "Cliente";
planilha.Cell(1, 3).Value = "Produto";
planilha.Cell(1, 4).Value = "Valor";
planilha.Cell(1, 5).Value = "Status";

var linhaExcel = 2;

// -----------------------------------------------------------------------------
// ETAPA 4 - EXTRAIR O GRID
// -----------------------------------------------------------------------------

foreach (var linha in linhas)
{
    var colunas =
        linha.FindElements(By.TagName("td"));

    // Proteção para evitar erro se alguma linha
    // não possuir as cinco colunas esperadas.
    if (colunas.Count < 5)
    {
        Console.WriteLine(
            "Linha ignorada: quantidade de colunas inválida."
        );

        continue;
    }

    var id = colunas[0].Text;
    var cliente = colunas[1].Text;
    var produto = colunas[2].Text;
    var valor = colunas[3].Text;
    var status = colunas[4].Text;

    Console.WriteLine(
        $"{id} | " +
        $"{cliente} | " +
        $"{produto} | " +
        $"{valor} | " +
        $"{status}"
    );

    // Grava no Excel
    planilha.Cell(linhaExcel, 1).Value = id;
    planilha.Cell(linhaExcel, 2).Value = cliente;
    planilha.Cell(linhaExcel, 3).Value = produto;

    if (decimal.TryParse(
        valor,
        System.Globalization.NumberStyles.Any,
        System.Globalization.CultureInfo.InvariantCulture,
        out var valorDecimal))
    {
        planilha.Cell(
            linhaExcel,
            4
        ).Value = valorDecimal;
    }
    else
    {
        planilha.Cell(
            linhaExcel,
            4
        ).Value = valor;
    }

    planilha.Cell(
        linhaExcel,
        5
    ).Value = status;

    linhaExcel++;
}

// -----------------------------------------------------------------------------
// ETAPA 5 - FORMATAÇÃO DO EXCEL
// -----------------------------------------------------------------------------

var cabecalho =
    planilha.Range("A1:E1");

cabecalho.Style.Font.Bold = true;

planilha.Columns()
    .AdjustToContents();

planilha.Column(4)
    .Style
    .NumberFormat
    .Format = "#,##0.00";

// -----------------------------------------------------------------------------
// ETAPA 6 - SALVAR O EXCEL
// -----------------------------------------------------------------------------

workbook.SaveAs(caminhoExcel);

Console.WriteLine();
Console.WriteLine(
    "Excel gerado com sucesso!"
);

Console.WriteLine(
    $"Arquivo: {caminhoExcel}"
);

Console.WriteLine();
Console.WriteLine(
    "Pressione ENTER para finalizar."
);

Console.ReadLine();