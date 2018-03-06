using System;

/// <summary>
/// Summary description for TaxInfo
/// </summary>
[Serializable]
public class TaxInfo
{
    double StateRate;
    double EstimatedCountyRate;
    double EstimatedCityRate;
    double EstimatedSpecialRate;
    String message;
    
    public double getStateRate()
    {
        return StateRate;
    }

    public double getEstimatedCountyRate()
    {
        return EstimatedCountyRate;
    }

    public double getEstimatedCityRate()
    {
        return EstimatedCityRate;
    }

    public double getEstimatedSpecialRate()
    {
        return EstimatedSpecialRate;
    }

    public void setMessage(string message)
    {
        this.message = message;
    }

    public string getMessage()
    {
        return message;
    }

    public TaxInfo()
    {
    }

    public TaxInfo(double StateRate, double EstimatedCountyRate, double EstimatedCityRate, double EstimatedSpecialRate)
    {
        this.StateRate = StateRate;
        this.EstimatedCountyRate = EstimatedCountyRate;
        this.EstimatedCityRate = EstimatedCityRate;
        this.EstimatedSpecialRate = EstimatedSpecialRate;
    }

    public TaxInfo(double StateRate) {
        this.StateRate = StateRate;
    }
}