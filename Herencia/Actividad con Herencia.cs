// Ejemplo 1: Sistema de Gestión de Empleados
public class Empleado {
    public string? Nombre { get; set; }
    public int Edad { get; set; }

    public void MostrarInformacion() {
        Console.WriteLine($"Nombre: {Nombre}, Edad: {Edad}");
    }
}

public class Gerente : Empleado {
    public string? Departamento { get; set; }

    public void MostrarDepartamento() {
        Console.WriteLine($"Departamento: {Departamento}");
    }
}

// Ejemplo 2: Sistema de Notificaciones
public class Notificacion {
    public string? Mensaje { get; set; }

    public void Enviar() {
        Console.WriteLine($"Enviando mensaje: {Mensaje}");
    }
}

public class NotificacionEmail : Notificacion {
    public string? Destinatario { get; set; }

    public void EnviarEmail() {
        Console.WriteLine($"Enviando email a: {Destinatario}");
    }
}

public class NotificacionPrioritaria : NotificacionEmail {
    public void MarcarComoUrgente() {
        Console.WriteLine("¡Notificación marcada como urgente!");
    }
}

// Ejemplo 3: Sistema de Figuras Geométricas
public class Figura {
    public virtual void Dibujar() {
        Console.WriteLine("Dibujando una figura genérica.");
    }
}

public class Circulo : Figura {
    public override void Dibujar() {
        Console.WriteLine("Dibujando un círculo.");
    }
}

public class Rectangulo : Figura {
    public override void Dibujar() {
        Console.WriteLine("Dibujando un rectángulo.");
    }
}

// Ejemplo 4: Sistema de Pagos
public interface IPago {
    void ProcesarPago();
}

public interface IReembolso {
    void ProcesarReembolso();
}

public class Transaccion : IPago, IReembolso {
    public void ProcesarPago() {
        Console.WriteLine("Pago procesado con éxito.");
    }

    public void ProcesarReembolso() {
        Console.WriteLine("Reembolso procesado con éxito.");
    }
}

// Ejemplo 5: Sistema de Gestión de Biblioteca
public class Recurso {
    public string? Titulo { get; set; }
    public int AñoPublicacion { get; set; }

    public void MostrarDetalles() {
        Console.WriteLine($"Título: {Titulo}, Año: {AñoPublicacion}");
    }
}

public class Libro : Recurso {
    public string? Autor { get; set; }

    public void MostrarAutor() {
        Console.WriteLine($"Autor: {Autor}");
    }
}

public class Revista : Recurso {
    public string? Editor { get; set; }

    public void MostrarEditor() {
        Console.WriteLine($"Editor: {Editor}");
    }
}

public class LibroDigital : Libro {
    public string? Formato { get; set; }

    public void MostrarFormato() {
        Console.WriteLine($"Formato: {Formato}");
    }
}

// Programa Principal
class Program {
    static void Main(string[] args) {
        // Sistema de Gestión de Empleados
        Console.WriteLine("=== Ejemplo 1: Sistema de Gestión de Empleados ===");
        Gerente gerente = new Gerente {
            Nombre = "Carlos",
            Edad = 40,
            Departamento = "Ventas"
        };
        gerente.MostrarInformacion();
        gerente.MostrarDepartamento();
        Console.WriteLine();

        // Sistema de Notificaciones
        Console.WriteLine("=== Ejemplo 2: Sistema de Notificaciones ===");
        NotificacionPrioritaria notificacion = new NotificacionPrioritaria {
            Mensaje = "Reunión importante a las 10 AM",
            Destinatario = "juan@example.com"
        };
        notificacion.Enviar();
        notificacion.EnviarEmail();
        notificacion.MarcarComoUrgente();
        Console.WriteLine();

        // Sistema de Figuras Geométricas
        Console.WriteLine("=== Ejemplo 3: Sistema de Figuras Geométricas ===");
        Figura figura1 = new Circulo();
        Figura figura2 = new Rectangulo();
        figura1.Dibujar();
        figura2.Dibujar();
        Console.WriteLine();

        // Sistema de Pagos
        Console.WriteLine("=== Ejemplo 4: Sistema de Pagos ===");
        Transaccion transaccion = new Transaccion();
        transaccion.ProcesarPago();
        transaccion.ProcesarReembolso();
        Console.WriteLine();

        // Sistema de Gestión de Biblioteca
        Console.WriteLine("=== Ejemplo 5: Sistema de Gestión de Biblioteca ===");
        LibroDigital libroDigital = new LibroDigital {
            Titulo = "C# Avanzado",
            AñoPublicacion = 2023,
            Autor = "Ana López",
            Formato = "PDF"
        };
        libroDigital.MostrarDetalles();
        libroDigital.MostrarAutor();
        libroDigital.MostrarFormato();
    }
}