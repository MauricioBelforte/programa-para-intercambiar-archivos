# 🎯 Intercambio de nombres de imágenes en C# - Proyecto Visual Studio

Este proyecto fue creado con **Visual Studio** y tiene como finalidad intercambiar nombres de imágenes entre dos grupos, evitando conflictos mediante el uso de archivos temporales.

## 🧱 Estructura del Proyecto

- **Solución**: `IntercambiarNombres.sln`
- **Archivo principal**: `Program.cs`
- **Carpetas generadas automáticamente**:
  - `bin/`: contiene los ejecutables generados al compilar
  - `obj/`: archivos temporales usados por el compilador
  - `.vs/`: configuración interna de Visual Studio
  - Archivo `.csproj`: configuración del proyecto para .NET 5.0

## 📝 Ruta de trabajo

```
D:\\CarpetasPersonales\\Escritorio\\TRABAJOS\\Web Radio Santa Barbara\\radio-Santa-Barbara\\imagenes
```
### Entonces, ¿qué necesitas para que funcione en cualquier ruta?

- Cambiar la variable rutaDirectorio a la carpeta deseada.

- Asegurarte de que esa carpeta contenga las seis imágenes requeridas con los nombres esperados.

- Si los nombres cambian o son distintos, también tenés que ajustar los arrays grupo1 y grupo2.


## 🚀 ¿Qué hace el programa?

1. Toma dos grupos de imágenes (`grupo1` y `grupo2`), cada uno con tres archivos.
2. Renombra los archivos de `grupo1` a nombres temporales.
3. Renombra los archivos de `grupo2` para que tomen los nombres originales de `grupo1`.
4. Finalmente, los archivos temporales reciben los nombres originales de `grupo2`.
5. Muestra un mensaje en consola y espera que el usuario presione una tecla.

Este enfoque permite un intercambio seguro sin pérdida ni sobreescritura de archivos.

## 🛠️ Tecnologías utilizadas

- **Lenguaje**: C#
- **Entorno**: Visual Studio
- **Framework**: .NET 5.0

## 🖥️ Ejecución del programa

- El ejecutable se encuentra en:

  ```
  IntercambiarNombres\\bin\\Debug\\net5.0\\IntercambiarNombres.exe
  ```

- Se puede abrir con **doble clic**, y la consola se mantendrá visible hasta que se presione una tecla.
- Asegurarse de que la ruta especificada exista y contenga las imágenes necesarias para evitar errores.

---
