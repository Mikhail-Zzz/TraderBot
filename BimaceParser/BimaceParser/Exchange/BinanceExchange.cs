using BimaceParser.Models;
using RestSharp;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;


namespace BimaceParser.Exchange
{
    public class BinanceExchange
    {
        private RestClient CLIENT = new RestClient();

        public ExchangeInfo Pairs { get; private set; }
        public RecentTradesInfo[] OldTradesList { get; private set; }
        public RecentTradesInfo[] RecentTradesList { get; private set; }

        public Stats Stats { get; private set; }
        public OrderBook OrderBook { get; private set; }

        public event EventHandler<EventArgs> OnIterationCompleted;
        public event EventHandler<EventArgs> OnPairsUpdated;

        private Task Loop { get; set; }
        private CancellationTokenSource TokenSource { get; set; }

        private bool pause;
        public bool Pause
        {
            get => pause;
            set
            {
                if (!value)
                    UpdateOldTradesAndContinue();
                else
                    pause = true;
            }
        }

        private Symbol selectedSymbol;
        public Symbol SelectedSymbol
        {
            get => selectedSymbol;
            set
            {
                if (selectedSymbol == value)
                    return;

                if (TokenSource == null || TokenSource.IsCancellationRequested || SelectedSymbol == null)
                    selectedSymbol = value;
                else
                {
                    TokenSource.Cancel();
                    selectedSymbol = value;
                    Loop = InitCycle();
                }
            }
        }

        public BinanceExchange()
        {
            UpdatePairs();
        }

        public async void UpdatePairs()
        {
            Pairs = await GetPairs();
            OnPairsUpdated?.Invoke(this, new EventArgs());
        }

        public async Task InitCycle()
        {
            using (TokenSource = new CancellationTokenSource())
            {
                if (SelectedSymbol != null)
                    OldTradesList = await GetOldTradesList();

                while (true)
                {
                    await Task.Delay(50);

                    if (TokenSource.IsCancellationRequested)
                        break;

                    if (Pause || SelectedSymbol == null)
                        continue;

                    await CycleIteration();
                    OnIterationCompleted?.Invoke(this, new EventArgs());
                }
            }
        }

        private async void UpdateOldTradesAndContinue()
        {
            if (TokenSource == null)
            {
                pause = false;
                await InitCycle();
            }
            else
            {
                OldTradesList = await GetOldTradesList();
                pause = false;
            }
        }

        private async Task CycleIteration()
        {
            Stats = await GetStats();
            OrderBook = await GetOrderBook();
            RecentTradesInfo[] recentTrades = await GetRecentTrades();

            int index = recentTrades.ToList().FindIndex(TradesList => TradesList.Id == OldTradesList[OldTradesList.Length - 1].Id) + 1;
            OldTradesList = recentTrades;

            RecentTradesList = new RecentTradesInfo[recentTrades.Length - index];
            Array.Copy(recentTrades, index, RecentTradesList, 0, RecentTradesList.Length);
        }

        #region request

        private async Task<Stats> GetStats()
        {
            RestRequest statsRestRequest = new RestRequest($"https://api1.binance.com/api/v3/ticker/24hr?symbol={SelectedSymbol}", Method.GET);
            IRestResponse statsResponse = await CLIENT.ExecuteAsync(statsRestRequest, TokenSource.Token);
            return JsonConvert.DeserializeObject<Stats>(statsResponse.Content);
        }

        private async Task<OrderBook> GetOrderBook()
        {
            RestRequest orderBookRestRequest = new RestRequest($"https://api1.binance.com/api/v3/depth?symbol={SelectedSymbol}&limit=20", Method.GET);
            IRestResponse orderBookResponse = await CLIENT.ExecuteAsync(orderBookRestRequest, TokenSource.Token);
            return JsonConvert.DeserializeObject<OrderBook>(orderBookResponse.Content);
        }

        private async Task<RecentTradesInfo[]> GetRecentTrades()
        {
            RestRequest recentTradesListRestRequest = new RestRequest($"https://api1.binance.com/api/v3/trades?symbol={SelectedSymbol}", Method.GET);
            IRestResponse recentTradesListResponse = await CLIENT.ExecuteAsync(recentTradesListRestRequest, TokenSource.Token);
            return JsonConvert.DeserializeObject<RecentTradesInfo[]>(recentTradesListResponse.Content);
        }

        private async Task<ExchangeInfo> GetPairs()
        {
            RestRequest restRequest = new RestRequest("https://api1.binance.com/api/v3/exchangeInfo", Method.GET);
            IRestResponse response = await CLIENT.ExecuteAsync(restRequest);
            return JsonConvert.DeserializeObject<ExchangeInfo>(response.Content);
        }

        private async Task<RecentTradesInfo[]> GetOldTradesList()
        {
            RestRequest recentTradesListRestRequest = new RestRequest($"https://api1.binance.com/api/v3/trades?symbol={SelectedSymbol}", Method.GET);
            IRestResponse recentTradesListResponse = await CLIENT.ExecuteAsync(recentTradesListRestRequest, TokenSource.Token);
            return JsonConvert.DeserializeObject<RecentTradesInfo[]>(recentTradesListResponse.Content);
        }

        #endregion
    }
}
