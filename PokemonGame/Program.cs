using System;

public interface IPokemon
{
    string Nombre { get; }
    string Tipo { get; }
    int Salud { get; set; }
    int[] Ataques { get; }
    int[] Defensas { get; }
    int AtacarPokemon();
    int DefenderPokemon();
}

public class Pokemon : IPokemon
{
    private string nombre;
    private string tipo;
    private int salud;
    private int[] ataques;
    private int[] defensas;

    public Pokemon(string nombre, string tipo, int salud, int[] ataques, int[] defensas)
    {
        this.nombre = nombre;
        this.tipo = tipo;
        this.salud = salud;
        this.ataques = ataques;
        this.defensas = defensas;
    }

    public string Nombre
    {
        get { return this.nombre; }
    }

    public string Tipo
    {
        get { return this.tipo; }
    }

    public int Salud
    {
        get { return this.salud; }
        set { this.salud = value; }
    }

    public int[] Ataques
    {
        get { return this.ataques; }
    }

    public int[] Defensas
    {
        get { return this.defensas; }
    }

    public int AtacarPokemon()
    {
        Random rand = new Random();
        int indiceAtaque = rand.Next(0, 3);
        int valorAtaque = this.ataques[indiceAtaque];
        double multiplier = rand.NextDouble() <= 0.5 ? 0 : rand.NextDouble() <= 0.5 ? 1 : 1.5;
        return (int)(valorAtaque * multiplier);
    }

    public int DefenderPokemon()
    {
        Random rand = new Random();
        int indiceDefensa = rand.Next(0, 2);
        int valorDefensa = this.defensas[indiceDefensa];
        double multiplier = rand.NextDouble() <= 0.5 ? 0.5 : 1;
        return (int)(valorDefensa * multiplier);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese los datos del Pokémon 1:");
        Console.Write("Nombre: ");
        string nombre1 = Console.ReadLine();
        Console.Write("Tipo: ");
        string tipo1 = Console.ReadLine();
        Console.Write("Salud: ");
        int salud1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese los 3 ataques del Pokémon 1:");
        int[] ataques1 = new int[3];
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Ataque {i + 1}: ");
            ataques1[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Ingrese las 2 defensas del Pokémon 1:");
        int[] defensas1 = new int[2];
        for (int i = 0; i < 2; i++)
        {
            Console.Write($"Defensa {i + 1}: ");
            defensas1[i] = int.Parse(Console.ReadLine());
        }
        IPokemon pokemon1 = new Pokemon(nombre1, tipo1, salud1, ataques1, defensas1);

        Console.WriteLine("Ingrese los datos del Pokémon 2:");
        Console.Write("Nombre: ");
        string nombre2 = Console.ReadLine();
        Console.Write("Tipo: ");
        string tipo2 = Console.ReadLine();
        Console.Write("Salud: ");
        int salud2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese los 3 ataques del Pokémon 2:");
        int[] ataques2 = new int[3];
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Ataque {i + 1}: ");
            ataques2[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Ingrese las 2 defensas del Pokémon 2:");
        int[] defensas2 = new int[2];
        for (int i = 0; i < 2; i++)
        {
            Console.Write($"Defensa {i + 1}: ");
            defensas2[i] = int.Parse(Console.ReadLine());
        }
        IPokemon pokemon2 = new Pokemon(nombre2, tipo2, salud2, ataques2, defensas2);

        Console.WriteLine("¡Comienza el combate!");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Turno {i + 1}:");

            int ataque1 = pokemon1.AtacarPokemon();
            int defensa2 = pokemon2.DefenderPokemon();
            Console.WriteLine($"{pokemon1.Nombre} ataca con {ataque1} de daño.");
            if (ataque1 > defensa2)
            {
                int danio = ataque1 - defensa2;
                pokemon2.Salud -= danio;
                Console.WriteLine($"{pokemon2.Nombre} recibe {danio} de daño. Ahora tiene {pokemon2.Salud} de salud.");
            }
            else
            {
                Console.WriteLine($"{pokemon2.Nombre} se defiende exitosamente.");
            }

            int ataque2 = pokemon2.AtacarPokemon();
            int defensa1 = pokemon1.DefenderPokemon();
            Console.WriteLine($"{pokemon2.Nombre} ataca con {ataque2} de daño.");
            if (ataque2 > defensa1)
            {
                int danio = ataque2 - defensa1;
                pokemon1.Salud -= danio;
                Console.WriteLine($"{pokemon1.Nombre} recibe {danio} de daño. Ahora tiene {pokemon1.Salud} de salud.");
            }
            else
            {
                Console.WriteLine($"{pokemon1.Nombre} se defiende exitosamente.");
            }
        }

        if (pokemon1.Salud > pokemon2.Salud)
        {
            Console.WriteLine($"¡{pokemon1.Nombre} ha ganado el combate!");
        }
        else if (pokemon1.Salud < pokemon2.Salud)
        {
            Console.WriteLine($"¡{pokemon2.Nombre} ha ganado el combate!");
        }
        else
        {
            Console.WriteLine("¡El combate ha terminado en empate!");
        }
    }
}