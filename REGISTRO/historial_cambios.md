# Bitácora de Modificaciones - Arquitectura Frontend

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
