public class Fraciones
{
    public int Numerador { get; private set; }
    public int Denominador { get; private set; }

    public bool IsPropria => Math.Abs(Numerador) < Denominador;
    public bool IsImpropria => Math.Abs(Numerador) >= Denominador;
    public bool IsAparente => Numerador % Denominador == 0;
    public bool IsUnitaria => Math.Abs(Numerador) == 1 && Denominador == 1;

    public Fraciones(int numerador, int denominador)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(denominador, nameof(denominador));
        
        Numerador = numerador;
        Denominador = denominador;
        Simplificar();
    }
    
    public Fraciones(int numerador) : this(numerador, 1) { }

    public Fraciones(string FracionesString)
    {
        var partes = FracionesString.Split('/');
        if (partes.Length != 2)
            throw new ArgumentException("Formato da fração é inválido");
            
        Numerador = int.Parse(partes[0]);
        Denominador = int.Parse(partes[1]);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(Denominador, nameof(Denominador));
        Simplificar();
    }
    
    public Fraciones(double valor)
    {
        Denominador = 1;
        ConverterDoubleParaFraciones(valor);
    }

    public Fraciones Somar(Fraciones outra)
    {
        int novoNumerador = Numerador * outra.Denominador + outra.Numerador * Denominador;
        int novoDenominador = Denominador * outra.Denominador;
        return new Fraciones(novoNumerador, novoDenominador);
    }
    
    public Fraciones Somar(int valor) => Somar(new Fraciones(valor));
    public Fraciones Somar(double valor) => Somar(new Fraciones(valor));
    public Fraciones Somar(string valor) => Somar(new Fraciones(valor));

    public static Fraciones operator +(Fraciones a, Fraciones b) => a.Somar(b);
    public static Fraciones operator +(Fraciones a, int b) => a.Somar(b);
    public static Fraciones operator +(Fraciones a, double b) => a.Somar(b);
    public static Fraciones operator +(Fraciones a, string b) => a.Somar(b);
    
    public static bool operator ==(Fraciones a, Fraciones b)
    {
        if (a is null) return b is null;
        if (b is null) return false;
        return a.Equals(b);
    }
    
    public static bool operator !=(Fraciones a, Fraciones b) => !(a == b);
    
    public static bool operator <(Fraciones a, Fraciones b)
    {
        double valorA = a.Numerador / (double)a.Denominador;
        double valorB = b.Numerador / (double)b.Denominador;
        return valorA < valorB;
    }
    
    public static bool operator >(Fraciones a, Fraciones b) => b < a;
    public static bool operator <=(Fraciones a, Fraciones b) => a < b || a == b;
    public static bool operator >=(Fraciones a, Fraciones b) => a > b || a == b;

    public override string ToString() => $"{Numerador}/{Denominador}";

    public override bool Equals(object obj)
    {
        if (obj is Fraciones outra)
        {
            return Numerador == outra.Numerador && Denominador == outra.Denominador;
        }
        return false;
    }
    
    public override int GetHashCode() => HashCode.Combine(Numerador, Denominador);

    private void Simplificar()
    {
        int mdc = MDC(Math.Abs(Numerador), Math.Abs(Denominador));
        Numerador /= mdc;
        Denominador /= mdc;
        
        if (Denominador < 0)
        {
            Numerador = -Numerador;
            Denominador = -Denominador;
        }
    }
    
    private int MDC(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    private void ConverterDoubleParaFraciones(double valor)
    {
        double epsilon = 1.0E-8;
        double n = Math.Abs(valor);
        int numerador = 1;
        int denominador = 1;
        double Fraciones = numerador / (double)denominador;
        
        while (Math.Abs(Fraciones - n) > epsilon)
        {
            if (Fraciones < n)
            {
                numerador++;
            }
            else
            {
                denominador++;
                numerador = (int)(n * denominador);
            }
            Fraciones = numerador / (double)denominador;
        }
        
        Numerador = valor < 0 ? -numerador : numerador;
        Denominador = denominador;
        Simplificar();
    }
}