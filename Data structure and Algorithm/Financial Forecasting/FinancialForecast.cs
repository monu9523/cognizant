using System;

class FinancialForecast
{
    public static double PredictFutureValue(double currentValue, double growthRate, int years)
    {
        // Base case
        if (years == 0)
            return currentValue;

        // Recursive case
        return PredictFutureValue(currentValue, growthRate, years - 1) * (1 + growthRate);
    }

    static void Main()
    {
        Console.Write("Enter Current Value: ");
        double currentValue = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Annual Growth Rate (%): ");
        double growthRate = Convert.ToDouble(Console.ReadLine()) / 100;

        Console.Write("Enter Number of Years: ");
        int years = Convert.ToInt32(Console.ReadLine());

        double futureValue = PredictFutureValue(currentValue, growthRate, years);

        Console.WriteLine("\n----- Financial Forecast -----");
        Console.WriteLine($"Current Value: ₹{currentValue:F2}");
        Console.WriteLine($"Growth Rate: {growthRate * 100}%");
        Console.WriteLine($"Years: {years}");
        Console.WriteLine($"Predicted Future Value: ₹{futureValue:F2}");
    }
}