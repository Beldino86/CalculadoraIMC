# Calculadora de IMC (Windows Forms)

Pequena aplicação em C# / Windows Forms para calcular o Índice de Massa Corporal.

## Como executar

```powershell
dotnet run --project .\CalculadoraIMC.csproj
```

## Funcionalidades

- `txtPeso` — peso em quilogramas.
- `txtAltura` — altura em metros.
- `btnCalcular` — processa os dados (também funciona com a tecla Enter).
- `lblResultado` — mostra o IMC com duas casas decimais e a classificação.

## Validação e cálculo

Os valores são lidos com `double.TryParse` (`NumberStyles.Float`, cultura invariante),
ponto ou vírgula como separador decimal. Valores não finitos (`NaN`/`Infinity`) e
valores menores ou iguais a zero são rejeitados.

Fórmula aplicada:

```text
IMC = peso / altura²
```

Classificação (OMS):

| IMC            | Classificação      |
| -------------- | ------------------ |
| < 18,5         | Abaixo do peso     |
| 18,5 – 24,9    | Peso normal        |
| 25,0 – 29,9    | Sobrepeso          |
| 30,0 – 34,9    | Obesidade grau I   |
| 35,0 – 39,9    | Obesidade grau II  |
| ≥ 40,0         | Obesidade grau III |

> A pasta `calculadorIMC/` contém um projeto antigo/duplicado e está excluída da
> compilação do projeto principal.
