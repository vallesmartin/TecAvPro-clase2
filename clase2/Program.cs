using System;
using System.Collections.Generic;

namespace clase2
{
    public class Program
    {
        // Para todas
        static string textoEntrada = "Ingrese ";
        static string textoSalida = "Presione una tecla para continuar.";

        // Actividad 1
        static short cantPersonas = 5;
        static string entradaCaracteres = "nombre de la persona";
        static string[] nombres = new string[cantPersonas];
        static string entradaNumerica = "la edad";
        static short[] edades = new short[cantPersonas];

        // Actividad 2
        static string entradaRadio = "radio de circunferencia";
        static int radio;

        // Actividad 3
        static short distanciaMinima = 200;
        static string entradaCapacidadTanque = "la capacidad del tanque";
        static string entradaPorcentajeTanque = "porcentaje de tanque restante";
        static string entradaConsumo = "consumo en litros por kilometro";
        static short capacidadTanque, porcentajeCombustible, consumo;

        // Actividad 4
        static string entradaProducto = "producto";
        static string entradaOtroProducto = "otro producto? 0=NO 1=SI";
        static string entradaPrecio = "Precio:";
        static string entradaExtra = "Despues de la medianoche? 0=NO 1=SI";
        private class Producto { public string Nombre; public int Precio; }
        static List<Producto> productos = new List<Producto>();
        static bool extraPorMedianoche;
        static int importeCostoEnvio, importeTotal;

        public static void Main(string[] args)
        {
            // Se ejecutan las actividades secuencialmente. Para omitir una actividad, comentar su porcion del codigo.
            Actividad1();
            Salida();

            Actividad2();
            Salida();

            Actividad3();
            Salida();

            Actividad4();
            Salida();
        }

        private static void Actividad4()
        {
            Actividad4_IngresoProductos();
            Actividad4_IngresoExtras();
            Actividad4_CalculoFacturacion();
            Actividad4_MuestraFacturacion();
        }

        private static void Actividad4_CalculoFacturacion()
        {
            // Calcula importe sin extras
            int importeSinExtras = Actividad4_CalculoSinExtras();
            // Calcula extras
            int importeDeExtras = Actividad4_CalculoExtraPorMonto(importeSinExtras);
            int importeExtraMedianoche = Actividad4_CalculoExtraMedianoche();
            // Calcula importe de extra
            importeCostoEnvio = importeDeExtras + importeExtraMedianoche;
            // Calcula importe total
            importeTotal = importeSinExtras + importeCostoEnvio;
        }

        private static int Actividad4_CalculoExtraMedianoche()
        {
            if (extraPorMedianoche)
                return 5;
            else
                return 0;
        }

        private static int Actividad4_CalculoExtraPorMonto(float importeSinExtras)
        {
            if (importeSinExtras < 20)
                return 2;
            else
                return 3;
        }

        private static int Actividad4_CalculoSinExtras()
        {
            int importeProducto = 0;
            foreach (Producto producto in productos)
                importeProducto += producto.Precio;
            return importeProducto;
        }

        private static void Actividad4_IngresoExtras()
        {
            extraPorMedianoche = IngresaValorBool(entradaExtra);
            Console.Clear();
        }

        private static void Actividad4_MuestraFacturacion()
        {
            Console.WriteLine("Factura:");
            foreach (Producto prodcuto in productos)
                Console.WriteLine("{0,40}{1,8}", prodcuto.Nombre, prodcuto.Precio.ToString());
            Console.WriteLine("{0,40}{1,8}", "Envio:", importeCostoEnvio.ToString());
            Console.WriteLine("{0,40}{1,8}", "Total:", importeTotal.ToString());
        }

        private static void Actividad4_IngresoProductos()
        {
            do
            {
                Console.Clear();
                Producto producto = new Producto();
                producto.Nombre = IngresaValorStr(entradaProducto);
                producto.Precio = IngresaValorInt(entradaPrecio);
                productos.Add(producto);
                
            } while (IngresaValorBool(entradaOtroProducto));
        }

        private static void Actividad3()
        {
            Actividad3_PideDatos();
            Actividad3_CalculaNecesidadCombustible();
        }     

        private static void Actividad3_PideDatos()
        {
            capacidadTanque = IngresaValorShort(entradaCapacidadTanque);
            porcentajeCombustible = IngresaValorShort(entradaPorcentajeTanque);
            consumo = IngresaValorShort(entradaConsumo);
        }

        private static void Actividad3_CalculaNecesidadCombustible()
        {
            // Determina si el combustible es suficiente o no
            float combustibleRestante = (capacidadTanque * porcentajeCombustible / 100);
            bool necesitaCombustible = (combustibleRestante * consumo) < distanciaMinima;

            if (necesitaCombustible)
                Console.WriteLine("Necesita combustible");
            else
                Console.WriteLine("Combustible suficiente");
        }

        private static void Actividad2()
        {
            Actividad2_CalculaRadio();
        }

        private static void Actividad2_CalculaRadio()
        {
            // A partir del radio ingresado, se calcula el area
            radio = IngresaValorInt(entradaRadio);
            double area = Math.PI * Math.Pow(radio, 2);
            Console.WriteLine("El area de la circunferencia es:" + area.ToString());
        }

        private static void Actividad1()
        {
            Actividad1_PideDatos();
            Actividad1_CalculaDatos();
        }

        private static void Actividad1_PideDatos()
        {
            // Actividad 1 pide cinco nombres y edades, y muestra promedio
            for (var i = 0; i < cantPersonas; i++)
            {
                Console.WriteLine("Datos de persona nro " + (i+1).ToString());
                nombres[i] = IngresaValorStr(entradaCaracteres);
                edades[i] = IngresaValorShort(entradaNumerica);
                Console.Clear();
            }
        }

        private static void Actividad1_CalculaDatos()
        {
            short promedio, total = 0;
            // Calcula el promedio desde el array
            for (var i = 0; i < edades.Length; i++)
                total += edades[i];
            promedio = (short)(total / cantPersonas);
            Console.WriteLine("El promedio de edades ingresado es: "+promedio.ToString());
        }

        private static string IngresaValorStr(string title)
        {
            Console.WriteLine(textoEntrada + title);
            return Console.ReadLine();
        }

        private static bool IngresaValorBool(string title)
        {
            short ingreso;
            do
            {
                Console.WriteLine(textoEntrada + title);
                ingreso = short.Parse(Console.ReadLine());
            } while (ingreso != 1 && ingreso != 0);

            if (ingreso == 1)
                return true;
            else
                return false;
        }

        private static short IngresaValorShort(string title)
        {
            Console.WriteLine(textoEntrada + title);
            return short.Parse(Console.ReadLine());
        }

        private static int IngresaValorInt(string title)
        {
            Console.WriteLine(textoEntrada + title);
            return int.Parse(Console.ReadLine());
        }

        private static void Salida()
        {
            Console.WriteLine(textoSalida);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
