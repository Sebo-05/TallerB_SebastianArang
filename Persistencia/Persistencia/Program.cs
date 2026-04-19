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
			} else{
				Console.WriteLine("Directorio ya existente o posible error");
				}
			
			Console.Write("Presione cualquier tecla");
			Console.ReadKey(true);
			Console.Clear();
			
			//Desafio 1:Validador de seguridad
			string registro_u="Carlitos,123";
			string[] claveseprda=registro_u.Split(',');
			string archivoseguridad=Path.Combine(rutaRaiz,"Seguridad.txt");
			
			if(claveseprda[1].Contains("123")){
				using (StreamWriter seguridad= new StreamWriter(archivoseguridad, true)){
				seguridad.WriteLine("Clave Debil detectada: " +claveseprda[1]);
				}
				Console.WriteLine("Clave debil detectada...");
			}
				else{
					Console.WriteLine("Clave fuerte.");
				}
			Console.WriteLine("Presione cualquier tecla...");
			Console.ReadKey(true);
			Console.Clear();
			
			//Desafio 2: El clonador de imagenes
			string avatar=Path.Combine(rutaRaiz,"avatar.jpg");
			string respaldo=Path.Combine(rutaRaiz,"respaldo.jpg");
			int bytesrecopilados;
			
			using (FileStream fsavatar= new FileStream(avatar,FileMode.Open,FileAccess.Read)){
				using (FileStream fsrespaldo= new FileStream(respaldo,FileMode.Create, FileAccess.Write)){
					byte[] buffer= new byte[1024];
					while((bytesrecopilados= fsavatar.Read(buffer, 0, buffer.Length))>0){
						fsrespaldo.Write(buffer, 0, bytesrecopilados);
					}
				}
			}
						
			Console.WriteLine("Respaldo hecho...");
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
			Console.Clear();
			
			//Desafio 3: Buscador de archivos pesados
			string[] archivosre= Directory.GetFiles(rutaReportes);
			
			foreach(string infarchivos in archivosre){
				FileInfo datos= new FileInfo(infarchivos);
				if(datos.Length>5120){
					Console.WriteLine("Eliminando: " +datos.Name);
					File.Delete(infarchivos);
				}else{
					Console.WriteLine("No se borrara: " +datos.Name);
				}		
			}
			Console.Write("Presione una tecla para salir.");
			Console.ReadKey(true);
		}
	}
}