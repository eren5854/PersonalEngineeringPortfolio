namespace PersonalEngineeringPortfolio.Models;

public abstract class OrderedEntity : Entity
{
    public int DisplayOrder { get; set; }
}
