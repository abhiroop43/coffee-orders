namespace CoffeeOrders.Api.Shared.Exceptions;

public class BadRequestException(string message) : Exception(message) { }
