using System;         // Proporciona funcionalidades básicas del sistema como consola y manejo de tipos
using System.IO;      // Incluye clases para manipular archivos y rutas como File y Path

// Soluciona el problema cuando tenemos 2 archivos, y a uno le quiero poner el nombre del otro pero el sistema operativo dice que ya existe un archivo uno con ese nombre. Y al reves con el otro archivo pasa lo mismo.
/*  A mano como se hace? 
Tenemos 2 imagenes promo1.jpg y promoExtra1.jpg
A una imagen (vamos a llamarle la primera) le borro el nombre y le pongo cualquiera. pepe.jpg y promoExtra1.jpg
Ahi a la segunda le pongo el nombre que borre de la primera, porque ya lo puedo usar.  pepe.jpg y promo1.jpg
Ahi a la primera le pongo el nombre que borre de la segunda porque ahora lo puedo usar. promoExtra1.jpg y promo1.jpg
Eso mismo hace este programa pero con 3 imagenes. */

// Por lo menos en este programa nunca guarde o asigne un archivo a una variable. Sino que guarde los path, es decir las rutas.
// Solo movio archivos el  File.move() pero yo no asigne nombres a esas variables "implicitas"
class Programa
{
    static void Main(string[] args)
    {
        // ✅ Ruta absoluta del directorio donde se encuentran las imágenes a intercambiar
        string rutaDirectorio = @"D:\CarpetasPersonales\Escritorio\TRABAJOS\Web Radio Santa Barbara\radio-Santa-Barbara\imagenes";

        // ✅ Arreglo original de imágenes promocionales (grupo1)
        string[] grupo1 = { "promo1.jpg", "promo2.jpg", "promo3.jpg" };

        // ✅ Arreglo alternativo de imágenes promocionales (grupo2)
        string[] grupo2 = { "promo1extra.jpg", "promo2extra.jpg", "promo3extra.jpg" };

        /*      
                Los arreglos grupo1 y grupo2 guardan strings con los nombres de los archivos. 
                Esos nombres de los arreglos no se modifican durante la ejecución del programa, lo que cambian son los nombres de los archivos.
                El programa toma estos nombres como referencia y usa File.Move() para realizar el intercambio físico de nombres de archivo en el disco, pero el contenido de los arrays en memoria no se altera.
         */

        // ✅ Llamado a la función que intercambia los nombres de los archivos entre grupo1 y grupo2
        IntercambiarNombres(rutaDirectorio, grupo1, grupo2);

        // ✅ Muestra mensaje y espera una tecla para cerrar la ventana de consola
        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();  // Evita que la consola se cierre automáticamente
    }

