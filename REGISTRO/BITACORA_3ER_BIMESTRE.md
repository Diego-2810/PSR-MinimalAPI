# 📑 Bitácora de Desarrollo - Requisitos Académicos del 3er Bimestre

**Proyecto:** PSR-MinimalAPI (Pizzería Artesanal)  
**Rol:** Arquitecto de Software & Desarrollador Backend Senior ASP.NET Core MVC  
**Fecha de Registro:** 11 de Septiembre de 2026  

---

## 🎯 Objetivo General
Cumplir de manera estricta y transparente con los requisitos innegociables exigidos en la evaluación del 3er bimestre:
1. Arquitectura N-Capas con interfaces y servicios asíncronos (`IPedidoService`, `PedidoService`, `IPedidoRepositoryAsync`, `PedidoRepositoryAsync`).
2. Programación asíncrona obligatoria (`async` / `await` devolviendo `Task<T>`) en todas las capas de datos, negocio y controladores.
3. Inyección de Dependencias (DI) registrada adecuadamente en `Program.cs`.
4. Integración completa MVC (Controlador -> Servicio -> Repositorio -> Vista con Tag Helpers).
5. Implementación de **Bundling & Minificación** mediante `bundleconfig.json` para archivos CSS modularizados.

---

## 📜 1. Capa de Servicios y Repositorios Asíncronos (Fase 1)

### 1.1 Interfaces Asíncronas
- **`IPedidoRepositoryAsync`** (`Backend/Repositories/IPedidoRepositoryAsync.cs`):
  Define el contrato asíncrono para la persistencia del dominio.
  ```csharp
  public interface IPedidoRepositoryAsync
  {
      Task<Pedido> CrearAsync(Pedido pedido);
      Task<Pedido?> ObtenerPorIdAsync(int id);
      Task<IEnumerable<Pedido>> ObtenerTodosAsync();
      Task<bool> ActualizarEstadoAsync(int id, EstadoPedido nuevoEstado);
  }
  ```

- **`IPedidoService`** (`Backend/Services/IPedidoService.cs`):
  Define el contrato de la capa de aplicación/negocio, garantizando el desacoplamiento total entre controladores y repositorios.
  ```csharp
  public interface IPedidoService
  {
      Task<Pedido> RegistrarPedidoAsync(Pedido pedido);
      Task<Pedido?> ConsultarPedidoPorIdAsync(int id);
      Task<IEnumerable<Pedido>> ListarPedidosAsync();
      Task<bool> CambiarEstadoPedidoAsync(int id, EstadoPedido nuevoEstado);
  }
  ```

### 1.2 Implementaciones de Negocio y Datos
- **`SocketServerService`** (`Backend/Sockets/SocketServerService.cs`):
  Refactorizado para inyectar `IPedidoRepositoryAsync` por constructor y utilizar llamadas asíncronas, garantizando que el servicio de segundo plano TCP y la Inyección de Dependencias en `Program.cs` se inicialicen sin conflictos.


### 1.3 Inyección de Dependencias (`Program.cs`)
En `Backend/Program.cs`, se configuró la Inyección de Dependencias utilizando el contenedor nativo IoC de ASP.NET Core:
```csharp
// 3. Registro de repositorios y servicios de negocio de forma 100% asíncrona
builder.Services.AddSingleton<IPedidoRepositoryAsync, PedidoRepositoryAsync>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
```
- `AddSingleton<IPedidoRepositoryAsync, PedidoRepositoryAsync>`: Mantiene la persistencia en memoria durante el ciclo de vida del servidor web.
- `AddScoped<IPedidoService, PedidoService>`: Crea una instancia por cada petición HTTP procesada, asegurando un aislamiento adecuado.

