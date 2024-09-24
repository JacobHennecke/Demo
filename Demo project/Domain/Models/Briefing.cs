namespace Demo_project.Domain.Models
{
    public record Briefing(
        string name,
        string description,
        string assetId,
        string createdBy,
        DateOnly createdDate,
        string status,
        string comments
        );
}
