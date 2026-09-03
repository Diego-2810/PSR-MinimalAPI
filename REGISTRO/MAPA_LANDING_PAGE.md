# 🗺️ Mapa Estructural de la Landing Page

Este documento especifica exactamente dónde se encuentra ubicado cada elemento visual y de contenido de la Landing Page en el código del proyecto.

---

## 📂 Archivos Principales de la Landing Page

1. **Vista de Contenido**: `Backend/Views/Home/Index.cshtml`
2. **Plantilla Maestra (Layout)**: `Backend/Views/Shared/_Layout.cshtml`
3. **Hoja de Estilos CSS**: `Backend/wwwroot/css/landing.css`

---

## 🎯 Ubicación de Componentes y Elementos Visuales

### 1. Encabezado / Menú de Navegación (Navbar)
* **Ubicación en Código**: `Backend/Views/Shared/_Layout.cshtml` (Líneas `<header>` y `<nav>`)
* **Elementos incluidos**:
  * **Logo & Nombre (`🍕 Pizzería PSR`)**: Enlace con Tag Helper `asp-controller="Home" asp-action="Index"`.
  * **Enlace "Inicio"**: `<a asp-controller="Home" asp-action="Index">`.
  * **Enlace "Menú"**: `<a asp-controller="Menu" asp-action="Index">`.
  * **Enlace "Seguimiento"**: `<a asp-controller="Pedido" asp-action="Seguimiento">`.
  * **Botón "Pedir Ahora 🍕"**: Botón destacado `<a asp-controller="Pedido" asp-action="Crear">`.

---

### 2. Sección Hero (Encabezado Principal a Gran Tamaño)
* **Ubicación en Código**: `Backend/Views/Home/Index.cshtml` (Sección `<section class="hero-section">`)

| Elemento Visual | Código / Etiqueta | Ubicación Exacta |
| :--- | :--- | :--- |
| **Badge "Tradición & Sabor Napolitano"** | `<span class="hero-badge">` | `Index.cshtml` (~Línea 34) |
| **Título Principal** | `<h1 class="hero-title">` | *"Las mejores pizzas artesanales, directas a tu casa"* (`Index.cshtml`) |
| **Texto de Resalte en Título** | `<span class="hero-title-highlight">` | *"directas a tu casa"* con fondo dorado animado |
| **Subtítulo Persuasivo** | `<p class="hero-subtitle">` | *"Masa madre fermentada lentamente durante 48 horas..."* (`Index.cshtml`) |
| **Botón Principal CTA ("Pedir Ahora")** | `<a asp-controller="Pedido" asp-action="Crear" class="btn-cta-giant">` | Botón gigante naranja/rojo con degradado e icono 🍕 |
| **Botón Secundario ("Ver Menú Completo")** | `<a asp-controller="Menu" asp-action="Index" class="btn-secondary-custom">` | Botón con borde delgado y efecto al pasar cursor |
| **Indicadores de Confianza** | `<div class="hero-proof">` | Métricas: *48hs Fermentación*, *450°C Horno*, *★ 4.9/5 (+15.000 clientes)* |
| **Ilustración SVG de la Pizza** | `<svg class="pizza-svg-art">` | Gráfico vectorial artesanal con animación flotante (`float 5s`) |
| **Badge Flotante 1** | `<div class="floating-badge badge-top-left">` | *"100% Masa Madre - Sin aditivos ni conservantes"* |
| **Badge Flotante 2** | `<div class="floating-badge badge-bottom-right">` | *"Llega Caliente - Entrega prom. 25-35 min"* |

---

### 3. Sección de Destacados (Features / Pilares del Negocio)
* **Ubicación en Código**: `Backend/Views/Home/Index.cshtml` (Sección `<section class="features-section">`)

* **Título de la Sección**: *"¿Por qué nuestras pizzas son inigualables?"* (`<h2 class="section-title">`)
* **Tarjeta 1: "Ingredientes Frescos"**:
  * **Icono SVG**: Hoja orgánica verde vectorial (`<svg class="feature-icon-svg">`).
  * **Título & Texto**: `<h3 class="feature-card-title">` + `<p class="feature-card-desc">` (*San Marzano D.O.P., Fior di Latte*).
* **Tarjeta 2: "Horno de Barro"**:
  * **Icono SVG**: Fuego/Llama artesanal vectorial (`<svg class="feature-icon-svg">`).
  * **Título & Texto**: `<h3 class="feature-card-title">` + `<p class="feature-card-desc">` (*Cocción a 450°C en leña de quebracho*).
* **Tarjeta 3: "Delivery Veloz"**:
  * **Icono SVG**: Moto de entregas rápida vectorial (`<svg class="feature-icon-svg">`).
  * **Título & Texto**: `<h3 class="feature-card-title">` + `<p class="feature-card-desc">` (*Bolsas térmicas rígidas, menos de 30 min*).

---

### 4. Sección de Menú Destacado
* **Ubicación en Código**: `Backend/Views/Home/Index.cshtml` (Sección `<section class="promo-banner-section">`)
* **Elementos incluidos**:
  * **Título**: *"Descubrí las pizzas más pedidas de la semana"*.
  * **Tarjetas de Productos (`<div class="mini-pizza-card">`)**:
    1. *Margarita Napolitana* ($8.500)
    2. *Pepperoni Supremo* ($9.800)
    3. *Cuatro Quesos Gourmet* ($10.200)
    4. *Fugazzeta Rellena* ($9.500)

---

### 5. Pie de Página (Footer Básico)
* **Ubicación en Código**: `Backend/Views/Home/Index.cshtml` (Sección `<footer class="pizza-footer">`)
* **Elementos incluidos**:
  * **Columna Branding**: Descripción de la pizzería y botones de Redes Sociales (Instagram, Facebook, WhatsApp).
  * **Columna Navegación**: Enlaces rápidos utilizando Tag Helpers (`asp-controller`, `asp-action`).
  * **Columna Horarios**: Días y horarios de atención al cliente.
  * **Columna Contacto**: Dirección ficticia (*Av. Corrientes 1234, CABA*), Teléfono (`+54 11 4567-8900`) y Correo Electrónico.
  * **Créditos y Copyright**: `© @DateTime.Now.Year Pizzería PSR`.

---

### 6. Estilos Visuales y Personalización (CSS)
* **Ubicación en Código**: `Backend/wwwroot/css/landing.css`

| Concepto Visual | Variable / Regla CSS | Descripción |
| :--- | :--- | :--- |
| **Colores Principales** | `--color-primary: #D9381E;` | Rojo Terracota / Fuego artesanal |
| **Colores Secundarios** | `--color-secondary: #E87A1E;` | Naranja Ámbar / Horno de leña |
| **Color Dorado** | `--color-accent: #FFB338;` | Dorado cálido / Queso fundido |
| **Color Fondo Oscuro** | `--color-dark: #1A1412;` | Carbón de quebracho |
| **Color Fondo Crema** | `--color-cream: #FAF4EE;` | Crema masa madre |
| **Tipografía Títulos** | `--font-heading: 'Playfair Display'` | Fuente Serif elegante para títulos |
| **Tipografía Cuerpo** | `--font-body: 'Plus Jakarta Sans'` | Fuente Sans-Serif moderna para textos |
| **Animación Flotante** | `@keyframes float` | Hace levitar la ilustración de la pizza suavemente |
| **Efecto Botón CTA** | `.btn-cta-giant::before` | Destello de luz brillante al pasar el cursor |
