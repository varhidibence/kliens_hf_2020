using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using GameOhThrones.Core.Models;
using GameOhThrones.Core.Services;
using GameOhThrones.Helpers;

using Microsoft.Toolkit.Uwp.UI.Controls;
using Windows.Media.Miracast;

namespace GameOhThrones.ViewModels
{
    public class BooksViewModel : Observable
    {
        private Book _selected;

        public Book Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ObservableCollection<Book> SampleItems { get; private set; } = new ObservableCollection<Book>();

        public BooksViewModel()
        {
        }

        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            SampleItems.Clear();
            var books = await GameOfThronesDataService.GetAllBooksAsync();

            foreach (var book in books)
            {
                if (book != null)
                {
                    SampleItems.Add(book);
                }
            }

            if (viewState == MasterDetailsViewState.Both)
            {
                if (SampleItems != null)
                    Selected = SampleItems.First();
            }
        }
        public async Task LoadDataAsyncWithURLs(MasterDetailsViewState viewState, string[] urls = null)
        {
            SampleItems.Clear();
            if (urls != null)
            {
                var books = await GameOfThronesDataService.GetBookByUrlAsync(urls, 15);
                SampleItems.Clear();
                foreach (var book in books)
                {
                    if (book != null)
                    {
                        SampleItems.Add(book);
                    }
                }
            }

            if (viewState == MasterDetailsViewState.Both)
            {
                if (SampleItems != null)
                    Selected = SampleItems.First();
            }
        }
    }
}
