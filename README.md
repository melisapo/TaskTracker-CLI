#  ˚₊‧꒰ა Task Tracker CLI ໒꒱ ‧₊˚

Una aplicación de línea de comandos en C# para gestionar tus tareas de manera eficiente y organizada. Este proyecto fue inspirado por [Roadmap.sh](https://roadmap.sh/projects/task-tracker) **୨୧**

## Características Principales (๑╹ᵕ╹๑)⸝*

- **★ Gestión completa de tareas**: Crear, editar, eliminar y listar tareas
- **꩜ Seguimiento de estados**: Por hacer, En progreso, Completada
- **𐙚 Persistencia de datos**: Guardado automático en archivo JSON
- **𖹭 Interfaz visual atractiva**: Tablas formateadas con colores y emojis
- **✿ Filtros inteligentes**: Listar tareas por estado específico
- **⏾ Fácil de usar**: Comandos intuitivos y ayuda integrada

## Comandos Disponibles ദ്ദി(˵ •̀ᴗ- ˵) ✧

| Comando     | Uso                           | Descripción                                                   |
|-------------|-------------------------------|---------------------------------------------------------------|
| `ayuda`     | `ayuda`                       | Muestra la lista de todos los comandos disponibles            |
| `crear`     | `crear -[descripción]`        | Crea una nueva tarea. Ej: `crear -Comprar tomates`            |
| `editar`    | `editar -[id] -[descripción]` | Edita una tarea existente. Ej: `editar -1 -Comprar 5 tomates` |
| `eliminar`  | `eliminar -[id]`              | Elimina una tarea. Ej: `eliminar -1`                          |
| `marcar -p` | `marcar -p -[id]`             | Marca una tarea como 'En Progreso'. Ej: `marcar -p -1`        |
| `marcar -c` | `marcar -c -[id]`             | Marca una tarea como completada. Ej: `marcar -c -1`           |
| `listar`    | `listar`                      | Lista todas las tareas                                        |
| `listar -h` | `listar -h`                   | Lista todas las tareas por hacer                              |
| `listar -p` | `listar -p`                   | Lista todas las tareas en progreso                            |
| `listar -c` | `listar -c`                   | Lista todas las tareas completadas                            |
| `limpiar`   | `limpiar`                     | Limpia la consola                                             |
| `salir`     | `salir`                       | Sale de la aplicación TaskTracker                             |

## Instalación y Configuración ദ്ദി(ᗜˬᗜ)

### Requisitos
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

### Clonar y Ejecutar

1. **Clona el repositorio**:
   ```bash
   git clone https://github.com/melisapo/TaskTracker-CLI.git
   cd TaskTracker-CLI
   ```

2. **Compila el proyecto**:
   ```bash
   dotnet build
   ```

3. **Ejecuta la aplicación**:
   ```bash
   dotnet run
   ```

## Ejemplos de Uso ദ്ദി(˵ •̀ᴗ- ˵) ✧

### Crear una nueva tarea
```
 ╰┈➤ crear -Pasear al perro
La tarea 'Pasear al perro' se ha creado. Id: 1. (๑╹ᵕ╹๑)⸝* 
```

### Listar todas las tareas
```
 ╰┈➤ listar

ID    Descripción       Estado       Creado               Actualizado         
------------------------------------------------------------------------------
1     Pasear al perro   Por Hacer    23/10/2025 10:38 p.m. 24/10/2025 3:30 p.m.
------------------------------------------------------------------------------
2     Comprar tomates   Completada   24/10/2025 3:31 p.m. 24/10/2025 3:34 p.m.
------------------------------------------------------------------------------
3     Regar las plantas Por Hacer    24/10/2025 3:34 p.m. 24/10/2025 3:34 p.m.
------------------------------------------------------------------------------
```

### Marcar tarea como completada
```
 ╰┈➤ marcar -c -1
La tarea 'Pasear al perro' se ha marcado como 'Completada'✧｡٩(ˊᗜˋ )و✧*｡
```

## Almacenamiento de Datos ദ്ദി(ᗜˬᗜ)

Las tareas se guardan automáticamente en el archivo `Data/data.json` en el directorio de la aplicación. El formato es:

```json
{
  "Id": 1,
  "Description": "Pasear al perro",
  "Status": 2,
  "CreatedAt": "2025-10-23T22:38:03.8961401-04:00",
  "UpdatedAt": "2025-10-24T15:36:53.1090056-04:00"
}
```

**Estados en JSON:**
- `0` = Por Hacer
- `1` = En Progreso
- `2` = Completada

### ¡Disfruta organizando tus tareas con Task Tracker CLI! ( ˘ ³˘)♥︎
