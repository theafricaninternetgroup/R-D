namespace Multitenancy.Web
{
    public class Tenant
    {
        public int Id { get; set; }
        public string? Name { get; set; }=string.Empty;
        public string[]? HostNames { get; set; } = default;

    }
}
