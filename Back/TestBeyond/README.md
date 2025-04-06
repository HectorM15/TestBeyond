# TestBeyond API

Este proyecto representa la parte back-end del sistema TodoList. Está construido con **.NET 8**


---

## 📦 Proyectos incluidos

- `TestBeyond.Domain`: lógica de negocio y entidades del dominio
- `TestBeyond.Infrastructure`: implementación en memoria del repositorio
- `TestBeyond.API`: API RESTful para gestionar TodoItems y progresos
- `TestBeyond.Console`: demo en consola
- `TestBeyond.Tests`: pruebas unitarias con xUnit

---

## 🚀 Cómo ejecutar

Desde Visual Studio o terminal:

```bash
dotnet run --project TestBeyond.API
```

Por defecto, se expone en:

```
https://localhost:44367
```

---

## 🛠 Endpoints principales

- `GET /api/todolist`
- `POST /api/todolist`
- `POST /api/todolist/{id}/progression`
- `PUT /api/todolist/{id}`
- `DELETE /api/todolist/{id}`

---

## ✅ Requisitos funcionales

- No se puede eliminar/modificar una tarea con más del 50% completado
- El progreso total no puede superar el 100%
- Las fechas deben ir en orden creciente

---

## 🧪 Tests

Para ejecutar los tests unitarios:

```bash
dotnet test
```

---

## 🧠 Autor

Héctor Mediero – GitHub: [@HectorM15](https://github.com/HectorM15)
