using System;
using System.Collections.Generic;

public interface IPlayer
{
    string Nombre { get; }
    int Rendimiento { get; }
}

public class Player : IPlayer
{
    private string nombre;
    private int rendimiento;

    public Player(string nombre)
    {
        this.nombre = nombre;
        this.rendimiento = new Random().Next(1, 11);
    }

    public string Nombre
    {
        get { return this.nombre; }
    }

    public int Rendimiento
    {
        get { return this.rendimiento; }
    }
}

public class Team
{
    private string nombre;
    private List<IPlayer> jugadores;
    private int totalRendimiento;

    public Team(string nombre)
    {
        this.nombre = nombre;
        this.jugadores = new List<IPlayer>();
        this.totalRendimiento = 0;
    }

    public string Nombre
    {
        get { return this.nombre; }
    }

    public int TotalRendimiento
    {
        get { return this.totalRendimiento; }
    }

    public void AgregarJugador(IPlayer jugador)
    {
        this.jugadores.Add(jugador);
        this.totalRendimiento += jugador.Rendimiento;
    }

    public void ListarJugadores()
    {
        Console.WriteLine($"Jugadores del equipo {this.Nombre}:");
        foreach (IPlayer jugador in this.jugadores)
        {
            Console.WriteLine($"- {jugador.Nombre} ({jugador.Rendimiento})");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<IPlayer> jugadores = new List<IPlayer>();
        for (int i = 1; i <= 6; i++)
        {
            jugadores.Add(new Player($"Jugador {i}"));
        }

        Team equipo1 = new Team("Equipo 1");
        Team equipo2 = new Team("Equipo 2");

        Console.WriteLine("Seleccionando jugadores para los equipos...");
        Random rand = new Random();
        for (int i = 0; i < 3; i++)
        {
            int indiceJugador = rand.Next(0, jugadores.Count);
            IPlayer jugadorSeleccionado = jugadores[indiceJugador];
            jugadores.RemoveAt(indiceJugador);

            if (i % 2 == 0)
            {
                equipo1.AgregarJugador(jugadorSeleccionado);
            }
            else
            {
                equipo2.AgregarJugador(jugadorSeleccionado);
            }

            Console.WriteLine($"Se ha agregado a {jugadorSeleccionado.Nombre} al {(i % 2 == 0 ? "Equipo 1" : "Equipo 2")}.");
        }

        equipo1.ListarJugadores();
        equipo2.ListarJugadores();

        Console.WriteLine("¡Comienza el partido!");
        if (equipo1.TotalRendimiento > equipo2.TotalRendimiento)
        {
            Console.WriteLine($"¡El {equipo1.Nombre} ha ganado el partido!");
        }
        else if (equipo1.TotalRendimiento < equipo2.TotalRendimiento)
        {
            Console.WriteLine($"¡El {equipo2.Nombre} ha ganado el partido!");
        }
        else
        {
            Console.WriteLine("¡El partido ha terminado en empate!");
        }
    }
}