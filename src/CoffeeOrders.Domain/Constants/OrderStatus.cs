namespace CoffeeOrders.Domain.Constants;

public static class OrderStatus
{
    public static string Preparing { get; set; } = "PREPARING";
    public static string Serving { get; set; } = "SERVING";
    public static string Completed { get; set; } = "COMPLETED";
    public static string OnHold { get; set; } = "ONHOLD";
    public static string Cancelled { get; set; } = "CANCELLED";
    public static string Refunded { get; set; } = "REFUNDED";
}
