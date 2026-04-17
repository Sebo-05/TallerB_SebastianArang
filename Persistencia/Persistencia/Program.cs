/*
 * Creado por SharpDevelop.
 * Usuario: Sebastian Aranguren
 * Fecha: 17/04/2026
 * Hora: 14:27
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;

namespace Persistencia
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("-----Taller-----");
			
			// Creando directorio
			
			string rutaRaiz= Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"DatosIUJO");
			string rutaReportes= Path.Combine(rutaRaiz, "Reportes");
			
			Console.WriteLine(rutaRaiz);
			Console.WriteLine(rutaReportes);
			
			if(!Directory.Exists(rutaReportes)){
				//Se creara el directorio "Reportes"
				Directory.CreateDirectory(rutaReportes);
				Console.WriteLine("Directorio creado correctamente");
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}