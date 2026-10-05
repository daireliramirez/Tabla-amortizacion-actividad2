//TABLA DE AMORTIZACION DE PRESTAMO
using Spectre.Console;

//ENTRADA DE DATOS
decimal montoPrestamo = AnsiConsole.Ask<decimal>("Ingrese el monto del prestamo");
decimal interesAnual = AnsiConsole.Ask<decimal>("Ingresa el interes anual");
int plazoPrestamo = AnsiConsole.Ask<int>("Ingrese el plazo del prestamo");


// TABLA
var table = new Table()
.BorderColor(Color.DeepPink1);

// COLUMNAS
table.AddColumn("NO. CUOTA");
table.AddColumn("PAGO DE CUOTA");
table.AddColumn("INTERES A PAGAR");
table.AddColumn("ABONO A CAPITAL");
table.AddColumn("SALDO");

//CALCULOS

//interesMensual = interesAnual / 100
decimal interesMensual = interesAnual / 12 / 100;
decimal saldo = montoPrestamo;

double factorPotencia = Math.Pow(1 + (double)interesMensual, plazoPrestamo);
decimal divArriba = interesMensual * (decimal)factorPotencia;
decimal decimaldivAbajo = (decimal)factorPotencia - 1m; 

decimal cuotaFija = montoPrestamo * (divArriba / decimaldivAbajo);

for(int i = 1; i <= plazoPrestamo; i++)
{
    decimal interesApagar = saldo * interesMensual;
    decimal abonoCapital = cuotaFija - interesApagar;

if (i == plazoPrestamo)
{
    abonoCapital = saldo;
    cuotaFija = abonoCapital + interesApagar;
    saldo = 0m;
    }
else 
{
    saldo -= abonoCapital;
}

// AGREGAR FILA DE LA CUOTA A LA TABLA
table.AddRow(
 $"{i}",
 $"{cuotaFija:N2}",
 $"{interesApagar:N2}",
 $"{abonoCapital:N2}",
 $"{saldo:N2}" );
}

AnsiConsole.WriteLine();
AnsiConsole.Write(table);