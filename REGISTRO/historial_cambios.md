# Bitácora de Modificaciones - Arquitectura Frontend

## Fecha: 2026-09-23

### Reestructuración Crítica: Separación de Backend Minimal API y Frontend MVC (Rollback)
Se realizó una separación estricta y física de responsabilidades para respetar los requisitos de sistemas distribuidos, deshaciendo la unificación errónea previa:
- **Backend (Minimal API)**: Se limpió de cualquier artefacto MVC (`Controllers`, `Views`, `wwwroot`). El `Program.cs` se restauró para servir EXCLUSIVAMENTE endpoints puros, Sockets y OpenAPI.
- **FrontendWeb (MVC)**: Se creó un nuevo proyecto ASP.NET Core MVC completamente aislado. A este proyecto se trasladaron los `Controllers` (HomeController), la capa de presentación (`Views`) y estáticos (`wwwroot`, `bundleconfig.json`).
- **Shared (Biblioteca de Clases)**: Además de mantener las Entidades/Dominio (Pedido, ItemPedido), se movieron aquí las carpetas `Services` y `Repositories`. Sus namespaces fueron actualizados a `Shared.Services` y `Shared.Repositories`. De esta manera, tanto el FrontendWeb (para las Vistas) como el Backend (para Endpoints) pueden referenciar e inyectar esta lógica de negocio sin mezclarse entre sí.
- Todos los proyectos compilan correctamente y respetan la arquitectura orientada a servicios.

## Fecha: 2026-09-09

### Refactorización de CSS (Modularización)
El archivo monolítico `landing.css` (de aprox. 800 líneas) fue diseccionado y dividido en los siguientes módulos lógicos para mejorar el mantenimiento y escalabilidad:

- **`variables.css`**: Archivo base con Google Fonts, variables CSS (`:root`), colores, sombras y el *reset* global responsivo.
- **`layout.css`**: Estructura principal (`.pizza-landing-container`), grid del pie de página y media queries globales.
- **`botones.css`**: Componentes de *Call To Action* (`.btn-cta-giant`, `.btn-secondary-custom`) y sus animaciones.
- **`hero.css`**: Aislamiento de la sección superior (Hero), degradados, ilustraciones, insignias flotantes y keyframes de animación.
- **`features.css`**: Componentes de tarjetas de características, banner promocional oscuro y tarjetas miniatura.
- **`landing.css`**: Se refactorizó para funcionar exclusivamente como el *entry point* (punto de entrada) que utiliza `@import` para ensamblar todos los módulos anteriores. No se requirió modificar el HTML.

### Gestión de Recursos
- **Directorio de Imágenes**: Se estipuló la creación y uso obligatorio del directorio `wwwroot/images/ia/` para alojar cualquier recurso gráfico nuevo o generado por IA, garantizando un control estricto de los activos.
