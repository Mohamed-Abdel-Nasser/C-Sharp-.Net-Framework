using System;

public struct InventoryItem
{
    public int ItemId { get; }
    public string Name { get; }
    public decimal UnitPrice { get; }
    public int QuantityInStock { get; }

    public InventoryItem(int itemId, string name, decimal unitPrice, int quantityInStock)
    {
        ItemId = itemId;
        Name = name;
        UnitPrice = unitPrice;
        QuantityInStock = quantityInStock;
    }

    // Method to calculate total value of inventory item
    public decimal CalculateTotalValue()
    {
        return UnitPrice * QuantityInStock;
    }

    // Method to print inventory item details
    public void PrintItemDetails()
    {
        Console.WriteLine($"Item ID: {ItemId}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Unit Price: {UnitPrice:C}");
        Console.WriteLine($"Quantity in Stock: {QuantityInStock}");
        Console.WriteLine($"Total Value: {CalculateTotalValue():C}");
    }
}

class Program
{
    static void Main()
    {
        // Example usage
        InventoryItem item1 = new InventoryItem(101, "Widget A", 25.50m, 50);
        InventoryItem item2 = new InventoryItem(102, "Gadget B", 15.75m, 100);

        Console.WriteLine("Inventory Item 1:");
        item1.PrintItemDetails();

        Console.WriteLine("\nInventory Item 2:");
        item2.PrintItemDetails();
    }
}
