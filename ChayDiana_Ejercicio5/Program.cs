Console.WriteLine("EVALUACION DE PRESTAMO BANCARIO POR REGLAS");
Console.WriteLine("- Tipo de solicitante -");
Console.WriteLine("1. Empleado fijo");
Console.WriteLine("2. Empleado temporal");
Console.WriteLine("3. Trabajador independiente");
Console.WriteLine("4. Estudiante");
Console.Write("Ingrese el número correspondiente al tipo de solicitante (1-4): ");
int tipoSolicitante = int.Parse(Console.ReadLine());

Console.WriteLine("Ingreso mensual (con punto decimal ej. 5223.12) ");
double ingresoMensual = double.Parse(Console.ReadLine());

Console.WriteLine("Antigüedad laboral en meses (meses)");
int antiguedadmesual = int.Parse(Console.ReadLine());

Console.WriteLine("Monto solicitado:");
double monto = double.Parse(Console.ReadLine());

Console.WriteLine("- Historial crediticio -");
Console.WriteLine("1. Excelente");
Console.WriteLine("2. Bueno");
Console.WriteLine("3. Regular");
Console.WriteLine("4. Malo");
Console.Write("Ingrese el número correspondiente al historial crediticio (1-4): ");
int historialCrediticio = int.Parse(Console.ReadLine());

Console.WriteLine("Tiene fiador? (S/N)");
string fiador = Console.ReadLine().ToUpper();

