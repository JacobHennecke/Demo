namespace Demo_project.Domain.Models
{
    public record ContentDistribution(
        DateOnly distributionDate,
        string[] distributionChannels,
        string[] distributionMethods,
        ContentDistributionAssets[] assets
        );
}
