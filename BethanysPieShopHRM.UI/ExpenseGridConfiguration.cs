using BethanysPieShopHRM.Shared;
using Blazor.FlexGrid.Components.Configuration;
using Blazor.FlexGrid.Components.Configuration.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.UI
{
    public class ExpenseGridConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.Property(x => x.Title).IsSortable();
            builder.Property(x => x.ExpenseType).IsSortable();
            builder.Property(x => x.Amount).IsSortable();

            builder.Property(x => x.EmployeeId).IsVisible(false);
            builder.Property(x => x.CurrencyId).IsVisible(false);
            builder.Property(x => x.Employee).IsVisible(false);
            builder.Property(x => x.Description).IsVisible(false);
            builder.Property(x => x.CoveredAmount).IsVisible(false);
            builder.Property(x => x.Currency).IsVisible(false);

            //builder.Property(x => x.Currency.Name).HasCaption(" ");
        }
    }
}
