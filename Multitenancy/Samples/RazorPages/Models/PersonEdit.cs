using Csla;

namespace Multitenancy.Web.RazorPages.Models
{
    [Serializable]
    public class PersonEdit:BusinessBase<PersonEdit>
    {
        public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(nameof(Id));
        public int Id
        {
            get=>GetProperty(IdProperty);
            private set=>LoadProperty(IdProperty, value);
        }
        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(nameof(Name));
        public  string Name
        {
            get=>GetProperty(NameProperty);
            set=>SetProperty(NameProperty, value);
        }

        protected override void AddBusinessRules()
        {
            var tenant=ApplicationContext.GetRequiredService<Tenant>();
            base.AddBusinessRules();
            BusinessRules.RuleSet = tenant.Name;
            AddTenantSpecificBusinessRules();
        }

        private void AddTenantSpecificBusinessRules()
        {
            var tenant=ApplicationContext.GetRequiredService<Tenant>();
            Console.WriteLine($"The current tenant is {tenant.Name}");
            Console.WriteLine($"The current rule set is {BusinessRules.RuleSet}");
        }


        [Create]
        private void Create([Inject]Tenant tenant)
        {
            using (BypassPropertyChecks)
            {
                Id = -1;
                BusinessRules.RuleSet = tenant.Name;
            }
        }
    }
}
