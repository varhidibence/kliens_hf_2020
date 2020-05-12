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

        public async Task LoadDataAsync(MasterDetailsViewState viewState, string[] urls = null)
        {
            SampleItems.Clear();

            if (urls != null)
            {
                foreach (string url in urls)
                {
                    int i = 0;
                    if (url != null)
                    {
                        var book = await GameOfThronesDataService.GetBookByUrlAsync(url);
                        if (book != null)
                        {
                            
                            SampleItems.Add(book);
                            if (++i > 15)
                                break;
                        }

                    }

                }
            }
            else
            {
                //var data = await SampleDataService.GetSampleBookAsync();
                var data = await GameOfThronesDataService.GetAllBooksAsync();

                foreach (var item in data)
                {
                    if (item != null)
                        SampleItems.Add(item);
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
