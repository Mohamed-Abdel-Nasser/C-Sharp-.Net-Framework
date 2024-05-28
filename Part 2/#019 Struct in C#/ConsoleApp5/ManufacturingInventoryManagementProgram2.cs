using System;

namespace ManufacturingInventoryManagementSystem2
{
    class ManufacturingInventoryManagementProgram2
    {
        static void Main()
        {
            try
            {
                // Create inventory items
                InventoryItem item1 = new InventoryItem(2001, "Raw Material X", 1000, 10.50m);
                InventoryItem item2 = new InventoryItem(2002, "Component Y", 500, 5.75m);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=== Initial Inventory ===");
                Console.ResetColor();
                DisplayInventoryItem(item1);
                DisplayInventoryItem(item2);

                // Update inventory
                item1.AddStock(200);
                item2.RemoveStock(100);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n=== Inventory After Updates ===");
                Console.ResetColor();
                DisplayInventoryItem(item1);
                DisplayInventoryItem(item2);

                // Display total values
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n=== Total Inventory Value ===");
                Console.ResetColor();
                Console.WriteLine($"Item '{item1.Name}': {item1.CalculateTotalValue():C}");
                Console.WriteLine($"Item '{item2.Name}': {item2.CalculateTotalValue():C}");
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error creating or updating inventory item: {ex.Message}");
                Console.ResetColor();
            }
            catch (InvalidOperationException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void DisplayInventoryItem(InventoryItem item)
        {
            // Define colors for different sections
            ConsoleColor sectionColor = ConsoleColor.Yellow;
            ConsoleColor labelColor = ConsoleColor.White;
            ConsoleColor valueColor = ConsoleColor.Gray;

            // Display section header
            Console.ForegroundColor = sectionColor;
            Console.WriteLine($"=== Inventory Item ===");

            // Display each attribute with label and value
            DisplayAttribute("Item ID", item.ItemId.ToString(), labelColor, valueColor);
            DisplayAttribute("Name", item.Name, labelColor, valueColor);
            DisplayAttribute("Quantity", item.Quantity.ToString(), labelColor, valueColor);
            DisplayAttribute("Unit Price", item.UnitPrice.ToString("C"), labelColor, valueColor);

            // Add a separator after each item
            Console.WriteLine("".PadRight(30, '-'));

            // Reset console color after each item display
            Console.ResetColor();
            Console.WriteLine();
        }

        static void DisplayAttribute(string label, string value, ConsoleColor labelColor, ConsoleColor valueColor)
        {
            Console.ForegroundColor = labelColor;
            Console.Write($"{label}: ");
            Console.ForegroundColor = valueColor;
            Console.WriteLine(value);
        }
    }

    public struct InventoryItem
    {
        public int ItemId { get; }
        public string Name { get; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; }

        public InventoryItem(int itemId, string name, int quantity, decimal unitPrice)
        {
            if (itemId <= 0)
                throw new ArgumentException("Item ID must be positive.", nameof(itemId));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Item name cannot be empty or null.", nameof(name));

            if (quantity < 0)
                throw new ArgumentException("Quantity cannot be negative.", nameof(quantity));

            if (unitPrice < 0)
                throw new ArgumentException("Unit price cannot be negative.", nameof(unitPrice));

            ItemId = itemId;
            Name = name;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public decimal CalculateTotalValue()
        {
            return Quantity * UnitPrice;
        }

        public void AddStock(int quantityToAdd)
        {
            if (quantityToAdd < 0)
                throw new ArgumentException("Quantity to add cannot be negative.", nameof(quantityToAdd));

            Quantity += quantityToAdd;
        }

        public void RemoveStock(int quantityToRemove)
        {
            if (quantityToRemove < 0)
                throw new ArgumentException("Quantity to remove cannot be negative.", nameof(quantityToRemove));

            if (quantityToRemove > Quantity)
                throw new InvalidOperationException("Insufficient stock.");

            Quantity -= quantityToRemove;
        }

        public override string ToString()
        {
            return $"Item ID: {ItemId}, Name: {Name}, Quantity: {Quantity}, Unit Price: {UnitPrice:C}";
        }
    }
}