### 1.4 Refactorización de Controlador y Endpoints MVC
- **`HomeController`** (`Backend/Controllers/HomeController.cs` y `Controllers/HomeController.cs`):
  Refactorizado para recibir únicamente `IPedidoService` a través del constructor. Todas sus acciones de vista fueron transformadas a métodos asíncronos `async Task<IActionResult>`:
  ```csharp
  [HttpGet]
  public async Task<IActionResult> Index()
  {
      _logger.LogInformation("Navegando a la Landing Page principal de la Pizzería PSR.");
      var pedidos = await _pedidoService.ListarPedidosAsync();
      return View(pedidos);
  }
  ```
- **`PedidoEndpoints`** (`Backend/Endpoints/PedidoEndpoints.cs`):
  Convertido para invocar de forma asíncrona a `IPedidoService` en las rutas de la Minimal API `/api/pedidos`.

---

## 📦 2. Implementación de Bundling y Minificación (Fase 2)

### 2.1 Configuración de `bundleconfig.json`
Se creó el archivo `bundleconfig.json` tanto en la raíz del proyecto como en la carpeta `Backend/`, configurado para tomar los archivos CSS divididos de la carpeta `wwwroot/css/`:
- `variables.css` (definición de variables CSS, colores y fuentes)
- `layout.css` (grillas responsivas y footer)
- `botones.css` (botones CTA animados)
- `hero.css` (sección principal y animaciones vectoriales)
- `features.css` (tarjetas de pilares e inventario promocional)

**Contenido exacto de `bundleconfig.json`:**
```json
[
  {
    "outputFileName": "wwwroot/css/bundle.min.css",
    "inputFiles": [
      "wwwroot/css/variables.css",
      "wwwroot/css/layout.css",
      "wwwroot/css/botones.css",
      "wwwroot/css/hero.css",
      "wwwroot/css/features.css"
    ],
    "minify": {
      "enabled": true,
      "lowerCamelCase": false
    }
  }
]
```

### 2.2 Generación del Bundle CSS Minificado (`bundle.min.css`)
Se unificaron y minificaron los 5 módulos CSS en `wwwroot/css/bundle.min.css`, eliminando comentarios, espacios innecesarios y redundancias de sintaxis.

### 2.3 Actualización de Plantilla Maestra (`_Layout.cshtml`)
En `Views/Shared/_Layout.cshtml`, se actualizó el elemento `<link>` para apuntar exclusivamente al bundle minificado, incluyendo el Tag Helper `asp-append-version="true"` para la invalidación de caché por hash:
```html
<!-- Hoja de estilos unificada y minificada (Agrupamiento con bundleconfig.json) -->
<link rel="stylesheet" href="~/css/bundle.min.css" asp-append-version="true" />
```

---

## ⚡ 3. Impacto en Rendimiento y Arquitectura del Sistema

### 3.1 Beneficios Arquitectónicos (Patrón N-Capas y Principios SOLID)
- **Desacoplamiento Estricto (Inversión de Dependencias - DIP)**: El controlador no sabe cómo ni dónde se guardan los datos (memoria, SQL, MongoDB); solo depende de la abstracción `IPedidoService`.
- **Mantenibilidad y Testabilidad**: Es posible probar unitariamente el controlador simulando `IPedidoService` con Mocks/Stubs sin necesidad de acceder a la base de datos o repositorios reales.
- **Transiciones de Estado Seguras**: Las entidades del dominio (`Pedido`, `ItemPedido`, `EstadoPedido`) encapsulan la lógica de cambio de estado (`IniciarPreparacion()`, `MarcarComoListo()`, `EnviarAReparto()`, `Entregar()`), impidiendo transiciones inválidas.

### 3.3 Limpieza Arquitectura de Archivos Huérfanos
- **Eliminación de Duplicados**: Se eliminaron las carpetas huérfanas en la raíz (`/Controllers`, `/Views`, `/wwwroot`, `/bundleconfig.json`).
- **Única Fuente de Verdad (Single Source of Truth)**: Todo el código fuente web, controladores, vistas y activos estáticos residen exclusivamente dentro de `Backend/`, eliminando la redundancia y alineándose con los estándares de diseño de ASP.NET Core MVC.

