using System;
using System.IO;

class Programa
{
    static void Main(string[] args)
    {
        string rutaDirectorio = @"D:\CarpetasPersonales\Escritorio\TRABAJOS\Web Radio Santa Barbara\radio-Santa-Barbara\imagenes";
        string[] grupo1 = { "promo1.jpg", "promo2.jpg", "promo3.jpg" };
        string[] grupo2 = { "promo1extra.jpg", "promo2extra.jpg", "promo3extra.jpg" };

        IntercambiarNombres(rutaDirectorio, grupo1, grupo2);
        // Pausar el programa para ver la salida 
        Console.WriteLine("Presiona cualquier tecla para salir..."); 
        Console.ReadKey();
    }

    static void IntercambiarNombres(string rutaDirectorio, string[] grupo1, string[] grupo2)
    {
        if (grupo1.Length != 3 || grupo2.Length != 3)
        {
            Console.WriteLine("Cada grupo debe contener exactamente tres archivos.");
            return;
        }

        string[] archivosTemporales = {
            Path.Combine(rutaDirectorio, "temporal1.tmp"),
            Path.Combine(rutaDirectorio, "temporal2.tmp"),
            Path.Combine(rutaDirectorio, "temporal3.tmp")
        };

        // Renombrar archivos del grupo1 a nombres temporales
        for (int i = 0; i < 3; i++)
        {
            File.Move(Path.Combine(rutaDirectorio, grupo1[i]), archivosTemporales[i]);
        }

        // Renombrar archivos del grupo2 a los nombres originales del grupo1
        for (int i = 0; i < 3; i++)
        {
            File.Move(Path.Combine(rutaDirectorio, grupo2[i]), Path.Combine(rutaDirectorio, grupo1[i]));
        }

        // Renombrar archivos temporales a los nombres originales del grupo2
        for (int i = 0; i < 3; i++)
        {
            File.Move(archivosTemporales[i], Path.Combine(rutaDirectorio, grupo2[i]));
        }

        Console.WriteLine("Nombres de archivos intercambiados exitosamente.");
    }
}
