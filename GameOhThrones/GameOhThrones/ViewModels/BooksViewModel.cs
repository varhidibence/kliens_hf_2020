﻿using System;
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

        public List<String> authors { get; set; }

        public BooksViewModel()
        {
        }

        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            SampleItems.Clear();

            //var data = await SampleDataService.GetSampleBookAsync();
            var data = await GameOfThronesDataService.GetAllBooksAsync();

            foreach (var item in data)
            {
                SampleItems.Add(item);

            }

            if (viewState == MasterDetailsViewState.Both)
            {
                Selected = SampleItems.First();
            }
        }
    }
}
