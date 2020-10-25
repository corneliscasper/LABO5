using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LABO5.Models;
using LABO5.Repositories;
using Xamarin.Forms;

namespace LABO5.Views
{
    public partial class TrelloListPage : ContentPage
    {
        public TrelloBoard boardcontent { get; set; }
        public TrelloListPage(TrelloBoard trelloBoard)
        {
            this.boardcontent = trelloBoard;
            InitializeComponent();
            GetItemsList();
        }

        private  async Task GetItemsList()
        {
            List<TrelloList> trelloLists = await TrelloRepository.GetTrelloListAsync(boardcontent.BoardId);
            this.Title=$"{boardcontent.Name}";
            lvwTrelloLists.ItemsSource = trelloLists;
        }

        void lvwTrelloLists_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            TrelloList selectedList = lvwTrelloLists.SelectedItem as TrelloList;// item ophalen en casten naar een trelloboard
            if (selectedList != null)
            {
                //navigate to trello lists page, pass the selected board
                Navigation.PushAsync(new TrelloCardPage(selectedList));

                //clear selection
                lvwTrelloLists.SelectedItem = null;
            }
        }
    }
}
