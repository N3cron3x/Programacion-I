// Patrón de Diseño Creacional Prototype. Permite clonar objetos en lugar de crear nuevas instancias desde cero.
// La clase Prototype define la interfaz de clonación y ConcretePrototype implementa la clonación real.
public abstract class Prototype
{
    public abstract Prototype Clone();
}

public class ConcretePrototype : Prototype
{
    public string Data { get; set; }
    
    public ConcretePrototype(string data)
    {
        Data = data;
    }
    
    public override Prototype Clone()
    {
        return new ConcretePrototype(Data);
    }
}

// Patrón de Diseño Estructural Decorator. Agrega funcionalidad extra a un objeto sin modificar su estructura.

public interface IComponent
{
    void Operation();
}

public class ConcreteComponent : IComponent
{
    public void Operation()
    {
        Console.WriteLine("Operación del componente base");
    }
}

public abstract class Decorator : IComponent
{
    protected IComponent component;
    
    public Decorator(IComponent component)
    {
        this.component = component;
    }
    
    public virtual void Operation()
    {
        component.Operation();
    }
}

public class ConcreteDecorator : Decorator
{
    public ConcreteDecorator(IComponent component) : base(component) { }
    
    public override void Operation()
    {
        base.Operation();
        Console.WriteLine("Operación adicional del decorador");
    }
}

// Patrón de Diseño de Comportamiento Strategy. Permite intercambiar algoritmos de manera dinámica sin afectar el código cliente.

public interface IStrategy
{
    void Execute();
}

public class ConcreteStrategyA : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Estrategia A ejecutada");
    }
}

public class ConcreteStrategyB : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Estrategia B ejecutada");
    }
}

public class Context
{
    private IStrategy strategy = new ConcreteStrategyA(); // Se inicializa con un valor predeterminado
    
    public Context() { }
    
    public Context(IStrategy strategy)
    {
        this.strategy = strategy;
    }
    
    public void SetStrategy(IStrategy strategy)
    {
        this.strategy = strategy;
    }
    
    public void ExecuteStrategy()
    {
        strategy.Execute();
    }
}

// Implementación en la función Main para probar los patrones de diseño.

class Program
{
    static void Main()
    {
        // Prototype
        Console.WriteLine("--- Prototype ---");
        ConcretePrototype prototype = new ConcretePrototype("Dato original");
        ConcretePrototype clone = (ConcretePrototype)prototype.Clone();
        Console.WriteLine("Clon: " + clone.Data);
        
        // Decorator
        Console.WriteLine("--- Decorator ---");
        IComponent component = new ConcreteComponent();
        IComponent decoratedComponent = new ConcreteDecorator(component);
        decoratedComponent.Operation();
        
        // Strategy
        Console.WriteLine("--- Strategy ---");
        Context context = new Context();
        context.ExecuteStrategy();
        context.SetStrategy(new ConcreteStrategyB());
        context.ExecuteStrategy();
    }
}