    // ✅ Declaración de función que intercambia los nombres de imágenes entre dos grupos
    static void IntercambiarNombres(string rutaDirectorio, string[] grupo1, string[] grupo2)
    {
        // ✅ Valida que ambos grupos tengan exactamente tres archivos para evitar errores
        if (grupo1.Length != grupo2.Length)
        {
            Console.WriteLine("Cada grupo debe contener exactamente la misma cantidad archivos.");
            return;
        }

        // ✅ Se crean rutas string temporales para alojar los archivos de grupo1 durante el intercambio.
        // Es decir es un arreglo con 3 strings que son 3 rutas
        string[] archivosTemporales = {
            Path.Combine(rutaDirectorio, "temporal1.tmp"),
            Path.Combine(rutaDirectorio, "temporal2.tmp"),
            Path.Combine(rutaDirectorio, "temporal3.tmp")
        };

        /*
         🔧 ¿Qué es Path.Combine?
         - Es un método estático de la clase Path.
         - Combina partes de una ruta en un solo string correctamente formateado.
         - Evita errores comunes como olvidarse de la barra invertida.
         - Recibe múltiples argumentos (normalmente 2 o más strings).
         - Ejemplo: Path.Combine("carpeta", "archivo.txt") → "carpeta\\archivo.txt"
        */
        
        /*             
        Originalmente tenemos
        promo1.jpg - promo1extra.jpg
        promo2.jpg - promo2extra.jpg
        promo3.jpg - promo3extra.jpg 
        */

        // ✅ Paso 1: Se renombra cada imagen del grupo1 a su nombre temporal correspondiente.
        // Cambia los nombres de los archivos del grupo1 por nombres temporales. 
        // Las imagenes no se llaman mas promo1.jpg promo2.jpg promo3.jpg ahora se llaman temporal1.tmp temporal2.tmp y temporal3.tmp
        // Ahora puedo usar los nombres promo1.jpg promo2.jpg promo3.jpg porque ya no hay imagenes con esos nombres.  Ademas los nombres NO SE PERDIERON, ESTAN EN EL ARREGLO grupo1
        for (int i = 0; i < grupo1.Length; i++)
        {
            // Se renombra cada archivo de la izquierda por los nombres de cada archivo la derecha
            File.Move(Path.Combine(rutaDirectorio, grupo1[i]), archivosTemporales[i]);

            /*             
            Quedando
            temporal1.tmp - promo1extra.jpg
            temporal2.tmp - promo2extra.jpg
            temporal3.tmp - promo3extra.jpg 
            */
        }

        /*
         🔧 ¿Qué hace File.Move?
         - Es un método estático de la clase File.
         - Mueve un archivo de una ruta string origen a otra ruta string destino.
         - Si los 2 archivos estan en la misma carpeta, es como renombrar el archivo.
         - Sintaxis: File.Move(origen, destino) // Entonces se renombra el de la izquierda por el de la derecha
         - Si la ruta destino ya existe, lanza una excepción.
        

        */



        // ✅ Paso 2: Cada archivo del grupo2 se mueve y se renombra para que tome el nombre original de las imagenes del grupo1. 
        // Se pueden usar los nombres del grupo1 original porque ya no hay imagenes con los nombres "promo1.jpg", "promo2.jpg", "promo3.jpg" 
        // Las imagenes dejan de llamarse "promo1extra.jpg", "promo2extra.jpg", "promo3extra.jpg" para llamarse  "promo1.jpg", "promo2.jpg", "promo3.jpg" donde estos ultimos nombres se sacan del arreglo grupo1.
        // Ahora puedo usar los nombres "promo1extra.jpg", "promo2extra.jpg", "promo3extra.jpg" porque ya no hay imagenes con esos nombres.  Ademas los nombres NO SE PERDIERON, ESTAN EN EL ARREGLO grupo2
        for (int i = 0; i < grupo1.Length; i++)
        {
            File.Move(Path.Combine(rutaDirectorio, grupo2[i]), Path.Combine(rutaDirectorio, grupo1[i]));
        }
        /*             
            Quedando
            temporal1.tmp - promo1.jpg
            temporal2.tmp - promo2.jpg
            temporal3.tmp - promo3.jpg 
        */

        // ✅ Paso 3: Los archivos temporales se mueven y ahora toman los nombres originales del grupo2
        // Se pueden usar los nombres del grupo2 original porque ya no hay imagenes con los nombres "promo1extra.jpg", "promo2extra.jpg", "promo3extra.jpg"
        // Los archivos temporales donde estan las imagenes originales dejan de llamarse temporal1.tmp temporal2.tmp y temporal3.tmp y pasan a llamarse "promo1extra.jpg", "promo2extra.jpg", "promo3extra.jpg"
        for (int i = 0; i < grupo1.Length; i++)
        {
            File.Move(archivosTemporales[i], Path.Combine(rutaDirectorio, grupo2[i]));
        }
        /*             
            Quedando
            promo1extra.jpg - promo1.jpg 
            promo2extra.jpg - promo2.jpg 
            promo3extra.jpg - promo3.jpg  
        */

        // ✅ Mensaje final que indica que el intercambio se realizó exitosamente
        Console.WriteLine("Nombres de archivos intercambiados exitosamente.");
    }
}
