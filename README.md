# Proyecto de Computación Gráfica - Implementación de Algoritmos

## Introducción

Este proyecto consiste en el desarrollo de una aplicación de escritorio implementada en C# utilizando Windows Forms, orientada al estudio y visualización de algoritmos fundamentales de Computación Gráfica. La aplicación permite representar gráficamente diferentes técnicas empleadas en la generación de primitivas geométricas, curvas, circunferencias, algoritmos de relleno y algoritmos de recorte, proporcionando además una visualización detallada de los pasos internos ejecutados por cada método.

El objetivo principal del proyecto es analizar el comportamiento matemático y computacional de los algoritmos clásicos utilizados en sistemas gráficos bidimensionales, permitiendo observar tanto el resultado visual como los cálculos intermedios que intervienen en la construcción de figuras y regiones dentro de un plano cartesiano.

## Algoritmos Implementados

### Generación de Líneas

**DDA (Digital Differential Analyzer)**

Implementación del algoritmo incremental para el trazado de líneas rectas mediante cálculos sucesivos de incrementos en los ejes X y Y, permitiendo aproximar una línea continua utilizando coordenadas discretas.

**Punto Medio (Midpoint Line Algorithm)**

Algoritmo basado en un parámetro de decisión que determina el siguiente píxel a seleccionar utilizando únicamente operaciones enteras, reduciendo el costo computacional respecto a métodos basados en cálculos de pendiente.

### Curvas

**Curva de Bézier Cuadrática**

Implementación de curvas paramétricas generadas a partir de puntos de control, utilizando las ecuaciones de Bézier para obtener trayectorias suaves ampliamente utilizadas en diseño gráfico, modelado y animación.

### Generación de Circunferencias

**Método Base**

Construcción de circunferencias utilizando la ecuación analítica del círculo y el aprovechamiento de sus propiedades de simetría para generar todos los puntos de la figura.

**Método Polar**

Generación de circunferencias mediante coordenadas polares, calculando los puntos a partir de funciones trigonométricas dependientes del ángulo de rotación.

**Método de Rotación por Matriz**

Construcción de circunferencias utilizando transformaciones geométricas basadas en matrices de rotación, generando nuevos puntos mediante multiplicación matricial sucesiva.

### Algoritmos de Relleno

**Flood Fill**

Técnica de propagación recursiva o iterativa que rellena una región conectada a partir de un punto semilla hasta encontrar cambios de color o límites definidos.

**Boundary Fill**

Algoritmo de relleno que expande una región hasta alcanzar un color de frontera previamente establecido, permitiendo delimitar áreas cerradas dentro del espacio gráfico.

**Scan Line Fill**

Método de relleno de polígonos basado en el recorrido horizontal de líneas de exploración (scanlines), calculando intersecciones con los bordes del polígono para determinar las zonas que deben colorearse.

### Algoritmos de Recorte

**Cohen-Sutherland**

Algoritmo clásico de recorte de líneas que utiliza códigos de región para determinar de forma eficiente si un segmento debe aceptarse, rechazarse o recortarse parcialmente respecto a una ventana rectangular.

**Liang-Barsky**

Método paramétrico de recorte que utiliza las ecuaciones de la línea para calcular directamente los puntos de intersección con la ventana de recorte, reduciendo el número de operaciones necesarias.

**Nicholl-Lee-Nicholl**

Algoritmo optimizado de recorte de líneas que clasifica la posición del punto inicial respecto a la ventana y reduce significativamente la cantidad de intersecciones calculadas, mejorando la eficiencia en comparación con otros métodos clásicos.

## Objetivo Académico

La implementación de estos algoritmos permite comprender los fundamentos matemáticos de la computación gráfica bidimensional, analizar técnicas de rasterización, estudiar métodos de optimización gráfica y comparar diferentes enfoques utilizados para la representación y procesamiento de objetos geométricos dentro de sistemas computacionales.
