# 📜 Historial de Cambios y Trabajo Realizado

Este documento registra de forma cronológica todas las tareas, componentes desarrollados y decisiones arquitectónicas implementadas en el proyecto **PSR-MinimalAPI**.

---

## 📅 Sesión de Trabajo - Desarrollo e Integración de Landing Page & MVC

### 1. Diseño y Desarrollo de la Vista Razor (`Index.cshtml`)
* **Ubicación final**: `Backend/Views/Home/Index.cshtml`
* **Lo realizado**:
  * Se construyó la estructura HTML responsiva adaptada para la sintaxis C# Razor.
  * Se implementaron **ASP.NET Core Tag Helpers** (`asp-controller`, `asp-action`) para todos los enlaces y botones de navegación en sustitución del atributo `href` clásico.
  * Se diseñó la **Sección Hero** con el título principal *"Las mejores pizzas artesanales, directas a tu casa"*, subtítulo persuasivo, métricas de confianza, badges flotantes e ilustración SVG vectorial.
  * Se creó la **Sección de Destacados (Features)** con tres tarjetas responsivas: *"Ingredientes Frescos"*, *"Horno de Barro"* y *"Delivery Veloz"*, acompañadas de iconos vectoriales SVG.
  * Se incorporó la **Sección de Menú Destacado** y el **Footer Básico** con información de contacto, horarios y redes sociales.

---

### 2. Creación del Sistema de Estilos (`landing.css`)
* **Ubicación final**: `Backend/wwwroot/css/landing.css`
* **Lo realizado**:
  * Se implementó una **paleta de colores cálida y artesanal** basada en variables CSS (`:root`): Rojo Terracota (`#D9381E`), Naranja Ámbar (`#E87A1E`), Dorado (`#FFB338`), Carbón de Quebracho (`#1A1412`) y Crema Masa Madre (`#FAF4EE`).
  * Se importaron tipografías desde Google Fonts: `Playfair Display` (para títulos elegantes) y `Plus Jakarta Sans` (para lectura fluida).
  * Se programaron animaciones CSS (`@keyframes`): levitación fluida (`float`), pulso de resplandor (`pulse-glow`), rotación del anillo de luz (`spin-slow`) y destello en botones CTA.
  * Se añadieron reglas de diseño responsivo (*Media Queries*) a `992px` y `640px` para adaptar la interfaz a teléfonos y tablets.

---

### 3. Implementación del Controlador MVC (`HomeController.cs`)
* **Ubicación final**: `Backend/Controllers/HomeController.cs`
* **Lo realizado**:
  * Se creó la clase `HomeController` heredando de `Microsoft.AspNetCore.Mvc.Controller`.
  * Se implementó la acción `Index()` que retorna explícitamente `return View();` para servir la Landing Page.
  * Se inyectó `ILogger<HomeController>` para registro de logs de auditoría al navegar a la página principal.

---

### 4. Creación de la Plantilla Maestra (`_Layout.cshtml`)
* **Ubicación final**: `Backend/Views/Shared/_Layout.cshtml`
* **Lo realizado**:
  * Se definió la estructura base del documento HTML con la etiqueta `<head>` enlazando a `~/css/landing.css` mediante `asp-append-version="true"`.
  * Se construyó la barra de navegación superior (Navbar) con enlaces Tag Helpers.
  * Se inyectó la directiva obligatoria `@RenderBody()` para permitir que ASP.NET Core MVC renderice las vistas hijas.

---

### 5. Estructura de Servicios y Repositorios Asíncronos (Patrón Repository + Async)
* **Ubicación de archivos**:
  * `Backend/Repositories/IPedidoRepositoryAsync.cs`
  * `Backend/Repositories/PedidoRepositoryAsync.cs`
  * `Backend/Services/IPedidoService.cs`
  * `Backend/Services/PedidoService.cs`
* **Lo realizado**:
  * Se diseñaron las interfaces e implementaciones para el acceso a datos asíncrono (`Task<T>`) mediante el **Patrón Repository**.
  * Se creó la Capa de Servicios de Negocio `PedidoService` para desacoplar las reglas de validación y cálculo de pedidos del repositorio y de los controladores.

---

### 6. Configuración e Inyección de Dependencias (`Backend/Program.cs`)
* **Ubicación final**: `Backend/Program.cs`
* **Lo realizado**:
  * Se registró el servicio de controladores y vistas MVC: `builder.Services.AddControllersWithViews();`.
  * Se inyectaron las interfaces asíncronas en el contenedor de dependencias IoC: `IPedidoRepositoryAsync` y `IPedidoService`.
  * Se habilitó el middleware de archivos estáticos: `app.UseStaticFiles();`.
  * Se configuró el ruteo predeterminado MVC: `app.MapDefaultControllerRoute();` para apuntar por defecto a `Home/Index`.

---

### 7. Reorganización de Archivos dentro del Proyecto `Backend/`
* **Lo realizado**:
  * Se movieron y unificaron las carpetas `Controllers/`, `Views/` y `wwwroot/` directamente dentro del directorio ejecutable `Backend/` para asegurar que el motor Razor de ASP.NET Core localice nativamente las vistas y recursos estáticos sin errores de ruta.

---

## 📅 Sesión de Trabajo - Requisitos de Evaluación del 3er Bimestre

### 8. Implementación Estricta N-Capas y Asincronismo (`async`/`await`)
* **Ubicación de archivos**:
  * `Backend/Repositories/IPedidoRepositoryAsync.cs` & `PedidoRepositoryAsync.cs`
  * `Backend/Services/IPedidoService.cs` & `PedidoService.cs`
  * `Backend/Controllers/HomeController.cs` & `Controllers/HomeController.cs`
  * `Backend/Endpoints/PedidoEndpoints.cs`
* **Lo realizado**:
  * Se garantizó el desacoplamiento total N-Capas: Controlador -> Servicio (`IPedidoService`) -> Repositorio (`IPedidoRepositoryAsync`) -> Entidades de Dominio.
  * Todas las operaciones de negocio y consulta de datos fueron convertidas a métodos asíncronos retornando `Task<T>`.
  * Se refactorizó `HomeController` para inyectar únicamente `IPedidoService` por constructor y servir las vistas utilizando `async Task<IActionResult>`.

### 9. Implementación de Bundling y Minificación (`bundleconfig.json`)
* **Ubicación de archivos**:
  * `bundleconfig.json` (Raíz y `Backend/`)
  * `wwwroot/css/bundle.min.css` (Raíz y `Backend/`)
  * `Views/Shared/_Layout.cshtml` (Raíz y `Backend/`)
* **Lo realizado**:
  * Se configuró `bundleconfig.json` para unificar y minificar los 5 archivos CSS divididos (`variables.css`, `layout.css`, `botones.css`, `hero.css`, `features.css`).
  * Se generó `bundle.min.css` optimizando el tiempo de carga del sitio.
  * Se actualizó `_Layout.cshtml` con `<link rel="stylesheet" href="~/css/bundle.min.css" asp-append-version="true" />`.

