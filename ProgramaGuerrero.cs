
using System;

class ProgramaGuerrero
{
    static int fuerza = 10, resistencia = 10, energia = 10, experiencia = 0, nivel = 1;
    static bool vivo = true;

    static void Main()
    {
        int opcion;

        do
        {
            Console.WriteLine("\n=== Entrenamiento del Guerrero ===");
            Console.WriteLine("1. Ver estado");
            Console.WriteLine("2. Entrenar fuerza");
            Console.WriteLine("3. Entrenar resistencia");
            Console.WriteLine("4. Pelear");
            Console.WriteLine("5. Descansar");
            Console.WriteLine("6. Salir");
            Console.Write("Elige una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida.");
                continue;
            }

            switch (opcion)
            {
                case 1: VerEstado(); break;
                case 2: EntrenarFuerza(); break;
                case 3: EntrenarResistencia(); break;
                case 4: Pelear(); break;
                case 5: Descansar(); break;
                case 6: Console.WriteLine("Saliendo del juego..."); break;
                default: Console.WriteLine("Opción inválida."); break;
            }

            if (!vivo)
            {
                Console.WriteLine("\nFin del juego. El guerrero ha caído.");
                break;
            }

        } while (opcion != 6);
    }

    static void VerEstado()
    {
        Console.WriteLine("\n--- Estado del Guerrero ---");
        Console.WriteLine($"Nivel: {nivel}");
        Console.WriteLine($"Fuerza: {fuerza}");
        Console.WriteLine($"Resistencia: {resistencia}");
        Console.WriteLine($"Energía: {energia}");
        Console.WriteLine($"Experiencia: {experiencia}");
        Console.WriteLine("---------------------------");
    }

    static void SubirNivel()
    {
        if (experiencia >= 100)
        {
            nivel++;
            experiencia -= 100;
            fuerza += 5;
            resistencia += 5;
            energia = 10;
            Console.WriteLine($"\n¡Felicidades! Has subido al nivel {nivel}!");
        }
    }

    static void EntrenarFuerza()
    {
        int horas = PedirHoras("entrenar fuerza");
        if (horas == -1) return;

        if (energia < horas)
        {
            Console.WriteLine("No tienes suficiente energía para entrenar tanto.");
            return;
        }

        for (int i = 0; i < horas; i++)
        {
            fuerza += 2;
            experiencia += 10;
            energia--;
        }

        Console.WriteLine($"Entrenaste fuerza por {horas} horas.");
        SubirNivel();
    }

    static void EntrenarResistencia()
    {
        int horas = PedirHoras("entrenar resistencia");
        if (horas == -1) return;

        if (energia < horas)
        {
            Console.WriteLine("No tienes suficiente energía para entrenar tanto.");
            return;
        }

        for (int i = 0; i < horas; i++)
        {
            resistencia += 2;
            experiencia += 8;
            energia--;
        }

        Console.WriteLine($"Entrenaste resistencia por {horas} horas.");
        SubirNivel();
    }

    static void Pelear()
    {
        if (energia < 3)
        {
            Console.WriteLine("No tienes suficiente energía para pelear.");
            return;
        }

        Console.WriteLine("\nHas entrado en batalla...");
        energia -= 3;

        if (fuerza + resistencia > 25)
        {
            Console.WriteLine("¡Ganaste la pelea! +30 experiencia.");
            experiencia += 30;
        }
        else
        {
            Console.WriteLine("Perdiste la pelea... pierdes 2 de fuerza.");
            fuerza -= 2;
            if (fuerza <= 0)
            {
                vivo = false;
                Console.WriteLine("Has muerto en batalla.");
            }
        }

        SubirNivel();
    }

    static void Descansar()
    {
        int horas = PedirHoras("descansar");
        if (horas == -1) return;

        energia += horas;
        if (energia > 10) energia = 10;

        Console.WriteLine($"Descansaste {horas} horas y recuperaste energía.");
    }

    static int PedirHoras(string accion)
    {
        Console.Write($"\n¿Cuántas horas quieres {accion}? (1-6): ");
        if (!int.TryParse(Console.ReadLine(), out int horas) || horas < 1 || horas > 6)
        {
            Console.WriteLine("Horas inválidas.");
            return -1;
        }
        return horas;
    }
}
