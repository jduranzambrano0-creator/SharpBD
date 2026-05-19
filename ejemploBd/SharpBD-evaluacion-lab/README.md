## Curso: Algorítmica y Programación – Instituto Universitario Jesús Obrero
## Herramientas: SharpDevelop 4.4, XAMPP, phpMyAdmin, MySQL Connector/NET 

---

## 1. ¿Qué es un CRUD?

CRUD son las cuatro operaciones básicas sobre datos:

- **Create** (Crear / Insertar)
- **Read** (Leer / Consultar)
- **Update** (Actualizar / Modificar)
- **Delete** (Eliminar / Borrar)

Ejemplo:  Puedes agregar un usuario (Create), ver todas (Read), editar  y borrar (Delete).

# EjemploBD con SharpDevelop y Mysql 

## 1 Script SQL para crear la base de datos y la tabla
```Mysql
--
-- Base de datos: `peducativa`
--
CREATE DATABASE IF NOT EXISTS `peducativa` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `peducativa`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE IF NOT EXISTS `usuario` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `clave` varchar(50) NOT NULL,
  `rol` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
```

## 2 Configurar ShaarpDevelop
### 2.1 Instalar el conector MySQL para .NET
Descarga `MySql.Data.dll`desde [https://github.com/jdcadenas/SharpEjemploBD/tree/main/LIB_CONEXION/MySql.Data.dll](https://github.com/jdcadenas/SharpEjemploBD/tree/main/LIB_CONEXION/MySql.Data.dll)

### 2.2. Crear el proyecto en SharpDevelop
- Abre SharpDevelop → `File` → `New` → `Solution` → `C#` → `Windows Forms Application`  
- Nombre: `ejemploBD`  
- Haz clic en `Create`.

### 2.3. Agregar referencia a `MySql.Data.dll`
- En el `Solution Explorer`, haz clic derecho en `References` → `Add Reference`  
- Pestaña `.NET Assembly Browser` → `Browse`  
- Busca el archivo `MySql.Data.dll` en la carpeta del conector y selecciónalo.  
- Haz clic en `OK`. Verás que `MySql.Data` aparece bajo `References`.

### 2.4. Agregar los espacios de nombres
Abre `MainForm.cs` y, al inicio, junto a los `using` existentes, escribe:

```csharp
using MySql.Data.MySqlClient;
using System.Data;
```

## 2. Entidad elegida: `usuario`

Para que el aprendizaje sea rápido y claro, usaremos una tabla con **solo 3 columnas**:

| Campo        | Tipo         | Descripción                          |
|--------------|--------------|--------------------------------------|
| `id`         | INT          | Número único, automático (llave primaria) |
| `usuario`| VARCHAR(200) | Texto del usuario                    |
| `clave`| VARCHAR(200) | Texto de la clave                   |
| `rol` | int      | 0 = administrador, 1 = jugador        |


No hay relaciones con otras tablas. Es totalmente independiente.

---

## 5. Diseño del formulario (interfaz)

Agrega los siguientes controles desde la `Toolbox`:

| Control        | Nombre          | Propiedades importantes                     |
|----------------|-----------------|---------------------------------------------|
| `DataGridView` | `dgvUsuarios`     | `SelectionMode = FullRowSelect`            |
| `Button`       | `btnAgregar`    | `Text = "Agregar"`                         |
| `Button`       | `btnActualizar` | `Text = "Actualizar"`                      |
| `Button`       | `btnEliminar`   | `Text = "Eliminar"`                        |
| `Button`       | `btnLimpiar`    | `Text = "Limpiar"`                         |
| `Label`        | `lblEstado`     | `Text = "Listo"`                           |

**Distribución sugerida:**  
- `dgvUsuarios` ocupa la parte superior.  


---

## 6. Diagrama de flujo del CRUD

```
[Inicio]
   │
   ▼
[Cargarusuarios()] ────→ [Mostrar DataGridView]
   │
   ▼
[Esperar acción del usuario]
   │
   ├──► [Agregar] ──► [Validar] ──► [INSERT] ──► [Limpiar] ──► [Recargar]
   │
   ├──► [Seleccionar fila] ──► [Mostrar datos en campos]
   │
   ├──► [Actualizar] ──► [Validar selección] ──► [UPDATE] ──► [Limpiar] ──► [Recargar]
   │
   ├──► [Eliminar] ──► [Confirmar] ──► [DELETE] ──► [Limpiar] ──► [Recargar]
   │
   └──► [Limpiar] ──► [Vaciar campos]
   │
   ▼
[Fin]
```

---

## 7. Explicación paso a paso 
### 7.1. Crear la base de datos (5 min)
*“Abran XAMPP, inicien MySQL, vayan a phpMyAdmin, crean la base de datos y ejecutan el script SQL ”*

### 7.2. Configurar SharpDevelop (10 min)
*“Nuevo proyecto, agregamos la referencia a la DLL de MySQL, importamos los espacios de nombre.”*

### 7.3. Diseñar el formulario (10 min)
*“Arrastren los controles como ven en la tabla. Nombren cada uno exactamente como está escrito.”*

### 7.4. Escribir el código – Cargar usuarios (10 min)
*“El método `CargarUsuarios` se conecta, hace un `SELECT` y llena el DataGridView.”*

### 7.5. Seleccionar fila (5 min)
*“El evento `SelectionChanged` captura la fila que el usuario hace clic. Guardamos el `id` y mostramos la descripción y el estado en los controles.”*

### 7.6. Agregar, Actualizar, Eliminar (15 min)
*“Cada botón ejecuta una consulta SQL con parámetros. Siempre limpiamos los campos después y recargamos la grilla.”*

### 7.7. Probar (10 min)
*“Ejecuten (F5). Agreguen una usuario, márquenla como completada, actualícenla, elimínenla. Todo debe funcionar.”*




### 3. El proceso de entrega (Pull Request)

Como quieres que te entreguen vía GitHub, lo más limpio para ti como profesor es que el **Estudiante A** (el dueño del Fork) sea quien haga el **Pull Request** hacia tu repositorio original.

**¿Por qué esto es mejor para ti?**

* GitHub te mostrará exactamente qué líneas de código agregaron ellos en los archivos `.cs`.
* Podrás dejarles comentarios directamente en las líneas de código si algo está mal (ej. *"Aquí te faltó cerrar la conexión"*).
* En el cuerpo del Pull Request, pídeles que peguen los nombres de la pareja.

---

### 4. Resumen de comandos sugeridos 

> **Guía rápida de consola para el Laboratorio:**
> 1. `git clone [URL_DE_SU_FORK]`
> 2. *(Hacer los cambios en SharpDevelop)*
> 3. `git add .`
> 4. `git commit -m "Solución Fase 2 y 3 - Apellido1 y Apellido2"`
> 5. `git push origin main`
> 
> 
**no** suban la carpeta `bin` ni `obj` 
