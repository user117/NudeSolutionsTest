using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using NudeSolutions.Shared;

namespace NudeSolutions.Client.Pages
{
    public partial class Index:ComponentBase
    {

        private string Name { get; set; }
        private int Value { get; set; }
        private string Category { get; set; }

        public IList<Item> Items = new List<Item>();

        public int Sum()
        {
            return Items.Count > 0 ? Items.Sum(x => x.Value) : 0;
        }

        protected override async Task OnInitializedAsync()
        {

            Category = "General";
            await GetItems();
            if (Items.Count > 0)
            {

                Console.WriteLine(Items[0].CategoryName);
                Console.WriteLine($"{Items.Count}");
            }
        }

        private async Task GetItems()
        {
            Items = await Http.GetFromJsonAsync<IList<Item>>("Item");
        }

        private async Task AddItem()
        {
            var item = new Item { Name = Name, Value = Value, CategoryName = Category };

            if (Category != null)
            {
                Items.Add(item);

                await Http.PostAsJsonAsync("Item", item);
            }
        }

        private async Task DeleteItem(int itemId)
        {
            Console.WriteLine(itemId);
            await Http.DeleteAsync("item/" + itemId);
            await GetItems();
        }

        public int SumByCategory(string category)
        {
            return Items.Where(x => x.CategoryName.Equals(category)).Sum(x => x.Value);
        }
    }
}
