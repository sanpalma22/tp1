using System.Collections.Generic;
cuandoEsMiCumple();
obtenerFechasPago();
obtenerMesesEntre();
List<int> listaDatos = new List<int>();
crearLista(listaDatos);
calcularDatosDeLista(listaDatos);


string ingresarFecha(string r)
{
    int dia, mes, año;
    string stringFecha;
    bool posibleFecha;
    do
    {
        Console.WriteLine(r);
        Console.WriteLine("dia:");
        dia = int.Parse(Console.ReadLine());
        Console.WriteLine("mes:");
        mes = int.Parse(Console.ReadLine());
        Console.WriteLine("año:");
        año = int.Parse(Console.ReadLine());
        stringFecha = año + "/" + mes + "/" + dia;
        posibleFecha = DateTime.TryParse(stringFecha, out DateTime fecha);
        if (!posibleFecha) Console.WriteLine("Has ingresado mal la fecha");
    } while (!posibleFecha);
    return stringFecha;
}

void cuandoEsMiCumple()
{
    string fechaString;
    int diferenciaDias, diasCumple = 0, diasHoy = 0;
    DateTime hoy = DateTime.Today;
    fechaString = ingresarFecha("Ingrese la fecha de nacimiento");
    DateTime tuCumple = DateTime.Parse(fechaString);
    int[] meses = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    for (int i = 0; i < tuCumple.Month; i++)
    {
        diasCumple += meses[i];
    }
    diasCumple += tuCumple.Day;
    for (int i = 0; i < hoy.Month; i++)
    {
        diasHoy += meses[i];
    }
    diasHoy += hoy.Day;
    diferenciaDias = diasCumple - diasHoy;
    if (diferenciaDias <= 0)
    {
        Console.WriteLine("Han pasado " + (-diferenciaDias) + " dias, desde tu cumple");

    }
    else
    {
        Console.WriteLine("Faltan " + diferenciaDias + " dias, para tu cumple");
    }

}

void obtenerFechasPago()
{
    string fechaString;
    int cuotas;
    List<string> listaCuotas = new List<string>();
    fechaString = ingresarFecha("Ingrese la fecha de la compra");
    cuotas = ingresarEntero("Ingrese las cuotas a pagar");
    DateTime fechaCompra = DateTime.Parse(fechaString);
    for (int i = 0; i < cuotas; i++)
    {
        DateTime cuotaSiguiente = fechaCompra.AddMonths(i);
        listaCuotas.Add(cuotaSiguiente.ToShortDateString());
    }
    foreach (string cuota in listaCuotas)
    {
        Console.WriteLine(cuota);
    }
}

void obtenerMesesEntre()
{
    string[] meses = { "", "enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre" };
    string fechaString1, fechaString2;
    fechaString1 = ingresarFecha("ingrese una fecha");
    DateTime fecha1 = DateTime.Parse(fechaString1);
    fechaString2 = ingresarFecha("ingrese otra fecha del mismo año y mayor a la anterior");
    DateTime fecha2 = DateTime.Parse(fechaString2);
    while (fecha2.Year != fecha1.Year || fecha1.Day > fecha2.Day || fecha1.Month > fecha2.Month)
    {
        Console.WriteLine("La sgunda fecha esta mal ingresada");
        fechaString2 = ingresarFecha("ingrese otra fecha del mismo año y mayor a la anterior");
    }
    for (int i = fecha1.Month; i <= fecha2.Month; i++)
    {
        Console.WriteLine(meses[i]);
    }
}
int ingresarEntero(string v)
{
    int num;
    Console.WriteLine(v);
    num = int.Parse(Console.ReadLine());
    return num;
}
void crearLista(List<int> list)
{
    int num;
    do
    {
        num = ingresarEntero("Ingrese un número o 0 para dejar de ingresar");
        if (num != 0) list.Add(num);
    } while (num != 0);
}
void calcularDatosDeLista(List<int> list)
{
    int maxNum = 0;
    int minNum = list[0], acum = 0;
    double promedio;
    for (int i = 0; i < list.Count; i++)
    {
        if (list[i] > maxNum) maxNum = list[i];
        if (list[i] < minNum) minNum = list[i];
        acum += list[i];
    }
    promedio = acum / list.Count;
    Console.WriteLine("El valor maximo es de " + maxNum);
    Console.WriteLine("El valor minimo es de " + minNum);
    Console.WriteLine("La suma de todos los valores es de " + acum);
    Console.WriteLine("El promedio es de " + promedio);
    Console.WriteLine("La cantidad de elementod de la lista es de " + list.Count);
}