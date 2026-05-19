# Evaluación de Laboratorio: Flujo Bilingüe (10%)

**IUJO - Algorítmica y Programación**

### Datos de la Pareja

* **Nombre 1:** _JOSE DURAN CI 30 004 848___


---

### 1. El Flujo de Trabajo en Parejas

1. **Estudiante A:** Hace el **Fork** del repositorio a su cuenta y añade al **Estudiante B** como colaborador (en *Settings > Collaborators*).
2. **Ambos:** Clonan el repositorio del Estudiante A en sus computadoras.
3. **Sincronización:** Deben ejecutar `git pull` antes de empezar a escribir código para recibir lo que su compañero haya subido y evitar conflictos.
4. **Regla de oro:** No trabajen en el mismo archivo al mismo tiempo. Si el Estudiante A está en `GestionModulos.cs`, el Estudiante B debe estar en la Base de Datos o en `GestionPreguntas.cs`.

---

### INSTRUCCIONES

> ⚠️ **IMPORTANTE:** El repositorio tiene dos carpetas con nombres similares.
> * **Guía de Referencia:** Utilice la carpeta `ejemploBd` que está en la **raíz** del repositorio para consultar código funcional.
> * **Carpeta de Examen:** Realice todos sus cambios exclusivamente dentro de la carpeta `evaluacion/ejemploBd`. Abra el archivo `.sln` ubicado dentro de esta última.

Su examen consiste en completar la **Gestión de Módulos y Preguntas** dentro de la carpeta `evaluacion`.

---

************************************************************************************************************************************************************************************************************************************************************************************************

### FASE 1: Base de Datos (Módulos)

1. **Tablas:** Asegúrese de tener creadas las tablas `modulo` y `pregunta` (ver scripts en `README.md`).
2. **Datos:** Inserte manualmente en phpMyAdmin los 4 módulos: *Architecture, Anthropology, Calculus, Sports*.
3. **Análisis de Integridad:** En el script SQL, la relación tiene la instrucción `ON DELETE CASCADE`. ¿Qué sucede con las preguntas asociadas si eliminamos un módulo de la tabla `modulo`?
* *R:* (ON DELETE CASCADE): R: Si eliminamos un registro de la tabla modulo, la base de datos eliminará automáticamente todas las filas en la tabla pregunta que estén en ese módulo. Esto evita que queden "sin lugar" datos que apuntan a un módulo que ya no existe.

4. **Tipos de Datos:** ¿Por qué es obligatorio que el campo `id_modulo` (en `pregunta`) tenga el mismo tipo de dato que el `id` (en `modulo`) para que la relación funcione?

* *R:* R: Es obligatorio porque la base de datos compara estos campos para vincularlos y crear índices. Si los tipos o tamaños no son los mismos el motor bloqueara la llave foranea porq no garantiza la integridad de los datos.

---

************************************************************************************************************************************************************************************************************************************************************************************************

### FASE 2: Gestión de Módulos (Incompleto)

1. **Conexión:** En `GestionModulos.cs`, la instancia de conexión debe configurarse. **Tome como referencia el MainForm.cs del ejemplo.**
2. **Consulta SQL:** Complete el `SELECT` en `CargarModulos` para mostrar `id`, `nombre_es` y `nombre_en`.
3. **Carga:** Programe la línea que usa el `adaptador` para llenar el `DataTable` y mostrar los datos en la grilla.

---

### FASE 3: Paso de Parámetros (El Reto)

1. **Del Padre al Hijo:** En `GestionModulos.cs`, al hacer clic en el botón para ver preguntas, debe capturar el `id` del módulo seleccionado en el DataGridView.
2. **El Constructor:** En `GestionPreguntas.cs`, complete el constructor para que reciba ese `id` y lo asigne a la variable interna de la clase.
3. **El Filtro:** En la consulta SQL de la ventana de preguntas, use el `id` recibido (cláusula `WHERE`) para que **solo** se muestren las preguntas del módulo seleccionado.

---

************************************************************************************************************************************************************************************************************************************************************************************************

### FASE 4: Preguntas Teóricas

1. **Lógica:** Si al abrir la ventana de preguntas estas aparecen vacías para todos los módulos (pero no hay errores de código), ¿qué objeto revisaría primero: la `Conexion` o la consulta `SQL`? Justifique.
* *R:*  la consulta SQL. Si el problema fuera la Conexion, el programa arrojaría una excepción al intentar abrirlo, me paso haciendo el trabajo se me olvidoi activar el servidor local por lo cual arroja error instantaneamente . Si la ventana se abre normalmente pero sin datos, significa que la conexión fue exitosa en teoria, pero la consulta select no devolvió ningún registro puede ser mala nomenclatura o errores al hacer el select.


2. **Encapsulamiento:** ¿Cuál es la ventaja de recibir el ID mediante el **Constructor** y guardarlo en una variable `private`, en lugar de simplemente declarar una variable `public` que cualquiera pueda modificar?

La ventaja es la seguridad y el control. Al recibirlo por el constructor y guardarlo como private,el formulario de preguntas nace con ese ID y que ninguna otra parte externa del programa pueda modificarlo accidentalmente durante su ejecución, asegurando que siempre muestre los datos


**************************************************************************************************************************************************************************************************************************************************************************************************************************************************
---

### ENTREGA (Pull Request)

Para finalizar la evaluación, el **Estudiante A** (el dueño del Fork) debe realizar el **Pull Request** hacia el repositorio original del profesor.

### Resumen de comandos sugeridos

> **Guía rápida de consola para el Laboratorio:**
> 1. `git add .`
> 2. `git commit -m "Solución Laboratorio - Apellido1 y Apellido2"`
> 3. `git push origin evaluacion-lab`
> 
> 

**⚠️ IMPORTANTE:** No intente subir las carpetas `bin` ni `obj`. El archivo `.gitignore` ya está configurado para mantener el repositorio limpio.

---
