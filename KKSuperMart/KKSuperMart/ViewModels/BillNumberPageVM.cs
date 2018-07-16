using System;
using System.Collections.Generic;
using System.Net.Http;
using KKSuperMart.Models;
using Newtonsoft.Json;

namespace KKSuperMart.ViewModels
{
    public class BillNumberPageVM:BaseViewModel
    {
        private string _Title { get; set; }
        public string Title 
        { 
            get { return _Title; }
            set { _Title = value; OnPropertyChanged("Title"); }
        }
        private List<BillItem> _BillItems { get; set; }
        public List<BillItem> BillItems
        {
            get { return _BillItems; }
            set { _BillItems = value; OnPropertyChanged("BillItems"); }
        }

        private BillTotal _BillTotal { get; set; }
        public BillTotal BillTotal
        {
            get { return _BillTotal; }
            set { _BillTotal = value; OnPropertyChanged("BillTotal"); }
        }

        private PurchaseItem _SelectedItem { get; set; }
        public PurchaseItem SelectedItem
        {
            get { return _SelectedItem; }
            set { _SelectedItem = value; OnPropertyChanged("SelectedItem"); }
        }



        public BillNumberPageVM()
        {
            try
            {
                BillTotal = new BillTotal();
                BillItems = new List<BillItem>();
                SelectedItem = Helpers.Data.Data.SelectedPurchaseItem;
                Title = "Bill Number: " + SelectedItem.VCHRNO;
                LoadBillItems();
            }
            catch { }
        }

        public async void LoadBillItems()
        {
            try
            {
                String url = BillItem.GenerateBillItemsURL(SelectedItem.VCHRNO, Helpers.Data.Data.MemberDetails.email, Helpers.Data.Data.MemberDetails.companyid );
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    BillItems = JsonConvert.DeserializeObject<List<BillItem>>(json);
                    if(BillItems != null && BillItems.Count > 0)
                    {
                        foreach (var item in BillItems)
                        {
                            item.SNo = BillItems.IndexOf(item) + 1;
                        }

                        BillTotal = new BillTotal()
                        {
                            TAXABLE = BillItems[0].TAXABLE,
                            TOTAMNT = BillItems[0].TOTAMNT,
                            DCAMNT = BillItems[0].DCAMNT,
                            NONTAXABLE = BillItems[0].NONTAXABLE,
                            NETAMNT = BillItems[0].NETAMNT,
                            VATAMNT = BillItems[0].VATAMNT,
                        };
                        
                    }

                }
                
            }catch(Exception e) { await  App.Current.MainPage.DisplayAlert("Error","Cannot Connect to Server:\n" + e.Message,"Ok"); }
           
        }
    }
}
