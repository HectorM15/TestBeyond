# TodoList App – Frontend

Este es el cliente **frontend** de la prueba técnica para Beyond Hospitality, desarrollado con **React 18**, **Vite** y **Tailwind CSS**.  
Se conecta con la API en `.NET 8` mediante Axios para gestionar tareas (`TodoItems`) y su progreso (`Progressions`).

---

## ✅ Funcionalidades

- Crear nuevas tareas con título, descripción y categoría.
- Registrar progresos por fecha y porcentaje.
- Visualizar tareas ordenadas por ID.
- Mostrar porcentaje acumulado por tarea.
- Visualizar barras de progreso animadas con CSS.
- Toda la información se actualiza sin recargar la pantalla.

---

## 🚀 Instalación

1. Asegúrate de tener instalado Node.js 18+  
   [Descargar desde nodejs.org](https://nodejs.org)

2. Clona el repositorio principal y accede a la carpeta del cliente:

```bash
git clone https://github.com/HectorM15/TestBeyond.git
cd TestBeyond/todolist-client
```

3. Instala dependencias:

```bash
npm install
```

4. Ejecuta la aplicación:

```bash
npm run dev
```

Por defecto se abrirá en `http://localhost:5173`

---

## ⚙️ Configuración de la API

Edita el archivo `src/config.json` si tu backend no está en `https://localhost:44367`:

```json
{
  "apiBaseUrl": "https://localhost:44367"
}
```

---

## 🖼️ Vista del resultado

```
1) Tarea 1 - Descripción (Work) Completed:True
10/12/2025 - 20%
[ Barra visual 20]
11/12/2025 - 70%
[ Barra visual  90]
```

---

## 🧪 Tecnologías utilizadas

- ⚛️ React 18 + Vite
- 💨 Tailwind CSS
- 🌐 Axios
- 🔁 Comunicación REST con API .NET
- 🧠 Arquitectura modular por componentes

---

## 🧠 Autor

**Héctor Mediero**  
GitHub: [@HectorM15](https://github.com/HectorM15)

