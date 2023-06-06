namespace FoodOrdering.Exceptions;

public class FoodOrderingException : Exception
{
    public FoodOrderingException(string message) : base(message)
    {
    }
}