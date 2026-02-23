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
int antiguedadmensual = int.Parse(Console.ReadLine());

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

if (tipoSolicitante < 1 || tipoSolicitante > 4)
{
    Console.WriteLine("Tipo de solicitante fuera de rago (1-4)");
}
else if (historialCrediticio < 1 || historialCrediticio > 4)
{
    Console.WriteLine("Historial crediticio fuera de rago (1-4)");
}
else if (ingresoMensual < 0)
{
   Console.WriteLine("Ingreso mensual no puede ser negativo");
}
else if (antiguedadmensual < 0)
{
    Console.WriteLine("Antigüedad laboral no puede ser negativa");
}
else if (monto < 0)
{
    Console.WriteLine("Monto solicitado no puede ser negativo");
}
else if (historialCrediticio < 1 || historialCrediticio > 4)
{
    Console.WriteLine("Historial crediticio fuera del rango (1-4)");
}
else if (fiador != "S" && fiador != "N")
{
    Console.WriteLine("Respuesta invalida (S/N)");
}

double MONTO_PEQUENO = 15000.0;

// Minimos por tipo
double minIngreso = 0.0;
int minAntig = 0;

string resultado = "Rechazado";
string motivo = "No evaluado";

switch (tipoSolicitante)
{
    case 1: // Empleado fijo
        minIngreso = 4000.0;
        minAntig = 12;

        if (historialCrediticio == 4)
        {
            if (fiador == "S" && monto <= MONTO_PEQUENO)
            {
                resultado = "Aprobado con condiciones";
                motivo = "Historial malo, se aprueba por fiador y monto pequeño.";
            }
            else
            {
                resultado = "Rechazado";
                motivo = "Historial crediticio malo.";
            }
        }
        else
        {
            if (ingresoMensual < minIngreso)
            {
                if (fiador == "S" && monto <= MONTO_PEQUENO && historialCrediticio <= 2)
                {
                    resultado = "Aprobado con condiciones";
                    motivo = "Ingreso por debajo del mínimo; aprobado por fiador y monto pequeño.";
                }
                else
                {
                    resultado = "Rechazado";
                    motivo = "Ingreso insuficiente para empleado fijo.";
                }
            }
            else if (antiguedadmensual < minAntig)
            {
                if (fiador == "S" && historialCrediticio <= 2)
                {
                    resultado = "Aprobado con condiciones";
                    motivo = "Antigüedad insuficiente; requiere fiador.";
                }
                else
                {
                    resultado = "Rechazado";
                    motivo = "Antigüedad insuficiente.";
                }
            }
            else
            {
                // Cumple mínimos: decide por historial
                if (historialCrediticio == 1 || historialCrediticio == 2)
                {
                    resultado = "Aprobado";
                    motivo = "Cumple ingreso y antigüedad con buen historial.";
                }
                else if (historialCrediticio == 3)
                {
                    // Regular: condiciones
                    if (fiador == "S" || monto <= 20000)
                    {
                        resultado = "Aprobado con condiciones";
                        motivo = "Historial regular; se aprueba con condiciones.";
                    }
                    else
                    {
                        resultado = "Rechazado";
                        motivo = "Historial regular sin fiador y monto alto.";
                    }
                }
            }
        }
        break;

    case 2: // Temporal
        minIngreso = 5000.0;
        minAntig = 6;

        if (historialCrediticio == 4)
        {
            if (fiador == "S" && monto <= MONTO_PEQUENO)
            {
                resultado = "Aprobado con condiciones";
                motivo = "Historial malo; fiador y monto pequeño.";
            }
            else
            {
                resultado = "Rechazado";
                motivo = "Historial crediticio malo.";
            }
        }
        else
        {
            if (ingresoMensual < minIngreso)
            {
                if (fiador == "S" && monto <= MONTO_PEQUENO && historialCrediticio <= 2)
                {
                    resultado = "Aprobado con condiciones";
                    motivo = "Ingreso bajo; aprobado por fiador y monto pequeño.";
                }
                else
                {
                    resultado = "Rechazado";
                    motivo = "Ingreso insuficiente para temporal.";
                }
            }
            else if (antiguedadmensual < minAntig)
            {
                // Excepción: si monto es pequeño y fiador=S, se puede
                if (fiador == "S" && monto <= MONTO_PEQUENO)
                {
                    resultado = "Aprobado con condiciones";
                    motivo = "Antigüedad baja; aprobado por fiador y monto pequeño.";
                }
                else
                {
                    resultado = "Rechazado";
                    motivo = "Antigüedad insuficiente.";
                }
            }
            else
            {
                // Si monto alto, podría requerir fiador
                if (monto > 50000 && fiador == "N" && historialCrediticio >= 3)
                {
                    resultado = "Rechazado";
                    motivo = "Monto alto sin fiador y con historial no óptimo.";
                }
                else
                {
                    if (historialCrediticio == 1 || historialCrediticio == 2)
                    {
                        resultado = "Aprobado";
                        motivo = "Cumple requisitos y buen historial.";
                    }
                    else
                    {
                        resultado = "Aprobado con condiciones";
                        motivo = "Historial regular; aprobado con condiciones.";
                    }
                }
            }
        }
        break;

    case 3: // Independiente (exige mayor ingreso)
        minIngreso = 7000.0;
        minAntig = 24;

        if (historialCrediticio == 4)
        {
            if (fiador == "S" && monto <= MONTO_PEQUENO)
            {
                resultado = "Aprobado con condiciones";
                motivo = "Historial malo; fiador y monto pequeño.";
            }
            else
            {
                resultado = "Rechazado";
                motivo = "Historial crediticio malo.";
            }
        }
        else
        {
            if (ingresoMensual < minIngreso)
            {
                if (fiador == "S" && monto <= MONTO_PEQUENO && historialCrediticio <= 2)
                {
                    resultado = "Aprobado con condiciones";
                    motivo = "Independiente con ingreso bajo; aprobado por fiador y monto pequeño.";
                }
                else
                {
                    resultado = "Rechazado";
                    motivo = "Independiente exige mayor ingreso.";
                }
            }
            else if (antiguedadmensual < minAntig)
            {
                if (fiador == "S" && historialCrediticio <= 2 && monto <= 30000)
                {
                    resultado = "Aprobado con condiciones";
                    motivo = "Antigüedad en actividad insuficiente; requiere fiador.";
                }
                else
                {
                    resultado = "Rechazado";
                    motivo = "Antigüedad insuficiente para independiente.";
                }
            }
            else
            {
                if (historialCrediticio == 1)
                {
                    resultado = "Aprobado";
                    motivo = "Excelente historial y cumple requisitos.";
                }
                else if (historialCrediticio == 2)
                {
                    resultado = "Aprobado";
                    motivo = "Buen historial y cumple requisitos.";
                }
                else // regular
                {
                    if (fiador == "S" || monto <= 25000)
                    {
                        resultado = "Aprobado con condiciones";
                        motivo = "Historial regular; aprobado con condiciones.";
                    }
                    else
                    {
                        resultado = "Rechazado";
                        motivo = "Historial regular sin fiador y monto alto.";
                    }
                }
            }
        }
        break;

    case 4: // Estudiante (solo con fiador)
        minIngreso = 0.0; 
        minAntig = 0;  

        if (fiador != "S")
        {
            resultado = "Rechazado";
            motivo = "Estudiante requiere fiador.";
        }
        else
        {
            if (historialCrediticio == 4)
            {
                if (monto <= MONTO_PEQUENO)
                {
                    resultado = "Aprobado con condiciones";
                    motivo = "Historial malo; se aprueba por fiador y monto pequeño.";
                }
                else
                {
                    resultado = "Rechazado";
                    motivo = "Historial malo con monto alto.";
                }
            }
            else if (historialCrediticio == 3)
            {
                resultado = "Aprobado con condiciones";
                motivo = "Estudiante con historial regular; se aprueba con fiador.";
            }
            else
            {
                // Excelente/Bueno
                if (monto > 30000)
                {
                    resultado = "Aprobado con condiciones";
                    motivo = "Estudiante: monto alto; se aprueba con condiciones.";
                }
                else
                {
                    resultado = "Aprobado";
                    motivo = "Estudiante con fiador y buen historial.";
                }
            }
        }
        break;
}
Console.WriteLine("- RESULTADOS DE EVALUACION -");
Console.WriteLine($"Decisión: {resultado}");
Console.WriteLine($"Motivo principal: {motivo}");