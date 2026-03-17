// ============================================================
//   🍕 Bella Napoli — Simulador de Pedidos
//   Lógica de Programación | Aplicación de Consola C#
// ============================================================

using System;

class Program
{
    static void Main(string[] args)
    {
        // ── Ingredientes base (siempre incluidos) ──
        string[] base_ingredientes = { "Tomate", "Mozzarella" };

        // ── Ingredientes adicionales por tipo ──
        string[] ingredientesVegetarianos    = { "Pimiento 🫑", "Tofu 🧊" };
        string[] ingredientesNoVegetarianos  = { "Peperoni 🍕", "Jamón 🍖", "Salmón 🐟" };

        // ─────────────────────────────────────────
        //  Bienvenida
        // ─────────────────────────────────────────
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║   🍕  Bienvenido a Bella Napoli      ║");
        Console.WriteLine("║   Crea tu pizza personalizada        ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.ResetColor();

        // ─────────────────────────────────────────
        //  Paso 1: ¿Vegetariana o no?
        // ─────────────────────────────────────────
        Console.WriteLine();
        Console.WriteLine("  ¿Qué tipo de pizza deseas?");
        Console.WriteLine("    1. Vegetariana 🥦");
        Console.WriteLine("    2. No vegetariana 🍖");
        Console.Write("\n  Elige una opción (1 o 2): ");

        string entradaTipo = Console.ReadLine()!.Trim();

        // Validar que sea 1 o 2
        while (entradaTipo != "1" && entradaTipo != "2")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  Opción inválida. Elige 1 o 2: ");
            Console.ResetColor();
            entradaTipo = Console.ReadLine()!.Trim();
        }

        bool esVegetariana = entradaTipo == "1";
        string tipoPizza   = esVegetariana ? "Vegetariana" : "No Vegetariana";

        // ─────────────────────────────────────────
        //  Paso 2: Menú dinámico según tipo
        // ─────────────────────────────────────────
        string[] opcionesAdicionales = esVegetariana
            ? ingredientesVegetarianos
            : ingredientesNoVegetarianos;

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"  Ingredientes adicionales para pizza {tipoPizza}:");
        Console.ResetColor();

        for (int i = 0; i < opcionesAdicionales.Length; i++)
            Console.WriteLine($"    {i + 1}. {opcionesAdicionales[i]}");

        // ─────────────────────────────────────────
        //  Paso 3: Elegir UN ingrediente adicional
        // ─────────────────────────────────────────
        Console.Write("\n  Elige tu ingrediente adicional (número): ");
        string entradaIngrediente = Console.ReadLine()!.Trim();

        int indiceElegido;
        bool esValido = int.TryParse(entradaIngrediente, out indiceElegido)
                        && indiceElegido >= 1
                        && indiceElegido <= opcionesAdicionales.Length;

        while (!esValido)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"  Opción inválida. Elige entre 1 y {opcionesAdicionales.Length}: ");
            Console.ResetColor();
            entradaIngrediente = Console.ReadLine()!.Trim();
            esValido = int.TryParse(entradaIngrediente, out indiceElegido)
                       && indiceElegido >= 1
                       && indiceElegido <= opcionesAdicionales.Length;
        }

        string ingredienteElegido = opcionesAdicionales[indiceElegido - 1];

        // ─────────────────────────────────────────
        //  Paso 4: Resumen final
        // ─────────────────────────────────────────
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("  ╔══════════════════════════════════════╗");
        Console.WriteLine("  ║        🍕  TU PEDIDO                 ║");
        Console.WriteLine("  ╠══════════════════════════════════════╣");
        Console.ResetColor();

        Console.WriteLine($"  ║  Tipo de pizza : {tipoPizza,-22}║");
        Console.WriteLine($"  ║  Ingredientes  :                     ║");

        // Imprimir ingredientes base
        for (int i = 0; i < base_ingredientes.Length; i++)
            Console.WriteLine($"  ║    • {base_ingredientes[i],-34}║");

        // Imprimir ingrediente adicional elegido
        Console.WriteLine($"  ║    • {ingredienteElegido,-34}║");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("  ╚══════════════════════════════════════╝");
        Console.ResetColor();

        // Salida en el formato exacto del enunciado
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"  Tipo de pizza: {tipoPizza}");
        Console.Write("  Ingredientes: ");
        Console.Write(string.Join(", ", base_ingredientes));
        Console.WriteLine($", {ingredienteElegido}.");
        Console.ResetColor();
    }
}
