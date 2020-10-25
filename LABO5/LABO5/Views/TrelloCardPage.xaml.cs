using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LABO5.Models;
using LABO5.Repositories;
using Xamarin.Forms;

namespace LABO5.Views
{
    public partial class TrelloCardPage : ContentPage
    {
        public TrelloList list { get; set; }
     
        public TrelloCardPage(TrelloList trelloList)
        {
            this.list = trelloList;
//            lblListName.Text = this.list.Name;
            getCards();
            InitializeComponent();
            SingleCardPage();
        }

        private async Task getCards()
        {
            List<TrelloCard> trelloCards = await TrelloRepository.GetTrelloCardAsync(list.ListId);
            this.Title = "Xamarin";
            lvwCards.ItemsSource = trelloCards;
        }

        private async Task SingleCardPage()
        {
            TapGestureRecognizer gesture = new TapGestureRecognizer();
            gesture.Tapped += AddCard_Tapped;
            lblAddCard.GestureRecognizers.Add(gesture);
        }

        void AddCard_Tapped(System.Object sender, System.EventArgs e)
        {
            TrelloList list = new TrelloList();// item ophalen en casten naar een singleCardPage
            TrelloBoard board = new TrelloBoard();// item ophalen en casten naar een singleCardPage
            Navigation.PushAsync(new SingleCardPage(list,board));
        }

        void btnGoBack_Clicked(System.Object sender, System.EventArgs e)
        {
            TrelloBoard selectedList = new TrelloBoard();
            if (selectedList != null)
            {
                //navigate to trello lists page, pass the selected board
                Navigation.PopAsync();

                //clear selection
                
            }
        }

        public async Task UpdateTrelloCardAsync()
        {
            getCards();
        }

        void btnCloseCard_Clicked(System.Object sender, System.EventArgs e)
        {

            //get listview item in which this button was clicked + convert to trello card
            TrelloCard card = (sender as Button).BindingContext as TrelloCard;
            card.IsClosed = true;
            UpdateTrelloCardAsync();
        }
            

    }
    }
    

